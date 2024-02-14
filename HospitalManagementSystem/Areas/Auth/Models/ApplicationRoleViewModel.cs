using HospitalManagementSystem.Data.Entity;
using HospitalManagementSystem.Data.Entity.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Areas.Auth.Models
{
    public class ApplicationRoleViewModel
    {
        public string? RoleId { get; set; }
        public int? usertype { get; set; }
        public string?[] roleIdList { get; set; }

        public string? userId { get; set; }

        public string? userName { get; set; }

        public string? RoleName { get; set; }

        public string? nid { get; set; }

        public string? mobile { get; set; }

        public int? rankId { get; set; }

        public int? Id { get; set; }
        public IEnumerable<ApplicationRoleViewModel> roleViewModels { get; set; }
        public IEnumerable<ApplicationUser> userList { get; set; }
        public IEnumerable<UserType> userTypes { get; set; }
    }
}
