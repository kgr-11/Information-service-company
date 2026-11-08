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
    public partial class Archive : Form
    {
        private DataTable arch;
        public Archive(DataTable arch)
        {
            InitializeComponent();
            this.arch = arch;
            dataGridView_arch.Rows.Clear();
            dataGridView_arch.Columns.Clear();
            dataGridView_arch.DataSource = arch;

            dataGridView_arch.Columns["id"].Visible = false;
            dataGridView_arch.Columns["content"].Visible = false;

            dataGridView_arch.ReadOnly = true;
            dataGridView_arch.AllowUserToAddRows = false;
            dataGridView_arch.AllowUserToDeleteRows = false;
            dataGridView_arch.DefaultCellStyle.Font = new Font("Times New Roman", 10);//стиль самих ячеек
            dataGridView_arch.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
        }

        private void button_details_Click(object sender, EventArgs e)
        {
            if (textBox_number_doc.Text == "")
            {
                MessageBox.Show("Сначала надо выбрать документ", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //нужно выбрать данные по заданному номеру и создать окно с данными выбранного документа
            string number_doc = textBox_number_doc.Text;
            //поиск нужно записи
            DataRow source_row = null;
            for (int i = 0; i < arch.Rows.Count; i++)
            { 
                DataRow row=arch.Rows[i];
                if (row["Номер документа"].ToString()==number_doc)
                {
                    source_row = row;
                    break;
                }
            }
            string type_doc = source_row["Тип документа"].ToString();
            DateTime create =Convert.ToDateTime(source_row["Дата создания документа"]);
            DateTime delete = Convert.ToDateTime(source_row["Дата занесения в архив"]);
            string content = source_row["content"].ToString();
            //создание еще одной формы и передача ей информации
            DetailsDocument form= new DetailsDocument(type_doc,number_doc,create,delete,content);
            form.ShowDialog();
            form.Dispose();
        }

        private void dataGridView_arch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // e.RowIndex - индекс строки, по которой кликнули
            // e.ColumnIndex - индекс колонки, по которой кликнули

            if (e.RowIndex >= 0)  // Проверка, что кликнут не по заголовку
            {
                DataGridViewRow row=dataGridView_arch.Rows[e.RowIndex];
                textBox_number_doc.Text = row.Cells["Номер документа"].Value.ToString(); 
            }
        }
    }
}
