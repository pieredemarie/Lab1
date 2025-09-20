using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLab1
{
    public class StudentSubject
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int Grade { get; set; }

        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
