namespace HospitalManagementSystem.Areas.Public.Views.Home
{
    public class AppoinmentVM
    {
        public string? pName { get; set; }
        public string? pAdd { get; set; }
        public string? pPhone { get; set; }
        public int? deptId { get; set; }
        public int? docId { get; set; }
        public DateTime date { get; set; }
    }
}
