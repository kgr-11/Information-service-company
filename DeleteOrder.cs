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
    public partial class DeleteOrder : Form
    {
        List<List<string>> clients;
        List<List<string>> order;
        List<KeyValuePair<string, string>> phys_client;//id,имя
        List<KeyValuePair<string, string>> legal_client;//id,название
        string connectionString;
        public DeleteOrder(List<List<string>> clients, List<List<string>> order, string connectionString)
        {
            InitializeComponent();
            this.clients = clients;
            //заполнение информации по клиенту
            this.clients = clients;
            phys_client = new List<KeyValuePair<string, string>>();
            legal_client = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < clients.Count(); i++)
            {
                if (clients[i][1] == "Физическое лицо")
                {
                    phys_client.Add(new KeyValuePair<string, string>(clients[i][0], clients[i][3]));
                }
                else if (clients[i][1] == "Юридическое лицо")
                {
                    legal_client.Add(new KeyValuePair<string, string>(clients[i][0], clients[i][3]));
                }
            }
            this.order = order;
            comboBox_type_client.SelectedIndex = 0;
            textBox_number_doc.ReadOnly = true;
            this.connectionString = connectionString;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            dataGridView1.DefaultCellStyle.Font = new Font("Timew New Roman", 10);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void comboBox_type_client_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_client.SelectedIndexChanged -= comboBox_client_SelectedIndexChanged;
            comboBox_client.DataSource = null;
            comboBox_client.SelectedIndexChanged += comboBox_client_SelectedIndexChanged;
            comboBox_type_client.SelectedIndexChanged -= comboBox_type_client_SelectedIndexChanged;
            if (comboBox_type_client.SelectedIndex == 0)//выбираем всех физ лиц
            {
                if (phys_client.Count() == 0)
                {
                    comboBox_client.Enabled = false;
                    comboBox_client.Text = "Покупателей данного типа пока нет!";
                    dataGridView1.DataSource = null;
                }
                else
                {
                    comboBox_client.Enabled = true;
                    comboBox_client.DataSource = phys_client;
                    comboBox_client.DisplayMember = "Value";
                    comboBox_client.ValueMember = "Key";
                    comboBox_client.SelectedIndex = 0;
                }

            }
            else //выбираем все юр лица
            {
                if (legal_client.Count() == 0)
                {
                    comboBox_client.Enabled = false;
                    comboBox_client.Text = "Покупателей данного типа пока нет!";
                    dataGridView1.DataSource = null;
                }
                else
                {
                    comboBox_client.Enabled = true;
                    comboBox_client.DataSource = legal_client;
                    comboBox_client.DisplayMember = "Value";
                    comboBox_client.ValueMember = "Key";
                    comboBox_client.SelectedIndex = 0;
                }
            }
            comboBox_type_client.SelectedIndexChanged += comboBox_type_client_SelectedIndexChanged;
        }

        private void comboBox_client_SelectedIndexChanged(object sender, EventArgs e)
        {
            string client_id = ((KeyValuePair<string, string>)comboBox_client.SelectedItem).Key;//принимаем сразу пару, приводим к типу и распоковываем
            DataTable dt = new DataTable();
            dt.Columns.Add("invoice_id", typeof(string));
            dt.Columns.Add("id_doc", typeof(string));
            dt.Columns.Add("Номер документа", typeof(string));
            dt.Columns.Add("Дата оформления заказа", typeof(string));
            dt.Columns.Add("client_id", typeof(string));
            for (int i = 0; i < order.Count(); i++)
            {
                if (client_id == order[i][4])
                {
                    DataRow row = dt.NewRow();
                    row["invoice_id"] = order[i][0];
                    row["id_doc"] = order[i][1];
                    row["Номер документа"] = order[i][2];
                    row["Дата оформления заказа"] = order[i][3];
                    row["client_id"] = order[i][4];
                    dt.Rows.Add(row);
                }
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["invoice_id"].Visible = false;
            dataGridView1.Columns["id_doc"].Visible = false;
            dataGridView1.Columns["client_id"].Visible = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // e.RowIndex - индекс строки, по которой кликнули
            // e.ColumnIndex - индекс колонки, по которой кликнули

            if (e.RowIndex >= 0)  // Проверка, что кликнут не по заголовку
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox_number_doc.Text = row.Cells["Номер документа"].Value.ToString();
            }
        }
        private void button_delete_Click(object sender, EventArgs e)
        {
            if (textBox_number_doc.Text == "")
            {
                MessageBox.Show("Сначала надо выбрать документ", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string doc_id = "";
                string invoice_id = "";
                for (int i = 0; i < order.Count(); i++)
                {
                    if (order[i][2] == textBox_number_doc.Text)
                    {
                        doc_id = order[i][1];
                        invoice_id = order[i][0];
                        break;
                    }
                }
                //теперь надо удалить заказ из dataGridView
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if ((string)dataGridView1.Rows[i].Cells["Номер документа"].Value == textBox_number_doc.Text)
                    {
                        dataGridView1.Rows.RemoveAt(i);
                        textBox_number_doc.Text = "";
                        break;
                    }
                }
                //удаление заказа из БД
                MySqlConnection conn = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand("", conn);


                //удаление связей с партиями
                string deleteConn = @"USE corparation;
                                     DELETE FROM connectioin_product_and_documents
                                     WHERE id_doc=@doc_id;";
                cmd.CommandText = deleteConn;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@doc_id", doc_id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                //удаление самого документа
                string deleteDoc = @"USE corparation;
                                     DELETE FROM documents
                                     WHERE id_doc=@doc_id;";
                cmd.CommandText = deleteDoc;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@doc_id", doc_id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                //удаление записи из invoice
                string deleteOrder = @"USE corparation;
                                     DELETE FROM invoice
                                     WHERE id=@invoice_id;";
                cmd.CommandText = deleteOrder;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@invoice_id", invoice_id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void button_delete_MouseEnter(object sender, EventArgs e)
        {
            button_delete.BackColor = Color.Red;
            button_delete.Cursor = Cursors.Hand;
        }

        private void button_delete_MouseLeave(object sender, EventArgs e)
        {
            button_delete.BackColor = SystemColors.Control;
            button_delete.Cursor = Cursors.Default;
        }
    }
}
