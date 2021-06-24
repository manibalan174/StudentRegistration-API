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
        #region Interface Declaration
        private readonly EmployeeRegistrationIService _Iservices;
        #endregion

        #region Interface Injection
        public StudentRegistrationController(EmployeeRegistrationIService Iservices)
        {
            _Iservices = Iservices;
        }
        #endregion


        #region Login Check
        [HttpPost]
        public IActionResult LoginCheck(LoginDetails loginDetails)
        {
           var Result= _Iservices.Loginvalidation(loginDetails);
            if(Result==true)
            {
                return Ok("studentDetilasList");
            }
            return Ok("LoginCheck");
        }
        #endregion

        [HttpGet]
        public IActionResult StudentDetailsList()
        {
            var studentDetilasList = _Iservices.listStudents();
            return Ok(studentDetilasList);
        }
       
        [HttpGet]
        public IActionResult AddEditStudentDetails(int StudentId)
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
               var Measssage=  _Iservices.SaveAndEditStudentDetails(StudentProperties);
            }
            return RedirectToAction("StudentDetailsList");
        }
        [HttpDelete]
        public IActionResult StudentDetailDelete(int StudentId)
        {
            if (StudentId != 0)   //Delete For StudentDetails in List Page
            {
                _Iservices.StudentDetailsDelete(StudentId);
            }
            return RedirectToAction("StudentDetailsList");
        }
    }
}
