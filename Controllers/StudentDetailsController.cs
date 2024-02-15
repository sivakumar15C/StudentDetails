using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentDetails;


namespace StudentDetails.Controllers
{
    public class StudentDetailsController : Controller
    {
        private StudentDetailsEntity db = new StudentDetailsEntity();

        // GET: StudentDetails
        public ActionResult Index()
        {
            return View(db.StudentDetails.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(StudentDetail data)
        {
            db.StudentDetails.Add(data);
            db.SaveChanges();
            ViewBag.Message = "data inserted successfully";
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = db.StudentDetails.Where(x => x.StudentId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(StudentDetail model)
        {
            var data = db.StudentDetails.Where(x => x.StudentId ==model.StudentId).FirstOrDefault();
            if (data != null)
            {
                data.StudentCity =model. StudentCity;
                data.StudentName = model.StudentName;
                data.StudentFeez = model.StudentFeez;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            var data = db.StudentDetails.Where(x => x.StudentId == id).FirstOrDefault();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
           var data= db.StudentDetails.Where(x=>x.StudentId==id).FirstOrDefault();
            db.StudentDetails.Remove(data);
            db.SaveChanges();
            ViewBag.Message = "data deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
