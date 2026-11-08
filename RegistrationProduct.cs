using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace DB2
{
    public partial class RegistrationProduct : Form
    {
        private List<string> section;
        private List<List<string>> cells;
        DataTable products;
        public RegistrationProduct(List<string> sec, List<List<string>> c,DataTable prs)
        {
            InitializeComponent();
            section= sec;   
            cells= c;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            comboBox_unit.Text = "Выберите единицу измерения";
            comboBox_forPrice.SelectedIndex = 0;
            for (int i = 0; i < section.Count(); i++)
            { 
                comboBox_section.Items.Add(section[i]);
            }
            comboBox_section.Text = "Выберите секцию";
            comboBox_cells.Text= "Сначала выберите секцию";
            comboBox_cells.Enabled = false;

            products = prs;
            comboBox_products.DataSource = products;
            comboBox_products.DisplayMember = "name_product";
            comboBox_products.ValueMember = "id_product";
            comboBox_products.SelectedIndex = 0;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public string id_product;
        public decimal productCount;
        public string unit_measure;
        public string delivery_date;
        public string expiration_date;
        public int temperature;
        public decimal purchase_price;
        public string id_cell;
        public string number_partie;
        private void registration_Click(object sender, EventArgs e)
        {
            id_product = comboBox_products.SelectedValue.ToString();
            if (textBox_productCount.Text == "" || textBox_price.Text == "")
            {
                MessageBox.Show("Для регистрации товара необходимо заполнить все поля", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            productCount =Convert.ToDecimal(textBox_productCount.Text);
            unit_measure = comboBox_unit.Text;
            delivery_date=dateTimePicker1.Text;
            expiration_date=dateTimePicker2.Text;
            temperature = Convert.ToInt32(numericUpDown_temper.Value);
            purchase_price = Convert.ToDecimal(textBox_price.Text);
            if (comboBox_forPrice.SelectedIndex == 1)
            {
                purchase_price *= 1000;
            }
            else if (comboBox_forPrice.SelectedIndex == 2)
            {
                purchase_price *= 1000000;
            }
            else if (comboBox_forPrice.SelectedIndex == 3)
            {
                purchase_price *= 1000000000;
            }
            for (int i = 0; i < cells.Count(); i++)
            {
                if (cells[i][1] == comboBox_section.Text && cells[i][2] == comboBox_cells.Text)
                { 
                    id_cell=cells[i][0];
                    break;
                }
            }
            if (productCount <=0)
            {
                MessageBox.Show("Недоступное число для количества товара", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (unit_measure == "Выберите единицу измерения")
            {
                MessageBox.Show("Для регистрации товара необходимо выбрать единичу измерения товара", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (comboBox_section.Text == "Выберите секцию" || comboBox_cells.Text == "Сначала выберите секцию"|| comboBox_cells.Text== "Выберите ячейку"|| comboBox_cells.Text == "Секция переполнена")
            {
                MessageBox.Show("Для регистрации товара необходимо выбрать ячейку для его хранения", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            number_partie="ПАРТИЯ-"+new Random().Next(1,999999).ToString("D6");
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

        private void registration_MouseEnter(object sender, EventArgs e)
        {
            registration.BackColor = Color.Green;
            registration.Cursor = Cursors.Hand;
        }

        private void registration_MouseLeave(object sender, EventArgs e)
        {
            registration.BackColor = SystemColors.Control;
            registration.Cursor = Cursors.Default;
        }

        private void comboBox_section_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_cells.Items.Clear();
            comboBox_cells.Text = string.Empty;
            for (int i = 0; i < cells.Count(); i++)
            {
                if (cells[i][1] == comboBox_section.Text)
                {
                    comboBox_cells.Items.Add(cells[i][2]);
                }
            }
            if (comboBox_cells.Items.Count == 0)
            {
                MessageBox.Show("Данная секция переполнена.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox_cells.Text = "Секция переполнена";
                comboBox_cells.Enabled =false;
                return;
            }
            comboBox_cells.Text = "Выберите ячейку";
            comboBox_cells.Enabled=true;
        }
    }
}
