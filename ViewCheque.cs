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
    public partial class ViewCheque : Form
    {
        private DataTable convertContent(string cont)
        {
            DataTable content = new DataTable();
            content.Columns.Add("Название продукта", typeof(string));
            content.Columns.Add("Количество", typeof(string));
            content.Columns.Add("Единица измерения", typeof(string));
            content.Columns.Add("Продажная цена за все количество", typeof(string));
            content.Columns.Add("Закупочная цена за все количество", typeof(string));

            //извлечение контента
            string[] rows = cont.Split('\n');//отделили строки
            for (int i = 0; i < rows.Length - 1; i++)
            {
                string[] parts_row = rows[i].Split(';');
                string[] result_row = new string[parts_row.Length];
                for (int j = 0; j < parts_row.Length; j++)
                {
                    int index = parts_row[j].IndexOf(": ") + ": ".Length;
                    result_row[j] = parts_row[j].Substring(index);
                }
                content.Rows.Add(result_row);
            }
            return content;
        }

        public ViewCheque(string number_cheque, string client, DateTime date, string content)
        {
            InitializeComponent();
            textBox_number.Text = number_cheque;
            textBox_client.Text = client;
             
            dateTimePicker1.Value = date;
            dateTimePicker1.Enabled = false;//запрет на изменение
            //здесь распаковка контента

            dataGridView1.DataSource = convertContent(content);
            decimal all_finish_price = 0;
            for(int i=0;i<dataGridView1.Rows.Count;i++)
            {
                all_finish_price += Convert.ToDecimal(dataGridView1.Rows[i].Cells["Продажная цена за все количество"].Value);
            }
            textBox_price.Text= all_finish_price.ToString();    
            dataGridView1.Columns["Закупочная цена за все количество"].Visible= false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            dataGridView1.DefaultCellStyle.Font = new Font("Timew New Roman", 10);
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
