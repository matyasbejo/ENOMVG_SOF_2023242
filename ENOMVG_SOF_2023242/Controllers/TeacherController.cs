using ENOMVG_SOF_2023242.Logic;
using ENOMVG_SOF_2023242.Models;
using ENOMVG_SOF_2023242.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ENOMVG_SOF_2023242.Controllers
{
    public class TeacherController : Controller
    {
        ITeacherRepository repo;
        ISchoolRepository schoolRepo;

        public TeacherController(ITeacherRepository repo, ISchoolRepository schoolrepo)
        {
            this.repo = repo;
            this.schoolRepo = schoolrepo;
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
        public IActionResult Create(Teacher teacher)
        {
            repo.Create(teacher);
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
            var teacher = repo.Read(id);
            return View(teacher);
        }

        [HttpPost]
        public IActionResult Update(Teacher teacher)
        {
            var DbTeacher = repo.Read(teacher.Id);
            DbTeacher.Salary = teacher.Salary;
            DbTeacher.Name = teacher.Name;
            DbTeacher.MainSubject = teacher.MainSubject;
            DbTeacher.SchoolId = teacher.SchoolId;
            DbTeacher.School = schoolRepo.Read(teacher.SchoolId);
            repo.Update(DbTeacher);
            return RedirectToAction(nameof(Index));
        }
    }
}
