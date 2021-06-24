using StudentRegistration.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Core.IService
{
   public interface EmployeeRegistrationIService
    {
        string SaveAndEditStudentDetails(StudentRegistrationModel studentDetail);
        List<StudentRegistrationModel> listStudents();
        StudentRegistrationModel StudentDetailsReterive(int StudentId);
        void StudentDetailsDelete(int StudentId);

        bool Loginvalidation(LoginDetails loginDetails);
    }
}
