using FireSharp.Config;
using FireSharp.Extensions;
using FireSharp.Interfaces;
using FireSharp.Response;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class fDangKi : Form
    {
        public FirestoreDb database;
        public fDangKi()
        {
            InitializeComponent();
        }

        private void fDangKi_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"cloudfire.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            database = FirestoreDb.Create("test-964d0");
        }

        private async void btnDoctorRegister_Click(object sender, EventArgs e)
        {
            
            DocumentReference totalRes = database.Collection("Counter").Document("Total");
            DocumentSnapshot totalSnap = await totalRes.GetSnapshotAsync();
            Counter totalCnt = totalSnap.ConvertTo<Counter>();

            DocumentReference res = database.Collection("Counter").Document("Doctor");
            DocumentSnapshot cntSnap = await res.GetSnapshotAsync();
            Counter cnt = cntSnap.ConvertTo<Counter>();

            //if (txtDocAcc.Text.Length != 10 || txtDocAcc.Text[0] != '0')
            //{
            //    MessageBox.Show("Sai định dạng số điện thoại");
            //    return;
            //}

            DocumentReference docRes = database.Collection("Doctor").Document(txtDocAcc.Text).Collection("Information").Document("Information");
            DocumentSnapshot docSnap = await docRes.GetSnapshotAsync();

            DocumentReference patRes = database.Collection("Patient").Document(txtDocAcc.Text).Collection("Information").Document("Information");
            DocumentSnapshot patSnap = await patRes.GetSnapshotAsync();

            if (docSnap.Exists || patSnap.Exists)
            {
                MessageBox.Show("Tài khoản đã tồn tại");
                return;
            }

            var rong = new Empty
            {
                rong = "null",
            };

            var data = new Doctor
            {
                userName = txtDocAcc.Text,
                password = txtDocAcc.Text,
                displayName = txtDocName.Text,
                type = "Doctor",
                position = txtPos.Text,
                specialization = cbSpe.SelectedItem.ToString(),
                credential = txtCre.Text,
            };

            var count = new Counter
            {
                cnt = totalCnt.cnt + 1,
            };

            var doc = new Counter
            {
                cnt = cnt.cnt + 1,
            };

            DocumentReference emptySet = database.Collection("Doctor").Document(data.userName);
            emptySet.SetAsync(rong);

            DocumentReference docSet = database.Collection("Doctor").Document(data.userName).Collection("Information").Document("Information");
            docSet.SetAsync(data);

            DocumentReference totalCntSet = database.Collection("Counter").Document("Total");
            totalCntSet.SetAsync(count);

            DocumentReference docCntSet = database.Collection("Counter").Document("Doctor");
            docCntSet.SetAsync(doc);
           

            MessageBox.Show("Đăng kí thành công");
        }

        private async void btnPatRes_Click(object sender, EventArgs e)
        {
            DocumentReference totalRes = database.Collection("Counter").Document("Total");
            DocumentSnapshot totalSnap = await totalRes.GetSnapshotAsync();
            Counter totalCnt = totalSnap.ConvertTo<Counter>();

            DocumentReference res = database.Collection("Counter").Document("Patient");
            DocumentSnapshot cntSnap = await res.GetSnapshotAsync();
            Counter cnt = cntSnap.ConvertTo<Counter>();

            //if (txtPatAcc.Text.Length != 10 || txtPatAcc.Text[0] != '0')
            //{
            //    MessageBox.Show("Sai định dạng số điện thoại");
            //    return;
            //}

            DocumentReference docRes = database.Collection("Doctor").Document(txtPatAcc.Text).Collection("Information").Document("Information");
            DocumentSnapshot docSnap = await docRes.GetSnapshotAsync();

            DocumentReference patRes = database.Collection("Patient").Document(txtPatAcc.Text).Collection("Information").Document("Information");
            DocumentSnapshot patSnap = await patRes.GetSnapshotAsync();

            if (docSnap.Exists || patSnap.Exists)
            {
                MessageBox.Show("Tài khoản đã tồn tại");
                return;
            }

            var rong = new Empty
            {
                rong = "null",
            };

            var data = new Patient
            {
                userName = txtPatAcc.Text,
                password = txtPatAcc.Text,
                displayName = txtPatName.Text,
                type = "Patient",
                medicalHistory = txtMedHis.Text,
                testingResult = txtTesRes.Text,
                diagnosis = txtDia.Text,
                regDate = Google.Cloud.Firestore.Timestamp.FromDateTime(DateTime.UtcNow),
                progress = "chưa có tiến triển",
            };

            var count = new Counter
            {
                cnt = totalCnt.cnt + 1,
            };

            var doc = new Counter
            {
                cnt = cnt.cnt + 1,
            };

            DocumentReference emptySet = database.Collection("Patient").Document(data.userName);
            emptySet.SetAsync(rong);

            DocumentReference patSet = database.Collection("Patient").Document(data.userName).Collection("Information").Document("Information");
            patSet.SetAsync(data);

            DocumentReference totalCntSet = database.Collection("Counter").Document("Total");
            totalCntSet.SetAsync(count);

            DocumentReference patCntSet = database.Collection("Counter").Document("Patient");
            patCntSet.SetAsync(doc);

            MessageBox.Show("Đăng kí thành công");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cbSpe.SelectedItem.ToString());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Google.Cloud.Firestore.Timestamp regDate = Google.Cloud.Firestore.Timestamp.FromDateTime(DateTime.UtcNow);
            System.DateTime date = regDate.ToDateTime();
            MessageBox.Show(date.ToString());
            date = date.AddHours(7);
        }

        private void txtDocAcc_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
