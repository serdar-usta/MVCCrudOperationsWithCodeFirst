using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCrudWithCodeFirst.Models;

namespace MvcCrudWithCodeFirst.Controllers
{
    [AuthenticationRequired]
    public class LessonController : Controller
    {
        XCourseContext _db;

        // GET: Lesson
        public ActionResult Index()
        {
            _db = new XCourseContext();

            List<Lesson> lessonList = _db.Lessons.Include("Teacher").ToList();

            return View(lessonList);
        }


        public ActionResult CreatePartial()
        {
            _db = new XCourseContext();

            SelectList teachersList = new SelectList(_db.Teachers.ToList(), "Id", "FullName");

            ViewData["TeachersList"] = teachersList;

            return PartialView("Create_Content");
        }


        [HttpPost]
        public ActionResult CreatePartial(Lesson model)
        {
            _db = new XCourseContext();
            Lesson lesson = new Lesson();
            lesson.Name = model.Name;
            lesson.TeacherId = model.TeacherId;

            _db.Lessons.Add(lesson);

            try
            {
                _db.SaveChanges();

                List<Lesson> lessonList = _db.Lessons.Include("Teacher").ToList();

                return PartialView("Index_Content", lessonList);

            }
            catch (Exception)
            {
                return PartialView("Create_Content");


            }
        }

    }
}