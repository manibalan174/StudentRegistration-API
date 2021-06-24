using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Core.Modals
{
    public class StudentRegistrationModel
    {
        public int StudentId { get; set; }
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        public int StudentAge { get; set; }
        public string FavoriteSubject { get; set; }
        public string InterestedCourse { get; set; }
        public int MathsMark { get; set; }
        public int ChemistryMark { get; set; }
        public int ComputerScienceMark { get; set; }
        public int Average { get; set; }
    }
}
