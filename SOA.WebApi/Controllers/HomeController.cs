using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.ProjectOxford.Face;
using SOA.WebApi.Models;


namespace SOA.WebApi.Controllers
{
    
    public class HomeController : Controller
    {
        FaceServiceClient client = new FaceServiceClient("e2a92091771a473b88b2c8599836f7c7");
        public ActionResult Index(HttpPostedFileBase file)
        {
            file.SaveAs(Server.MapPath("~/Images/" + file.FileName));
            return RedirectToAction("GetResult", new { fileName = file.FileName });
        }
        public async Task<ActionResult> GetResult(string filePath)
        {
            string baseAddress = "http://localhost:50745/";
            string url = string.Format("api/faces?fileName={0}", filePath);
            string apiUri = baseAddress + url;
            List<AbsenceTracking> absenceTrackings = new List<AbsenceTracking>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(apiUri);
                if (response.IsSuccessStatusCode)
                {
                    absenceTrackings = await response.Content.ReadAsAsync<List<AbsenceTracking>>();
                    //var data = await response.Content.ReadAsStringAsync();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);

                }


            }
            return View(absenceTrackings);
        }
    }
}
