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
using System.Xml.Linq;

namespace WindowsFormsApp2
{
    public partial class fPatient : Form
    {
        public FirestoreDb database;
        public fPatient()
        {
            InitializeComponent();
        }

        private async void fPatient_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"cloudfire.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            database = FirestoreDb.Create("test-964d0");

            DocumentReference curRes = database.Collection("CurrentAccount").Document("Acc");
            DocumentSnapshot curSnap = await curRes.GetSnapshotAsync();
            Taikhoan pat = curSnap.ConvertTo<Patient>();

            DocumentReference accRes = database.Collection("Account").Document(pat.type).Collection(pat.userName).Document(pat.userName);
            DocumentSnapshot accSnap = await accRes.GetSnapshotAsync();
            pat = accSnap.ConvertTo<Patient>();

            txtName.Text = pat.displayName;
            txtMedHis.Text = pat.medicalHistory;
            txtTesRes.Text = pat.testingResult;
            txtDia.Text = pat.diagnosis;
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
