using HospitalManagementSystem.Data.Entity;
using HospitalManagementSystem.Data.Entity.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Services.Interfaces
{
  public interface IUserInfoService
    {
        Task<ApplicationUser> GetUserBasicInfoes(string userName);
        Task<bool> DeleteRoleById(string Id);
        Task<IEnumerable<ApplicationUser>> GetUserList();
        Task<IEnumerable<UserType>> GetAllUserType();
        Task<List<string>> UsersRoles(string name);
    }
}
