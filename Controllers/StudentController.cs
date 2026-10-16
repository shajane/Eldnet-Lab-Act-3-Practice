using LA2_Duyongco.Models;
using Microsoft.AspNetCore.Mvc;

namespace LA2_Duyongco.Controllers
{
    public class StudentController : Controller
    {
        private static readonly List<Student> students = new List<Student>
        {
             new Student { Id = 1, Name = "Juan Dela Cruz", Course = "BSIT" },
             new Student { Id = 2, Name = "Maria Santos", Course = "BSCS" },
             new Student { Id = 3, Name = "Pedro Garcia", Course = "BSIS" }
        };

        // Replaces Index
        public IActionResult StudentListView()
        {
            return View("StudentListView", students);
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View("AddStudentView");
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            // Auto-increment ID
            student.Id = students.Any() ? students.Max(s => s.Id) + 1 : 1;
            students.Add(student);
            return RedirectToAction("StudentListView");
        }

        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            return View("EditStudentView", student);
        }

        [HttpPost]
        public IActionResult EditStudent(Student updatedStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == updatedStudent.Id);
            if (student != null)
            {
                student.Name = updatedStudent.Name;
                student.Course = updatedStudent.Course;
                student.Grade = updatedStudent.Grade; // This line saves the grade
            }
            return RedirectToAction("StudentListView");
        }

        public IActionResult DetailsStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            return View("DetailsStudentView", student);
        }

        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            return View("DeleteStudentView", student);
        }

        [HttpPost, ActionName("DeleteStudent")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
            }
            return RedirectToAction("StudentListView");
        }


    }
}
