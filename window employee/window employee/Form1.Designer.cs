namespace window_employee
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.btnsignin = new System.Windows.Forms.Button();
            this.btnlogin = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.GroupBox();
            this.adddetails = new System.Windows.Forms.GroupBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.btnclear = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radmale = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.employeedetails = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnshow = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.login.SuspendLayout();
            this.adddetails.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.employeedetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee Details";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Name";
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(173, 21);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(155, 20);
            this.txtname.TabIndex = 4;
            this.txtname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtname_KeyPress);
            // 
            // btnsignin
            // 
            this.btnsignin.Location = new System.Drawing.Point(189, 100);
            this.btnsignin.Name = "btnsignin";
            this.btnsignin.Size = new System.Drawing.Size(75, 23);
            this.btnsignin.TabIndex = 5;
            this.btnsignin.Text = "Sign In";
            this.btnsignin.UseVisualStyleBackColor = true;
            this.btnsignin.Click += new System.EventHandler(this.btnsignin_Click);
            // 
            // btnlogin
            // 
            this.btnlogin.Location = new System.Drawing.Point(98, 100);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(75, 23);
            this.btnlogin.TabIndex = 6;
            this.btnlogin.Text = "Login";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // login
            // 
            this.login.Controls.Add(this.radioButton1);
            this.login.Controls.Add(this.label6);
            this.login.Controls.Add(this.btnshow);
            this.login.Controls.Add(this.txtname);
            this.login.Controls.Add(this.btnlogin);
            this.login.Controls.Add(this.label2);
            this.login.Controls.Add(this.btnsignin);
            this.login.Controls.Add(this.radioButton2);
            this.login.Location = new System.Drawing.Point(25, 60);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(438, 141);
            this.login.TabIndex = 7;
            this.login.TabStop = false;
            // 
            // adddetails
            // 
            this.adddetails.Controls.Add(this.txtid);
            this.adddetails.Controls.Add(this.btnclear);
            this.adddetails.Controls.Add(this.btnupdate);
            this.adddetails.Controls.Add(this.btnsave);
            this.adddetails.Controls.Add(this.groupBox1);
            this.adddetails.Controls.Add(this.dateTimePicker1);
            this.adddetails.Controls.Add(this.label7);
            this.adddetails.Controls.Add(this.label5);
            this.adddetails.Controls.Add(this.label4);
            this.adddetails.Controls.Add(this.radmale);
            this.adddetails.Controls.Add(this.textBox1);
            this.adddetails.Location = new System.Drawing.Point(25, 252);
            this.adddetails.Name = "adddetails";
            this.adddetails.Size = new System.Drawing.Size(438, 256);
            this.adddetails.TabIndex = 8;
            this.adddetails.TabStop = false;
            this.adddetails.Text = "Add New Employee";
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(292, 19);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(93, 20);
            this.txtid.TabIndex = 18;
            // 
            // btnclear
            // 
            this.btnclear.Location = new System.Drawing.Point(253, 226);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(75, 23);
            this.btnclear.TabIndex = 17;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.Location = new System.Drawing.Point(147, 226);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(75, 23);
            this.btnupdate.TabIndex = 16;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(53, 226);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 15;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkedListBox1);
            this.groupBox1.Location = new System.Drawing.Point(44, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 113);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Skills";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "C#",
            "ASP.NET",
            "SQL",
            "JQUERY",
            "JAVASCRIPT",
            "HTML",
            "CSS",
            "BOOTSTRAP"});
            this.checkedListBox1.Location = new System.Drawing.Point(87, 13);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(155, 94);
            this.checkedListBox1.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(131, 45);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(155, 20);
            this.dateTimePicker1.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Gender";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Date of Birth";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Name";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(227, 57);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 17);
            this.radioButton2.TabIndex = 8;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Female";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radmale
            // 
            this.radmale.AutoSize = true;
            this.radmale.Location = new System.Drawing.Point(131, 71);
            this.radmale.Name = "radmale";
            this.radmale.Size = new System.Drawing.Size(48, 17);
            this.radmale.TabIndex = 7;
            this.radmale.TabStop = true;
            this.radmale.Text = "Male";
            this.radmale.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(131, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(155, 20);
            this.textBox1.TabIndex = 5;
            // 
            // employeedetails
            // 
            this.employeedetails.Controls.Add(this.btncancel);
            this.employeedetails.Controls.Add(this.dataGridView1);
            this.employeedetails.Location = new System.Drawing.Point(25, 349);
            this.employeedetails.Name = "employeedetails";
            this.employeedetails.Size = new System.Drawing.Size(438, 184);
            this.employeedetails.TabIndex = 9;
            this.employeedetails.TabStop = false;
            this.employeedetails.Text = "Employee Details";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(401, 106);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(344, 136);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 23);
            this.btncancel.TabIndex = 1;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnshow
            // 
            this.btnshow.Location = new System.Drawing.Point(280, 100);
            this.btnshow.Name = "btnshow";
            this.btnshow.Size = new System.Drawing.Size(75, 23);
            this.btnshow.TabIndex = 7;
            this.btnshow.Text = "Show Details";
            this.btnshow.UseVisualStyleBackColor = true;
            this.btnshow.Click += new System.EventHandler(this.btnshow_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(106, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Gender";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(173, 57);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(48, 17);
            this.radioButton1.TabIndex = 14;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Male";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 536);
            this.Controls.Add(this.employeedetails);
            this.Controls.Add(this.adddetails);
            this.Controls.Add(this.login);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.login.ResumeLayout(false);
            this.login.PerformLayout();
            this.adddetails.ResumeLayout(false);
            this.adddetails.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.employeedetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Button btnsignin;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.GroupBox login;
        private System.Windows.Forms.GroupBox adddetails;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radmale;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.GroupBox employeedetails;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnshow;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label6;
    }
}

