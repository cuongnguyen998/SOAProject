using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.ProjectOxford.Face;
using SOA.WebApi.Models;
namespace SOA.WebApi.Controllers
{
    public class StudentsController : ApiController
    {
        FaceServiceClient client = new FaceServiceClient(ConstPara.subcriptionKey);


        // GET: api/Students
        public IEnumerable<Student> Get()
        {

            return new List<Student>();
        }

        // GET: api/Students/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Students
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Students/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Students/5
        public void Delete(int id)
        {
        }
    }
}
