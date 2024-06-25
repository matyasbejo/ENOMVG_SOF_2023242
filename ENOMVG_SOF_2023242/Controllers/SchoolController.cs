using ENOMVG_SOF_2023242.Logic;
using ENOMVG_SOF_2023242.Models;
using ENOMVG_SOF_2023242.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core.Infrastructure;
using Newtonsoft.Json;
using System.ComponentModel;

namespace ENOMVG_SOF_2023242.Controllers
{
    public class SchoolController : Controller
    {
        ISchoolRepository repo;
        private readonly UserManager<IdentityUser> _userManager;

        public SchoolController(ISchoolRepository repo, UserManager<IdentityUser> umanager)
        {
            this.repo = repo;
            _userManager = umanager;
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
        public IActionResult Create(School school, IFormFile imagedata)
        {
            if (imagedata != null)
            {
                using (var stream = imagedata.OpenReadStream())
                {
                    byte[] buffer = new byte[imagedata.Length];
                    stream.Read(buffer, 0, (int)imagedata.Length);
                    string filename = $"{school.Id}_picture.{imagedata.FileName.Split('.')[1]}";
                    school.ImageFileName = filename;
                    System.IO.File.WriteAllBytes(Path.Combine("wwwroot", "images", filename), buffer);
                }
            }
            //if (!ModelState.IsValid) return View(school);
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
        public IActionResult Update(School school, IFormFile imagedata)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(school);
            //}

            var DbSchool = repo.Read(school.Id);
            if (imagedata != null)
            {
                using (var stream = imagedata.OpenReadStream())
                {
                    byte[] buffer = new byte[imagedata.Length];
                    stream.Read(buffer, 0, (int)imagedata.Length);
                    string filename = $"{school.Id}_picture.{imagedata.FileName.Split('.')[1]}";
                    if (!school.ImageFileName.Contains('.')) System.IO.File.Delete(Path.Combine("wwwroot", "images", school.ImageFileName));
                    school.ImageFileName = filename;
                    DbSchool.ImageFileName = filename;
                    System.IO.File.WriteAllBytes(Path.Combine("wwwroot", "images", filename), buffer);
                }
            }

            DbSchool.Age = school.Age;
            DbSchool.Name = school.Name;
            DbSchool.Type = school.Type;
            repo.Update(DbSchool);
            return RedirectToAction(nameof(Index));
        }


    }
}
