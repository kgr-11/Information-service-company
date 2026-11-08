namespace DB2
{
    partial class GetProduct
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
            this.comboBox_select = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_act = new System.Windows.Forms.GroupBox();
            this.comboBox_act = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox_order = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_order = new System.Windows.Forms.ComboBox();
            this.button_get = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox_act.SuspendLayout();
            this.groupBox_order.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox_order);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox_select);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 116);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // comboBox_select
            // 
            this.comboBox_select.FormattingEnabled = true;
            this.comboBox_select.Items.AddRange(new object[] {
            "акту",
            "накладной"});
            this.comboBox_select.Location = new System.Drawing.Point(153, 15);
            this.comboBox_select.Name = "comboBox_select";
            this.comboBox_select.Size = new System.Drawing.Size(169, 24);
            this.comboBox_select.TabIndex = 0;
            this.comboBox_select.SelectedIndexChanged += new System.EventHandler(this.comboBox_select_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выдача товара по: ";
            // 
            // groupBox_act
            // 
            this.groupBox_act.Controls.Add(this.label2);
            this.groupBox_act.Controls.Add(this.comboBox_act);
            this.groupBox_act.Location = new System.Drawing.Point(12, 58);
            this.groupBox_act.Name = "groupBox_act";
            this.groupBox_act.Size = new System.Drawing.Size(329, 57);
            this.groupBox_act.TabIndex = 1;
            this.groupBox_act.TabStop = false;
            // 
            // comboBox_act
            // 
            this.comboBox_act.FormattingEnabled = true;
            this.comboBox_act.Location = new System.Drawing.Point(154, 15);
            this.comboBox_act.Name = "comboBox_act";
            this.comboBox_act.Size = new System.Drawing.Size(169, 24);
            this.comboBox_act.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Список актов: ";
            // 
            // groupBox_order
            // 
            this.groupBox_order.Controls.Add(this.label3);
            this.groupBox_order.Controls.Add(this.comboBox_order);
            this.groupBox_order.Location = new System.Drawing.Point(0, 45);
            this.groupBox_order.Name = "groupBox_order";
            this.groupBox_order.Size = new System.Drawing.Size(328, 57);
            this.groupBox_order.TabIndex = 2;
            this.groupBox_order.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Список накладных: ";
            // 
            // comboBox_order
            // 
            this.comboBox_order.FormattingEnabled = true;
            this.comboBox_order.Location = new System.Drawing.Point(153, 15);
            this.comboBox_order.Name = "comboBox_order";
            this.comboBox_order.Size = new System.Drawing.Size(169, 24);
            this.comboBox_order.TabIndex = 0;
            // 
            // button_get
            // 
            this.button_get.Location = new System.Drawing.Point(13, 135);
            this.button_get.Name = "button_get";
            this.button_get.Size = new System.Drawing.Size(328, 76);
            this.button_get.TabIndex = 2;
            this.button_get.Text = "Выдать";
            this.button_get.UseVisualStyleBackColor = true;
            this.button_get.Click += new System.EventHandler(this.button_get_Click);
            // 
            // GetProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 222);
            this.Controls.Add(this.button_get);
            this.Controls.Add(this.groupBox_act);
            this.Controls.Add(this.groupBox1);
            this.Name = "GetProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выдача товара";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_act.ResumeLayout(false);
            this.groupBox_act.PerformLayout();
            this.groupBox_order.ResumeLayout(false);
            this.groupBox_order.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_select;
        private System.Windows.Forms.GroupBox groupBox_act;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_act;
        private System.Windows.Forms.GroupBox groupBox_order;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_order;
        private System.Windows.Forms.Button button_get;
    }
}