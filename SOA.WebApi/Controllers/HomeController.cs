using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.ProjectOxford.Face;
namespace SOA.WebApi.Controllers
{
    
    public class HomeController : Controller
    {
        FaceServiceClient client = new FaceServiceClient("e2a92091771a473b88b2c8599836f7c7");
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexView()
        {
            return View();
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            //Process
            file.SaveAs(Server.MapPath("~/Images/" + file.FileName));
            return "/Images/" + file.FileName;
        }
    }
}
