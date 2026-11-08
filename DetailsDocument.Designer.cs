namespace DB2
{
    partial class DetailsDocument
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_content = new System.Windows.Forms.DataGridView();
            this.dateTimePicker_delete_doc = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_create_doc = new System.Windows.Forms.DateTimePicker();
            this.textBox_number_doc = new System.Windows.Forms.TextBox();
            this.textBox_type_doc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_content)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.dateTimePicker_delete_doc);
            this.groupBox1.Controls.Add(this.dateTimePicker_create_doc);
            this.groupBox1.Controls.Add(this.textBox_number_doc);
            this.groupBox1.Controls.Add(this.textBox_type_doc);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(734, 574);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView_content);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(6, 177);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(721, 390);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Содержание документа:";
            // 
            // dataGridView_content
            // 
            this.dataGridView_content.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_content.Location = new System.Drawing.Point(7, 30);
            this.dataGridView_content.Name = "dataGridView_content";
            this.dataGridView_content.RowHeadersWidth = 51;
            this.dataGridView_content.RowTemplate.Height = 24;
            this.dataGridView_content.Size = new System.Drawing.Size(708, 354);
            this.dataGridView_content.TabIndex = 0;
            // 
            // dateTimePicker_delete_doc
            // 
            this.dateTimePicker_delete_doc.Location = new System.Drawing.Point(257, 139);
            this.dateTimePicker_delete_doc.Name = "dateTimePicker_delete_doc";
            this.dateTimePicker_delete_doc.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker_delete_doc.TabIndex = 6;
            // 
            // dateTimePicker_create_doc
            // 
            this.dateTimePicker_create_doc.Location = new System.Drawing.Point(257, 97);
            this.dateTimePicker_create_doc.Name = "dateTimePicker_create_doc";
            this.dateTimePicker_create_doc.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker_create_doc.TabIndex = 7;
            // 
            // textBox_number_doc
            // 
            this.textBox_number_doc.Location = new System.Drawing.Point(257, 60);
            this.textBox_number_doc.Name = "textBox_number_doc";
            this.textBox_number_doc.Size = new System.Drawing.Size(200, 22);
            this.textBox_number_doc.TabIndex = 4;
            // 
            // textBox_type_doc
            // 
            this.textBox_type_doc.Location = new System.Drawing.Point(257, 19);
            this.textBox_type_doc.Name = "textBox_type_doc";
            this.textBox_type_doc.Size = new System.Drawing.Size(200, 22);
            this.textBox_type_doc.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(32, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Дата занесения в архив: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(13, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Дата создания документа: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(79, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Номер документа: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(101, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Тип документа: ";
            // 
            // DetailsDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 600);
            this.Controls.Add(this.groupBox1);
            this.Name = "DetailsDocument";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Детали документа";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_content)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView_content;
        private System.Windows.Forms.DateTimePicker dateTimePicker_delete_doc;
        private System.Windows.Forms.DateTimePicker dateTimePicker_create_doc;
        private System.Windows.Forms.TextBox textBox_number_doc;
        private System.Windows.Forms.TextBox textBox_type_doc;
    }
}