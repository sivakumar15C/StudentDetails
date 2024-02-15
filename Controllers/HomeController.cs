using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentDetails.Controllers
{
    public class HomeController : Controller
    {
        StudentDetailsEntity _context = new StudentDetailsEntity();
        public ActionResult Index()
        {
            var listofdata = _context.StudentDetails.ToList();
            return View(listofdata);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
public ActionResult Create(StudentDetail model)
{
_context.StudentDetails.Add(model);
_context.SaveChanges();
ViewBag.Message = "Data insert succefully";
return RedirectToAction("Index");
}
[HttpGet]
public ActionResult Edit(int id)
{
var data = _context.StudentDetails.Where(x => x.StudentId == id).FirstOrDefault();
return View(data);
}
[HttpPost]
public ActionResult Edit(StudentDetail Model)
{
    var data = _context.StudentDetails.Where(x => x.StudentId == Model.StudentId).FirstOrDefault();
    if (data != null)
    {
    data.StudentCity = Model.StudentCity;
    data.StudentName = Model.StudentName;
    data.StudentFeez = Model.StudentFeez;
    _context.SaveChanges();
}
return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
{
    var data = _context.StudentDetails.Where(x => x.StudentId == id).FirstOrDefault();
    return View(data);
}
public ActionResult Delete(int id)
{
    var data = _context.StudentDetails.Where(x => x.StudentId == id).FirstOrDefault();
    _context.StudentDetails.Remove(data);
    _context.SaveChanges();
    ViewBag.Message = "record deleted successfully";
    return RedirectToAction("Index");
}
    }
}