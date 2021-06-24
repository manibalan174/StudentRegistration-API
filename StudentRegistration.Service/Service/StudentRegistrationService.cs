using StudentRegistration.Core.IRepostories;
using StudentRegistration.Core.IService;
using StudentRegistration.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Service.Service
{
   public class StudentRegistrationService: EmployeeRegistrationIService
    {
        #region Declaration
        readonly EmployeeRegistrationIRepostories _Repositorie;
        #endregion

        public StudentRegistrationService(EmployeeRegistrationIRepostories iRepositorie)
        {
            _Repositorie = iRepositorie;
        }


        #region Login validation
        public bool Loginvalidation(LoginDetails loginDetails)
        {
           return _Repositorie.Loginvalidation(loginDetails);
        }
        #endregion

        #region Save Student Details
        public string SaveAndEditStudentDetails(StudentRegistrationModel studentDetail)
        {
          return  _Repositorie.SaveAndEditStudentDetails(studentDetail);
        }
        #endregion

        #region listStudents Details
        public List<StudentRegistrationModel> listStudents()
        {
            return _Repositorie.listStudents();
        }
        #endregion

        #region StudentDetailsReterive
        public StudentRegistrationModel StudentDetailsReterive(int StudentId)
        {
            return _Repositorie.StudentDetailsReterive(StudentId);
        }
        #endregion

        #region MyRegion
        public void StudentDetailsDelete(int StudentId)
        {
            _Repositorie.StudentDetailsDelete(StudentId);
        }
        #endregion
    }
}
