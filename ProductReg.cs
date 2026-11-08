using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB2
{
    public partial class ProductReg : Form
    {
        List<string> products;
        public ProductReg(List<string> pr)
        {
            InitializeComponent();
            products = pr; 
        }

        public string name;
        private void add_Click(object sender, EventArgs e)
        {
            name=textBox_product.Text;
            if (name == "")
            {
                MessageBox.Show("Названием товара не может быть пустая строка", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < products.Count(); i++)
            {
                if (products[i] == name)
                {
                    MessageBox.Show("Данный товар уже есть в системе", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            DialogResult = DialogResult.OK;
            Close();
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
    }
}
