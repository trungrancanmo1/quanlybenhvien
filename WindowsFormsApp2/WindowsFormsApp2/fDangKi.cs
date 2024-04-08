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

            if (txtDocAcc.Text.Length != 10 || txtDocAcc.Text[0] != '0')
            {
                MessageBox.Show("Sai định dạng số điện thoại");
                return;
            }

            DocumentReference docRes = database.Collection("Account").Document("Doctor").Collection(txtDocAcc.Text).Document(txtDocAcc.Text);
            DocumentSnapshot docSnap = await docRes.GetSnapshotAsync();

            DocumentReference patRes = database.Collection("Account").Document("Patient").Collection(txtDocAcc.Text).Document(txtDocAcc.Text);
            DocumentSnapshot patSnap = await patRes.GetSnapshotAsync();

            if (docSnap.Exists || patSnap.Exists)
            {
                MessageBox.Show("Tài khoản đã tồn tại");
                return;
            }

            var data = new Doctor
            {
                userName = txtDocAcc.Text,
                password = txtDocAcc.Text,
                displayName = txtDocName.Text,
                type = "Doctor",
                position = txtPos.Text,
                specialization = txtSpe.Text,
            };

            var count = new Counter
            {
                cnt = totalCnt.cnt + 1,
            };

            var doc = new Counter
            {
                cnt = cnt.cnt + 1,
            };

            var list = new AccountList
            {
                userName = data.userName,
                type = data.type,
            };            

            DocumentReference docSet = database.Collection("Account").Document("Doctor").Collection(data.userName).Document(data.userName);
            docSet.SetAsync(data);

            DocumentReference totalCntSet = database.Collection("Counter").Document("Total");
            totalCntSet.SetAsync(count);

            DocumentReference docCntSet = database.Collection("Counter").Document("Doctor");
            docCntSet.SetAsync(doc);
           
            DocumentReference listSet = database.Collection("AccountList").Document("Doctor").Collection((cnt.cnt).ToString()).Document((cnt.cnt).ToString());
            listSet.SetAsync(list);

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

            if (txtPatAcc.Text.Length != 10 || txtPatAcc.Text[0] != '0')
            {
                MessageBox.Show("Sai định dạng số điện thoại");
                return;
            }

            DocumentReference docRes = database.Collection("Account").Document("Doctor").Collection(txtPatAcc.Text).Document(txtPatAcc.Text);
            DocumentSnapshot docSnap = await docRes.GetSnapshotAsync();

            DocumentReference patRes = database.Collection("Account").Document("Patient").Collection(txtPatAcc.Text).Document(txtPatAcc.Text);
            DocumentSnapshot patSnap = await patRes.GetSnapshotAsync();

            if (docSnap.Exists || patSnap.Exists)
            {
                MessageBox.Show("Tài khoản đã tồn tại");
                return;
            }

            var data = new Patient
            {
                userName = txtPatAcc.Text,
                password = txtPatAcc.Text,
                displayName = txtPatName.Text,
                type = "Patient",
                medicalHistory = txtMedHis.Text,
                testingResult = txtTesRes.Text,
                diagnosis = txtDia.Text,
            };

            var count = new Counter
            {
                cnt = totalCnt.cnt + 1,
            };

            var doc = new Counter
            {
                cnt = cnt.cnt + 1,
            };

            var list = new AccountList
            {
                userName = data.userName,
                type = data.type,
            };

            var date = new ThoiGian
            {
                timestamp = Google.Cloud.Firestore.Timestamp.FromDateTime(DateTime.UtcNow),
            };

            DocumentReference patTimeSet = database.Collection("Account").Document("Patient").Collection(data.userName).Document("DateTime");
            patTimeSet.SetAsync(date);

            DocumentReference patSet = database.Collection("Account").Document("Patient").Collection(data.userName).Document(data.userName);
            patSet.SetAsync(data);

            DocumentReference totalCntSet = database.Collection("Counter").Document("Total");
            totalCntSet.SetAsync(count);

            DocumentReference patCntSet = database.Collection("Counter").Document("Patient");
            patCntSet.SetAsync(doc);

            DocumentReference listSet = database.Collection("AccountList").Document("Patient").Collection((cnt.cnt).ToString()).Document((cnt.cnt).ToString());
            listSet.SetAsync(list);

            MessageBox.Show("Đăng kí thành công");
        }
    }
}
