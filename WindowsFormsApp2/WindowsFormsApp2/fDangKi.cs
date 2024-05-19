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
        
        public fDangKi()
        {
            InitializeComponent();
        }

        private void fDangKi_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"cloudfire.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            Database.Instance.database = FirestoreDb.Create("test-964d0");
        }

        private async void btnDoctorRegister_Click(object sender, EventArgs e)
        {
            if (txtDocAcc.Text == "") return;
            if (txtDocAcc.Text.Length != 10 || txtDocAcc.Text[0] != '0')
            {
                MessageBox.Show("Sai định dạng số điện thoại");
                return;
            }

            DocumentReference docRes = Database.Instance.database.Collection("Doctor").Document(txtDocAcc.Text).Collection("Information").Document("Information");
            DocumentSnapshot docSnap = await docRes.GetSnapshotAsync();

            DocumentReference patRes = Database.Instance.database.Collection("Patient").Document(txtDocAcc.Text).Collection("Information").Document("Information");
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


            DocumentReference emptySet = Database.Instance.database.Collection("Doctor").Document(data.userName);
            await emptySet.SetAsync(rong);

            DocumentReference docSet = Database.Instance.database.Collection("Doctor").Document(data.userName).Collection("Information").Document("Information");
            await docSet.SetAsync(data);

            MessageBox.Show("Đăng kí thành công");
        }

        private async void btnPatRes_Click(object sender, EventArgs e)
        {
            if (txtPatAcc.Text == "") return;
            if (txtPatAcc.Text.Length != 10 || txtPatAcc.Text[0] != '0')
            {
                MessageBox.Show("Sai định dạng số điện thoại");
                return;
            }

            DocumentReference docRes = Database.Instance.database.Collection("Doctor").Document(txtPatAcc.Text).Collection("Information").Document("Information");
            DocumentSnapshot docSnap = await docRes.GetSnapshotAsync();

            DocumentReference patRes = Database.Instance.database.Collection("Patient").Document(txtPatAcc.Text).Collection("Information").Document("Information");
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


            DocumentReference emptySet = Database.Instance.database.Collection("Patient").Document(data.userName);
            await emptySet.SetAsync(rong);

            DocumentReference patSet = Database.Instance.database.Collection("Patient").Document(data.userName).Collection("Information").Document("Information");
            await patSet.SetAsync(data);

            MessageBox.Show("Đăng kí thành công");
        }

        private void txtDocAcc_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnAdminRes_Click(object sender, EventArgs e)
        {
            if (txtAdminAcc.Text == "")
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin !");
                return;
            }
            if (!char.IsLetter(txtAdminAcc.Text[0]))
            {
                MessageBox.Show("Tài khoản Admin bắt đầu bằng chữ cái");
                return;
            }
            DocumentReference adRes = Database.Instance.database.Collection("Admin").Document(txtAdminAcc.Text).Collection("Information").Document("Information");
            DocumentSnapshot adSnap = await adRes.GetSnapshotAsync();

            if (adSnap.Exists)
            {
                MessageBox.Show("Tài khoản đã tồn tại");
                return;
            }

            var rong = new Empty
            {
                rong = "null",
            };

            var data = new Admin
            {
                userName = txtAdminAcc.Text,
                password = txtAdminPass.Text,
                displayName = "Administrator",
                type = "Admin",
            };


            DocumentReference emptySet = Database.Instance.database.Collection("Admin").Document(data.userName);
            await emptySet.SetAsync(rong);

            DocumentReference adminSet = Database.Instance.database.Collection("Admin").Document(data.userName).Collection("Information").Document("Information");
            await adminSet.SetAsync(data);

            MessageBox.Show("Đăng kí thành công");
        }
    }
}
