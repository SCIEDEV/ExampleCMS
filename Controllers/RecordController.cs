using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Data;
using CMS.Models;
using Microsoft.AspNetCore.Mvc;

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
            List<Classes> objClassList = _db.Classes.ToList();
            Console.Write(objClassList[0].className);
            return View(objClassList);
        }

        public IActionResult Assessments()
        {
            return View();
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

