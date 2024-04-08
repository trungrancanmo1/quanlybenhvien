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

namespace WindowsFormsApp2
{
    public partial class fChangePassword : Form
    {
        public FirestoreDb database;
        public fChangePassword()
        {
            InitializeComponent();
        }

        private async void changepass_Click(object sender, EventArgs e)
        {
            if (txtNewPass.Text != txtReNewPass.Text)
            {
                MessageBox.Show("Mật khẩu không khớp");
                return;
            }
            DocumentReference curRes = database.Collection("CurrentAccount").Document("Acc");
            DocumentSnapshot curSnap = await curRes.GetSnapshotAsync();
            Taikhoan acc = curSnap.ConvertTo<Taikhoan>();

            DocumentReference accRes = database.Collection("Account").Document(acc.type).Collection(acc.userName).Document(acc.userName);
            DocumentSnapshot accSnap = await accRes.GetSnapshotAsync();

            if (txtOldPass.Text != acc.password)
            {
                MessageBox.Show("Mật khẩu cũ không đúng");
                return;
            }
            if (acc.type == "Admin")
            {
                acc = accSnap.ConvertTo<Admin>();
                var data = new Admin
                {
                    userName = acc.userName,
                    password = txtNewPass.Text,
                    displayName = acc.displayName,
                    type = acc.type,
                };
                DocumentReference passSet = database.Collection("Account").Document("Admin").Collection(acc.userName).Document(acc.userName);
                passSet.SetAsync(data);
            }
            else if (acc.type == "Doctor")
            {
                acc = accSnap.ConvertTo<Doctor>();
                var data = new Doctor
                {
                    userName = acc.userName,
                    password = txtNewPass.Text,
                    displayName = acc.displayName,
                    type = acc.type,
                    position = acc.position,
                    specialization = acc.specialization,
                };
                DocumentReference passSet = database.Collection("Account").Document("Doctor").Collection(acc.userName).Document(acc.userName);
                passSet.SetAsync(data);
            }
            else
            {
                acc = accSnap.ConvertTo<Patient>();
                var data = new Patient
                {
                    userName = acc.userName,
                    password = txtNewPass.Text,
                    displayName = acc.displayName,
                    type = acc.type,
                    medicalHistory = acc.medicalHistory,
                    testingResult = acc.testingResult,
                    diagnosis = acc.diagnosis,
                };
                DocumentReference passSet = database.Collection("Account").Document("Patient").Collection(acc.userName).Document(acc.userName);
                passSet.SetAsync(data);
            }

            MessageBox.Show("Đổi mật khẩu thành công");
            this.Close();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fChangePassword_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"cloudfire.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            database = FirestoreDb.Create("test-964d0");
        }
    }
}