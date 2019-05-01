using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Image Image { get; set; }
        public Student(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
