using HospitalManagementSystem.Data.Entity.MasterData;

namespace HospitalManagementSystem.Data.Entity
{
    public class Doctor:Base
    {
        public string? name { get; set; }
        public string? address { get; set; }
        public string? registrationNo { get; set; }
        public string? phone { get; set; }
        public int? departmentId { get; set; }
        public Departments? department { get; set; }
    }
}
