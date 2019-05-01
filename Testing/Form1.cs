using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testing
{
    public partial class Form1 : Form
    {
        FaceServiceClient client = new FaceServiceClient("e2a92091771a473b88b2c8599836f7c7");
        public Form1()
        {
            InitializeComponent();
        }
        void OpenFile()
        {
            OpenFileDialog openFile = new OpenFileDialog
            {
                InitialDirectory = @"E:\SOA",
                Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" + "All files (*.*)|*.*"
            };

            if (openFile.ShowDialog(this) == DialogResult.OK)
            {
                ptbxSource.Image = new Bitmap(openFile.FileName);
                ptbxSource.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        async void DefineStudentInStudentList()
        {
            ////Tạo list sinh viên và thêm phần tử vào list
            List<Student> listStudent = new List<Student>();
            //string rootPath = Directory.GetCurrentDirectory();
            //string parentDirectory = Directory.GetParent(rootPath).Parent.FullName + "\\Image";
            for (int i = 1; i < 4; i++)
            {
                Student student = new Student
                {
                    //string imageFile = Path.Combine()
                    Id = string.Format("SV{0}", i),
                    Name = string.Format("Sinh viên {0}", i),
                    //Image = new Bitmap()
                };
                listStudent.Add(student);
            }
            //Tạo personGroup
            string personGroupId = "G001";
            //await client.CreatePersonGroupAsync(personGroupId, "BI001");


            foreach (Student item in listStudent)
            {
                CreatePersonResult student = await client.CreatePersonAsync(personGroupId, item.Name);

            }
            //Traing
            TrainingModel(personGroupId);
        }
        async void TrainingModel(string personGroupId)
        {
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
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            //DefineStudentInStudentList();
            string rootPath = Directory.GetCurrentDirectory();
            string parentDirectory = Directory.GetParent(rootPath).Parent.FullName + "\\Image\\1.JPG";
            byte[] byteData = GetImageAsByteArray(parentDirectory);
            rtxbString.Text = byteData.ToString();
        }
        static byte[] GetImageAsByteArray(string imageFilePath)
        {
            using (FileStream fileStream =
                new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
            {
                BinaryReader binaryReader = new BinaryReader(fileStream);
                return binaryReader.ReadBytes((int)fileStream.Length);
            }
        }
    }
}
