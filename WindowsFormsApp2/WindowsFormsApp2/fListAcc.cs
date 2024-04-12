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
                if (j == 0)
                {
                    Query list = database.Collection("Admin");
                    QuerySnapshot listSnap = await list.GetSnapshotAsync();
                    foreach (DocumentSnapshot document in listSnap.Documents)
                    {
                        string reference = document.Id;                        
                        DocumentReference res = database.Collection("Admin").Document(reference).Collection("Information").Document("Information");
                        DocumentSnapshot resSnap = await res.GetSnapshotAsync();
                        Taikhoan data = resSnap.ConvertTo<Taikhoan>();
                        DataRow row = dt.NewRow();
                        row["displayName"] += data.displayName;
                        row["userName"] += data.userName;
                        row["password"] += data.password;
                        row["type"] += data.type;
                        dt.Rows.Add(row);
                    }
                }
                else if(j == 1)
                {
                    /*DocumentReference res1 = database.Collection("Doctor").Document("0123456789").Collection("Information").Document("Information");
                    DocumentSnapshot listSnap1 = await res1.GetSnapshotAsync();
                    Taikhoan f = listSnap1.ConvertTo<Taikhoan>();
                    MessageBox.Show(f.userName);*/
                    Query list = database.Collection("Doctor");
                    QuerySnapshot listSnap = await list.GetSnapshotAsync();
                    foreach (DocumentSnapshot document in listSnap.Documents)
                    {
                        string reference = document.Id;
                        DocumentReference res = database.Collection("Doctor").Document(reference).Collection("Information").Document("Information");
                        DocumentSnapshot resSnap = await res.GetSnapshotAsync();
                        Taikhoan data = resSnap.ConvertTo<Taikhoan>();
                        DataRow row = dt.NewRow();
                        row["displayName"] += data.displayName;
                        row["userName"] += data.userName;
                        row["password"] += data.password;
                        row["type"] += data.type;
                        dt.Rows.Add(row);
                    }
                }
                else
                {
                    Query list = database.Collection("Patient");
                    QuerySnapshot listSnap = await list.GetSnapshotAsync();
                    foreach (DocumentSnapshot document in listSnap.Documents)
                    {
                        string reference = document.Id;
                        DocumentReference res = database.Collection("Patient").Document(reference).Collection("Information").Document("Information");
                        DocumentSnapshot resSnap = await res.GetSnapshotAsync();
                        Taikhoan data = resSnap.ConvertTo<Taikhoan>();
                        DataRow row = dt.NewRow();
                        row["displayName"] += data.displayName;
                        row["userName"] += data.userName;
                        row["password"] += data.password;
                        row["type"] += data.type;
                        dt.Rows.Add(row);
                    }
                }
                
            }
            dgvAccList.DataSource = dt;
        }
    }
}
