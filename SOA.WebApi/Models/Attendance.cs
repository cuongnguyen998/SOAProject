using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOA.WebApi.Models
{
    public class Attendance
    {
        public List<Student> StudentList { get; set; }
        public DateTime CreateDate { get; set; }

    }
}