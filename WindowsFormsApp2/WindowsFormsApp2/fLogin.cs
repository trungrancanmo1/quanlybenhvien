using FireSharp.Response;
using Google.Apis.Util;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Rpc.Context.AttributeContext.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp2
{
    public partial class fLogin : Form
    {
        public FirestoreDb database;
        public fLogin()
        {
            InitializeComponent();
        }
        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void quenmatkhau_Click(object sender, EventArgs e)
        {
            fForgotPass f = new fForgotPass();
            this.Hide();
            f.ShowDialog();
            this.Show();

        }
        private async void dangnhap_Click(object sender, EventArgs e)
        {
            string userName = textAcc.Text;
            if (userName == "")
            {
                MessageBox.Show("Tài khoản không tồn tại");
                return;
            }
            DocumentReference adRes = database.Collection("Account").Document("Admin").Collection(userName).Document(userName);
            DocumentSnapshot adSnap = await adRes.GetSnapshotAsync();

            DocumentReference docRes = database.Collection("Account").Document("Doctor").Collection(userName).Document(userName);
            DocumentSnapshot docSnap = await docRes.GetSnapshotAsync();

            DocumentReference patRes = database.Collection("Account").Document("Patient").Collection(userName).Document(userName);
            DocumentSnapshot patSnap = await patRes.GetSnapshotAsync();

            if(!adSnap.Exists && !docSnap.Exists && !patSnap.Exists)
            {
                MessageBox.Show("Tài khoản không tồn tại");
                return;
            }

            Taikhoan acc = null;
            if (adSnap.Exists)
            {
                acc = adSnap.ConvertTo<Admin>();     
            }
            else if (docSnap.Exists)
            {
                acc = docSnap.ConvertTo<Doctor>();
            }
            else if (patSnap.Exists)
            {
                acc = patSnap.ConvertTo<Patient>();
            }

            if (acc.password == textPass.Text)
            {
                DocumentReference adSet = database.Collection("CurrentAccount").Document("Acc");
                var cur = new Taikhoan
                {
                    userName = acc.userName,
                    password = acc.password,
                    displayName = acc.displayName,
                    type = acc.type,
                };
                adSet.SetAsync(cur);
                if (acc.type == "Admin")
                {
                    fInterface f = new fInterface();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else if (acc.type == "Doctor")
                {
                    fDoctor f = new fDoctor();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else if (acc.type == "Patient")
                {
                    fPatient f = new fPatient();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("Sai mật khẩu");
                return;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"cloudfire.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            database = FirestoreDb.Create("test-964d0");
        }
        
    }
}
