using Org.BouncyCastle.Bcpg;
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
    public partial class Order : Form
    {
        List<List<string>> clients;
        List<KeyValuePair<string, string>> phys_client;//id,имя
        List<KeyValuePair<string, string>> legal_client;//id,название 
        List<List<string>> catalog;

        public List<List<string>> order;
        public Order(List<List<string>> clients, List<List<string>> catalog)
        {
            InitializeComponent();
            order = new List<List<string>>();
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
            comboBox_type_client.SelectedIndex = 0;
            //заполнение информации по товарам
            this.catalog = catalog;
            for (int i = 0; i < catalog.Count(); i++)
            {
                bool flag = true;
                for (int j = 0; j < comboBox_CategoryProduct.Items.Count; j++)
                {
                    if (catalog[i][0] == comboBox_CategoryProduct.Items[j].ToString())
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    comboBox_CategoryProduct.Items.Add(catalog[i][0]);
                }
            }
            if (comboBox_CategoryProduct.Items.Count == 0)
            {
                comboBox_CategoryProduct.Text = "Склад пока пуст!";
                comboBox_CategoryProduct.Enabled = false;
                comboBox_product.Enabled = false;
                textBox_price_count.Enabled = false;
                button_add.Enabled = false;

                textBox_price.Enabled = false;
                textBox_unit.Enabled = false;
                textBox_unit2.Enabled = false;
                textBox_count.Enabled = false;
            }
            else
            {
                comboBox_CategoryProduct.SelectedIndex = 0;
            }

        }

        private void comboBox_type_client_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_client.DataSource = null;
            comboBox_type_client.SelectedIndexChanged -= comboBox_type_client_SelectedIndexChanged;
            if (comboBox_type_client.SelectedIndex == 0)//выбираем всех физ лиц
            {
                if (phys_client.Count() == 0)
                {
                    comboBox_client.Enabled = false;
                    comboBox_client.Text = "Покупателей данного типа пока нет!";
                }
                else
                {
                    comboBox_client.Enabled = true;
                    comboBox_client.DataSource = phys_client;
                    comboBox_client.DisplayMember = "Value";
                    comboBox_client.ValueMember = "Key";
                }

            }
            else //выбираем все юр лица
            {
                if (legal_client.Count() == 0)
                {
                    comboBox_client.Enabled = false;
                    comboBox_client.Text = "Покупателей данного типа пока нет!";
                }
                else
                {
                    comboBox_client.Enabled = true;
                    comboBox_client.DataSource = legal_client;
                    comboBox_client.DisplayMember = "Value";
                    comboBox_client.ValueMember = "Key";
                }
            }
            comboBox_type_client.SelectedIndexChanged += comboBox_type_client_SelectedIndexChanged;

        }
        private void func_for_category()
        {
            comboBox_product.Items.Clear();
            for (int i = 0; i < catalog.Count(); i++)
            {
                if (catalog[i][0] == comboBox_CategoryProduct.Text.ToString())
                {
                    comboBox_product.Items.Add(catalog[i][2]);
                }
            }
            if (comboBox_product.Items.Count == 0)
            {
                comboBox_product.Text = "Данная категория товаров пока пуста!";
                comboBox_product.Enabled = false;
                textBox_price_count.Enabled = false;
                button_add.Enabled = false;

                textBox_price.Enabled = false;
                textBox_unit.Enabled = false;
                textBox_unit2.Enabled = false;
                textBox_count.Enabled = false;
            }
            else
            {
                func_for_product();
                comboBox_product.SelectedIndex = 0;
            }
        }
        private void comboBox_CategoryProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox_CategoryProduct.SelectedIndexChanged -= comboBox_CategoryProduct_SelectedIndexChanged;
            func_for_category();
            comboBox_CategoryProduct.SelectedIndexChanged += comboBox_CategoryProduct_SelectedIndexChanged;
        }
        private void func_for_product()
        {
            for (int i = 0; i < catalog.Count(); i++)
            {
                if (catalog[i][2] == comboBox_product.Text.ToString())
                {
                    //отображение актуальной информации о товаре
                    //нужно учесть товары из корзины
                    decimal count_in_order = 0;
                    if (order.Count() != 0)
                    {
                        for (int k = 0; k < order.Count(); k++)
                        {
                            if (catalog[i][2] == order[k][0])
                            {
                                count_in_order += Convert.ToDecimal(order[k][1]);
                            }
                        }
                    }
                    textBox_count.Text = (Convert.ToDecimal(catalog[i][3]) - count_in_order).ToString();
                    textBox_unit.Text = catalog[i][4].ToString();
                    textBox_unit2.Text = catalog[i][4].ToString();
                    textBox_price.Text = catalog[i][5].ToString();
                    if (textBox_price.Text == "")
                    { 
                        textBox_price_count.Enabled= false;
                        MessageBox.Show("Товар нельзя купить пока на него не назначена продажная цена","Внимание!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        textBox_price_count.Enabled = true;
                    }

                        break;
                }
            }
        }
        private void comboBox_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_product.SelectedIndexChanged -= comboBox_product_SelectedIndexChanged;
            func_for_product();
            comboBox_product.SelectedIndexChanged += comboBox_product_SelectedIndexChanged;
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if(textBox_price_count.Text=="")
            {
                MessageBox.Show("Нельзя купить ничего, необходимо ввести количество покупаемого товара", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_price_count.Text = "";
                return;
            }
            decimal count_product_order = Convert.ToDecimal(textBox_price_count.Text);
            //проверка, что не больше того, что есть
            decimal count_all_product = Convert.ToDecimal(textBox_count.Text);
            if (count_product_order > count_all_product)
            {
                MessageBox.Show("Нельзя купить больше, чем есть на складе", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_price_count.Text = "";
                return;
            }
            if (count_product_order <= 0)
            {
                MessageBox.Show("Количество товара не может быть отрицательным и ли равным 0", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_price_count.Text = "";
                return;
            }

            bool flag = true;
            for (int i = 0; i < order.Count(); i++)
            {
                if (order[i][0] == comboBox_product.Text)
                {
                    order[i][1] = (Convert.ToDecimal(order[i][1]) + count_product_order).ToString();
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                order.Add(new List<string>() { comboBox_product.Text, textBox_price_count.Text, textBox_unit2.Text, textBox_price.Text });//товар, количество,единица измерения, цена

            }
            MessageBox.Show("Товар добавлен в корзину", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox_price.Text = "";
            textBox_count.Text = "";
            textBox_price_count.Text = "";
            textBox_unit.Text = "";
            textBox_unit2.Text = "";
            func_for_product();
        }

        private void button_basket_Click(object sender, EventArgs e)
        {
            Basket form = new Basket(order);
            form.ShowDialog();
            order = form.basket;
            func_for_product();
        }
        public string client_id;
        private void button_order_Click(object sender, EventArgs e)
        {
            if (order.Count() == 0)
            {
                MessageBox.Show("Добавьте товар в корзину, чтобы оформить заказ", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            client_id = "";
            if (comboBox_type_client.Text == "Физическое лицо")
            {
                for (int i = 0; i < phys_client.Count(); i++)
                {
                    if (phys_client[i].Value == comboBox_client.Text)
                    {
                        client_id = phys_client[i].Key;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < legal_client.Count(); i++)
                {
                    if (legal_client[i].Value == comboBox_client.Text)
                    {
                        client_id = legal_client[i].Key;
                        break;
                    }
                }
            }
            if (client_id == "")
            {
                MessageBox.Show("Нельзя оформить заказ, клиент указан неверно", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Заказ успешно оформлен", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button_order_MouseEnter(object sender, EventArgs e)
        {
            button_order.BackColor = Color.Green;
            button_order.Cursor = Cursors.Hand;
        }

        private void button_order_MouseLeave(object sender, EventArgs e)
        {
            button_order.BackColor = SystemColors.Control;
            button_order.Cursor = Cursors.Default;
        }
    }
}
