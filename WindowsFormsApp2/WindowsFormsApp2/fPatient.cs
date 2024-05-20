using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Google.Cloud.Firestore;
using Google.Protobuf.WellKnownTypes;
using Google.Type;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp2
{
    public partial class fPatient : Form
    {
        
        private Taikhoan pat = null;
        public fPatient()
        {
            InitializeComponent();
        }

        private async void fPatient_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"cloudfire.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            Database.Instance.database = FirestoreDb.Create("test-964d0");

            pat = CurrentAccount.Instance.GetData();

            DocumentReference accRes = Database.Instance.database.Collection("Patient").Document(pat.userName).Collection("Information").Document("Information");
            DocumentSnapshot accSnap = await accRes.GetSnapshotAsync();
            pat = accSnap.ConvertTo<Patient>();

            System.DateTime date = pat.regDate.ToDateTime();
            date = date.AddHours(7);

            txtName.Text = pat.displayName;
            txtMedHis.Text = pat.medicalHistory;
            txtTesRes.Text = pat.testingResult;
            txtDia.Text = pat.diagnosis;
            dtpRegDate.Value = date;
            txtPro.Text = pat.progress;
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            fChangePassword f = new fChangePassword();
            this.Hide();
            f.ShowDialog();
            this.Show();
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

            DocumentReference patRes = Database.Instance.database.Collection("Patient").Document(pat.userName).Collection("Information").Document("Information");
            DocumentSnapshot patSnap = await patRes.GetSnapshotAsync();
            Taikhoan patient = patSnap.ConvertTo<Taikhoan>();

            CollectionReference schePatient = Database.Instance.database.Collection("Patient").Document(pat.userName).Collection("Schedule");
            QuerySnapshot scheList = await schePatient.GetSnapshotAsync();
            List<string> patientNames = new List<string>();

            foreach (DocumentSnapshot documentSnapshot in scheList.Documents)
            {
                patientNames.Add(documentSnapshot.Id);
            }

            foreach (string name in patientNames)
            {
                DocumentReference schedule = Database.Instance.database.Collection("Patient").Document(pat.userName).Collection("Schedule").Document(name);
                DocumentSnapshot scheSnap = await schedule.GetSnapshotAsync();
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

                    DocumentReference patschedule = Database.Instance.database.Collection("Schedules").Document(link);
                    DocumentSnapshot patscheSnap = await patschedule.GetSnapshotAsync();
                    if (patscheSnap.Exists)
                    {
                        Schedule patSche = patscheSnap.ConvertTo<Schedule>();

                        System.DateTime startday = patSche.begin.ToDateTime();
                        System.DateTime endday = patSche.end.ToDateTime();
                        startday = startday.AddHours(7);
                        endday = endday.AddHours(7);
                        string startDayString = startday.ToString("dd-MM-yyyy HH:mm:ss");
                        string endDayString = endday.ToString("dd-MM-yyyy HH:mm:ss");

                        DocumentReference doctor = Database.Instance.database.Collection("Doctor").Document(patSche.doctor).Collection("Information").Document("Information");
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
