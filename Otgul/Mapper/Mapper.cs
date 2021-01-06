using Otgul.Api.ViewModel;
using Otgul.Models;
using Otgul.Services.Interfaces;
using System.Linq;

namespace Otgul.Api
{
    public class Mapper
    {
        private readonly IDepartmentService _departmentService;
        private readonly IOtdelService _otdelService;
        private readonly IRoleService _roleService;
        private readonly IRightService _rightService;

        public Mapper (IRoleService roleService, IDepartmentService departmentService, IOtdelService otdelService, IRightService rightService)
        {
            _roleService = roleService;
            _departmentService = departmentService;
            _otdelService = otdelService;
            _rightService = rightService;
        }

        public ViewUser Map(User user)
        {
            return new ViewUser
            {
                Id = user.Id,
                Tabel = user.Tabel,
                Login = user.Login,
                Phone = user.Phone,
                Password = user.Password,
                WorkStatus = user.WorkStatus,
                FirstName = user.FirstName,
                IsDeleted = user.IsDeleted,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Role = Map(user.Role),
                Otdel = user.Otdel,
                Department = user.Department,
                UserRights = user.UserRights.Select(Map).ToList()
            };
        }

        public User Map(ViewUser viewUser)
        {
            User newUser = new User
            {
                Id = viewUser.Id,
                Tabel = viewUser.Tabel,
                Login = viewUser.Login,
                Phone = viewUser.Phone,
                WorkStatus = viewUser.WorkStatus,
                Password = viewUser.Password,
                FirstName = viewUser.FirstName,
                LastName = viewUser.LastName,
                MiddleName = viewUser.MiddleName,
                Role = _roleService.GetRoleFromId(viewUser.Role.Id),
                Otdel = _otdelService.GetOtdelFromId(viewUser.Otdel.Id),
                Department = _departmentService.GetDepartmentFromId(viewUser.Department.Id),
                IsDeleted = viewUser.IsDeleted,
            };

            foreach (ViewRight right in viewUser.UserRights)
            {
                Right dbRight = _rightService.GetRightFromId(right.Id);
                UserRight userRight = new UserRight
                {
                    Right = dbRight,
                    User = newUser
                };

                newUser.UserRights.Add(userRight);
            }

            return newUser;

        }

        public ViewRole Map(Role role)
        {
            if (role == null)
                return null;

            return new ViewRole
            {
                Id = role.Id,
                Name = role.Name,
                IsDeleted = role.IsDeleted,
                RoleRights = role.RoleRights.Select(Map).ToList()
            };
        }
        private ViewRight Map(UserRight right)
        {
            if (right == null)
                return null;

            return new ViewRight
            { 
                Id = right.Right.Id, 
                Name = right.Right.Name 
            };
        }
        private ViewRight Map(RoleRight right)
        {
            if (right == null)
                return null;

            return new ViewRight
            {
                Id = right.Right.Id,
                Name = right.Right.Name
            };
        }
        /*
        private ViewPPERequestParam Map(PPERequestParam param)
        {
            return new ViewPPERequestParam
            {
                branch = Map(param.Branch),
                name = param.Name,
                nsg = Map(param.NSG),
                num = param.Num,
                value = param.Value,
                nsdParam = param.NSDParam,
                paramId = param.paramId,
                deployedValue = param.DeployedValue
            };
        }

        private ViewResponseBranch Map(Branch branch)
        {
            if (branch == null)
                return null;

            return new ViewResponseBranch
            {
                Name = branch.Name,
                BranchId = branch.BranchId,
                CreatedOn = branch.CreatedOn,
                IsDeleted = branch.IsDeleted,
                UpdatedOn = branch.UpdatedOn,
                Status = branch.Status
            };
        }

        private ViewNSG Map(NSG nsg)
        {
            if (nsg == null)
                return null;

            return new ViewNSG
            {
                NsgId = nsg.NSGId,
                IsMaster = nsg.IsMaster
            };
        }

        private ViewPPECustomerService Map(PPECustomerService service)
        {
            if (service == null)
                return null;

            return new ViewPPECustomerService
            {
                SysName = service.Service.SysName
            };
        }
        */
    }
}
