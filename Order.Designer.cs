namespace DB2
{
    partial class Order
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
            this.comboBox_client = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_type_client = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_price = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button_add = new System.Windows.Forms.Button();
            this.textBox_unit2 = new System.Windows.Forms.TextBox();
            this.textBox_price_count = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_unit = new System.Windows.Forms.TextBox();
            this.textBox_count = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_product = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_CategoryProduct = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_basket = new System.Windows.Forms.Button();
            this.button_order = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_client);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox_type_client);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 105);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Клиент";
            // 
            // comboBox_client
            // 
            this.comboBox_client.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_client.FormattingEnabled = true;
            this.comboBox_client.Location = new System.Drawing.Point(191, 67);
            this.comboBox_client.Name = "comboBox_client";
            this.comboBox_client.Size = new System.Drawing.Size(202, 27);
            this.comboBox_client.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Клиент: ";
            // 
            // comboBox_type_client
            // 
            this.comboBox_type_client.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_type_client.FormattingEnabled = true;
            this.comboBox_type_client.Items.AddRange(new object[] {
            "Физическое лицо",
            "Юридическое лицо"});
            this.comboBox_type_client.Location = new System.Drawing.Point(191, 30);
            this.comboBox_type_client.Name = "comboBox_type_client";
            this.comboBox_type_client.Size = new System.Drawing.Size(202, 27);
            this.comboBox_type_client.TabIndex = 1;
            this.comboBox_type_client.SelectedIndexChanged += new System.EventHandler(this.comboBox_type_client_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Тип клиента: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_price);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.button_add);
            this.groupBox2.Controls.Add(this.textBox_unit2);
            this.groupBox2.Controls.Add(this.textBox_price_count);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox_unit);
            this.groupBox2.Controls.Add(this.textBox_count);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.comboBox_product);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBox_CategoryProduct);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(13, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(406, 313);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Содержание заказа";
            // 
            // textBox_price
            // 
            this.textBox_price.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_price.Location = new System.Drawing.Point(219, 119);
            this.textBox_price.Name = "textBox_price";
            this.textBox_price.ReadOnly = true;
            this.textBox_price.Size = new System.Drawing.Size(75, 27);
            this.textBox_price.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(129, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 26);
            this.label7.TabIndex = 15;
            this.label7.Text = "Цена: ";
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(6, 226);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(394, 75);
            this.button_add.TabIndex = 14;
            this.button_add.Text = "Добавить в корзину";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // textBox_unit2
            // 
            this.textBox_unit2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_unit2.Location = new System.Drawing.Point(300, 196);
            this.textBox_unit2.Name = "textBox_unit2";
            this.textBox_unit2.ReadOnly = true;
            this.textBox_unit2.Size = new System.Drawing.Size(59, 27);
            this.textBox_unit2.TabIndex = 13;
            // 
            // textBox_price_count
            // 
            this.textBox_price_count.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_price_count.Location = new System.Drawing.Point(219, 196);
            this.textBox_price_count.Name = "textBox_price_count";
            this.textBox_price_count.Size = new System.Drawing.Size(75, 27);
            this.textBox_price_count.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(107, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 26);
            this.label6.TabIndex = 11;
            this.label6.Text = "Купить: ";
            // 
            // textBox_unit
            // 
            this.textBox_unit.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_unit.Location = new System.Drawing.Point(300, 157);
            this.textBox_unit.Name = "textBox_unit";
            this.textBox_unit.ReadOnly = true;
            this.textBox_unit.Size = new System.Drawing.Size(59, 27);
            this.textBox_unit.TabIndex = 10;
            // 
            // textBox_count
            // 
            this.textBox_count.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_count.Location = new System.Drawing.Point(219, 157);
            this.textBox_count.Name = "textBox_count";
            this.textBox_count.ReadOnly = true;
            this.textBox_count.Size = new System.Drawing.Size(75, 27);
            this.textBox_count.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(79, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 26);
            this.label5.TabIndex = 8;
            this.label5.Text = "Доступно: ";
            // 
            // comboBox_product
            // 
            this.comboBox_product.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_product.FormattingEnabled = true;
            this.comboBox_product.Location = new System.Drawing.Point(219, 80);
            this.comboBox_product.Name = "comboBox_product";
            this.comboBox_product.Size = new System.Drawing.Size(141, 27);
            this.comboBox_product.TabIndex = 7;
            this.comboBox_product.SelectedIndexChanged += new System.EventHandler(this.comboBox_product_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Товар: ";
            // 
            // comboBox_CategoryProduct
            // 
            this.comboBox_CategoryProduct.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_CategoryProduct.FormattingEnabled = true;
            this.comboBox_CategoryProduct.Location = new System.Drawing.Point(219, 43);
            this.comboBox_CategoryProduct.Name = "comboBox_CategoryProduct";
            this.comboBox_CategoryProduct.Size = new System.Drawing.Size(141, 27);
            this.comboBox_CategoryProduct.TabIndex = 5;
            this.comboBox_CategoryProduct.SelectedIndexChanged += new System.EventHandler(this.comboBox_CategoryProduct_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 26);
            this.label4.TabIndex = 4;
            this.label4.Text = "Категория товара: ";
            // 
            // button_basket
            // 
            this.button_basket.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_basket.Location = new System.Drawing.Point(19, 444);
            this.button_basket.Name = "button_basket";
            this.button_basket.Size = new System.Drawing.Size(394, 75);
            this.button_basket.TabIndex = 2;
            this.button_basket.Text = "Корзина";
            this.button_basket.UseVisualStyleBackColor = true;
            this.button_basket.Click += new System.EventHandler(this.button_basket_Click);
            // 
            // button_order
            // 
            this.button_order.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_order.Location = new System.Drawing.Point(19, 525);
            this.button_order.Name = "button_order";
            this.button_order.Size = new System.Drawing.Size(394, 75);
            this.button_order.TabIndex = 3;
            this.button_order.Text = "Оформить заказ";
            this.button_order.UseVisualStyleBackColor = true;
            this.button_order.Click += new System.EventHandler(this.button_order_Click);
            this.button_order.MouseEnter += new System.EventHandler(this.button_order_MouseEnter);
            this.button_order.MouseLeave += new System.EventHandler(this.button_order_MouseLeave);
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 612);
            this.Controls.Add(this.button_order);
            this.Controls.Add(this.button_basket);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Order";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Оформление заказа";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_client;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_type_client;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_count;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_product;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_CategoryProduct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.TextBox textBox_unit2;
        private System.Windows.Forms.TextBox textBox_price_count;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_unit;
        private System.Windows.Forms.Button button_basket;
        private System.Windows.Forms.Button button_order;
        private System.Windows.Forms.TextBox textBox_price;
        private System.Windows.Forms.Label label7;
    }
}