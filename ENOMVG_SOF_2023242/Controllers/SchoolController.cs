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
            if(!ModelState.IsValid) return View(school);
            repo.Create(school);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        
        [HttpGet]
        public IActionResult Update(int id)
        {
            var school = repo.Read(id);
            return View(school);
        }
        
        [HttpPost]
        public IActionResult Update(School school )
        {
            if (!ModelState.IsValid)
            {
                return View(school);
            }
            var DbSchool = repo.Read(school.Id);
            DbSchool.Age = school.Age;
            DbSchool.Name = school.Name;
            DbSchool.Type = school.Type;
            repo.Update(DbSchool);
            return RedirectToAction(nameof(Index));
        }
    }
}
