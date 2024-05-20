using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class fDoctor : Form
    {
        private Doctor doctor;
        public fDoctor()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private async void fDoctor_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"cloudfire.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            Database.Instance.database = FirestoreDb.Create("test-964d0");

            Taikhoan doc = CurrentAccount.Instance.GetData();

            DocumentReference accRes = Database.Instance.database.Collection("Doctor").Document(doc.userName).Collection("Information").Document("Information");
            DocumentSnapshot accSnap = await accRes.GetSnapshotAsync();
            doctor = accSnap.ConvertTo<Doctor>();

            txtName.Text = doctor.displayName;
            txtPos.Text = doctor.position;
            txtSpe.Text = doctor.specialization;
            txtCre.Text = doctor.credential;
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            fChangePassword f = new fChangePassword();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void checkbutton_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            displayAllShedules();
        }
        private async void displayAllShedules()
        {
            System.DateTime a = resetSecond(this.dateTimePicker1.Value);
            System.DateTime b = resetSecond(this.dateTimePicker2.Value);
            Query scheduleCollection = Database.Instance.database.Collection("Doctor").Document(doctor.userName)
                .Collection("Schedule");
            QuerySnapshot tmp = await scheduleCollection.GetSnapshotAsync();
            bool available = false;
            foreach (DocumentSnapshot doc in tmp)
            {
                DocumentReference scheduleRef = doc.GetValue<DocumentReference>("ref");
                DocumentSnapshot scheduleSnap = await scheduleRef.GetSnapshotAsync();
                if (scheduleSnap.Exists)
                {
                    Schedule scheduleData = scheduleSnap.ConvertTo<Schedule>();
                    System.DateTime begin = scheduleData.begin.ToDateTime().ToLocalTime();
                    System.DateTime end = scheduleData.end.ToDateTime().ToLocalTime();
                    if (validTime(a, b, begin, end))
                    {
                        addDoctorToDataGridView(scheduleData);
                        available = true;
                    }
                }
            }
            if (!available)
            {
                MessageBox.Show("Không có lịch trình");
            }

        }
        private bool validTime(DateTime a, DateTime b, DateTime c, DateTime d)
        {
            // a and b are range 
            // c and d are schedule time
            int e = DateTime.Compare(a, c);
            int f = DateTime.Compare(b, d);
            if (e == 1)
            {
                return false;
            }
            if (f == -1)
            {
                return false;
            }
            return true;
        }
        private void addDoctorToDataGridView(Schedule schedule)
        {   
            this.dataGridView1.Rows.Add(schedule.begin.ToDateTime().ToLocalTime(), schedule.end.ToDateTime().ToLocalTime(), schedule.room, schedule.patient);
        }
        private System.DateTime resetSecond(System.DateTime beginTime)
        {
            return beginTime.AddSeconds(-beginTime.Second);
        }

        private async void btnFind_Click(object sender, EventArgs e)
        {
            DocumentReference accRes = Database.Instance.database.Collection("Patient").Document(txtFind.Text).Collection("Information").Document("Information");
            DocumentSnapshot accSnap = await accRes.GetSnapshotAsync();
            if (!accSnap.Exists)
            {
                MessageBox.Show("ID bệnh nhân không đúng");
                return;
            }
            Taikhoan pat = accSnap.ConvertTo<Patient>();

            System.DateTime date = pat.regDate.ToDateTime();
            date = date.AddHours(7);

            txtPatName.Text = pat.displayName;
            txtMedHis.Text = pat.medicalHistory;
            txtTesRes.Text = pat.testingResult;
            txtDia.Text = pat.diagnosis;
            dtpRegDate.Value = date;
            txtPro.Text = pat.progress;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
