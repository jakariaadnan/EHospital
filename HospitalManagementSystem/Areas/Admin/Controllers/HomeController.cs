using HospitalManagementSystem.Services.Dapper.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IDapper _dapper;
        public HomeController(IDapper dapper)
        {
            this._dapper = dapper;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
