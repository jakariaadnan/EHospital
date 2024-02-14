using HospitalManagementSystem.Areas.Public.Models;
using HospitalManagementSystem.Areas.Public.Views.Home;
using HospitalManagementSystem.Data.Entity;
using HospitalManagementSystem.Data.Entity.MasterData;
using HospitalManagementSystem.Services.Dapper.Interfaces;
using HospitalManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Areas.Public.Controllers
{
    [Area("Public")]
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
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = new PublicViewModel
            {
                departments= await _departmentsServices.GetDepartmentsList(),
                doctors = await _doctorServices.GetDoctorList()
            };
            return View(model);
        }
        [AllowAnonymous]
        public async Task<IActionResult> SaveAppoinment(AppoinmentVM model)
        {
            try
            {
            var sNo = await _doctorServices.GetAppoinmentNo((int)model.docId, model.date);
            var data = new Appoinment {
                name=model.pName,
                address=model.pAdd,
                date=model.date,
                doctorId=model.docId,
                phone=model.pPhone,
                serialNumber= sNo
            };
            var save = await _doctorServices.SaveAppoinment(data);
            return Json(sNo);

            }
            catch (Exception)
            {
                return Json(0);
            }
        }
        public async Task<IActionResult> Dashboard()
        {
            return View();
        }
        public async Task<IActionResult> AppointmentList()
        {
            var data = await _doctorServices.GetAppoinmentList();
            return View(data.OrderBy(x=>x.date).ThenBy(x=>x.doctorId).ThenBy(x=>x.serialNumber));
        }
    }
}
