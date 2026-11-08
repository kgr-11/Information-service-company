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
    public partial class RegistrationClient : Form
    {
        public string connectionString;
        public RegistrationClient(string connStr)
        {
            InitializeComponent();
            maskedTextBox_series.Mask = "00 00";
            maskedTextBox_number.Mask = "000000";
            maskedTextBox_INN_fis_face.Mask = "00 00 000000 00";
            maskedTextBox_INN_UR_face.Mask = "00 00 00000 0";
            maskedTextBox_bank.Mask = "00000000000000000000";
            comboBox1.SelectedIndex = 0;
            connectionString = connStr;
        }

        public int flag;//выбор кого регаем
                        //для физ лица
        public string firstname;
        public string secondname;
        public string thirdname;
        public string serie_passport;
        public string number_passport;
        public string address;
        public string INN_phys;
        //для юр лица
        public string nameCompany;
        public string addressCompany;
        public string bank;
        public string INN_UR;

        private void exit_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void registration_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
            if (comboBox1.SelectedIndex == 0)
            {
                flag = 1;
                firstname = textBox_firstname.Text;
                secondname = textBox_secondname.Text;
                thirdname = textBox_thirdname.Text;
                serie_passport = maskedTextBox_series.Text.Replace(" ", "").Replace("_", "");
                number_passport = maskedTextBox_number.Text.Replace(" ", "").Replace("_", "");
                address = textBox_address_fis_fase.Text;
                INN_phys = maskedTextBox_INN_fis_face.Text.Replace(" ", "").Replace("_", "");
                if (firstname == "" || secondname == "" || thirdname == "" || serie_passport == "" || number_passport == "" || address == "" || INN_phys == "")
                {
                    MessageBox.Show("Необходимо заполнить все поля данных.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
                    return;
                }
                //проверка есть ли такой тип в базе
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string checkPerson = @"USE corparation;
                                SELECT 1
                                FROM physical_person
                                WHERE serie_passport=@serie_passport AND number_passport=@number_passport OR INN=@INN_phys;";
                MySqlCommand cmd = new MySqlCommand(checkPerson, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@firstname", firstname);
                cmd.Parameters.AddWithValue("@secondname", secondname);
                cmd.Parameters.AddWithValue("@thirdname", thirdname);
                cmd.Parameters.AddWithValue("@serie_passport", serie_passport);
                cmd.Parameters.AddWithValue("@number_passport", number_passport);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@INN_phys", INN_phys);
                if (Convert.ToInt32(cmd.ExecuteScalar()) == 1)
                {
                    conn.Close();
                    MessageBox.Show("Данный пользователь уже есть в системе.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_thirdname.Text = "";
                    textBox_address_fis_fase.Text = "";
                    textBox_firstname.Text = "";
                    textBox_secondname.Text = "";
                    maskedTextBox_INN_fis_face.Text = "";
                    maskedTextBox_series.Text = "";
                    maskedTextBox_number.Text = "";
                    comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
                    return;
                }
                conn.Close();
            }
            else
            {
                flag = 2;
                nameCompany = textBox_companyName.Text;
                addressCompany = textBox_companyAddress.Text;
                bank = maskedTextBox_bank.Text.Replace(" ", "").Replace("_", "");
                INN_UR = maskedTextBox_INN_UR_face.Text.Replace(" ", "").Replace("_", "");
                if (nameCompany == "" || addressCompany == "" || bank == "" || INN_UR == "")
                {
                    MessageBox.Show("Необходимо заполнить все поля данных.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
                    return;
                }
                //проверка есть ли такое юр лицо в базе
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string check_legal_entity = @"USE corparation;
                                SELECT 1
                                FROM legal_entity
                                WHERE name_company=@nameCompany OR bank_data=@bank OR INN=@INN_UR;";
                MySqlCommand cmd = new MySqlCommand(check_legal_entity, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nameCompany", nameCompany);
                cmd.Parameters.AddWithValue("@addressCompany", addressCompany);
                cmd.Parameters.AddWithValue("@bank", bank);
                cmd.Parameters.AddWithValue("@INN_UR", INN_UR);
                if (Convert.ToInt32(cmd.ExecuteScalar()) == 1)
                {
                    conn.Close();
                    MessageBox.Show("Данная организация уже есть в системе.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_companyName.Text = "";
                    textBox_companyAddress.Text = "";
                    maskedTextBox_INN_UR_face.Text = "";
                    maskedTextBox_bank.Text = "";
                    comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
                    return;
                }
                conn.Close();
            }
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void exit_MouseEnter(object sender, EventArgs e)
        {
            exit.BackColor = Color.Red;
            exit.Cursor = Cursors.Hand;
        }
        private void exit_MouseLeave(object sender, EventArgs e)
        {
            exit.BackColor = SystemColors.Control;
            exit.Cursor = Cursors.Default;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                groupBox_company.Enabled = false;
                groupBox_company.Visible = false;
                groupBox_Fis_face.Enabled = true;
                groupBox_Fis_face.Visible = true;
                textBox_thirdname.Text = "";
                textBox_address_fis_fase.Text = "";
                textBox_firstname.Text = "";
                textBox_secondname.Text = "";
                maskedTextBox_INN_fis_face.Text = "";
                maskedTextBox_series.Text = "";
                maskedTextBox_number.Text = "";
            }
            else
            {
                groupBox_company.Enabled = true;
                groupBox_company.Visible = true;
                groupBox_Fis_face.Enabled = false;
                groupBox_Fis_face.Visible = false;
                textBox_companyName.Text = "";
                textBox_companyAddress.Text = "";
                maskedTextBox_INN_UR_face.Text = "";
                maskedTextBox_bank.Text = "";
            }
        }
    }
}
