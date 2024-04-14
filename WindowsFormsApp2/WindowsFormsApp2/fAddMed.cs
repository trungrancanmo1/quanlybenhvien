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
    public partial class fAddMed : Form
    {
        public FirestoreDb database;
        public fAddMed()
        {
            InitializeComponent();
        }
        private void fAddMed_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"cloudfire.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            database = FirestoreDb.Create("test-964d0");
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string textbox2Data = textBox2.Text.ToUpper().Replace(" ", "");
            var data = new Medical
            {
                name = textbox2Data,
                count = textBox3.Text,
                dateIn = dateTimePicker1.Text,
                dateOut=null,
                expiry = textBox4.Text,
            };
            string formattedDate = dateTimePicker1.Value.ToString("MMddyyyy");
            Dictionary<String, Object> dummyMap = new Dictionary<string, object>();
            DocumentReference item = database.Collection("Medical")
                                               .Document(textbox2Data)
                                               .Collection(textbox2Data)
                                               .Document(formattedDate);
            DocumentReference temp = database.Collection("Medical")
                                              .Document(textbox2Data);
            temp.SetAsync(dummyMap);
            temp = database.Collection("MedicalDelete")
                                              .Document(textbox2Data);
            temp.SetAsync(dummyMap);
            item.SetAsync(data);
            MessageBox.Show("Đăng kí thành công");
        }

    }
}
