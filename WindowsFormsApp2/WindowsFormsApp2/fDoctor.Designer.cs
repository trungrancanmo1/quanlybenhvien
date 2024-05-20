namespace WindowsFormsApp2
{
    partial class fDoctor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabinformation = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtCre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.txtSpe = new System.Windows.Forms.TextBox();
            this.specialize = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtPos = new System.Windows.Forms.TextBox();
            this.position = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkbutton = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtPro = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.dtpRegDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.txtDia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.txtTesRes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.txtMedHis = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.txtPatName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabinformation.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel14.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabinformation
            // 
            this.tabinformation.Controls.Add(this.tabPage1);
            this.tabinformation.Controls.Add(this.tabPage2);
            this.tabinformation.Controls.Add(this.tabPage3);
            this.tabinformation.Location = new System.Drawing.Point(12, 11);
            this.tabinformation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabinformation.Name = "tabinformation";
            this.tabinformation.SelectedIndex = 0;
            this.tabinformation.Size = new System.Drawing.Size(826, 425);
            this.tabinformation.TabIndex = 5;
            this.tabinformation.UseWaitCursor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnChangePass);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(818, 396);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thông tin cá nhân";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.UseWaitCursor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // btnChangePass
            // 
            this.btnChangePass.Location = new System.Drawing.Point(676, 303);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(128, 68);
            this.btnChangePass.TabIndex = 2;
            this.btnChangePass.Text = "Đổi mật khẩu";
            this.btnChangePass.UseVisualStyleBackColor = true;
            this.btnChangePass.UseWaitCursor = true;
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel9);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Location = new System.Drawing.Point(6, 4);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(798, 266);
            this.panel3.TabIndex = 0;
            this.panel3.UseWaitCursor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtCre);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(3, 199);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(792, 57);
            this.panel4.TabIndex = 3;
            this.panel4.UseWaitCursor = true;
            // 
            // txtCre
            // 
            this.txtCre.Location = new System.Drawing.Point(138, 18);
            this.txtCre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCre.Name = "txtCre";
            this.txtCre.ReadOnly = true;
            this.txtCre.Size = new System.Drawing.Size(649, 22);
            this.txtCre.TabIndex = 2;
            this.txtCre.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bằng cấp:";
            this.label1.UseWaitCursor = true;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.txtSpe);
            this.panel9.Controls.Add(this.specialize);
            this.panel9.Location = new System.Drawing.Point(3, 134);
            this.panel9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(792, 57);
            this.panel9.TabIndex = 0;
            this.panel9.UseWaitCursor = true;
            // 
            // txtSpe
            // 
            this.txtSpe.Location = new System.Drawing.Point(138, 18);
            this.txtSpe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSpe.Name = "txtSpe";
            this.txtSpe.ReadOnly = true;
            this.txtSpe.Size = new System.Drawing.Size(649, 22);
            this.txtSpe.TabIndex = 2;
            this.txtSpe.UseWaitCursor = true;
            // 
            // specialize
            // 
            this.specialize.AutoSize = true;
            this.specialize.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.specialize.Location = new System.Drawing.Point(4, 18);
            this.specialize.Name = "specialize";
            this.specialize.Size = new System.Drawing.Size(120, 23);
            this.specialize.TabIndex = 0;
            this.specialize.Text = "Chuyên môn:";
            this.specialize.UseWaitCursor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtName);
            this.panel7.Controls.Add(this.name);
            this.panel7.Location = new System.Drawing.Point(3, 4);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(792, 57);
            this.panel7.TabIndex = 0;
            this.panel7.UseWaitCursor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(138, 20);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(651, 22);
            this.txtName.TabIndex = 1;
            this.txtName.UseWaitCursor = true;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(5, 20);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(98, 23);
            this.name.TabIndex = 0;
            this.name.Text = "Họ và tên:";
            this.name.UseWaitCursor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtPos);
            this.panel6.Controls.Add(this.position);
            this.panel6.Location = new System.Drawing.Point(3, 69);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(792, 57);
            this.panel6.TabIndex = 0;
            this.panel6.UseWaitCursor = true;
            // 
            // txtPos
            // 
            this.txtPos.Location = new System.Drawing.Point(140, 20);
            this.txtPos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPos.Name = "txtPos";
            this.txtPos.ReadOnly = true;
            this.txtPos.Size = new System.Drawing.Size(649, 22);
            this.txtPos.TabIndex = 1;
            this.txtPos.UseWaitCursor = true;
            // 
            // position
            // 
            this.position.AutoSize = true;
            this.position.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.position.Location = new System.Drawing.Point(4, 18);
            this.position.Name = "position";
            this.position.Size = new System.Drawing.Size(87, 23);
            this.position.TabIndex = 0;
            this.position.Text = "Chức vụ:";
            this.position.UseWaitCursor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(818, 396);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Lịch trình";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.UseWaitCursor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkbutton);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.dateTimePicker2);
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(830, 44);
            this.panel2.TabIndex = 4;
            this.panel2.UseWaitCursor = true;
            // 
            // checkbutton
            // 
            this.checkbutton.Location = new System.Drawing.Point(378, 7);
            this.checkbutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkbutton.Name = "checkbutton";
            this.checkbutton.Size = new System.Drawing.Size(72, 33);
            this.checkbutton.TabIndex = 2;
            this.checkbutton.Text = "Kiểm tra";
            this.checkbutton.UseVisualStyleBackColor = true;
            this.checkbutton.UseWaitCursor = true;
            this.checkbutton.Click += new System.EventHandler(this.checkbutton_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(3, 10);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(262, 22);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.UseWaitCursor = true;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(565, 10);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(262, 22);
            this.dateTimePicker2.TabIndex = 1;
            this.dateTimePicker2.UseWaitCursor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(5, 57);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(827, 329);
            this.panel1.TabIndex = 3;
            this.panel1.UseWaitCursor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(3, 2);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(810, 325);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.UseWaitCursor = true;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel5);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(818, 396);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Tra cứu thông tin bệnh nhân";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.UseWaitCursor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel15);
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.panel10);
            this.panel5.Controls.Add(this.panel11);
            this.panel5.Controls.Add(this.panel12);
            this.panel5.Controls.Add(this.panel13);
            this.panel5.Controls.Add(this.panel14);
            this.panel5.Location = new System.Drawing.Point(6, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(809, 384);
            this.panel5.TabIndex = 7;
            this.panel5.UseWaitCursor = true;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.btnFind);
            this.panel15.Controls.Add(this.txtFind);
            this.panel15.Controls.Add(this.label8);
            this.panel15.Location = new System.Drawing.Point(1, 3);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(799, 44);
            this.panel15.TabIndex = 2;
            this.panel15.UseWaitCursor = true;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(650, 6);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(146, 31);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Tra cứu";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.UseWaitCursor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtFind
            // 
            this.txtFind.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.txtFind.Location = new System.Drawing.Point(178, 3);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(456, 32);
            this.txtFind.TabIndex = 1;
            this.txtFind.UseWaitCursor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(3, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 25);
            this.label8.TabIndex = 0;
            this.label8.Text = "ID bệnh nhân:";
            this.label8.UseWaitCursor = true;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.txtPro);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Location = new System.Drawing.Point(4, 336);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(799, 35);
            this.panel8.TabIndex = 5;
            this.panel8.UseWaitCursor = true;
            // 
            // txtPro
            // 
            this.txtPro.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.txtPro.Location = new System.Drawing.Point(179, 3);
            this.txtPro.Multiline = true;
            this.txtPro.Name = "txtPro";
            this.txtPro.ReadOnly = true;
            this.txtPro.Size = new System.Drawing.Size(617, 27);
            this.txtPro.TabIndex = 1;
            this.txtPro.UseWaitCursor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(3, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tiến triển:";
            this.label6.UseWaitCursor = true;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.dtpRegDate);
            this.panel10.Controls.Add(this.label2);
            this.panel10.Location = new System.Drawing.Point(4, 109);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(799, 44);
            this.panel10.TabIndex = 5;
            this.panel10.UseWaitCursor = true;
            // 
            // dtpRegDate
            // 
            this.dtpRegDate.CustomFormat = "dd/MM/yyyy hh:mm tt";
            this.dtpRegDate.Enabled = false;
            this.dtpRegDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRegDate.Location = new System.Drawing.Point(179, 8);
            this.dtpRegDate.Name = "dtpRegDate";
            this.dtpRegDate.Size = new System.Drawing.Size(200, 22);
            this.dtpRegDate.TabIndex = 1;
            this.dtpRegDate.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ngày vào viện:";
            this.label2.UseWaitCursor = true;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.txtDia);
            this.panel11.Controls.Add(this.label5);
            this.panel11.Location = new System.Drawing.Point(3, 288);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(803, 45);
            this.panel11.TabIndex = 4;
            this.panel11.UseWaitCursor = true;
            // 
            // txtDia
            // 
            this.txtDia.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.txtDia.Location = new System.Drawing.Point(179, 3);
            this.txtDia.Multiline = true;
            this.txtDia.Name = "txtDia";
            this.txtDia.ReadOnly = true;
            this.txtDia.Size = new System.Drawing.Size(618, 27);
            this.txtDia.TabIndex = 1;
            this.txtDia.UseWaitCursor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(9, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Chẩn đoán:";
            this.label5.UseWaitCursor = true;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.txtTesRes);
            this.panel12.Controls.Add(this.label4);
            this.panel12.Location = new System.Drawing.Point(3, 219);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(800, 63);
            this.panel12.TabIndex = 3;
            this.panel12.UseWaitCursor = true;
            // 
            // txtTesRes
            // 
            this.txtTesRes.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.txtTesRes.Location = new System.Drawing.Point(180, 3);
            this.txtTesRes.Multiline = true;
            this.txtTesRes.Name = "txtTesRes";
            this.txtTesRes.ReadOnly = true;
            this.txtTesRes.Size = new System.Drawing.Size(617, 53);
            this.txtTesRes.TabIndex = 1;
            this.txtTesRes.UseWaitCursor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(7, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 50);
            this.label4.TabIndex = 0;
            this.label4.Text = "Kết quả xét \r\nnghiệm:";
            this.label4.UseWaitCursor = true;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.txtMedHis);
            this.panel13.Controls.Add(this.label3);
            this.panel13.Location = new System.Drawing.Point(3, 159);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(800, 54);
            this.panel13.TabIndex = 2;
            this.panel13.UseWaitCursor = true;
            // 
            // txtMedHis
            // 
            this.txtMedHis.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.txtMedHis.Location = new System.Drawing.Point(180, 3);
            this.txtMedHis.Multiline = true;
            this.txtMedHis.Name = "txtMedHis";
            this.txtMedHis.ReadOnly = true;
            this.txtMedHis.Size = new System.Drawing.Size(617, 45);
            this.txtMedHis.TabIndex = 1;
            this.txtMedHis.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(1, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Lịch sử bệnh án:";
            this.label3.UseWaitCursor = true;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.txtPatName);
            this.panel14.Controls.Add(this.label7);
            this.panel14.Location = new System.Drawing.Point(4, 59);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(799, 44);
            this.panel14.TabIndex = 0;
            this.panel14.UseWaitCursor = true;
            // 
            // txtPatName
            // 
            this.txtPatName.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.txtPatName.Location = new System.Drawing.Point(178, 3);
            this.txtPatName.Name = "txtPatName";
            this.txtPatName.ReadOnly = true;
            this.txtPatName.Size = new System.Drawing.Size(618, 32);
            this.txtPatName.TabIndex = 1;
            this.txtPatName.UseWaitCursor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(3, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tên:";
            this.label7.UseWaitCursor = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Bắt đầu";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Kết thúc";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Phòng";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Id Bệnh nhân";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 150;
            // 
            // fDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 435);
            this.Controls.Add(this.tabinformation);
            this.Name = "fDoctor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bác sĩ";
            this.Load += new System.EventHandler(this.fDoctor_Load);
            this.tabinformation.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabinformation;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label specialize;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtPos;
        private System.Windows.Forms.Label position;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button checkbutton;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtSpe;
        private System.Windows.Forms.Button btnChangePass;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtCre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox txtPro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.DateTimePicker dtpRegDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TextBox txtDia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.TextBox txtTesRes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.TextBox txtMedHis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.TextBox txtPatName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}