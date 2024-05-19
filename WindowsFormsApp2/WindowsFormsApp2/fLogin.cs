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
        
        public fLogin()
        {
            InitializeComponent();
        }
        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void quenmatkhau_Click(object sender, EventArgs e)
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
            DocumentReference adRes = Database.Instance.database.Collection("Admin").Document(userName).Collection("Information").Document("Information");
            DocumentSnapshot adSnap = await adRes.GetSnapshotAsync();

            DocumentReference docRes = Database.Instance.database.Collection("Doctor").Document(userName).Collection("Information").Document("Information");
            DocumentSnapshot docSnap = await docRes.GetSnapshotAsync();

            DocumentReference patRes = Database.Instance.database.Collection("Patient").Document(userName).Collection("Information").Document("Information");
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
                var cur = new Taikhoan
                {
                    userName = acc.userName,
                    password = acc.password,
                    displayName = acc.displayName,
                    type = acc.type,
                };
                CurrentAccount.Instance.SetData(cur); 

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

        /*private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }*/

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"cloudfire.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            Database.Instance.database = FirestoreDb.Create("test-964d0");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            testing();
        }
        private async void testing()
        {
            DocumentReference documentReference = Database.Instance.database.Collection("Doctor").Document("069")
               .Collection("Schedule").Document("first");
            DocumentSnapshot snapshot = await documentReference.GetSnapshotAsync();
            if (snapshot.Exists)
            {
                Dictionary<string, DocumentReference> data = snapshot.ConvertTo<Dictionary<string, DocumentReference>>();
                foreach (var item in data)
                {
                    DocumentReference tmp = item.Value;
                    DocumentSnapshot snap = await tmp.GetSnapshotAsync();
                    Schedule schedule = snap.ConvertTo<Schedule>();
                    System.DateTime dateTime = schedule.begin.ToDateTime();
                    System.DateTime endTime = schedule.end.ToDateTime();
                    Console.WriteLine(dateTime);
                    Console.WriteLine(endTime);
                }
            }
            else
            {
                MessageBox.Show("NOT EXISTED");
            }
            //DocumentReference documentReference = Database.Instance.database.Document("Schedules/first");
            //Console.WriteLine(documentReference.Id);
        }
    }
}
