using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLab1
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();
    }
}
