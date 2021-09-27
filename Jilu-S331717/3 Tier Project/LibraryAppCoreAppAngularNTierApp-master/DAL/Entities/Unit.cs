using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Unit
    {
        public Int64 UnitID { get; set; } //(PK)
        public String Unit_Name { get; set; }
        public Int64 Unit_Credit { get; set; }
    }
}
