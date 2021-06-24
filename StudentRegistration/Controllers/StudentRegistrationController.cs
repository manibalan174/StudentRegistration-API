using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Core.IService;
using StudentRegistration.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistration.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StudentRegistrationController : ControllerBase
    {
       private readonly EmployeeRegistrationIService _Iservices;
        public StudentRegistrationController(EmployeeRegistrationIService Iservices)
        {
            _Iservices = Iservices;
        }
        [HttpGet]
        public IActionResult StudentDetailsList()
        {
            var studentDetilasList = _Iservices.listStudents();
            return Ok(studentDetilasList);
        }
        //public IActionResult AddEditStudentDetailsint StudentId = 0)
        //{
        //    if (StudentId != 0)   // reterive Method in List page to Edit Page
        //    {

        //        return View(StudentDetails);
        //    }
        //    else
        //    {
        //        return View(); // Normal Add Page
        //    }
        //}
        [HttpGet]
        public IActionResult AddEditStudentDetails(int StudentId = 0)
        {
            var StudentDetails = _Iservices.StudentDetailsReterive(StudentId);
            return Ok(StudentDetails);
        }

        //Insert
        [HttpPost]
        public ActionResult InsertUpdateStudentDetails(StudentRegistrationModel StudentProperties)
        {
            if (StudentProperties != null)
            {
                _Iservices.SaveAndEditStudentDetails(StudentProperties);
            }
            return RedirectToAction("StudentDetailsList");
        }
        [HttpDelete]
        public IActionResult StudentDetailDelete(int StudentId = 0)
        {
            if (StudentId != 0)   //Delete For StudentDetails in List Page
            {
                _Iservices.StudentDetailsDelete(StudentId);
            }
            return RedirectToAction("StudentDetailsList");
        }
    }
}
