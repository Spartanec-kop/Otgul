using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Otgul.Api.ViewModel;
using Otgul.Models;
using Otgul.Services.Interfaces;

namespace Otgul.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public UserController(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet("auth")]
        public async Task<ActionResult<string>> AuthUser(string login, string password)
        {
            var user = _userService.GetUserFromLogoPass(login, password);
            if (user == null)
            {
                return NotFound();
            }
            return _tokenService.Generate(user.Login);
        }

        // GET: api/User/all
        [HttpGet("all")]
        public async Task<JsonResult> GetUsers()
        {
            IEnumerable<User> users = _userService.GetActiveUser();
            IEnumerable<ViewUser> viewUsers = users.Select(u => new ViewUser
            {
                id = u.Id,
                login = u.Login,
                firstName = u.FirstName,
                lastName = u.LastName,
                middleName = u.MiddleName,
                role = u.Role.Name,
                otdel = u.Otdel,
                department = u.Department,
                rights = u.UserRights.Select(s => new ViewRight { Id = s.Right.Id, Name = s.Right.Name }).ToList()
            });
            return Json(viewUsers);
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<Object>> GetUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                List<Claim> claims = identity.Claims.ToList();

                User user = _userService.GetUserFromLogin(claims[0].Value);
                var viewUser = new ViewUser
                {
                    id = user.Id,
                    login = user.Login,
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    middleName = user.MiddleName,
                    role = user.Role.Name,
                    otdel = user.Otdel,
                    department = user.Department,
                    rights = user.UserRights.Select(s => new ViewRight{ Id = s.Right.Id, Name = s.Right.Name }).ToList()
                };
                return viewUser;
            }
            else
            {
                throw new Exception("Токен не определен");
            }
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            User user = _userService.GetUserFromId(id);
            if (user != null)
            {
                return user;
            }
            else
            {
                return NotFound();
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            User tmpUser = _userService.GetUserFromLogin(user.Login);
            if (tmpUser == null)
            {
                _userService.CreateUser(user);
            }
            return _userService.GetUserFromLogin(user.Login);
        }
    }
}
