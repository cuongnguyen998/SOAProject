using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SOA.WebApi.Controllers
{
    public class LoadFilesController : ApiController
    {
        // GET: api/LoadFiles
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/LoadFiles/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/LoadFiles
        public HttpResponseMessage Post()
        {
            HttpResponseMessage result = null;
            var request = HttpContext.Current.Request;
            if (request.Files.Count > 0)
            {
                var file = new List<string>();
                foreach (string item in request.Files)
                {
                    var postFile = request.Files[item];
                    var filePath = HttpContext.Current.Server.MapPath("~/" + postFile.FileName);
                    postFile.SaveAs(filePath);
                    file.Add(filePath);
                }
                result = Request.CreateResponse(HttpStatusCode.Created, file);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }

        // PUT: api/LoadFiles/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LoadFiles/5
        public void Delete(int id)
        {
        }
    }
}
