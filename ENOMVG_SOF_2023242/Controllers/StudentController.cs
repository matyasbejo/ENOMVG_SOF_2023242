using ENOMVG_SOF_2023242.Logic;
using ENOMVG_SOF_2023242.Models;
using ENOMVG_SOF_2023242.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace ENOMVG_SOF_2023242.Controllers
{
    public class StudentController : Controller
    {
        IStudentRepository repo;
        ISchoolRepository schoolRepo;

        public StudentController(IStudentRepository repo, ISchoolRepository schoolrepo)
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
        public IActionResult Create(Student student)
        {
            repo.Create(student);
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
            var student = repo.Read(id);
            var schools = schoolRepo.ReadAll();
            ViewBag.Schools = new SelectList(schools, "Id", "Name");
            return View(student);
        }

        [HttpPost]
        public IActionResult Update(Student student)
        {
            var DbStudent = repo.Read(student.Id);
            DbStudent.Age = student.Age;
            DbStudent.Name = student.Name;
            DbStudent.GradesAVG = student.GradesAVG;
            DbStudent.SchoolId = student.SchoolId;
            DbStudent.School = schoolRepo.Read(student.SchoolId);
            repo.Update(DbStudent);
            return RedirectToAction(nameof(Index));
        }
    }
}
