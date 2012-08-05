using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MsftDashboard.Models
{
    public class EducationInformation
    {
        public int IdSchoolType { get; set; }
        public int IdSchoolLevel { get; set; }
        public string SchoolTypeName { get; set; }
        public string SchoolLevelName { get; set; }
        public string StateName { get; set; }
        public int NumberSchools { get; set; }
        public int NumberTeachers { get; set; }
        public int NumberStudents { get; set; }
    }
}
