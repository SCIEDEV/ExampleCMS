using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Data;
using CMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMS.Controllers
{
    public class RecordController : Controller
    {
        private readonly ClassDatabaseContext _db;
        public RecordController(ClassDatabaseContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TimeTable()
        {
            List<Classes> objClassList = _db.Classes.OrderBy(x => x.period).ToList();
            return View(objClassList);
        }

        public IActionResult Assessments()
        {
            return View();
        }

        public IActionResult AddClass()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditClass(int id)
        {
            var obj = _db.Classes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult EditClass(int ID, Classes editedClass)
        {
            if (ModelState.IsValid)
            {
                // Update your database with edited class details
                _db.Update(editedClass);
                _db.SaveChanges();
                return RedirectToAction("TimeTable"); // or whatever your main view is
            }
            return View(editedClass);
        }


        [HttpPost]
        public IActionResult AddClass(Classes obj)
        {
            if (ModelState.IsValid)
            {
                _db.Classes.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("TimeTable");
            }
            return View("AddClass");
        }

        [HttpPost]
        public IActionResult DeleteClass(int ID)
        {
            var objClass = _db.Classes.Find(ID);
            if (objClass == null)
            {
                return NotFound();
            }
            _db.Classes.Remove(objClass);
            _db.SaveChanges();
            return RedirectToAction("TimeTable");
        }


        [HttpPost]
        public ActionResult TestForm(Models.TestResult sm)
        {
            ViewBag.subject = sm.subject;
            ViewBag.grade = sm.grade;

            return View("Assessments");
        }
    }
}

