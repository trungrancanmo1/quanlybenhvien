﻿namespace WindowsFormsApp2
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
            this.panel10 = new System.Windows.Forms.Panel();
            this.lichtrinh = new System.Windows.Forms.Label();
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnset = new System.Windows.Forms.Button();
            this.tabinformation.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabinformation
            // 
            this.tabinformation.Controls.Add(this.tabPage1);
            this.tabinformation.Controls.Add(this.tabPage2);
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
            this.btnChangePass.Location = new System.Drawing.Point(57, 297);
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
            this.panel3.Controls.Add(this.panel10);
            this.panel3.Controls.Add(this.panel9);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Location = new System.Drawing.Point(6, 4);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(798, 269);
            this.panel3.TabIndex = 0;
            this.panel3.UseWaitCursor = true;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.btnset);
            this.panel10.Controls.Add(this.comboBox1);
            this.panel10.Controls.Add(this.lichtrinh);
            this.panel10.Location = new System.Drawing.Point(3, 199);
            this.panel10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(792, 57);
            this.panel10.TabIndex = 1;
            this.panel10.UseWaitCursor = true;
            // 
            // lichtrinh
            // 
            this.lichtrinh.AutoSize = true;
            this.lichtrinh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lichtrinh.Location = new System.Drawing.Point(3, 21);
            this.lichtrinh.Name = "lichtrinh";
            this.lichtrinh.Size = new System.Drawing.Size(106, 23);
            this.lichtrinh.TabIndex = 0;
            this.lichtrinh.Text = "Tình trạng:";
            this.lichtrinh.UseWaitCursor = true;
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
            this.dataGridView1.Location = new System.Drawing.Point(3, 2);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(821, 325);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.UseWaitCursor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Rảnh",
            "Bận"});
            this.comboBox1.Location = new System.Drawing.Point(138, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(133, 24);
            this.comboBox1.TabIndex = 1;
            // 
            // btnset
            // 
            this.btnset.Location = new System.Drawing.Point(312, 17);
            this.btnset.Name = "btnset";
            this.btnset.Size = new System.Drawing.Size(142, 35);
            this.btnset.TabIndex = 2;
            this.btnset.Text = "Thiết lập";
            this.btnset.UseVisualStyleBackColor = true;
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
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabinformation;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label lichtrinh;
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
        private System.Windows.Forms.Button btnset;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}