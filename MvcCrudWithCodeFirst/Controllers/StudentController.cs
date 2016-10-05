using MvcCrudWithCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCrudWithCodeFirst.Controllers
{
    public class StudentController : Controller
    {
        XCourseContext db;

        // GET: Student
        public ActionResult Index()
        {
            db = new XCourseContext();

            List<Student> model = db.Students.ToList();


            //string resultMessage = (string)TempData["ResultMessage"];
            //TempData.Keep("ResultMessage");

            //resultMessage = (string)TempData.Peek("ResultMessage");

            return View(model);
        }

        public ActionResult Create()
        {
            db = new XCourseContext();

            List<Teacher> allTeachers = db.Teachers.ToList();

            SelectList teachersSelectList = new SelectList(allTeachers, "Id", "FullName");

            ViewBag.Teachers = teachersSelectList;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Student model)
        {
            Student student = new Student();
            student.FirstName = model.FirstName;
            student.LastName = model.LastName;
            student.DateOfBirth = model.DateOfBirth;
            student.TeacherId = model.TeacherId;

            db = new XCourseContext();

            try
            {
                db.Entry(student).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                TempData["ResultMessage"] = "Kayıt işlemi başarılı";
                TempData["StudentEntity"] = student;
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

    }
}