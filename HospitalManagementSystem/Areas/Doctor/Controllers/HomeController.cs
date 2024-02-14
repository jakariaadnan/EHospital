using HospitalManagementSystem.Areas.Doctor.Models;
using HospitalManagementSystem.Data.Entity.MasterData;
using HospitalManagementSystem.Services;
using HospitalManagementSystem.Services.Dapper.Interfaces;
using HospitalManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IDapper _dapper;
        private readonly IDepartmentsServices _departmentsServices;
        private readonly IDoctorServices _doctorServices;
        public HomeController(IDapper dapper, IDoctorServices doctorServices, IDepartmentsServices departmentsServices)
        {
            this._dapper = dapper;
            this._doctorServices = doctorServices;
            this._departmentsServices = departmentsServices;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> DoctorInfo()
        {
            var m = new DoctorViewModel
            {
                departments= await _departmentsServices.GetDepartmentsList(),
                doctors = await _doctorServices.GetDoctorList()
            };
            return View(m);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DoctorInfo([FromForm] DoctorViewModel model)
        {
            model.doctors = await _doctorServices.GetDoctorList();
            model.departments = await _departmentsServices.GetDepartmentsList();
            if (!ModelState.IsValid)
            {
                return View(model); 
            }

            var doctor  = new HospitalManagementSystem.Data.Entity.Doctor
            {
                Id = Convert.ToInt32(model.id),
                name = model.name,
                address= model.address,
                departmentId=model.departmentId,
                registrationNo = model.registrationNo,
                phone = model.phone
            };

            await _doctorServices.SaveDoctor(doctor);
            model.doctors = await _doctorServices.GetDoctorList();
            return View(model);
        }

        public async Task<JsonResult> DeleteDoctorById(int Id)
        {
            await _doctorServices.DeleteDoctorById(Id);
            return Json(true);
        }
    }
}
