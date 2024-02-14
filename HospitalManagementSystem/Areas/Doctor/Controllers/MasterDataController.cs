using HospitalManagementSystem.Areas.Doctor.Models;
using HospitalManagementSystem.Data.Entity.MasterData;
using HospitalManagementSystem.Services.Dapper.Interfaces;
using HospitalManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    [Authorize]
    public class MasterDataController : Controller
    {
        private readonly IDapper _dapper;
        private readonly IDepartmentsServices _departmentsServices;
        public MasterDataController(IDapper dapper, IDepartmentsServices departmentsServices)
        {
            this._dapper = dapper;
            this._departmentsServices = departmentsServices;
        }
        public async Task<IActionResult> Department()
        {
            var m= new DepartmentViewModel
            {
                Departments=await _departmentsServices.GetDepartmentsList()
            };
            return View(m);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Department([FromForm] DepartmentViewModel model)
        {
            model.Departments = await _departmentsServices.GetDepartmentsList();
            if (!ModelState.IsValid)
            {
                
                return View(model);
            }

            Departments departments = new Departments
            {
                Id =Convert.ToInt32(model.id),
                name = model.name,
                description = model.description,
            };

            await _departmentsServices.SaveDepartments(departments);
            model.Departments = await _departmentsServices.GetDepartmentsList();
            return View(model);
        }

        public async Task<JsonResult> DeleteCategoryById(int Id)
        {
            await _departmentsServices.DeleteDepartmentsById(Id);
            return Json(true);
        }
    }
}
