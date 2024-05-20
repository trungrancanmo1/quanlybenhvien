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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp2
{
    public partial class fForgotPass : Form
    {
        public fForgotPass()
        {
            InitializeComponent();
        }

        private async void quenmatkhau_Click(object sender, EventArgs e)
        {
            string userName = textAcc.Text;
            if (userName == "")
            {
                MessageBox.Show("Hãy nhập tên tài khoản");
                return;
            }
            DocumentReference adRes = Database.Instance.database.Collection("Admin").Document(userName).Collection("Information").Document("Information");
            DocumentSnapshot adSnap = await adRes.GetSnapshotAsync();

            DocumentReference docRes = Database.Instance.database.Collection("Doctor").Document(userName).Collection("Information").Document("Information");
            DocumentSnapshot docSnap = await docRes.GetSnapshotAsync();

            DocumentReference patRes = Database.Instance.database.Collection("Patient").Document(userName).Collection("Information").Document("Information");
            DocumentSnapshot patSnap = await patRes.GetSnapshotAsync();

            if (!adSnap.Exists && !docSnap.Exists && !patSnap.Exists)
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

            if (acc.displayName != textDisName.Text)
            {
                MessageBox.Show("Tên hiển thị sai");
                return;
            }

             MessageBox.Show("Mật khẩu của bạn là: " + acc.password.ToString());
        }
        private void thoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void quenmatkhau_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"cloudfire.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            Database.Instance.database = FirestoreDb.Create("test-964d0");
        }
  
    }
}
