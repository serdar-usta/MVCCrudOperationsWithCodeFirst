using MvcCrudWithCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCrudWithCodeFirst.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            XCourseContext db = new XCourseContext();

            List<Teacher> model = db.Teachers.ToList();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Teacher model)
        {
            XCourseContext db = new XCourseContext();

            Teacher teacher = new Teacher();
            teacher.FirstName = model.FirstName;
            teacher.LastName = model.LastName;
            teacher.Proficiency = model.Proficiency;

            try
            {
                db.Entry(teacher).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("Index");

                //List<Teacher> teacherList = db.Teachers.ToList();
                //return View("Index", teacherList);

            }
            catch (Exception)
            {

                return View(model);
                //return RedirectToAction("Create");
            }
        }

        public ActionResult Edit(int id)
        {
            XCourseContext db = new XCourseContext();

            Teacher model = db.Teachers.Find(id);

            if (model == null)
            {
                return HttpNotFound();
                //return View("Error");
                //return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Teacher model)
        {
            XCourseContext db = new XCourseContext();

            Teacher teacher = db.Teachers.Find(model.Id);
            teacher.FirstName = model.FirstName;
            teacher.LastName = model.LastName;
            teacher.Proficiency = model.Proficiency;

            try
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(model);
            }


            //db.Entry(model);
            //db.Teachers.Attach(model);

            //// Bu aşamada model'in state'i UNCHANGED

            //db.Entry(model).State = System.Data.Entity.EntityState.Modified;

            //// Bu aşamada model'in state'i MODIFIED

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (Exception)
            //{

            //    throw;
            //}

        }

        public ActionResult Delete(int id)
        {
            XCourseContext db = new XCourseContext();

            Teacher model = db.Teachers.Find(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            XCourseContext db = new XCourseContext();

            Teacher teacher = db.Teachers.Find(id);

            try
            {
                db.Entry(teacher).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(teacher);
            }
        }

    }

}