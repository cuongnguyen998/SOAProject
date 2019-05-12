using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using SOA.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace SOA.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FacesController : ApiController
    {
        FaceServiceClient client = new FaceServiceClient(ConstPara.subcriptionKey, "https://southeastasia.api.cognitive.microsoft.com/face/v1.0");
        //SOAModalDataContext db = new SOAModalDataContext();
        SOAModelDataContext db = new SOAModelDataContext();
        private string fileName = "";
        //private string serverPath = HttpContext.Current.Server.MapPath("/Images/");
        List<AbsenceTracking> list = new List<AbsenceTracking>()
        {
            //new Student("31161021612","Cường", HttpContext.Current.Server.MapPath("/Images/" + "Quoc Cuong/31161021612.png") ),
            //new Student("31161026676","Khoa", HttpContext.Current.Server.MapPath("/Images/"+ "Dang Khoa/31161026676.png")),
            //new Student("31161020017", "Du", HttpContext.Current.Server.MapPath("/Images/" + "Khanh Du/31161020017.png")),
            //new Student("31161020836", "Bình", HttpContext.Current.Server.MapPath("/Images/"+ "Trong Binh/31161020836.png")),
            //new Student("31161020474", "Dũng", HttpContext.Current.Server.MapPath("/Images/" + "Anh Dung/31161020474.png")),
            //new Student("31161020232", "Bích Tuyền", HttpContext.Current.Server.MapPath("/Images/" + "Bich Tuyen/31161020232.png")),
            //new Student("31161024677", "Hạnh Mai", HttpContext.Current.Server.MapPath("/Images/" + "Hanh Mai/31161024677.png")),
            //new Student("31161021131", "Hiếu Mỹ", HttpContext.Current.Server.MapPath("/Images/"+"Hieu My/31161021131.png")),
            //new Student("31161023705", "Hoài Linh", HttpContext.Current.Server.MapPath("/Images/"+ "Hoai Linh/31161023705.png")),
            //new Student("31161021419", "Hoài Thương", HttpContext.Current.Server.MapPath("/Images/"+"Hoai Thuong/31161021419.png")),
            //new Student("31161026492", "Hoàng Khánh", HttpContext.Current.Server.MapPath("/Images/"+"Hoang Khanh/31161026492.png")),
            //new Student("31161024227", "Hoàng Nam", HttpContext.Current.Server.MapPath("/Images/"+"Hoang Nam/31161024227.png")),
            //new Student("31161023018", "Quỳnh Chi", HttpContext.Current.Server.MapPath("/Images/"+"Huynh Chi/31161023018.png")),
            //new Student("31161020515", "Huỳnh Đức", HttpContext.Current.Server.MapPath("/Images/" + "Huynh Duc/31161020515.png")),
            //new Student("31161021392", "Quỳnh Như", HttpContext.Current.Server.MapPath("/Images/"+"Huynh Nhu/31161021392.png")),
            //new Student("31161020990", "Khải Hoàn", HttpContext.Current.Server.MapPath("/Images/"+"Khai Hoan/31161020990.png")),
            //new Student("31161022233", "Khánh Linh", HttpContext.Current.Server.MapPath("/Images/"+"Khanh Linh/31161022233.png")),
            //new Student("31161020484", "Khánh Trang", HttpContext.Current.Server.MapPath("/Images/"+"Khanh Trang/31161020484.png")),
            //new Student("31161026660", "Lệ Thu", HttpContext.Current.Server.MapPath("/Images/"+"Le Thu/31161026660.png")),
            //new Student("31161021295", "Phan Minh An", HttpContext.Current.Server.MapPath("/Images/"+"Minh An/31161021295.png")),
            //new Student("31161020013", "Nguyễn Minh An", HttpContext.Current.Server.MapPath("/Images/"+"Minh An Nguyen/31161020013.png")),
            //new Student("31161020183", "Minh Quân", HttpContext.Current.Server.MapPath("/Images/"+"Minh Quan/31161020183.png")),
            //new Student("31161026355", "Minh Trị", HttpContext.Current.Server.MapPath("/Images/"+"Minh Tri/31161026355.png")),
            //new Student("31161024815", "Như Khuê", HttpContext.Current.Server.MapPath("/Images/"+"Nhu Khue/Khue.jpg")),
            //new Student("31161024043", "Sỹ Hiệp", HttpContext.Current.Server.MapPath("/Images/"+"Sy Hiep/31161024043.png")),
            //new Student("31161024491", "Thanh Châu", HttpContext.Current.Server.MapPath("/Images/"+"Thanh Chau/31161024491.png")),
            //new Student("31161023792", "Thành Đạt", HttpContext.Current.Server.MapPath("/Images/"+"Thanh Dat/31161023792.png")),
            //new Student("31161025161", "Thanh Hoài", HttpContext.Current.Server.MapPath("/Images/"+"Thanh Hoai/31161025161.png")),
            //new Student("31161022532", "Thanh Phong",HttpContext.Current.Server.MapPath("/Images/"+ "Thanh Phong/31161022532.png")),
            //new Student("31161022907", "Thu Phương", HttpContext.Current.Server.MapPath("/Images/"+"Thu Phuong/31161022907.png")),
            //new Student("31161025558", "Xuân Ngọc", HttpContext.Current.Server.MapPath("/Images/"+"Xuan Ngoc/31161025558.png")),
            //new Student("31161021641", "Anh Thy", HttpContext.Current.Server.MapPath("/Images/"+ "31161021641.png")),
            //new Student("31161021925", "Unname", HttpContext.Current.Server.MapPath("/Images/"+"31161021925.png")),
            //new Student("31161023543", "Unname1", HttpContext.Current.Server.MapPath("/Images/"+"31161023543.png")),
            //new Student("31161023590", "Unname2", HttpContext.Current.Server.MapPath("/Images/"+"31161023590.png")),
            //new Student("31161024766", "Unname3", HttpContext.Current.Server.MapPath("/Images/"+"31161024766.png")),
        };
        // GET: api/Faces
        public IEnumerable<AbsenceTracking> Get()
        {
            return db.AbsenceTrackings.ToList();
        }

        //GET:api/faces/2019-05-02
        //public List<Student> Get(Student student)
        //{
        //    List<Student> attendList = new List<Student>();
        //    var reslt = from st in db.Students
        //                where st.AttendDate == student.AttendDate
        //                select st;
        //    foreach (var item in reslt)
        //    {
        //        attendList.Add(item);
        //    }
        //    return attendList;

        //}

        //POST: api/Faces?fileName
        [ResponseType(typeof(AbsenceTracking))]
        public async Task<List<AbsenceTracking>> Get(string fileName)
        {
            List<AbsenceTracking> students = new List<AbsenceTracking>();
            if (fileName != "")
            {
                string filePath = HttpContext.Current.Server.MapPath("~/Images/" + fileName);
                
                List<Person> listp = await DefineStudentInStudentList(filePath, "groupone");
                foreach (Person item in listp)
                {
                    AbsenceTracking student = new AbsenceTracking
                    {
                        Id = item.Name,
                        AttendDate = DateTime.Now
                    };
                    students.Add(student);
                    db.AbsenceTrackings.InsertOnSubmit(student);
                    db.SubmitChanges();
                }
            }
            return students;

        }


        // POST: api/Faces
        [ResponseType(typeof(AbsenceTracking))]
        public async Task<List<AbsenceTracking>> Post()
        {

            //string filePath = HttpContext.Current.Server.MapPath("~/Images/" + fileName);
            HttpResponseMessage result = null;
            var request = HttpContext.Current.Request;
            string filePath = "";
            if (request.Files.Count > 0)
            {
                var file = new List<string>();

                foreach (string item in request.Files)
                {
                    var postFile = request.Files[item];
                    filePath = HttpContext.Current.Server.MapPath("~/Images/" + postFile.FileName);
                    postFile.SaveAs(filePath);
                    file.Add(filePath);
                }
                result = Request.CreateResponse(HttpStatusCode.Created, file);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            //string imagePath = @"E:\SOA\FaceIdentifyProject\SOA.WebApi\Images\Huynh Nhu\31161021392.png";
            //string imagePath = HttpContext.Current.Server.MapPath("/Images/" + fileName);
            List<AbsenceTracking> students = new List<AbsenceTracking>();
            List<Person> listp = await DefineStudentInStudentList(filePath, "groupone");
            foreach (Person item in listp)
            {
                AbsenceTracking student = new AbsenceTracking
                {
                    Id = item.Name,
                    AttendDate = DateTime.Now
                };
                students.Add(student);
                db.AbsenceTrackings.InsertOnSubmit(student);
                db.SubmitChanges();
            }
            return students;
        }

        async Task<List<Person>> DefineStudentInStudentList(string groupImagePath, string personGroup)
        {
            List<Person> listPerson = new List<Person>();
            //Tạo 1 groupPerson mới
            string personGroupId = personGroup;

            //var check = await client.GetPersonGroupAsync(personGroupId);
            //if (check == null)
            //{
            //    await client.CreatePersonGroupAsync(personGroupId, "BI001");
            //}

            //foreach (Student item in listStudent)
            //{
            //    CreatePersonResult student = await client.CreatePersonAsync(personGroupId, item.Id);
            //    using (Stream stream = File.OpenRead(item.ImagePath))
            //    {
            //        await client.AddPersonFaceAsync(personGroupId, student.PersonId, stream);
            //    }
            //    //RegisterFaceToCorrectStudent(imagePath,personGroupId,student);
            //}

            ////Traing
            //await client.TrainPersonGroupAsync(personGroupId);

            //TrainingStatus status = null;
            //while (true)
            //{
            //    status = await client.GetPersonGroupTrainingStatusAsync(personGroupId);
            //    if (status.Status != Status.Running)
            //    {
            //        break;
            //    }
            //    await Task.Delay(1000);
            //}
            //string groupImagePath = @"E:\SOA\FaceIdentifyProject\SOA.WebApi\Images\group.jpg";


            using (Stream stream = File.OpenRead(groupImagePath))
            {
                var faces = await client.DetectAsync(stream);
                var faceIds = faces.Select(face => face.FaceId).ToArray();
                var results = await client.IdentifyAsync(personGroupId, faceIds);
                foreach (var identifyResult in results)
                {
                    Console.WriteLine("Result of face: {0}", identifyResult.FaceId);
                    if (identifyResult.Candidates.Length == 0)
                    {
                        continue;
                    }
                    else
                    {
                        var candidateId = identifyResult.Candidates[0].PersonId;
                        var person = await client.GetPersonAsync(personGroupId, candidateId);
                        listPerson.Add(person);
                    }
                }
            }
            return listPerson;
        }

        // PUT: api/Faces/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/Faces/5
        public void Delete(int id)
        {

        }
    }
}
