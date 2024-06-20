using ENOMVG_SOF_2023242.Logic;
using ENOMVG_SOF_2023242.Models;
using ENOMVG_SOF_2023242.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ENOMVG_SOF_2023242.Controllers
{
    public class SchoolController : Controller
    {
        ISchoolRepository repo;

        public SchoolController(ISchoolRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            return View(repo.ReadAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]  
        public IActionResult Create(School school)
        {
            repo.Create(school);
            return RedirectToAction(nameof(Index));
        }
    }
}
