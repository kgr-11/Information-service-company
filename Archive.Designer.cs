namespace DB2
{
    partial class Archive
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
            this.dataGridView_arch = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_number_doc = new System.Windows.Forms.TextBox();
            this.button_details = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_arch)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView_arch);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(586, 526);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Архивированные документы";
            // 
            // dataGridView_arch
            // 
            this.dataGridView_arch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_arch.Location = new System.Drawing.Point(7, 30);
            this.dataGridView_arch.Name = "dataGridView_arch";
            this.dataGridView_arch.RowHeadersWidth = 51;
            this.dataGridView_arch.RowTemplate.Height = 24;
            this.dataGridView_arch.Size = new System.Drawing.Size(573, 490);
            this.dataGridView_arch.TabIndex = 0;
            this.dataGridView_arch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_arch_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_details);
            this.groupBox2.Controls.Add(this.textBox_number_doc);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(13, 546);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(586, 81);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Выбранный документ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Номер документа: ";
            // 
            // textBox_number_doc
            // 
            this.textBox_number_doc.Location = new System.Drawing.Point(193, 32);
            this.textBox_number_doc.Name = "textBox_number_doc";
            this.textBox_number_doc.Size = new System.Drawing.Size(170, 30);
            this.textBox_number_doc.TabIndex = 1;
            // 
            // button_details
            // 
            this.button_details.Location = new System.Drawing.Point(369, 19);
            this.button_details.Name = "button_details";
            this.button_details.Size = new System.Drawing.Size(204, 55);
            this.button_details.TabIndex = 2;
            this.button_details.Text = "Подробнее";
            this.button_details.UseVisualStyleBackColor = true;
            this.button_details.Click += new System.EventHandler(this.button_details_Click);
            // 
            // Archive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 638);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Archive";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Архив";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_arch)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView_arch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_details;
        private System.Windows.Forms.TextBox textBox_number_doc;
        private System.Windows.Forms.Label label1;
    }
}