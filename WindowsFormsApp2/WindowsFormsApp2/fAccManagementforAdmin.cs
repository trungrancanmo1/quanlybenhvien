﻿using FireSharp.Config;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp2
{
    public partial class fAccManagementforAdmin : Form
    {
        public FirestoreDb database;
        public fAccManagementforAdmin()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void danhsachtaikhoanquantri_Click(object sender, EventArgs e)
        {
            fListAcc f=new fListAcc();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        private void changepassword_Click(object sender, EventArgs e)
        {
            fChangePassword f = new fChangePassword();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private async void fAccManagementforAdmin_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"cloudfire.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            database = FirestoreDb.Create("test-964d0");

            DocumentReference curRes = database.Collection("CurrentAccount").Document("Acc");
            DocumentSnapshot curSnap = await curRes.GetSnapshotAsync();

            Taikhoan admin = curSnap.ConvertTo<Admin>();

            textName.Text = admin.displayName;
            textAcc.Text = admin.userName;
        }
    }
}