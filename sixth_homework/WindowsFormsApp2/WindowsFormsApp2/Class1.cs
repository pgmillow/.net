using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WindowsFormsApp2
{
    public class School
    {
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int SchoolId { get; set; } // Foreign key to School

        public override string ToString()
        {
            return ClassName;
        }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int ClassId { get; set; } // Foreign key to Class
    }

}
