using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using SOA.WebApi.Models;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Description;
using System.Web.Http.Cors;
using System.Drawing;

namespace SOA.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*",methods: "*")]
    public class FacesController : ApiController
    {
        FaceServiceClient client = new FaceServiceClient(ConstPara.subcriptionKey, "https://southeastasia.api.cognitive.microsoft.com/face/v1.0");
        SOAModalDataContext db = new SOAModalDataContext();
        List<Student> list = new List<Student>()
        {
            new Student("31161021612","Cường",@"E:\SOA\FaceIdentifyProject\SOA.WebApi\Images\Quoc Cuong\31161021612.png"),
            new Student("31161026676","Khoa",@"E:\SOA\FaceIdentifyProject\SOA.WebApi\Images\Dang Khoa\31161026676.png"),
            new Student("31161020017", "Du", @"E:\SOA\FaceIdentifyProject\SOA.WebApi\Images\Khanh Du\31161020017.png"),
            new Student("31161020836", "Bình", @"E:\SOA\FaceIdentifyProject\SOA.WebApi\Images\Trong Binh\31161020836.png"),
        };
        // GET: api/Faces
        public async Task<List<Student>> Get()
        {
            
            List<Student> students = new List<Student>();
            List<Person> listp = await DefineStudentInStudentList(list);
            foreach (Person item in listp)
            {
                Student student = new Student();
                student.Id = item.Name;
                student.AttendDate = DateTime.Now;
                students.Add(student);
                db.Students.InsertOnSubmit(student);
                db.SubmitChanges();
            }
            return students;
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

        // POST: api/Faces
        [ResponseType(typeof(Student))]
        public IHttpActionResult Post(Student student)
        {
            if (student == null)
            {
                return NotFound();
            }
            db.Students.InsertOnSubmit(student);
            db.SubmitChanges();
            return Ok(student);
            //DefineStudentInStudentList(listStudent,"");
        }
        async Task<List<Person>> DefineStudentInStudentList(List<Student> listStudent)
        {
            List<Person> listPerson = new List<Person>();
            //Tạo 1 groupPerson mới
            string personGroupId = "groupone";
            
            var check = await client.GetPersonGroupAsync(personGroupId);
            if (check == null)
            {
                await client.CreatePersonGroupAsync(personGroupId, "BI001");
            }
            
            foreach (Student item in listStudent)
            {
                CreatePersonResult student = await client.CreatePersonAsync(personGroupId, item.Id);
                using (Stream stream = File.OpenRead(item.ImagePath))
                {
                    await client.AddPersonFaceAsync(personGroupId, student.PersonId, stream);
                }
                //RegisterFaceToCorrectStudent(imagePath,personGroupId,student);
            }
            //Traing
            await client.TrainPersonGroupAsync(personGroupId);

            TrainingStatus status = null;
            while (true)
            {
                status = await client.GetPersonGroupTrainingStatusAsync(personGroupId);
                if (status.Status != Status.Running)
                {
                    break;
                }
                await Task.Delay(1000);
            }

            string groupImagePath = @"E:\SOA\FaceIdentifyProject\SOA.WebApi\Images\group.jpg";


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
