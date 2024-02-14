namespace HospitalManagementSystem.Data.Entity
{
    public class Appoinment:Base
    {
        public string? name { get; set; }
        public string? address { get; set; }
        public string? phone { get; set; }
        public DateTime? date { get; set; }
        public int? serialNumber { get; set; }
        public int? isPrescribe { get; set; }
        public int? doctorId { get; set; }
        public Doctor? doctor { get; set; }
    }
}
