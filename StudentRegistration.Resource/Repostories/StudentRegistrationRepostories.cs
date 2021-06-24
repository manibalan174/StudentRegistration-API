using StudentRegistration.Core.IRepostories;
using StudentRegistration.Core.Modals;
using StudentRegistration.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Resource.Repostories
{
   public class StudentRegistrationRepostories  : EmployeeRegistrationIRepostories
    {

            #region Login validation
            public bool Loginvalidation(LoginDetails loginDetails)
            {
            try
            {
                if (loginDetails != null)
                {
                    using (var entites = new StudentRegistrationEntity())
                    {
                        var dbStudentdetails = entites.login.SingleOrDefault(x => x.Uname == loginDetails.UserName && x.Upassword == loginDetails.Password);
                        if(dbStudentdetails !=null)
                        {
                            return true;
                        }
                    }
                }
             }
            catch (Exception)
            {

                throw;
            }
            return false;
        }
            #endregion
           
           
           #region Save And Update StudentDetails
        public string SaveAndEditStudentDetails(StudentRegistrationModel studentDetailProperties)
        {
            string _reslt = "";
        try
        {
            if (studentDetailProperties != null)
            {
                if (studentDetailProperties.StudentId == 0)
                {
                    // insert Function
                    using (var entites = new StudentRegistrationEntity())
                    {
                        StudentDetails dBStudenDetails = new StudentDetails();
                        //insert the datas in our porperties to database properties
                        dBStudenDetails.Fisrt_Name = studentDetailProperties.FisrtName;
                        dBStudenDetails.Last_Name = studentDetailProperties.LastName;
                        dBStudenDetails.Date_Of_Birth = studentDetailProperties.DateOfBirth;
                        dBStudenDetails.Age = studentDetailProperties.StudentAge;
                        dBStudenDetails.Favorite_Subject = studentDetailProperties.FavoriteSubject;
                        dBStudenDetails.Interested_Course = studentDetailProperties.InterestedCourse;
                        dBStudenDetails.Maths_Mark = studentDetailProperties.MathsMark;
                        dBStudenDetails.Chemistry_Mark = studentDetailProperties.ChemistryMark;
                        dBStudenDetails.Computer_Science_Mark = studentDetailProperties.ComputerScienceMark;
                        dBStudenDetails.Created_Time_Stamp = DateTime.Now;
                        dBStudenDetails.Updated_Time_Stamp = DateTime.Now;
                        dBStudenDetails.Is_Deleted = false;
                        entites.StudentDetails.Add(dBStudenDetails); //Add the properties to database
                        entites.SaveChanges();
                        _reslt = "Student Details Inserted Sueccesfully";
                    }
                }
                else
                {
                    // Update Function
                    using (var entites = new StudentRegistrationEntity())
                    {
                        var dbStudentdetails = entites.StudentDetails.Where(x => x.Student_Id == studentDetailProperties.StudentId && x.Is_Deleted == false).SingleOrDefault();
                        // StudentDetails dBStudenDetails = new StudentDetails();
                        //Update the datas in our porperties to database properties
                        dbStudentdetails.Fisrt_Name = studentDetailProperties.FisrtName;
                        dbStudentdetails.Last_Name = studentDetailProperties.LastName;
                        dbStudentdetails.Date_Of_Birth = studentDetailProperties.DateOfBirth;
                        dbStudentdetails.Age = studentDetailProperties.StudentAge;
                        dbStudentdetails.Favorite_Subject = studentDetailProperties.FavoriteSubject;
                        dbStudentdetails.Interested_Course = studentDetailProperties.InterestedCourse;
                        dbStudentdetails.Maths_Mark = studentDetailProperties.MathsMark;
                        dbStudentdetails.Chemistry_Mark = studentDetailProperties.ChemistryMark;
                        dbStudentdetails.Computer_Science_Mark = studentDetailProperties.ComputerScienceMark;
                        dbStudentdetails.Updated_Time_Stamp = DateTime.Now;
                        dbStudentdetails.Is_Deleted = false;
                        entites.SaveChanges(); // Update are Modify Datas in Database
                            _reslt = "Student Details Updated  Sueccesfully";
                        }
                }
            }

        }
        catch (Exception)
        {

            throw;
        }
            return _reslt;
    }
    #endregion
           
           #region List Students Details
    public List<StudentRegistrationModel> listStudents()
    {
        List<StudentRegistrationModel> StudentlistDetails = new List<StudentRegistrationModel>();   // Create List
        try
        {
            using (var entites = new StudentRegistrationEntity())
            {  
                var query = from student in entites.StudentDetails
                            where student.Is_Deleted == false
                            select student;
                var dbStudentDetails = query.ToList();

                if (dbStudentDetails != null)
                {
                    foreach (var item in dbStudentDetails)
                    {
                            StudentRegistrationModel StudentDetailsPropteries = new StudentRegistrationModel();
                        StudentDetailsPropteries.StudentId = item.Student_Id;
                        StudentDetailsPropteries.FisrtName = item.Fisrt_Name;
                        StudentDetailsPropteries.LastName = item.Last_Name;
                        StudentDetailsPropteries.DateOfBirth = Convert.ToDateTime(item.Date_Of_Birth);
                        StudentDetailsPropteries.StudentAge = item.Age;
                        StudentDetailsPropteries.FavoriteSubject = item.Favorite_Subject;
                        StudentDetailsPropteries.InterestedCourse = item.Interested_Course;
                        StudentDetailsPropteries.MathsMark = item.Maths_Mark;
                        StudentDetailsPropteries.ChemistryMark = item.Chemistry_Mark;
                        StudentDetailsPropteries.ComputerScienceMark = item.Computer_Science_Mark;
                        StudentDetailsPropteries.Average = (StudentDetailsPropteries.MathsMark + StudentDetailsPropteries.ChemistryMark + StudentDetailsPropteries.ComputerScienceMark) / 3;
                        StudentlistDetails.Add(StudentDetailsPropteries); /// Add Properties Values to List
                    }

                }
            }
        }
        catch (Exception)
        {
            throw;
        }
        return StudentlistDetails;
    }
    #endregion
           
           
           #region MyRegion  Reterive Student Details
    public StudentRegistrationModel StudentDetailsReterive(int StudentId)
    {
            StudentRegistrationModel StudentProperties = new StudentRegistrationModel();
        try
        {

            using (var entites = new StudentRegistrationEntity())
            {
                var dbStudentDetails = entites.StudentDetails.Where(x => x.Student_Id == StudentId && x.Is_Deleted == false).SingleOrDefault();
                if (dbStudentDetails != null)
                {
                    StudentProperties.StudentId = dbStudentDetails.Student_Id;
                    StudentProperties.FisrtName = dbStudentDetails.Fisrt_Name;
                    StudentProperties.LastName = dbStudentDetails.Last_Name;
                    StudentProperties.DateOfBirth = Convert.ToDateTime(dbStudentDetails.Date_Of_Birth);
                    StudentProperties.StudentAge = dbStudentDetails.Age;
                    StudentProperties.FavoriteSubject = dbStudentDetails.Favorite_Subject;
                    StudentProperties.InterestedCourse = dbStudentDetails.Interested_Course;
                    StudentProperties.MathsMark = dbStudentDetails.Maths_Mark;
                    StudentProperties.ChemistryMark = dbStudentDetails.Chemistry_Mark;
                    StudentProperties.ComputerScienceMark = dbStudentDetails.Computer_Science_Mark;
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
        return StudentProperties;
    }
    #endregion
           
           
           #region Student Details Delete
    public void StudentDetailsDelete(int StudentId)
    {
        try
        {
            using (var entites = new StudentRegistrationEntity())
            {
                var dbStudentDetails = entites.StudentDetails.Where(x => x.Student_Id == StudentId).SingleOrDefault();
                if (dbStudentDetails != null)
                {
                    dbStudentDetails.Is_Deleted = true;
                    dbStudentDetails.Updated_Time_Stamp = DateTime.Now;
                    entites.SaveChanges();
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion
   }          
}
