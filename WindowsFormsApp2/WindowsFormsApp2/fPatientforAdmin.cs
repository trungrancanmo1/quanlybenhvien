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
using System.Xml.Linq;
using Google.Api.Gax;
using Google.Cloud.Firestore;
using Google.Protobuf;
using Google.Type;

namespace WindowsFormsApp2
{
    public partial class fPatientforAdmin : Form
    {
        public FirestoreDb database;

        public bool flag = false;

        public string userID;
        public fPatientforAdmin()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private async void fPatientforAdmin_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"cloudfire.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            database = FirestoreDb.Create("test-964d0");
        }
        private async void button4_Click(object sender, EventArgs e) // xem
        {

            DataTable dt = new DataTable();

            dt.Columns.Add("SĐT", typeof(string));
            dt.Columns.Add("Tên", typeof(string));
            dt.Columns.Add("Ngày vào viện", typeof(string));
            dt.Columns.Add("Tiền sử bệnh án", typeof(string));
            dt.Columns.Add("Kết quả xét nghiệm", typeof(string));
            dt.Columns.Add("Chuẩn đoán", typeof(string));

            dt.Columns["SĐT"].ReadOnly = true;
            dt.Columns["Tên"].ReadOnly = true;
            dt.Columns["Ngày vào viện"].ReadOnly = true;
            dt.Columns["Tiền sử bệnh án"].ReadOnly = true;
            dt.Columns["Kết quả xét nghiệm"].ReadOnly = true;
            dt.Columns["Chuẩn đoán"].ReadOnly = true;


            CollectionReference patientres = database.Collection("Patient");
            QuerySnapshot patientList = await patientres.GetSnapshotAsync();
            List<string> patientNames = new List<string>();

            foreach (DocumentSnapshot documentSnapshot in patientList.Documents)
            {
                patientNames.Add(documentSnapshot.Id);
            }

            foreach (string name in patientNames)
            {
                DocumentReference patRes = database.Collection("Patient").Document(name).Collection("Information").Document("Information");
                DocumentSnapshot patSnap = await patRes.GetSnapshotAsync();
                Taikhoan patdata = patSnap.ConvertTo<Taikhoan>();
                System.DateTime date = patdata.regDate.ToDateTime();
                date = date.AddHours(7);
                string dateString = date.ToString("dd-MM-yyyy HH:mm:ss");


                DataRow row = dt.NewRow();
                row["SĐT"] += patdata.userName;
                row["Tên"] += patdata.displayName;
                row["Ngày vào viện"] += dateString;
                row["Tiền sử bệnh án"] += patdata.medicalHistory;
                row["Kết quả xét nghiệm"] += patdata.testingResult;
                row["Chuẩn đoán"] += patdata.diagnosis;
                dt.Rows.Add(row);

            }
            dataGridView1.DataSource = dt;
        }

        private async void button3_Click(object sender, EventArgs e) //xóa
        {
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox1.Text = "";

            dateTimePicker1.Value = System.DateTime.Now;
            dateTimePicker1.Enabled = true;
            flag = false;

        }

        private async void button6_Click(object sender, EventArgs e) // tìm
        {
            string id = textBox1.Text;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter patient's phone number");
                return;
            }
            flag = true;
            userID = id;

            DocumentReference patRes = database.Collection("Patient").Document(id).Collection("Information").Document("Information");
            DocumentSnapshot patSnap = await patRes.GetSnapshotAsync();
            Taikhoan data = patSnap.ConvertTo<Taikhoan>();

            if (!patSnap.Exists)
            {
                MessageBox.Show("Sai số điện thoại");
                flag = false;
                return;
            }

            System.DateTime date = data.regDate.ToDateTime();
            date = date.AddHours(7);


            textBox2.Text = data.displayName; // Tên
            textBox4.Text = data.medicalHistory; // Tiền sử bệnh án
            textBox5.Text = data.testingResult; // kết quả xét nghiệm
            textBox6.Text = data.diagnosis; //Chuẩn đoán
            dateTimePicker1.Value = date;

            dateTimePicker1.Enabled = false; // chỉ được xem ngầy

        }

        private async void button2_Click(object sender, EventArgs e) // Sửa
        {
            if (userID != textBox1.Text)
            {
                MessageBox.Show("Cannot be edited");
                return;
            }
            string id = textBox1.Text;
            string name = textBox2.Text;
            string his = textBox4.Text;
            string testResult = textBox5.Text;
            string dia = textBox6.Text;

            DocumentReference patRes = database.Collection("Patient").Document(userID).Collection("Information").Document("Information");
            DocumentSnapshot patSnap = await patRes.GetSnapshotAsync();
            Taikhoan data = patSnap.ConvertTo<Taikhoan>();

            Dictionary<string, object> updates = new Dictionary<string, object>
            {
                { "displayName", name },
                { "medicalHistory", his},
                { "testingResult", testResult },
                { "diagnosis", dia},

            };
            await patRes.UpdateAsync(updates);



            /*      DocumentReference documentReference = database.Collection("Doctor").Document("069").Collection("Schedule").Document("first");
                    DocumentSnapshot snapshot = await documentReference.GetSnapshotAsync();
                    if (snapshot.Exists)
                    {
                        Dictionary<string, DocumentReference> data1 = snapshot.ConvertTo<Dictionary<string, DocumentReference>>();
                        foreach (var item in data1)
                        {
                            DocumentReference tmp = item.Value;

                            Console.WriteLine(tmp.Id);
                            Console.WriteLine(item.Value.GetType());
                        }
                    }
                    else
                    {
                        MessageBox.Show("NOT EXISTED");
                    }*/
        }

        private async void btnView_Click(object sender, EventArgs e)
        {
            System.DateTime prevdate = dtpFromDate.Value;
            System.DateTime futuredate = dtpToDate.Value;

            DataTable dt = new DataTable();

            dt.Columns.Add("Bệnh nhân", typeof(string));
            dt.Columns.Add("Bác sĩ", typeof(string));
            dt.Columns.Add("Ngày vào viện", typeof(string));
            dt.Columns.Add("Ngày xuất viện", typeof(string));
            dt.Columns.Add("Phòng", typeof(string));
            dt.Columns.Add("Ghi chú", typeof(string));

            dt.Columns["Bệnh nhân"].ReadOnly = true;
            dt.Columns["Bác sĩ"].ReadOnly = true;
            dt.Columns["Ngày vào viện"].ReadOnly = true;
            dt.Columns["Ngày xuất viện"].ReadOnly = true;
            dt.Columns["Phòng"].ReadOnly = true;
            dt.Columns["Ghi chú"].ReadOnly = true;

            if (flag)
            {
                DocumentReference patRes = database.Collection("Patient").Document(userID).Collection("Information").Document("Information");
                DocumentSnapshot patSnap = await patRes.GetSnapshotAsync();
                Taikhoan patient = patSnap.ConvertTo<Taikhoan>();

                CollectionReference schePatient = database.Collection("Patient").Document(userID).Collection("Schedule");
                QuerySnapshot scheList = await schePatient.GetSnapshotAsync();
                List<string> patientNames = new List<string>();

                foreach (DocumentSnapshot documentSnapshot in scheList.Documents)
                {
                    patientNames.Add(documentSnapshot.Id);
                }

                foreach (string name in patientNames)
                {
                    DocumentReference schedule = database.Collection("Patient").Document(userID).Collection("Schedule").Document(name);
                    DocumentSnapshot scheSnap = await schedule.GetSnapshotAsync();
                    //MessageBox.Show("name  " + name);
                    string link = "";
                    if (scheSnap.Exists)
                    {
                        // object fieldValue = scheSnap.GetValue<object>("ref");

                        //   link = fieldValue.ToString();

                        Dictionary<string, DocumentReference> data1 = scheSnap.ConvertTo<Dictionary<string, DocumentReference>>();
                        foreach (var item in data1)
                        {
                            DocumentReference tmp = item.Value;
                            link = tmp.Id.ToString();
                        }
                        //   MessageBox.Show(link);

                        DocumentReference patschedule = database.Collection("Schedules").Document(link);
                        DocumentSnapshot patscheSnap = await patschedule.GetSnapshotAsync();
                        Schedule patSche = patscheSnap.ConvertTo<Schedule>();

                        System.DateTime startday = patSche.begin.ToDateTime();
                        System.DateTime endday = patSche.end.ToDateTime();
                        startday = startday.AddHours(7);
                        endday = endday.AddHours(7);
                        string startDayString = startday.ToString("dd-MM-yyyy HH:mm:ss");
                        string endDayString = endday.ToString("dd-MM-yyyy HH:mm:ss");

                        DocumentReference doctor = database.Collection("Doctor").Document(patSche.doctor).Collection("Information").Document("Information");
                        DocumentSnapshot doc = await doctor.GetSnapshotAsync();
                        Taikhoan doct = doc.ConvertTo<Taikhoan>();
                        string doctorName = doct.displayName;

                        if (startday > prevdate && endday < futuredate)
                        {
                            DataRow row = dt.NewRow();
                            row["Bệnh nhân"] += patient.displayName;
                            row["Bác sĩ"] += doctorName;
                            row["Ngày vào viện"] += startDayString;
                            row["Ngày xuất viện"] += endDayString;
                            row["Phòng"] += patSche.room;
                            row["Ghi chú"] += patSche.notes;
                            dt.Rows.Add(row);
                        }
                    }
                }
                dgv.DataSource = dt;
            }
            else
            {
                CollectionReference patientres = database.Collection("Patient");
                QuerySnapshot patientList = await patientres.GetSnapshotAsync();
                List<string> patNames = new List<string>();

                foreach (DocumentSnapshot documentPatSnapshot in patientList.Documents)
                {
                    patNames.Add(documentPatSnapshot.Id);
                }

                foreach (string patName in patNames)
                {
                    DocumentReference patRes = database.Collection("Patient").Document(patName).Collection("Information").Document("Information");
                    DocumentSnapshot patSnap = await patRes.GetSnapshotAsync();
                    Taikhoan patient = patSnap.ConvertTo<Taikhoan>();

                    CollectionReference schePatient = database.Collection("Patient").Document(patName).Collection("Schedule");
                    QuerySnapshot scheList = await schePatient.GetSnapshotAsync();
                    List<string> patientNames = new List<string>();

                    foreach (DocumentSnapshot documentSnapshot in scheList.Documents)
                    {
                        patientNames.Add(documentSnapshot.Id);
                    }

                    foreach (string name in patientNames)
                    {
                        DocumentReference schedule = database.Collection("Patient").Document(patName).Collection("Schedule").Document(name);
                        DocumentSnapshot scheSnap = await schedule.GetSnapshotAsync();
                        //MessageBox.Show("name  " + name);
                        string link = "";
                        if (scheSnap.Exists)
                        {
                            // object fieldValue = scheSnap.GetValue<object>("ref");

                            //   link = fieldValue.ToString();

                            Dictionary<string, DocumentReference> data1 = scheSnap.ConvertTo<Dictionary<string, DocumentReference>>();
                            foreach (var item in data1)
                            {
                                DocumentReference tmp = item.Value;
                                link = tmp.Id.ToString();
                            }
                            //   MessageBox.Show(link);

                            DocumentReference patschedule = database.Collection("Schedules").Document(link);
                            DocumentSnapshot patscheSnap = await patschedule.GetSnapshotAsync();
                            Schedule patSche = patscheSnap.ConvertTo<Schedule>();

                            System.DateTime startday = patSche.begin.ToDateTime();
                            System.DateTime endday = patSche.end.ToDateTime();
                            startday = startday.AddHours(7);
                            endday = endday.AddHours(7);
                            string startDayString = startday.ToString("dd-MM-yyyy HH:mm:ss");
                            string endDayString = endday.ToString("dd-MM-yyyy HH:mm:ss");

                            DocumentReference doctor = database.Collection("Doctor").Document(patSche.doctor).Collection("Information").Document("Information");
                            DocumentSnapshot doc = await doctor.GetSnapshotAsync();
                            Taikhoan doct = doc.ConvertTo<Taikhoan>();
                            string doctorName = doct.displayName;

                            if (startday > prevdate && endday < futuredate)
                            {
                                DataRow row = dt.NewRow();
                                row["Bệnh nhân"] += patient.displayName;
                                row["Bác sĩ"] += doctorName;
                                row["Ngày vào viện"] += startDayString;
                                row["Ngày xuất viện"] += endDayString;
                                row["Phòng"] += patSche.room;
                                row["Ghi chú"] += patSche.notes;
                                dt.Rows.Add(row);
                            }
                        }
                    }
                }
                dgv.DataSource = dt;
            }
        }
    }
}
