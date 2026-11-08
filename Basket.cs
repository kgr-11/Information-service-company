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
    public partial class Basket : Form
    {
        public List<List<string>> basket;
        public Basket(List<List<string>> basket)
        {
            InitializeComponent();
            button_save.Enabled = false;
            this.basket = basket;
            DataTable dt = new DataTable();
            dt.Columns.Add("Название товара", typeof(string));
            dt.Columns.Add("Количество товара", typeof(string));
            dt.Columns.Add("Единица измерения", typeof(string));
            dt.Columns.Add("Цена", typeof(string));
            for (int i = 0; i < basket.Count(); i++)
            {
                DataRow row = dt.NewRow();
                row["Название товара"] = basket[i][0];
                row["Количество товара"] = basket[i][1];
                row["Единица измерения"] = basket[i][2];
                row["Цена"] = (Convert.ToDecimal(basket[i][3]) * Convert.ToDecimal(basket[i][1])).ToString();
                dt.Rows.Add(row);
            }
            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            dataGridView1.DefaultCellStyle.Font = new Font("Timew New Roman", 10);
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            if (basket.Count() == 0)
            {
                MessageBox.Show("Корзина пуста!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.Name = "SelectColumn";
            checkBoxColumn.HeaderText = "Удалить из корзины";
            dataGridView1.Columns.Insert(0, checkBoxColumn);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["SelectColumn"].Value = false;
            }
            dataGridView1.ReadOnly = false;
            for (int i = 1; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].ReadOnly = true;
            }
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            button_save.Enabled = true;
            button_edit.Enabled = false;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            List<int> index_del_row = new List<int>();//индексы удаляемых строк
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if ((bool)dataGridView1.Rows[i].Cells["SelectColumn"].Value)
                {
                    index_del_row.Add(i);
                }
            }
            dataGridView1.Columns.RemoveAt(0);
            //удаление строк из заказа и отображаемой таблицы
            for (int i = index_del_row.Count() - 1; i >= 0; i--)
            {
                dataGridView1.Rows.RemoveAt(index_del_row[i]);
                basket.RemoveAt(index_del_row[i]);
            }
            button_edit.Enabled = true;
            button_save.Enabled = false;
        }
    }
}
