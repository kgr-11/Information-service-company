using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB2
{
    public partial class SalePrice : Form
    {
        private string stringConnection;
        DataTable products;
        public SalePrice(string strConn,DataTable pr)//передается таблица с id, названием товара и его среденей ценой
        {
            InitializeComponent();
            stringConnection = strConn;
            products = pr;
            comboBox_product.DataSource= products;
            comboBox_product.DisplayMember = "product";
            comboBox_product.ValueMember = "id";
            comboBox_product.SelectedIndex = 0;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; 
            Close();    
        }

        public string id;
        public decimal sale_price;
        private void add_Click(object sender, EventArgs e)
        {
            if (textBox_sale_price.Text == "")
            {
                MessageBox.Show("Необходимо ввести продажную цену товара", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            id = comboBox_product.SelectedValue.ToString();
            sale_price=Convert.ToDecimal(textBox_sale_price.Text);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void exit_MouseLeave(object sender, EventArgs e)
        {
            exit.BackColor = SystemColors.Control;
            exit.Cursor = Cursors.Default;
        }

        private void exit_MouseEnter(object sender, EventArgs e)
        {
            exit.BackColor = Color.Red;
            exit.Cursor = Cursors.Hand;
        }

        private void add_MouseEnter(object sender, EventArgs e)
        {
            add.BackColor = Color.Green;
            add.Cursor = Cursors.Hand;
        }

        private void add_MouseLeave(object sender, EventArgs e)
        {
            add.BackColor = SystemColors.Control;
            add.Cursor = Cursors.Default;
        }

        private void comboBox_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index= comboBox_product.SelectedIndex;
            DataRow dataRow=products.Rows[index];
            if (dataRow["avg_price"].ToString() == "0,00")
            {
                textBox_price.Text ="Товар отсутствует на складе";
            }
            else
            {
                textBox_price.Text = dataRow["avg_price"].ToString().Replace(".",",");
            }
            textBox_sale_price.Text = dataRow["sale_price"].ToString().Replace(".", ",");
        }
    }
}
