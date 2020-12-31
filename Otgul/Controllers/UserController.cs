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
using Otgul.Api;

namespace Otgul.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly Mapper _mapper;

        public UserController(Mapper mapper, ITokenService tokenService, IUserService userService)
        {
            _mapper = mapper;
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
            return Json(users.Select(u => _mapper.Map(u)));
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
                return _mapper.Map(user);
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
        public async Task<ActionResult<ViewUser>> PostUser([FromBody] ViewUser viewUser)
        {
            User tmpUser = _userService.GetUserFromLogin(viewUser.Login);
            if (tmpUser == null)
            {
                _userService.CreateUser(_mapper.Map(viewUser));
                return _mapper.Map(_userService.GetUserFromLogin(viewUser.Login));
            }
            else
            {
                return BadRequest("Пользователь с таким логином уже существует.");
            }
            
        }

        [HttpPut]
        public ActionResult<ViewUser> PutUser ([FromBody] User user)
        {
            User tmpUser = _userService.GetUserFromLogin(user.Login);
            if (tmpUser != null)
            {
                _userService.UpdateUser(user);
                return _mapper.Map(_userService.GetUserFromLogin(user.Login));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public ActionResult deleteUser (int userId)
        {
            User tmpUser = _userService.GetUserFromId(userId);
            if (tmpUser != null)
            {
                _userService.RemoveUser(userId);
                return Ok();
            } 
            else
            {
                return NotFound();
            }
        }
    }
}
