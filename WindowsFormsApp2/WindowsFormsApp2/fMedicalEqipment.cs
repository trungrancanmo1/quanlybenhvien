using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Google.Cloud.Firestore;
using Google.Type;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Cloud.Firestore.V1.StructuredAggregationQuery.Types.Aggregation.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class fMedicalEqipment : Form
    {
        
        public fMedicalEqipment()
        {
            InitializeComponent();
        }
        private void fMedicalEqipment_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"cloudfire.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            Database.Instance.database = FirestoreDb.Create("test-964d0");
            SetupDataGridViewBinding();
            dataGridView1.CellClick += DataGridView_CellClick;
            dataGridView2.CellClick += DataGridView_CellClick;
            dataGridView3.CellClick += DataGridView_CellClick;

        }
        // lấy thứ tự hàng
        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
        }
        // Binding
        private void SetupDataGridViewBinding()
        {
            dataGridView2.SelectionChanged += (sender, e) =>
            {
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                    textBox2.Text = selectedRow.Cells["name"].Value.ToString();
                    textBox3.Text = selectedRow.Cells["count"].Value.ToString();
                    dateTimePicker1.Text = selectedRow.Cells["dateIn"].Value.ToString();
                    dateTimePicker2.Text = selectedRow.Cells["dateOut"].Value.ToString();
                    textBox4.Text = selectedRow.Cells["expiry"].Value.ToString();
                }
            };
            dataGridView1.SelectionChanged += (sender, e) =>
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    textBox8.Text = selectedRow.Cells["name"].Value.ToString();
                    textBox6.Text = selectedRow.Cells["count"].Value.ToString();
                    dateTimePicker6.Text = selectedRow.Cells["dateIn"].Value.ToString();
                    dateTimePicker4.Text = selectedRow.Cells["dateOut"].Value.ToString();
                    dateTimePicker7.Text = selectedRow.Cells["dateMaintenance"].Value.ToString();
                    textBox9.Text = selectedRow.Cells["status"].Value.ToString();
                }
            };
        }
        // Mở hộp thoại thêm 
        private void btnAddmed_Click(object sender, EventArgs e)
        {
            fAddMed f = new fAddMed();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        private void btnAddequip_Click(object sender, EventArgs e)
        {
            fAddEqipment f = new fAddEqipment();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        // Xem 
        private void seeMed_Click(object sender, EventArgs e)
        {
            LoadData<Medical>("Medical", dataGridView2, false, new string[] { "name", "count", "dateIn", "dateOut", "expiry" });
        }

        private void seeEquip_Click(object sender, EventArgs e)
        {
            LoadData<Equipment>("Equipment", dataGridView1, false, new string[] { "name", "count", "dateIn", "dateOut", "dateMaintenance", "status" });
        }
        // Tìm kiếm
        private void FindMed_Click(object sender, EventArgs e)
        {
            SearchData<Medical>("Medical", dataGridView2, textBox1.Text, new string[] { "name", "count", "dateIn", "dateOut", "expiry" });

        }
        private void FindEquip_Click(object sender, EventArgs e)
        {
            SearchData<Equipment>("Equipment", dataGridView1, textBox5.Text, new string[] { "name", "count", "dateIn", "dateOut", "dateMaintenance", "status" });
        }
        // Sửa
        private async void updateMed_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hàng để sửa.");
                return;
            }

            string nameId = textBox2.Text.ToUpper().Replace(" ", "");
            string formattedDate = dateTimePicker1.Value.ToString("MMddyyyy");

            UpdateDataAsync("Medical", nameId, formattedDate,false);

            if (nameId != dataGridView2.SelectedRows[0].Cells["Name"].Value.ToString())
            {
                string selectedName = dataGridView2.SelectedRows[0].Cells["name"].Value.ToString();
                await RemoveDataAsync("Medical", dataGridView2, selectedName, formattedDate, true);
            }

            MessageBox.Show("Chỉnh sửa dữ liệu thành công");
            LoadData<Medical>("Medical", dataGridView2, true, new string[] { "name", "count", "dateIn", "dateOut", "expiry" });
        }

        private async void updateEquip_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hàng để sửa.");
                return;
            }

            string nameId = textBox8.Text.ToUpper().Replace(" ", "");
            string formattedDate = dateTimePicker6.Value.ToString("MMddyyyyHHmm");

            UpdateDataAsync("Equipment", nameId, formattedDate, false);

            string dateId = dataGridView1.SelectedRows[0].Cells["dateIn"].Value.ToString();
            System.DateTime dateTime = System.DateTime.Parse(dateId);
            string selectedDateId = dateTime.ToString("MMddyyyyHHmm");
            if (formattedDate != selectedDateId || nameId != dataGridView1.SelectedRows[0].Cells["name"].Value.ToString())
            {
                string oldnameId = dataGridView1.SelectedRows[0].Cells["name"].Value.ToString();
                await RemoveDataAsync("Equipment", dataGridView1, oldnameId, selectedDateId, true);
            }

            MessageBox.Show("Chỉnh sửa dữ liệu thành công");
            LoadData<Equipment>("Equipment", dataGridView1, true, new string[] { "name", "count", "dateIn", "dateOut", "dateMaintenance", "status" });
        }

        // Xóa
        private async void removeMed_Click(object sender, EventArgs e)
        {
            string textbox2Data = textBox2.Text.ToUpper().Replace(" ", "");
            string formattedDate = dateTimePicker1.Value.ToString("MMddyyyy");
            await RemoveDataAsync("Medical", dataGridView2, textbox2Data, formattedDate, false);
        }

        private async void removeEquip_Click(object sender, EventArgs e)
        {
            string textbox8Data = textBox8.Text.ToUpper().Replace(" ", "");
            string formattedDate = dateTimePicker6.Value.ToString("MMddyyyyHHmm");
            await RemoveDataAsync("Equipment", dataGridView1, textbox8Data, formattedDate, false);
        }

        // Xem lịch sử
        private void checkData_Click(object sender, EventArgs e)
        {
            dataGridHis();
        }
        // Xóa lịch sử 
        private async void removeData_Click(object sender, EventArgs e)
        {
            await RemoveDataAsync(dataGridView3);
        }

        // Functions

        // Xem
        private async void LoadData<T>(string collectionName, DataGridView dataGridView, bool change, string[] columnNames)
        {
            DataTable dt = new DataTable();

            foreach (string columnName in columnNames)
            {
                dt.Columns.Add(columnName, typeof(string)).ReadOnly = true;
            }

            Query list = Database.Instance.database.Collection(collectionName);
            QuerySnapshot listSnap = await list.GetSnapshotAsync();

            if (listSnap.Count > 0)
            {
                foreach (DocumentSnapshot document in listSnap.Documents)
                {
                    string reference = document.Id;
                    Query res = Database.Instance.database.Collection(collectionName).Document(reference).Collection(reference);
                    QuerySnapshot resSnap = await res.GetSnapshotAsync();
                    foreach (DocumentSnapshot temp in resSnap.Documents)
                    {
                        DocumentReference dataRef = Database.Instance.database.Collection(collectionName).Document(reference).Collection(reference).Document(temp.Id);
                        DocumentSnapshot dataSnap = await dataRef.GetSnapshotAsync();
                        T data = dataSnap.ConvertTo<T>();
                        DataRow row = dt.NewRow();
                        foreach (string columnName in columnNames)
                        {
                            row[columnName] += Convert.ToString(data.GetType().GetProperty(columnName).GetValue(data));
                        }
                        dt.Rows.Add(row);
                    }
                }
            }
            else
            {
                dataGridView.DataSource = null;
                MessageBox.Show("Không có dữ liệu để hiển thị");
                return;
            }

            dataGridView.DataSource = dt;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (!change) MessageBox.Show("Tải dữ liệu thành công");
        }
        // Cập nhật
        private async void UpdateDataAsync(string collectionName, string nameId, string dateId, bool sell)
        {
            try
            {
                if (sell && string.IsNullOrWhiteSpace(textBox10.Text))
                {
                    MessageBox.Show("Vui lòng nhập số lượng cần bán.");
                    return;
                }

                int initialCount;
                int sellCount = 0;

                if (!int.TryParse(textBox3.Text, out initialCount))
                {
                    MessageBox.Show("Số lượng hiện có không hợp lệ.");
                    return;
                }

                if (sell && !int.TryParse(textBox10.Text, out sellCount))
                {
                    MessageBox.Show("Số lượng cần bán không hợp lệ.");
                    return;
                }

                int remainMed = initialCount - sellCount;
                bool checkSell = remainMed >= 0;

                if (!checkSell && sell)
                {
                    MessageBox.Show("Vượt quá số lượng hiện có.");
                    return;
                }

                DocumentReference item = Database.Instance.database.Collection(collectionName)
                                                   .Document(nameId)
                                                   .Collection(nameId)
                                                   .Document(dateId);

                var dummyMap = new Dictionary<string, object>();
                DocumentReference temp = Database.Instance.database.Collection(collectionName)
                                                  .Document(nameId);
                await temp.SetAsync(dummyMap);
                temp = Database.Instance.database.Collection(collectionName + "Delete")
                                                  .Document(nameId);
                await temp.SetAsync(dummyMap);

                var data = new Dictionary<string, object>
        {
            { "name", nameId },
        };

                if (collectionName == "Medical")
                {
                    data.Add("count", sell ? remainMed.ToString() : textBox3.Text);
                    data.Add("dateIn", dateTimePicker1.Text);
                    data.Add("dateOut", dateTimePicker2.Text);
                    data.Add("expiry", textBox4.Text);
                }
                else if (collectionName == "Equipment")
                {
                    data.Add("count", textBox6.Text);
                    data.Add("dateIn", dateTimePicker6.Text);
                    data.Add("dateOut", dateTimePicker4.Text);
                    data.Add("dateMaintenance", dateTimePicker7.Text);
                    data.Add("status", textBox9.Text);
                }

                await item.SetAsync(data);
                if(sell) { MessageBox.Show("Bán thành công"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating data: {ex.Message}");
            }
        }

        //Xóa 
        private async Task RemoveDataAsync(string collectionName, DataGridView dataGridView, string nameId, string dateId, bool change)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hàng để xóa.");
                return;
            }

            DocumentReference item = Database.Instance.database.Collection(collectionName)
                                               .Document(nameId)
                                               .Collection(nameId)
                                               .Document(dateId);

            DocumentSnapshot dataDel = await item.GetSnapshotAsync();

            if (!dataDel.Exists)
            {
                MessageBox.Show("Dữ liệu không tồn tại.");
                return;
            }

            dynamic dataCut = null;
            if (collectionName == "Medical")
            {
                dataCut = dataDel.ConvertTo<Medical>();
            }
            else if (collectionName == "Equipment")
            {
                dataCut = dataDel.ConvertTo<Equipment>();
            }

            if (!change && collectionName == "Equipment")
            {
                DocumentReference dataDelete = Database.Instance.database.Collection(collectionName + "Delete")
                                                        .Document(nameId)
                                                        .Collection(nameId)
                                                        .Document(dateId);
                await dataDelete.SetAsync(dataCut);
            }

            await item.DeleteAsync();

            Query list = Database.Instance.database.Collection(collectionName).Document(nameId).Collection(nameId);
            QuerySnapshot listSnap = await list.GetSnapshotAsync();
            item = Database.Instance.database.Collection(collectionName).Document(nameId);
            if (listSnap.Count == 0)
            {
                await item.DeleteAsync();
            }

            int index = dataGridView.SelectedRows[0].Index;
            dataGridView.Rows.RemoveAt(index);

            if (dataGridView.Rows.Count == 0)
            {
                dataGridView.DataSource = null;
            }

            if (!change)
            {
                MessageBox.Show("Xóa dữ liệu thành công");
            }
        }
        
        // Tìm kiếm
        private async void SearchData<T>(string collectionName, DataGridView dataGridView, string searchText, string[] columnNames) where T : new()
        {
            searchText = searchText.ToUpper().Replace(" ", "");

            DataTable dt = new DataTable();

            foreach (string columnName in columnNames)
            {
                dt.Columns.Add(columnName, typeof(string)).ReadOnly = true;
            }

            Query list = Database.Instance.database.Collection(collectionName);
            QuerySnapshot listSnap = await list.GetSnapshotAsync();

            if (listSnap.Count > 0)
            {
                foreach (DocumentSnapshot document in listSnap.Documents)
                {
                    if (document.Id == searchText)
                    {
                        string reference = document.Id;
                        Query res = Database.Instance.database.Collection(collectionName).Document(reference).Collection(reference);
                        QuerySnapshot resSnap = await res.GetSnapshotAsync();
                        foreach (DocumentSnapshot temp in resSnap.Documents)
                        {
                            DocumentReference dataRef = Database.Instance.database.Collection(collectionName).Document(reference).Collection(reference).Document(temp.Id);
                            DocumentSnapshot dataSnap = await dataRef.GetSnapshotAsync();
                            T data = dataSnap.ConvertTo<T>();
                            DataRow row = dt.NewRow();
                            foreach (string columnName in columnNames)
                            {
                                row[columnName] += Convert.ToString(data.GetType().GetProperty(columnName).GetValue(data));
                            }
                            dt.Rows.Add(row);
                        }
                        break; 
                    }
                }

                dataGridView.DataSource = dt;
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                MessageBox.Show("Tải dữ liệu thành công");
            }
            else
            {
                dataGridView.DataSource = null;
                MessageBox.Show("Không tìm thấy dữ liệu phù hợp");
            }
        }


        // Xem lịch sử
        private async void dataGridHis()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("type", typeof(string));
            dt.Columns.Add("count", typeof(string));
            dt.Columns.Add("dateIn", typeof(string));
            dt.Columns.Add("dateOut", typeof(string));

            dt.Columns["name"].ReadOnly = true;
            dt.Columns["type"].ReadOnly = true;
            dt.Columns["count"].ReadOnly = true;
            dt.Columns["dateIn"].ReadOnly = true;
            dt.Columns["dateOut"].ReadOnly = true;


            await ProcessInstruments("MedicalDelete", dt, dateTimePicker3.Value, dateTimePicker5.Value);
            await ProcessInstruments("EquipmentDelete", dt, dateTimePicker3.Value, dateTimePicker5.Value);


            if (dt.Rows.Count > 0)
            {
                dataGridView3.DataSource = dt;
                dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                MessageBox.Show("Tải dữ liệu thành công");
            }
            else
            {
                dataGridView3.DataSource = null;
                MessageBox.Show("Không tìm thấy dữ liệu phù hợp");
            }
        }
        private async Task ProcessInstruments(string CollectionName, DataTable dt, System.DateTime startDate, System.DateTime endDate)
        {
            Query list = Database.Instance.database.Collection(CollectionName);
            QuerySnapshot listSnap = await list.GetSnapshotAsync();

            if (listSnap.Count > 0)
            {
                foreach (DocumentSnapshot document in listSnap.Documents)
                {
                    string reference = document.Id;
                    Query res = Database.Instance.database.Collection(CollectionName).Document(reference).Collection(reference);
                    QuerySnapshot resSnap = await res.GetSnapshotAsync();
                    foreach (DocumentSnapshot temp in resSnap.Documents)
                    {
                        DocumentReference dataMed = Database.Instance.database.Collection(CollectionName).Document(reference).Collection(reference).Document(temp.Id);
                        DocumentSnapshot dataMedSnap = await dataMed.GetSnapshotAsync();
                        Instrument data = dataMedSnap.ConvertTo<Instrument>();
                        if (System.DateTime.TryParse(data.dateIn, out System.DateTime dateInValue) &&
                            System.DateTime.TryParse(data.dateOut, out System.DateTime dateOutValue))
                        {
                            bool conditionResult = dateInValue >= startDate && dateOutValue <= endDate;
                            if (conditionResult)
                            {
                                DataRow row = dt.NewRow();
                                row["name"] = data.name;
                                row["type"] = CollectionName.Replace("Delete","");
                                row["count"] = data.count;
                                row["dateIn"] = data.dateIn;
                                row["dateOut"] = data.dateOut;
                                dt.Rows.Add(row);
                            }
                        }
                    }
                }
            }
        }
        //Xóa lịch sử
        private async Task RemoveDataAsync(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells["type"].Value != null)
                {
                    string type = row.Cells["type"].Value.ToString();
                    string name = row.Cells["name"].Value.ToString();
                    string dateIn = row.Cells["dateIn"].Value.ToString();
                    string dateOut = row.Cells["dateOut"].Value.ToString();
                    System.DateTime dateTime = System.DateTime.Parse(dateIn);
                    string formatDate = dateTime.ToString("MMddyyyyHHmm");
                    if (type == "Medical") formatDate = System.DateTime.Parse(dateOut).ToString("MMddyyyyHHmm");
                    DocumentReference docRef = Database.Instance.database.Collection(type + "Delete").Document(name).Collection(name).Document(formatDate);
                    await docRef.DeleteAsync();
                    Query list = Database.Instance.database.Collection(type + "Delete").Document(name).Collection(name);
                    QuerySnapshot listSnap = await list.GetSnapshotAsync();
                    if(listSnap.Count == 0)
                    {
                        DocumentReference temp = Database.Instance.database.Collection(type + "Delete").Document(name);
                        await temp.DeleteAsync();
                    }
                }
            }

            MessageBox.Show("Đã xóa dữ liệu thành công");
            dataGridView.DataSource = null;
        }

        private async void sellMed_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hàng để bán.");
                return;
            }

            string nameId = textBox2.Text.ToUpper().Replace(" ", "");
            string formattedDate = dateTimePicker1.Value.ToString("MMddyyyy");

            UpdateDataAsync("Medical", nameId, formattedDate, true);
            dateTimePicker2.Value = System.DateTime.Now;
            var data = new Medical
            {
                name = textBox2.Text,
                count = textBox10.Text,
                dateIn = dateTimePicker1.Text,
                dateOut = dateTimePicker2.Text,
                expiry = textBox4.Text,
            };

            formattedDate = dateTimePicker2.Value.ToString("MMddyyyyHHmm");

            DocumentReference dataDelete = Database.Instance.database.Collection("MedicalDelete")
                                                        .Document(nameId)
                                                        .Collection(nameId)
                                                        .Document(formattedDate);
            await dataDelete.SetAsync(data);
            LoadData<Medical>("Medical", dataGridView2, true, new string[] { "name", "count", "dateIn", "dateOut", "expiry" });
        }
    }
}
