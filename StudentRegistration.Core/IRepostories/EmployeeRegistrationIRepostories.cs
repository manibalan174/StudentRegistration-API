using StudentRegistration.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Core.IRepostories
{
    public interface EmployeeRegistrationIRepostories
    {
        bool Loginvalidation(LoginDetails loginDetails);
        string SaveAndEditStudentDetails(StudentRegistrationModel studentDetail);
        List<StudentRegistrationModel> listStudents();
        StudentRegistrationModel StudentDetailsReterive(int StudentId);
        void StudentDetailsDelete(int StudentId);
    }
}
