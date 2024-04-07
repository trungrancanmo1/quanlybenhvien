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
    public partial class fListAcc : Form
    {
        public FirestoreDb database;
        public fListAcc()
        {
            InitializeComponent();
        }

        private async void fListAcc_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"cloudfire.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            database = FirestoreDb.Create("test-964d0");
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("displayName", typeof(string));
            dt.Columns.Add("userName", typeof(string));
            dt.Columns.Add("password", typeof(string));
            dt.Columns.Add("type", typeof(string));

            dt.Columns["displayName"].ReadOnly = true;
            dt.Columns["userName"].ReadOnly = true;
            dt.Columns["password"].ReadOnly = true;
            dt.Columns["type"].ReadOnly = true;

            for (int j = 0; j < 3; j++)
            {
                Counter cnt = null;
                string path;
                if (j == 0)
                {
                    DocumentReference res = database.Collection("Counter").Document("Admin");
                    DocumentSnapshot cntSnap = await res.GetSnapshotAsync();
                    cnt = cntSnap.ConvertTo<Counter>();
                    path = "Admin";
                }
                else if(j == 1)
                {
                    DocumentReference res = database.Collection("Counter").Document("Doctor");
                    DocumentSnapshot cntSnap = await res.GetSnapshotAsync();
                    cnt = cntSnap.ConvertTo<Counter>();
                    path = "Doctor";
                }
                else
                {
                    DocumentReference res = database.Collection("Counter").Document("Patient");
                    DocumentSnapshot cntSnap = await res.GetSnapshotAsync();
                    cnt = cntSnap.ConvertTo<Counter>();
                    path = "Patient";
                }
                for (int i = 0; i < cnt.cnt; i++)
                {
                    DocumentReference adRes = database.Collection("AccountList").Document(path).Collection(i.ToString()).Document(i.ToString());
                    DocumentSnapshot adSnap = await adRes.GetSnapshotAsync();
                    AccountList list = adSnap.ConvertTo<AccountList>();

                    DocumentReference adGet = database.Collection("Account").Document(path).Collection(list.userName).Document(list.userName);
                    DocumentSnapshot adminSnap = await adGet.GetSnapshotAsync();
                    Taikhoan data = adminSnap.ConvertTo<Taikhoan>();

                    DataRow row = dt.NewRow();
                    row["displayName"] += data.displayName;
                    row["userName"] += data.userName;
                    row["password"] += data.password;
                    row["type"] += data.type;
                    dt.Rows.Add(row); 
                }
            }
            dgvAccList.DataSource = dt;
        }
    }
}
