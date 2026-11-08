namespace DB2
{
    partial class RegistrationClient
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_firstname = new System.Windows.Forms.TextBox();
            this.textBox_secondname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_thirdname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox_Fis_face = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_INN_fis_face = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_address_fis_fase = new System.Windows.Forms.TextBox();
            this.maskedTextBox_number = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.maskedTextBox_series = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox_company = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_bank = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.maskedTextBox_INN_UR_face = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_companyAddress = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_companyName = new System.Windows.Forms.TextBox();
            this.registration = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox_Fis_face.SuspendLayout();
            this.groupBox_company.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(623, 346);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Физическое лицо",
            "Юридическое лицо"});
            this.comboBox1.Location = new System.Drawing.Point(155, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(168, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Тип клиента: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(61, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Фамилия: ";
            // 
            // textBox_firstname
            // 
            this.textBox_firstname.Location = new System.Drawing.Point(185, 22);
            this.textBox_firstname.Name = "textBox_firstname";
            this.textBox_firstname.Size = new System.Drawing.Size(100, 22);
            this.textBox_firstname.TabIndex = 3;
            // 
            // textBox_secondname
            // 
            this.textBox_secondname.Location = new System.Drawing.Point(185, 61);
            this.textBox_secondname.Name = "textBox_secondname";
            this.textBox_secondname.Size = new System.Drawing.Size(100, 22);
            this.textBox_secondname.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(109, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "Имя: ";
            // 
            // textBox_thirdname
            // 
            this.textBox_thirdname.Location = new System.Drawing.Point(185, 100);
            this.textBox_thirdname.Name = "textBox_thirdname";
            this.textBox_thirdname.Size = new System.Drawing.Size(100, 22);
            this.textBox_thirdname.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(57, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 26);
            this.label4.TabIndex = 6;
            this.label4.Text = "Отчество: ";
            // 
            // groupBox_Fis_face
            // 
            this.groupBox_Fis_face.Controls.Add(this.maskedTextBox_INN_fis_face);
            this.groupBox_Fis_face.Controls.Add(this.label8);
            this.groupBox_Fis_face.Controls.Add(this.label7);
            this.groupBox_Fis_face.Controls.Add(this.textBox_address_fis_fase);
            this.groupBox_Fis_face.Controls.Add(this.maskedTextBox_number);
            this.groupBox_Fis_face.Controls.Add(this.label6);
            this.groupBox_Fis_face.Controls.Add(this.maskedTextBox_series);
            this.groupBox_Fis_face.Controls.Add(this.label5);
            this.groupBox_Fis_face.Controls.Add(this.textBox_thirdname);
            this.groupBox_Fis_face.Controls.Add(this.label2);
            this.groupBox_Fis_face.Controls.Add(this.label4);
            this.groupBox_Fis_face.Controls.Add(this.textBox_firstname);
            this.groupBox_Fis_face.Controls.Add(this.textBox_secondname);
            this.groupBox_Fis_face.Controls.Add(this.label3);
            this.groupBox_Fis_face.Location = new System.Drawing.Point(9, 62);
            this.groupBox_Fis_face.Name = "groupBox_Fis_face";
            this.groupBox_Fis_face.Size = new System.Drawing.Size(623, 296);
            this.groupBox_Fis_face.TabIndex = 8;
            this.groupBox_Fis_face.TabStop = false;
            // 
            // maskedTextBox_INN_fis_face
            // 
            this.maskedTextBox_INN_fis_face.Location = new System.Drawing.Point(185, 244);
            this.maskedTextBox_INN_fis_face.Name = "maskedTextBox_INN_fis_face";
            this.maskedTextBox_INN_fis_face.Size = new System.Drawing.Size(122, 22);
            this.maskedTextBox_INN_fis_face.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(105, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 26);
            this.label8.TabIndex = 14;
            this.label8.Text = "ИНН: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(29, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 52);
            this.label7.TabIndex = 12;
            this.label7.Text = "Адрес\r\nрегистрации: ";
            // 
            // textBox_address_fis_fase
            // 
            this.textBox_address_fis_fase.Location = new System.Drawing.Point(185, 176);
            this.textBox_address_fis_fase.Multiline = true;
            this.textBox_address_fis_fase.Name = "textBox_address_fis_fase";
            this.textBox_address_fis_fase.Size = new System.Drawing.Size(222, 52);
            this.textBox_address_fis_fase.TabIndex = 13;
            // 
            // maskedTextBox_number
            // 
            this.maskedTextBox_number.Location = new System.Drawing.Point(448, 138);
            this.maskedTextBox_number.Name = "maskedTextBox_number";
            this.maskedTextBox_number.Size = new System.Drawing.Size(71, 22);
            this.maskedTextBox_number.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(263, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 26);
            this.label6.TabIndex = 10;
            this.label6.Text = "номер паспорта: ";
            // 
            // maskedTextBox_series
            // 
            this.maskedTextBox_series.Location = new System.Drawing.Point(185, 138);
            this.maskedTextBox_series.Name = "maskedTextBox_series";
            this.maskedTextBox_series.Size = new System.Drawing.Size(59, 22);
            this.maskedTextBox_series.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(1, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 26);
            this.label5.TabIndex = 8;
            this.label5.Text = "серия паспорта: ";
            // 
            // groupBox_company
            // 
            this.groupBox_company.Controls.Add(this.maskedTextBox_bank);
            this.groupBox_company.Controls.Add(this.label11);
            this.groupBox_company.Controls.Add(this.maskedTextBox_INN_UR_face);
            this.groupBox_company.Controls.Add(this.label9);
            this.groupBox_company.Controls.Add(this.label10);
            this.groupBox_company.Controls.Add(this.textBox_companyAddress);
            this.groupBox_company.Controls.Add(this.label13);
            this.groupBox_company.Controls.Add(this.textBox_companyName);
            this.groupBox_company.Location = new System.Drawing.Point(9, 63);
            this.groupBox_company.Name = "groupBox_company";
            this.groupBox_company.Size = new System.Drawing.Size(623, 295);
            this.groupBox_company.TabIndex = 9;
            this.groupBox_company.TabStop = false;
            // 
            // maskedTextBox_bank
            // 
            this.maskedTextBox_bank.Location = new System.Drawing.Point(325, 127);
            this.maskedTextBox_bank.Name = "maskedTextBox_bank";
            this.maskedTextBox_bank.Size = new System.Drawing.Size(201, 22);
            this.maskedTextBox_bank.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(56, 123);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(243, 26);
            this.label11.TabIndex = 16;
            this.label11.Text = "Банковские реквизиты: ";
            // 
            // maskedTextBox_INN_UR_face
            // 
            this.maskedTextBox_INN_UR_face.Location = new System.Drawing.Point(325, 167);
            this.maskedTextBox_INN_UR_face.Name = "maskedTextBox_INN_UR_face";
            this.maskedTextBox_INN_UR_face.Size = new System.Drawing.Size(112, 22);
            this.maskedTextBox_INN_UR_face.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(230, 163);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 26);
            this.label9.TabIndex = 14;
            this.label9.Text = "ИНН: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(74, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(225, 26);
            this.label10.TabIndex = 12;
            this.label10.Text = "Юридический адрес: ";
            // 
            // textBox_companyAddress
            // 
            this.textBox_companyAddress.Location = new System.Drawing.Point(325, 58);
            this.textBox_companyAddress.Multiline = true;
            this.textBox_companyAddress.Name = "textBox_companyAddress";
            this.textBox_companyAddress.Size = new System.Drawing.Size(266, 52);
            this.textBox_companyAddress.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(6, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(293, 26);
            this.label13.TabIndex = 2;
            this.label13.Text = "Наименование организации: ";
            // 
            // textBox_companyName
            // 
            this.textBox_companyName.Location = new System.Drawing.Point(325, 22);
            this.textBox_companyName.Name = "textBox_companyName";
            this.textBox_companyName.Size = new System.Drawing.Size(266, 22);
            this.textBox_companyName.TabIndex = 3;
            // 
            // registration
            // 
            this.registration.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.registration.Location = new System.Drawing.Point(346, 364);
            this.registration.Name = "registration";
            this.registration.Size = new System.Drawing.Size(275, 68);
            this.registration.TabIndex = 11;
            this.registration.Text = "Зарегистрировать";
            this.registration.UseVisualStyleBackColor = true;
            this.registration.Click += new System.EventHandler(this.registration_Click);
            this.registration.MouseEnter += new System.EventHandler(this.registration_MouseEnter);
            this.registration.MouseLeave += new System.EventHandler(this.registration_MouseLeave);
            // 
            // exit
            // 
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exit.Location = new System.Drawing.Point(20, 364);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(205, 68);
            this.exit.TabIndex = 10;
            this.exit.Text = "Отмена";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            this.exit.MouseEnter += new System.EventHandler(this.exit_MouseEnter);
            this.exit.MouseLeave += new System.EventHandler(this.exit_MouseLeave);
            // 
            // RegistrationClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 445);
            this.Controls.Add(this.registration);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.groupBox_company);
            this.Controls.Add(this.groupBox_Fis_face);
            this.Controls.Add(this.groupBox1);
            this.Name = "RegistrationClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация клиента";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_Fis_face.ResumeLayout(false);
            this.groupBox_Fis_face.PerformLayout();
            this.groupBox_company.ResumeLayout(false);
            this.groupBox_company.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_firstname;
        private System.Windows.Forms.TextBox textBox_secondname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_thirdname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox_Fis_face;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_INN_fis_face;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_address_fis_fase;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_number;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_series;
        private System.Windows.Forms.GroupBox groupBox_company;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_INN_UR_face;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_companyAddress;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox_companyName;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_bank;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button registration;
        private System.Windows.Forms.Button exit;
    }
}