using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLab1
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int Hours { get; set; }

        public List<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();

    }
}
