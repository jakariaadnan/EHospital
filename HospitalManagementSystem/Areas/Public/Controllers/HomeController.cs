using HospitalManagementSystem.Areas.Public.Models;
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
        public async Task<IActionResult> Dashboard()
        {
            return View();
        }
    }
}
