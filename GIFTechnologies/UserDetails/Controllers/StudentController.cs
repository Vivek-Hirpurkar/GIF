using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserDetails.Models;

namespace UserDetails.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult GetAllStudents()
        {
            StudentDBHelper db = new StudentDBHelper();
            List<StudentDetails> students = db.GetAllStudents();
            return View(students);
        }
    }
}