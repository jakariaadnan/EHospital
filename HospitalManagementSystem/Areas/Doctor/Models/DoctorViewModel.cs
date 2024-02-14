using HospitalManagementSystem.Data.Entity.MasterData;

namespace HospitalManagementSystem.Areas.Doctor.Models
{
    public class DoctorViewModel
    {
        public IEnumerable<HospitalManagementSystem.Data.Entity.Doctor>? doctors { get; set; }
        public IEnumerable<Departments>? departments { get; set; }
        public int? id { get; set; }
        public string? name { get; set; }
        public string? address { get; set; }
        public string? registrationNo { get; set; }
        public string? phone { get; set; }
        public int? departmentId { get; set; }
    }
}
