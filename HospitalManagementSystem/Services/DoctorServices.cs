using HospitalManagementSystem.Data.Entity.MasterData;
using HospitalManagementSystem.Data.Entity;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Services
{
    public class DoctorServices: IDoctorServices
    {
        private readonly HMSDbContext _context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> _userManage;

        public DoctorServices(HMSDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteDoctorById(int id)
        {
            _context.doctors.Remove(_context.doctors.Find(id));
            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _context.doctors.FindAsync(id);
        }

        public async Task<IEnumerable<Doctor>> GetDoctorList()
        {
            return await _context.doctors.Include(x=>x.department).AsNoTracking().ToListAsync();
        }

        public async Task<bool> SaveDoctor(Doctor doctor)
        {
            if (doctor.Id != 0)
                _context.doctors.Update(doctor);
            else
                _context.doctors.Add(doctor);
            return 1 == await _context.SaveChangesAsync();
        }
    }
}
