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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp2
{
    public partial class fListAcc : Form
    {
        public bool exist = false;
        public Taikhoan acc = null;
        public fListAcc()
        {
            InitializeComponent();
        }

        private void fListAcc_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"cloudfire.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            Database.Instance.database = FirestoreDb.Create("test-964d0");
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
                    Query list = Database.Instance.database.Collection("Admin");
                    QuerySnapshot listSnap = await list.GetSnapshotAsync();
                    foreach (DocumentSnapshot document in listSnap.Documents)
                    {
                        string reference = document.Id;                        
                        DocumentReference res = Database.Instance.database.Collection("Admin").Document(reference).Collection("Information").Document("Information");
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
                    Query list = Database.Instance.database.Collection("Doctor");
                    QuerySnapshot listSnap = await list.GetSnapshotAsync();
                    foreach (DocumentSnapshot document in listSnap.Documents)
                    {
                        string reference = document.Id;
                        DocumentReference res = Database.Instance.database.Collection("Doctor").Document(reference).Collection("Information").Document("Information");
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
                    Query list = Database.Instance.database.Collection("Patient");
                    QuerySnapshot listSnap = await list.GetSnapshotAsync();
                    foreach (DocumentSnapshot document in listSnap.Documents)
                    {
                        string reference = document.Id;
                        DocumentReference res = Database.Instance.database.Collection("Patient").Document(reference).Collection("Information").Document("Information");
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

        private async void btnFind_Click(object sender, EventArgs e)
        {
            DocumentReference adRes = Database.Instance.database.Collection("Admin").Document(txtFind.Text).Collection("Information").Document("Information");
            DocumentSnapshot adSnap = await adRes.GetSnapshotAsync();

            DocumentReference docRes = Database.Instance.database.Collection("Doctor").Document(txtFind.Text).Collection("Information").Document("Information");
            DocumentSnapshot docSnap = await docRes.GetSnapshotAsync();

            DocumentReference patRes = Database.Instance.database.Collection("Patient").Document(txtFind.Text).Collection("Information").Document("Information");
            DocumentSnapshot patSnap = await patRes.GetSnapshotAsync();

            if (!adSnap.Exists && !docSnap.Exists && !patSnap.Exists)
            {
                MessageBox.Show("Tài khoản không tồn tại");
                return;
            }

            exist = true;

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

            txtDisName.Text = acc.displayName;
            txtType.Text = acc.type;
            txtUserName.Text = acc.userName;
            txtPass.Text = acc.password;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if(!exist)
            {
                MessageBox.Show("Hãy nhập đúng tên tài khoản");
                return;
            }  

            if (acc.type == "Admin")
            {
                if (txtFind.Text == CurrentAccount.Instance.GetData().userName)
                {
                    MessageBox.Show("Không thể xóa tài khoản Admin của bản thân");
                    return;
                }
                Query ad = Database.Instance.database.Collection("Admin");
                QuerySnapshot adSnap = await ad.GetSnapshotAsync();
                int cnt = 0;
                foreach (DocumentSnapshot documentSnapshot in adSnap)
                {
                    cnt++;
                }
                if (cnt <= 1)
                {
                    MessageBox.Show("Cần chừa lại ít nhất 1 tài khoản Admin");
                    return;
                }
                DocumentReference adRes = Database.Instance.database.Collection("Admin").Document(acc.userName);
                
                await DeleteCollection(adRes.Collection("Information"), 2);

                Dictionary<string, object> updates = new Dictionary<string, object>
                {
                    { "rong", FieldValue.Delete }
                };
                await adRes.UpdateAsync(updates);

                await adRes.DeleteAsync();

                MessageBox.Show("Xóa tài khoản Admin thành công");
            }
            else if (acc.type == "Doctor")
            {
                string tel = txtFind.Text;
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
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else if (acc.type == "Patient")
            {
                string telPati = txtFind.Text;
                //Xóa schedule          
                Query query = Database.Instance.database.Collection("Schedules");
                QuerySnapshot querySnapshots = await query.GetSnapshotAsync();
                foreach (DocumentSnapshot documentSnapshot in querySnapshots)
                {
                    if (documentSnapshot.Exists)
                    {
                        if (documentSnapshot.GetValue<string>("patient") == telPati)
                        {
                            await documentSnapshot.Reference.DeleteAsync();
                        }
                    }
                }
                // xóa colloection information 
                DocumentReference path = Database.Instance.database.Collection("Patient").Document(telPati);
                QuerySnapshot snapshot = await path.Collection("Information").Limit(2).GetSnapshotAsync();
                IReadOnlyList<DocumentSnapshot> documents = snapshot.Documents;
                while (documents.Count > 0)
                {
                    foreach (DocumentSnapshot document in documents)
                    {
                        await document.Reference.DeleteAsync();
                    }
                    snapshot = await path.Collection("Information").Limit(2).GetSnapshotAsync();
                    documents = snapshot.Documents;
                }
                // xóa colloection schedule
                QuerySnapshot snapshotSche = await path.Collection("Schedule").Limit(2).GetSnapshotAsync();
                IReadOnlyList<DocumentSnapshot> documentSche = snapshotSche.Documents;
                while (documentSche.Count > 0)
                {
                    foreach (DocumentSnapshot documentsch in documentSche)
                    {
                        await documentsch.Reference.DeleteAsync();
                    }
                    snapshot = await path.Collection("Schedule").Limit(2).GetSnapshotAsync();
                    documentSche = snapshot.Documents;
                }
                Dictionary<string, object> updates = new Dictionary<string, object>
                {
                { "rong", FieldValue.Delete }
                };
                await path.UpdateAsync(updates);
                await path.DeleteAsync();
                MessageBox.Show("Xóa tài khoản thành công");
            }
            txtFind.Text = "";
            txtDisName.Text = "";
            txtPass.Text = "";
            txtUserName.Text = "";
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
                    await document.Reference.DeleteAsync();
                }
                snapshot = await collectionReference.Limit(batchSize).GetSnapshotAsync();
                documents = snapshot.Documents;
            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            exist = false;
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!exist)
            {
                MessageBox.Show("Hãy nhập đúng tên tài khoản");
                return;
            }
            DocumentReference res = Database.Instance.database.Collection(acc.type).Document(acc.userName).Collection("Information").Document("Information");
            Dictionary<string, object> updates = new Dictionary<string, object>()
            {
                {"displayName", txtDisName.Text},
                {"password", txtPass.Text}
            };
            await res.UpdateAsync(updates);
            MessageBox.Show("Cập nhật thành công");
        }
    }
}
