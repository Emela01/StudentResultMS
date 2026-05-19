using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentResultMS.Data;
using StudentResultMS.Models;

namespace StudentResultMS.Controllers
{
    public class ResultController : Controller
    {
        private readonly StudentContext _context;

        public ResultController(StudentContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var results = _context.Results
                .Include(r => r.Student)
                .Include(r => r.Course)
                .ToList();
            return View(results);
        }

        public IActionResult Create()
        {

            ViewBag.Students = _context.Students.ToList(); // Populate ViewBag.Students
            ViewBag.Courses = _context.Courses.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Result result)
        {
            if (result.Score >= 70)
            {
                result.Grade = "A";
            }
            else if (result.Score >= 60)
            {
                result.Grade = "B";
            }
            else if (result.Score >= 50)
            {
                result.Grade = "C";
            }
            else if (result.Score >= 45)
            {
                result.Grade = "D";
            }
            else
            {
                result.Grade = "F";
            }

            _context.Results.Add(result);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = _context.Results.Find(id);
            if (result == null)
            {
                return NotFound();
            }

            ViewBag.Students = _context.Students.ToList(); // Populate ViewBag.Students
            ViewBag.Courses = _context.Courses.ToList();   // Populate ViewBag.Courses if needed
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Result result)
        {
            if (result.Score >= 70)
            {
                result.Grade = "A";
            }
            else if (result.Score >= 60)
            {
                result.Grade = "B";
            }
            else if (result.Score >= 50)
            {
                result.Grade = "C";
            }
            else if (result.Score >= 45)
            {
                result.Grade = "D";
            }
            else
            {
                result.Grade = "F";
            }

            _context.Results.Update(result);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = _context.Results
                .Include(r => r.Student)
                .Include(r => r.Course)
                .FirstOrDefault(r => r.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _context.Results.Find(id);

            if (result == null)
            {
                return NotFound();
            }

            _context.Results.Remove(result);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
