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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class fDoctorforAdmin : Form
    {
        private FirestoreDb database;
        private List<DocumentReference> availableDoctorRefs;
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
            DocumentReference documentReference = database.Collection("Doctor").Document(tel)
                .Collection("Information").Document("Information");
            DocumentSnapshot snapshot = await documentReference.GetSnapshotAsync();
            
            if (snapshot.Exists)
            {
                Doctor doctor = snapshot.ConvertTo<Doctor>();
                showDoctorInfomation(doctor);
            }else
            {
                MessageBox.Show("NOT FOUND");
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
            Query collectionReference = database.Collection("Doctor");
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

            database = FirestoreDb.Create("test-964d0");
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
            deleteDoctor();
        }
        private async void deleteDoctor()
        {
            string tel = this.textBox1.Text;
            DocumentReference documentReference = database.Collection("Doctor").Document(tel);
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
        }
        private async Task deleteDoctorSchedules(string tel)
        {
            Query query = database.Collection("Schedules");
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
            UpdateDoctorInformation();
        }
        private async void UpdateDoctorInformation()
        {
            string tel = this.textBox1.Text;
            DocumentReference documentReference = database.Collection("Doctor").Document(tel)
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
            MessageBox.Show("INFORMATION UPDATED");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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
            Query collectionReference = database.Collection("Doctor");
            QuerySnapshot snapshots = await collectionReference.GetSnapshotAsync();
            string spec = this.comboBox1.Text;
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
                        if (valid)
                        {
                            addDoctorToData(doctor);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("NOT EXISTED");
                }
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
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

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
            }
            if (room == "")
            {
                MessageBox.Show("HAY NHAP PHONG");
            }
            // Check if patient have a schedule or not
            if (!await checkIfPatientAvailable(patient, begin, end))
            {
                MessageBox.Show("PATIENT BUSY THIS TIME");
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
                DocumentReference newDocument = await database.Collection("Schedules")
                    .AddAsync(newSchedule);

                Dictionary<string, DocumentReference> newRef = new Dictionary<string, DocumentReference>()
                {
                    {"ref", newDocument},
                };
                // Create new doc in doctor to ref to new schedule
                CollectionReference doctorCollectionReference = database.Collection("Doctor").Document(doctor)
                    .Collection("Schedule");
                await doctorCollectionReference.AddAsync(newRef);

                // Create new doc in patient to ref to new schedule
                CollectionReference patientCollectionReference = database.Collection("Patient").Document(patient)
                    .Collection("Schedule");
                await patientCollectionReference.AddAsync(newRef);

                MessageBox.Show("PHAN CONG XONG");
            }
        }
        private async Task<bool> checkIfPatientAvailable(string patient, System.DateTime a, System.DateTime b)
        {
            Query collectionReference = database.Collection("Patient").Document(patient).Collection("Schedule");
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

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
