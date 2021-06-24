using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentRegistration.Core.Modals;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace StudentRegistration.web.Controllers
{
    public class StudentRegistrationController : Controller
    {

        #region Student Details List
        public ActionResult StudentDetailsList()
        {
            IEnumerable<StudentRegistrationModel> students = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:17753/StudentRegistration/");
                //HTTP GET
                var responseTask = client.GetAsync("StudentDetailsList");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<StudentRegistrationModel>>();
                    readTask.Wait();

                    students = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    students = Enumerable.Empty<StudentRegistrationModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(students);
        }
        #endregion

        #region Add Edit Student Details
        public IActionResult AddEditStudentDetails(int StudentId = 0)
        {
            if (StudentId != 0)   // reterive Method in List page to Edit Page
            {
                StudentRegistrationModel student = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:17753/StudentRegistration/");
                    //HTTP GET
                    var responseTask = client.GetAsync("AddEditStudentDetails?StudentId=" + StudentId);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<StudentRegistrationModel>();
                        readTask.Wait();

                        student = readTask.Result;
                    }
                }

                return View(student);
            }
            else
            {
                return View(); // Normal Add Page
            }
        }
        #endregion

        #region Insert Update Student Details
        public ActionResult InsertUpdateStudentDetails(StudentRegistrationModel StudentProperties)
        {
            var _result = "";

            if(StudentProperties.StudentId==0)
            {
                _result = "Sudent Details Inserted";
            }
            else
            {
                _result = "Sudent Details Inserted";
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:17753/StudentRegistration/InsertUpdateStudentDetails");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<StudentRegistrationModel>(client.BaseAddress, StudentProperties);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Alert"] = _result + "Successfully";
                    return RedirectToAction("StudentDetailsList");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            TempData["Alert1"] = _result + "Something Went To Wrong !";
            return RedirectToAction("AddEditStudentDetails");
        }
        #endregion

        #region Student Detail Delete
        public IActionResult StudentDetailDelete(int StudentId)
         {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:17753/StudentRegistration/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("StudentDetailDelete?StudentId=" + StudentId);
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("StudentDetailsList");
                }
            }
            return RedirectToAction("StudentDetailsList");
        }
        #endregion



    }
}
