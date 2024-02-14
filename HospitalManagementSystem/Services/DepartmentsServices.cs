using HospitalManagementSystem.Data.Entity;
using HospitalManagementSystem.Data;
using Microsoft.AspNetCore.Identity;
using HospitalManagementSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Data.Entity.MasterData;

namespace HospitalManagementSystem.Services
{
    public class DepartmentsServices: IDepartmentsServices
    {
        private readonly HMSDbContext _context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> _userManage;

        public DepartmentsServices(HMSDbContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> _userManage)
        {
            _context = context;
            this.roleManager = roleManager;
            this._userManage = _userManage;
        }

        public async Task<bool> DeleteDepartmentsById(int id)
        {
            _context.departments.Remove(_context.departments.Find(id));
            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<Departments> GetDepartmentById(int id)
        {
            return await _context.departments.FindAsync(id);
        }

        public async Task<IEnumerable<Departments>> GetDepartmentsList()
        {
            return await _context.departments.AsNoTracking().ToListAsync();
        }

        public async Task<bool> SaveDepartments(Departments departments)
        {
            if (departments.Id != 0)
                _context.departments.Update(departments);
            else
                _context.departments.Add(departments);
            return 1 == await _context.SaveChangesAsync();
        }
    }
}
