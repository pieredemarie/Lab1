using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLab1
{
    public class Faculty
    {
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }
        public string DeanName { get; set; }

        public List<Group> Groups { get; set; } = new List<Group>();
    }
}
