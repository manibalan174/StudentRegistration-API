using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace StudentRegistration.web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult LoginCheck(LoginDetails loginDetails)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:17753/StudentRegistration/LoginCheck");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<LoginDetails>(client.BaseAddress, loginDetails);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return Json("Login Succesully");
                }
            }
            return Json("UserName or Password is Invalid !");
        }
    }
}
