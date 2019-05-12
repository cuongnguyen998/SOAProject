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
        private SOAModelDataContext db = new SOAModelDataContext();


        // GET: api/Students
        public IEnumerable<AbsenceTracking> Get()
        {
            return db.AbsenceTrackings.ToList();
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
