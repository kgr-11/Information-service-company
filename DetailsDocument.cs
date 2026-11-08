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
    public partial class DetailsDocument : Form
    {
        //функция возвращающая контент в виде таблицы
        private DataTable convertRow(string cont,bool flag)
        {
            DataTable content = new DataTable();
            content.Columns.Add("Название продукта", typeof(string));
            if (!flag)
            {
                content.Columns.Add("Номер партии", typeof(string));
            }
            content.Columns.Add("Количество", typeof(string));
            if (!flag)
            {
                content.Columns.Add("Дата поступления", typeof(string));
            }
            if (flag)
            {
                content.Columns.Add("Единица измерения", typeof(string));
            }
            if (flag)//если это не акт, а заказ
            {
                content.Columns.Add("Продажная цена за все количество", typeof(string));
                content.Columns.Add("Закупочная цена за все количество", typeof(string));
            }
            //извлечение контента
            string[]rows = cont.Split('\n');//отделили строки
            for (int i = 0; i < rows.Length-1; i++)
            {
                string[] parts_row = rows[i].Split(';');
                string[] result_row=new string[parts_row.Length];//0-название, 1-количество, 2-ед изм, 3-продажная цена, 4-закупочная цена
                for (int j = 0; j < parts_row.Length; j++)
                {
                    int index = parts_row[j].IndexOf(": ")+": ".Length;
                    result_row[j] = parts_row[j].Substring(index);
                }
                content.Rows.Add(result_row);
            }
            if (flag)
            {
                //добавление столбца с прибылью
                content.Columns.Add("Чистая прибыль", typeof(string));
                decimal all_finish_price = 0;
                decimal all_start_price = 0;
                
                for (int i = 0; i < content.Rows.Count; i++)
                {
                    all_finish_price += Convert.ToDecimal(content.Rows[i]["Продажная цена за все количество"]);
                    all_start_price += Convert.ToDecimal(content.Rows[i]["Закупочная цена за все количество"]);
                    content.Rows[i]["Чистая прибыль"] = (Convert.ToDecimal(content.Rows[i]["Продажная цена за все количество"])- Convert.ToDecimal(content.Rows[i]["Закупочная цена за все количество"])).ToString();
                    
                }
                string[] lastRow = { "", "", "", all_finish_price.ToString(), all_start_price.ToString() ,(all_finish_price- all_start_price).ToString() };
                content.Rows.Add(lastRow);
            }
            return content;
        }
        public DetailsDocument(string type_doc,string number_doc,DateTime create,DateTime delete, string content)
        {
            InitializeComponent();
            textBox_type_doc.Text = type_doc;
            textBox_number_doc.Text = number_doc;
            dateTimePicker_create_doc.Value = create;
            dateTimePicker_delete_doc.Value = delete;
            textBox_number_doc.ReadOnly = true; 
            textBox_type_doc.ReadOnly = true;
            dateTimePicker_create_doc.Enabled = false;
            dateTimePicker_delete_doc.Enabled = false;


            dataGridView_content.Rows.Clear();
            dataGridView_content.Columns.Clear();
            bool flag=false;
            if (type_doc == "Накладная")
            { 
                flag = true;
            }    
            dataGridView_content.DataSource = convertRow(content,flag);
            dataGridView_content.ReadOnly = true;
            dataGridView_content.AllowUserToAddRows = false;
            dataGridView_content.AllowUserToDeleteRows = false;
            dataGridView_content.DefaultCellStyle.Font = new Font("Times New Roman", 10);//стиль самих ячеек
            dataGridView_content.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
        }
    }
}
