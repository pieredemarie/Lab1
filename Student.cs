using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLab1
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public List<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();
    }
}
