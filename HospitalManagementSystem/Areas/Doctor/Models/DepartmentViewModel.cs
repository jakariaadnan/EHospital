using HospitalManagementSystem.Data.Entity.MasterData;

namespace HospitalManagementSystem.Areas.Doctor.Models
{
    public class DepartmentViewModel
    {
        public IEnumerable<Departments>? Departments { get; set; }
        public int? id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
    }
}
