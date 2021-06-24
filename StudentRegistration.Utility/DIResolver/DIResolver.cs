using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using StudentRegistration.Core.IRepostories;
using StudentRegistration.Core.IService;
using StudentRegistration.Resource.Repostories;
using StudentRegistration.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Utility.DIResolver
{
   public class DIResolver
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<EmployeeRegistrationIService, StudentRegistrationService>();

            services.AddScoped<EmployeeRegistrationIRepostories, StudentRegistrationRepostories>();

        }
    }
}
