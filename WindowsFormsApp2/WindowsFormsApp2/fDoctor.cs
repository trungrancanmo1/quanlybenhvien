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
        public FirestoreDb database;
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

            database = FirestoreDb.Create("test-964d0");

            DocumentReference curRes = database.Collection("CurrentAccount").Document("Acc");
            DocumentSnapshot curSnap = await curRes.GetSnapshotAsync();
            Taikhoan doc = curSnap.ConvertTo<Doctor>();

            DocumentReference accRes = database.Collection("Account").Document(doc.type).Collection(doc.userName).Document(doc.userName);
            DocumentSnapshot accSnap = await accRes.GetSnapshotAsync();
            doc = accSnap.ConvertTo<Doctor>();

            txtName.Text = doc.displayName;
            txtPos.Text = doc.position;
            txtSpe.Text = doc.specialization;
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            fChangePassword f = new fChangePassword();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
