using FireSharp.Response;
using Google.Apis.Util;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Rpc.Context.AttributeContext.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp2
{
    public partial class fAddEqipment : Form
    {
        public fAddEqipment()
        {
            InitializeComponent();
        }
        private void fAddEqipment_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"cloudfire.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            Database.Instance.database = FirestoreDb.Create("test-964d0");
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string textbox2Data = textBox2.Text.ToUpper().Replace(" ", "");

            var data = new Equipment 
            {
                name = textbox2Data,
                count = textBox3.Text,
                dateIn = dateTimePicker3.Text,
                dateOut=null,
                dateMaintenance= dateTimePicker2.Text,
                status = textBox4.Text
            };
            string formattedDate = dateTimePicker3.Value.ToString("MMddyyyyHHmm");
            Dictionary<String, Object> dummyMap = new Dictionary<string, object>();
            DocumentReference item = Database.Instance.database.Collection("Equipment")
                                               .Document(textbox2Data)
                                               .Collection(textbox2Data)
                                               .Document(formattedDate);
            DocumentReference temp = Database.Instance.database.Collection("Equipment")
                                              .Document(textbox2Data);
            await temp.SetAsync(dummyMap);
            temp = Database.Instance.database.Collection("EquipmentDelete")
                                              .Document(textbox2Data);
            await temp.SetAsync(dummyMap);

            await item.SetAsync(data);
            MessageBox.Show("Đăng kí thành công");
    }
    }
}
