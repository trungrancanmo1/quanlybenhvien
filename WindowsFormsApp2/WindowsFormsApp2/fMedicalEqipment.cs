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
    public partial class fMedicalEqipment : Form
    {
        public fMedicalEqipment()
        {
            InitializeComponent();
        }

       

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
    }
}
