using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Course
    {
        public Int64 CourseID { get; set; } //(PK)
        public String Course_Name { get; set; }
    }
}
