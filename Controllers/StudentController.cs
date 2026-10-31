
using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Models;

namespace StudentRegistration.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Aarav Sharma", Email = "aarav.sharma@example.com", Course = "Computer Engineering", Semester = 5 },
            new Student { Id = 2, Name = "Priya Patel", Email = "priya.patel@example.com", Course = "Data Science", Semester = 3 },
            new Student { Id = 3, Name = "Rohan Verma", Email = "rohan.v@example.com", Course = "Information Technology", Semester = 6 }
        };
        private static int nextId = 4;

        public IActionResult Index()
        {
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = nextId++;
                students.Add(student);

                return RedirectToAction("Index");
            }

            return View(student);
        }

        public IActionResult Details(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
    }
}
