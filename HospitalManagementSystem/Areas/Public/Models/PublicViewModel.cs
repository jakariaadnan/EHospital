using HospitalManagementSystem.Data.Entity.MasterData;

namespace HospitalManagementSystem.Areas.Public.Models
{
    public class PublicViewModel
    {
        public IEnumerable<Departments> departments { get; set; }
        public IEnumerable<HospitalManagementSystem.Data.Entity.Doctor> doctors { get; set; }
    }
}
