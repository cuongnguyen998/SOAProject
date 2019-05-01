using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
namespace SOA.WebApi.Models
{
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime AttendDate { get; set; }
        public string ImagePath { get; set; }
        //public List<Image> Images { get; set; }
        public Student(string id, string name, string imagePath)
        {
            this.Id = id;
            this.Name = name;
            this.ImagePath = imagePath;
        }
        public Student()
        {

        }
    }
}