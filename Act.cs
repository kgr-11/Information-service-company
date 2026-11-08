using MySql.Data.MySqlClient;
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
    public partial class Act : Form
    {
        DataTable parties;//все не списанные еще партии
        string connectionString;
        void foo()
        {
            dataGridView_result.DataSource = null;
            dataGridView_result.Rows.Clear();
            dataGridView_result.Columns.Clear();

            DateTime date = dateTimePicker1.Value;
            DataTable result = parties.Clone();
            result.Rows.Clear();
            //добавим столбцы как в Products
            for (int i = 0; i < parties.Rows.Count; i++)
            {
                DataRow row = parties.Rows[i];

                DateTime storage_date = DateTime.Parse(row["Дата истечения срока хранения"].ToString());
                bool flag = storage_date < date;
                if (flag)//здесь сравнения дат !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                {
                    result.ImportRow(row);
                }
            }
            //составили таблицу списания
            dataGridView_result.DataSource = result;

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.Name = "SelectColumn";
            checkBoxColumn.HeaderText = "Выбор списания";
            checkBoxColumn.Width = 50;
            dataGridView_result.Columns.Insert(0, checkBoxColumn);

            foreach (DataGridViewRow row in dataGridView_result.Rows)
            {
                row.Cells["SelectColumn"].Value = false;
            }
            dataGridView_result.ReadOnly = false;
            for (int i = 1; i < dataGridView_result.Columns.Count; i++)
            {
                dataGridView_result.Columns[i].ReadOnly = true;
            }
            dataGridView_result.AllowUserToAddRows = false;
            dataGridView_result.AllowUserToDeleteRows = false;
            button_act.Enabled = true;
            dataGridView_result.Columns["id_partie"].Visible = false;//ID не отображаем
        }
        public Act(string connectionString,DataTable parties)
        {
            InitializeComponent();
            this.connectionString = connectionString;   
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.parties = parties;
            button_act.Enabled = true;
            dataGridView_result.DataSource= parties;//загрузка всех партий не списанных партий
            dataGridView_result.Columns["id_partie"].Visible = false;//ID не отображаем
            dataGridView_result.ReadOnly = true;
            dataGridView_result.AllowUserToAddRows = false;
            dataGridView_result.AllowUserToDeleteRows = false;

            //-- чтобы при открытии были  партии на актуальную дату
            //очистка прошлого результата
            foo();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            foo();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; 
            Close();
        }


        private void button_act_Click(object sender, EventArgs e)
        {
            //принудительно завершаем редактирование
            dataGridView_result.EndEdit();

            List<int> indexPartie = new List<int>();//индексы партий, которые списываем

            List<string> id_Partie = new List<string>();// id партий, которые списываем

            List<int> indexDel = new List<int>();//индексы удаляемых строк из dataGridView
            int k = 0;
            foreach (DataGridViewRow row in dataGridView_result.Rows)
            {
                bool flag = Convert.ToBoolean(row.Cells["SelectColumn"].EditedFormattedValue);
                if (flag == true)
                {
                    id_Partie.Add(Convert.ToString(row.Cells["id_partie"].Value));
                    indexDel.Add(k);
                }
                k++;
            }
            if (indexDel.Count() == 0)
            {
                MessageBox.Show("Не было выбрано что списывать!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //что мы списываем
            string contentAct = "";
            for (int i = indexDel.Count() - 1; i >= 0; i--)
            {
                DataGridViewRow rowAct = dataGridView_result.Rows[indexDel[i]];

                contentAct += "Название продукта: " + rowAct.Cells["Название продукта"].Value.ToString() + ";Номер партии: " + rowAct.Cells["Номер партии"].Value.ToString() + ";Количество: " + rowAct.Cells["Количество"].Value.ToString() + " " + rowAct.Cells["Единица измерения"].Value.ToString()
                    + ";Дата поступления: " + rowAct.Cells["Дата поступления"].Value.ToString() + "\n";  
                dataGridView_result.Rows.RemoveAt(indexDel[i]);//удаляем запись из отображаемой таблицы
                parties.Rows.RemoveAt(indexDel[i]);
            }
            //dataGridView_result.Columns.RemoveAt(0);//удаляем столбец чек-боксов

            //дальше прям здесь сделаем списывание и опять отобразим не списанные партии без фильтра
            DateTime date = dateTimePicker1.Value;
            //создание записи акта в таблицу актов
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("", conn);
            //изменение статуса партии
            for (int i = 0; i < id_Partie.Count(); i++)
            {
                string updateStatusPartie = @"USE corparation;
                                              UPDATE parties
                                              SET status ='Списана'
                                              WHERE id_partie=@id;";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id_Partie[i]);
                cmd.CommandText= updateStatusPartie;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            string number_act = "АКТ-"+new Random().Next(1,5000).ToString(); 
            string insertAct = @"USE corparation;
                                 INSERT INTO act(number_act,content,date_act)
                                 VALUES (@number_act,@contentAct,@date);";
            cmd.CommandText = insertAct;
            cmd.Parameters.AddWithValue("@number_act", number_act);
            cmd.Parameters.AddWithValue("@contentAct", contentAct);
            cmd.Parameters.AddWithValue("@date", date);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            //создание записи в таблицу документа
            string selectAct = @"USE corparation;
                                 SELECT id
                                 FROM act
                                 WHERE number_act=@number_act;";
            cmd.CommandText = selectAct;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@number_act", number_act);
            conn.Open();
            string id_act=cmd.ExecuteScalar().ToString();

            string insert_doc = @"USE corparation;
                                  INSERT INTO documents(type_doc,id_act,number_doc)
                                  VALUES ('act',@id_act,@number_doc);";
            cmd.CommandText = insert_doc;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id_act", id_act);
            cmd.Parameters.AddWithValue("@number_doc","ДОКУМЕНТ-"+new Random().Next(1,5000).ToString("D4") );
            cmd.ExecuteNonQuery();
            //создание связей документа с партиями
            string select_ID_doc = @"USE corparation;
                                   SELECT id_doc
                                   FROM documents
                                   WHERE id_act=@id_act;";
            cmd.CommandText = select_ID_doc;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id_act", id_act);
            string id_doc = cmd.ExecuteScalar().ToString();
            for (int i = 0; i < id_Partie.Count(); i++)
            {
                string insert_connection = @"USE corparation;
                                        INSERT INTO connectioin_product_and_documents(id_partie,id_doc)
                                        VALUES (@id_partie,@id_doc);";
                cmd.CommandText = insert_connection;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_doc", id_doc);
                cmd.Parameters.AddWithValue("@id_partie", id_Partie[i]);
                cmd.ExecuteNonQuery();  
            }
            conn.Close();



            button_act.Enabled = true;
        }
    }
}
