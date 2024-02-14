using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalManagementSystem.Data.Entity;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Data.Entity.Auth;

namespace HospitalManagementSystem.Services
{
    public class UserInfoService: IUserInfoService
    {
        private readonly HMSDbContext _context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> _userManage;

        public UserInfoService(HMSDbContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> _userManage)
        {
            _context = context;
            this.roleManager = roleManager;
            this._userManage = _userManage;
        }

        public async Task<ApplicationUser> GetUserBasicInfoes(string userName)
        {
            return await _context.Users.Where(x => x.UserName == userName).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> GetUserList()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<UserType>> GetAllUserType()
        {
            return await _context.UserTypes.AsNoTracking().ToListAsync();
        }

        public async Task<bool> DeleteRoleById(string Id)
        {
            _context.Roles.Remove(_context.Roles.Where(x => x.Id == Id).First());
            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<List<string>> UsersRoles(string name)
        {
            return (List<string>)await _userManage.GetRolesAsync(await _userManage.FindByNameAsync(name));
        }

    }
}
