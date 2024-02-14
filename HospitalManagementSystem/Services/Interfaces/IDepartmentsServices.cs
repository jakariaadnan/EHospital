using HospitalManagementSystem.Data.Entity.MasterData;

namespace HospitalManagementSystem.Services.Interfaces
{
    public interface IDepartmentsServices
    {
        Task<IEnumerable<Departments>> GetDepartmentsList();
        Task<Departments> GetDepartmentById(int id);
        Task<bool> SaveDepartments(Departments departments);
        Task<bool> DeleteDepartmentsById(int id);
    }
}
