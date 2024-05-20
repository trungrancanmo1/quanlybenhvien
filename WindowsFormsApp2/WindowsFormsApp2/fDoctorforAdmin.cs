using Google.Cloud.Firestore;
using Google.Protobuf.WellKnownTypes;
using Google.Type;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp2
{
    public partial class fDoctorforAdmin : Form
    {
        private bool exist = false;
        public fDoctorforAdmin()
        {
            InitializeComponent();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }
        // Seatch button
        private void findbuttuon_Click(object sender, EventArgs e)
        {
            string tel = this.textBox1.Text;
            search(tel);
        }
        private void getDoctorSchedule()
        {

        }
        private async void search(string tel)
        {
            DocumentReference documentReference = Database.Instance.database.Collection("Doctor").Document(tel)
                .Collection("Information").Document("Information");
            DocumentSnapshot snapshot = await documentReference.GetSnapshotAsync();
            
            if (snapshot.Exists)
            {
                Doctor doctor = snapshot.ConvertTo<Doctor>();
                showDoctorInfomation(doctor);
                exist = true;
            }else
            {
                MessageBox.Show("Tài khoản không tồn tại");
            }
        }
        private void showDoctorInfomation(Doctor doctor)
        {
            this.nameBox.Text = doctor.displayName;
            this.specBox.Text = doctor.specialization;
            this.positionBox.Text = doctor.position;
        }
        // Show Button
        private void button5_Click(object sender, EventArgs e)
        {
            resetDataGrid();
            showAllDoctor();
        }
        private void resetDataGrid()
        {
            this.dataGridView2.Rows.Clear();
        }
        private async void showAllDoctor()
        {
            Query collectionReference = Database.Instance.database.Collection("Doctor");
            QuerySnapshot snapshots = await collectionReference.GetSnapshotAsync();
            Console.WriteLine(snapshots.Count);
            foreach (var snapshot in snapshots)
            {
                DocumentSnapshot tmp = await snapshot.Reference.Collection("Information")
                    .Document("Information").GetSnapshotAsync();
                if (tmp.Exists)
                {
                    Doctor doctor = tmp.ConvertTo<Doctor>();
                    addRowToGridDataView(doctor);
                }else
                {
                    Console.WriteLine("NOT EXISTED");
                }
            }
        }
        private void addRowToGridDataView(Doctor doctor)
        {
            this.dataGridView2.Rows.Add(doctor.displayName, doctor.userName, doctor.specialization, doctor.credential);
        }
        ///////////////////////////
        private void fDoctorforAdmin_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"cloudfire.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            Database.Instance.database = FirestoreDb.Create("test-964d0");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void taikhoan_TextChanged(object sender, EventArgs e)
        {

        }
        // Delete a doctor
        private void button4_Click(object sender, EventArgs e)
        {
            if (!exist)
            {
                MessageBox.Show("Hãy nhập đúng số điện thoại");
                return;
            }
            deleteDoctor();

            textBox1.Text = "";
            nameBox.Text = "";
            positionBox.Text = "";
            specBox.Text = "";
            textBox7.Text = "";

            MessageBox.Show("Xóa tài khoản thành công");
        }
        private async void deleteDoctor()
        {
            string tel = this.textBox1.Text;
            DocumentReference documentReference = Database.Instance.database.Collection("Doctor").Document(tel);
            // Delete doctor's schedule
            await deleteDoctorSchedules(tel);
            // Delete SubCollection
            await DeleteCollection(documentReference.Collection("Information"), 2);
            await DeleteCollection(documentReference.Collection("Schedule"), 2);
            // Delete field
            Dictionary<string, object> updates = new Dictionary<string, object>
            {
                { "rong", FieldValue.Delete }
            };
            await documentReference.UpdateAsync(updates);
            await documentReference.DeleteAsync();
        }
        private async Task deleteDoctorSchedules(string tel)
        {
            Query query = Database.Instance.database.Collection("Schedules");
            QuerySnapshot querySnapshots = await query.GetSnapshotAsync();
            foreach (DocumentSnapshot documentSnapshot in querySnapshots)
            {
                if (documentSnapshot.Exists)
                {
                    if (documentSnapshot.GetValue<string>("doctor") == tel)
                    {
                        await documentSnapshot.Reference.DeleteAsync();
                    }
                } else
                {
                    Console.WriteLine("SCHEDULE NOT EXISTED IN FINDING DOCTOR");
                }
            }
        }
        private async Task DeleteCollection(CollectionReference collectionReference, int batchSize)
        {
            QuerySnapshot snapshot = await collectionReference.Limit(batchSize).GetSnapshotAsync();
            IReadOnlyList<DocumentSnapshot> documents = snapshot.Documents;
            while (documents.Count > 0)
            {
                foreach (DocumentSnapshot document in documents)
                {
                    Console.WriteLine("Deleting document {0}", document.Id);
                    await document.Reference.DeleteAsync();
                }
                snapshot = await collectionReference.Limit(batchSize).GetSnapshotAsync();
                documents = snapshot.Documents;
            }
            Console.WriteLine("Finished deleting all documents from the collection.");
        }
        // Update Information
        private void button6_Click(object sender, EventArgs e)
        {
            if (!exist)
            {
                MessageBox.Show("Hãy nhập đúng số điện thoại");
                return;
            }
            UpdateDoctorInformation();
        }
        private async void UpdateDoctorInformation()
        {
            string tel = this.textBox1.Text;
            DocumentReference documentReference = Database.Instance.database.Collection("Doctor").Document(tel)
                .Collection("Information").Document("Information");
            Dictionary<string, object> updates = new Dictionary<string, object>();
            if (this.nameBox.Text != "")
            {
                updates.Add( "displayName", this.nameBox.Text);
            }
            if (this.positionBox.Text != "")
            {
                updates.Add("position", this.positionBox.Text);
            }
            if (this.specBox.Text != "")
            {
                updates.Add("specialization", this.specBox.Text);
            }
            await documentReference.UpdateAsync(updates);
            MessageBox.Show("Cập nhật thành công");
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }
        // Search Doctor to make appointment
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.Text == "")
            {
                MessageBox.Show("HAY NHAP CHUYEN MON");
            }
            System.DateTime beginTime = this.dateTimePicker3.Value;
            System.DateTime endTime = this.dateTimePicker4.Value;
            beginTime = resetSecond(beginTime);
            endTime = resetSecond(endTime);
            if (beginTime < endTime)
            {
                filterAllDoctorWithSpecAndTime(beginTime, endTime);

            }
            else {
                MessageBox.Show("Invalid begin and end");
            }
        }
        private void clearDataGridView()
        {
            this.dataGridView3.Rows.Clear();
        }
        private System.DateTime resetSecond(System.DateTime beginTime)
        {
            return beginTime.AddSeconds(-beginTime.Second);
        }
        private async void filterAllDoctorWithSpecAndTime(System.DateTime a, System.DateTime b)
        {
            this.dataGridView3.Rows.Clear();
            Console.WriteLine(a + " " + b);
            Query collectionReference = Database.Instance.database.Collection("Doctor");
            QuerySnapshot snapshots = await collectionReference.GetSnapshotAsync();
            string spec = this.comboBox1.Text;
            bool available = false;
            foreach (var snapshot in snapshots)
            {
                DocumentSnapshot tmp = await snapshot.Reference.Collection("Information")
                    .Document("Information").GetSnapshotAsync();
               
                if (tmp.Exists)
                {
                    Doctor doctor = tmp.ConvertTo<Doctor>();
                    // if the spec is right then ... 
                    if (doctor.specialization == spec)
                    {
                        // All the schedules
                        Query schedules = snapshot.Reference.Collection("Schedule");
                        QuerySnapshot scheduleSnapshots = await schedules.GetSnapshotAsync();
                        bool valid = true;
                        foreach (DocumentSnapshot document in scheduleSnapshots)
                        {
                            DocumentReference temp = document.GetValue<DocumentReference>("ref");
                            Console.WriteLine(temp.ToString());
                            DocumentSnapshot scheduleSnap = await temp.GetSnapshotAsync();
                            if (scheduleSnap.Exists)
                            {
                                Schedule scheduleData = scheduleSnap.ConvertTo<Schedule>();
                                System.DateTime begin = scheduleData.begin.ToDateTime().ToLocalTime();
                                System.DateTime end = scheduleData.end.ToDateTime().ToLocalTime();
                                Console.WriteLine(begin + " " + end);
                                if (!validTime(begin, end, a, b))
                                {
                                    valid = false;
                                    break;
                                }
                            }
                        }
                        if (valid)
                        {
                            available = true;
                            addDoctorToData(doctor);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("NOT EXISTED");
                }
            }
            if (available == false)
            {
                MessageBox.Show("Không có bác sĩ nào thuộc chuyên môn trên rảnh trong khoảng thời gian đã chọn !" +
                    "Hãy lựa chọn khoảng thời gian khác !");
            }
        }
        
        private void addDoctorToData(Doctor doctor)
        {
            this.dataGridView3.Rows.Add(doctor.displayName, doctor.userName, doctor.specialization);
        }
        private bool validTime(System.DateTime a, System.DateTime b, System.DateTime c, System.DateTime d)
        {
            // a and b are fixed schedule
            // c and d are new schedule
            int e = System.DateTime.Compare(a, d);
            int f = System.DateTime.Compare(b, c);
            Console.WriteLine(e  + " " + f);
            if (e != -1)
            {
                return true;
            }
            if (f != 1)
            {
                return true;
            }
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foo();
        }
        private async void foo()
        {
            System.DateTime begin = resetSecond(this.dateTimePicker3.Value);
            System.DateTime end = resetSecond(this.dateTimePicker4.Value);
            string patient = this.textBox7.Text;
            string doctor = this.textBox6.Text;
            string room = this.textBox3.Text;

            if (patient == "")
            {
                MessageBox.Show("HAY NHAP ID BENH NHAN");
            }
            if (doctor == "")
            {
                MessageBox.Show("HAY NHAP ID BAC SI");
                return;
            }
            if (room == "")
            {
                MessageBox.Show("HAY NHAP PHONG");
                return;
            }

            DocumentReference docRes = Database.Instance.database.Collection("Doctor").Document(textBox6.Text).Collection("Information").Document("Information");
            DocumentSnapshot docSnap = await docRes.GetSnapshotAsync();

            if (!docSnap.Exists)
            {
                MessageBox.Show("ID nhân viên y tế không tồn tại");
                return;
            }

            // Check if patient have a schedule or not
            if (!await checkIfPatientAvailable(patient, begin, end))
            {
                MessageBox.Show("Bệnh nhân bận giờ này !");
            }else
            {
                // Make an appointment for a doctor and a patient
                Schedule newSchedule = new Schedule()
                {
                    begin = Google.Cloud.Firestore.Timestamp.FromDateTime(System.DateTime.SpecifyKind(begin.AddHours(-7), DateTimeKind.Utc)),
                    end = Google.Cloud.Firestore.Timestamp.FromDateTime(System.DateTime.SpecifyKind(end.AddHours(-7), DateTimeKind.Utc)),
                    room = room,
                    notes = "NEW NOTES",
                    doctor = doctor,
                    patient = patient,
                };

                // Create new schedule
                DocumentReference newDocument = await Database.Instance.database.Collection("Schedules")
                    .AddAsync(newSchedule);

                Dictionary<string, DocumentReference> newRef = new Dictionary<string, DocumentReference>()
                {
                    {"ref", newDocument},
                };
                // Create new doc in doctor to ref to new schedule
                CollectionReference doctorCollectionReference = Database.Instance.database.Collection("Doctor").Document(doctor)
                    .Collection("Schedule");
                await doctorCollectionReference.AddAsync(newRef);

                // Create new doc in patient to ref to new schedule
                CollectionReference patientCollectionReference = Database.Instance.database.Collection("Patient").Document(patient)
                    .Collection("Schedule");
                await patientCollectionReference.AddAsync(newRef);

                MessageBox.Show("Phân công thành công");
            }
        }
        private async Task<bool> checkIfPatientAvailable(string patient, System.DateTime a, System.DateTime b)
        {
            Query collectionReference = Database.Instance.database.Collection("Patient").Document(patient).Collection("Schedule");
            QuerySnapshot scheduleSnaps = await collectionReference.GetSnapshotAsync();
            foreach (DocumentSnapshot scheduleSnap in scheduleSnaps)
            {
                DocumentReference scheduleRef = scheduleSnap.GetValue<DocumentReference>("ref");
                DocumentSnapshot tmp = await scheduleRef.GetSnapshotAsync();
                if (tmp.Exists)
                {
                    Schedule schedule = tmp.ConvertTo<Schedule>();
                    System.DateTime begin = schedule.begin.ToDateTime().ToLocalTime();
                    System.DateTime end = schedule.end.ToDateTime().ToLocalTime();
                    if (!validTime(begin, end, a, b))
                    {
                        return false;
                    }
                }else
                {
                    Console.WriteLine("SCHEDULE NOT EXISTED !");
                }
            }
            return true;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void btnViewDia_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "") return;
            DocumentReference diaRes = Database.Instance.database.Collection("Patient").Document(textBox7.Text).Collection("Information").Document("Information");
            DocumentSnapshot diaSnap = await diaRes.GetSnapshotAsync();

            if (!diaSnap.Exists)
            {
                MessageBox.Show("ID bệnh nhân không tồn tại");
                return;
            }

            Taikhoan pat = diaSnap.ConvertTo<Patient>();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            exist = false;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            showAvailablePatient();
        }
        private async void showAvailablePatient()
        {
            System.DateTime beginTime = this.dateTimePicker3.Value;
            System.DateTime endTime = this.dateTimePicker4.Value;
            this.dataGridView1.Rows.Clear();
            Query collectionReference = Database.Instance.database.Collection("Patient");
            QuerySnapshot snapshots = await collectionReference.GetSnapshotAsync();
            bool available = false;
            foreach (var snapshot in snapshots)
            {
                string patientTel = snapshot.Reference.Id;
                if (await checkIfPatientAvailable(patientTel, beginTime, endTime))
                {
                    DocumentReference docRef = Database.Instance.database.Collection("Patient").Document(patientTel).Collection("Information").Document("Information");
                    DocumentSnapshot patientSnapshot = await docRef.GetSnapshotAsync();
                    if (patientSnapshot.Exists)
                    {
                        available = true;
                        Patient patient = patientSnapshot.ConvertTo<Patient>();
                        addPatientToData(patient);
                    }
                }
            }
            if (available == false)
            {
                MessageBox.Show("Không có bênh nhân nào rảnh trong khoảng thời gian đã chọn !\n" +
                                "Hãy lựa chọn khoảng thời gian khác !");
            }
        }
        private void addPatientToData(Patient patient)
        {
            this.dataGridView1.Rows.Add(patient.displayName, patient.userName, patient.diagnosis);
        }
        private void tabPage3_Click(object sender, EventArgs e)
        {
        }
        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            showAvailablePatient();
        }
    }
}
