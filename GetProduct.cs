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
    public partial class GetProduct : Form
    {
        
        public GetProduct(List<string> number_act, List<string> number_order)
        {
            InitializeComponent();
            comboBox_select.SelectedIndex = 0;
            for (int i = 0; i < number_act.Count(); i++)
            { 
                comboBox_act.Items.Add(number_act[i]);
            }
            for (int i = 0; i < number_order.Count(); i++)
            {
                comboBox_order.Items.Add(number_order[i]);
            }
            if (number_act.Count() != 0)
            {
                comboBox_act.SelectedIndex = 0;
            }
            else
            {
                comboBox_act.Text = "Актов еще нет!";
                comboBox_act.Enabled = false;
            }
            if (number_order.Count() != 0)
            {
                comboBox_order.SelectedIndex = 0;
            }
            else
            {
                comboBox_order.Text = "Накладных еще нет!";
                comboBox_order.Enabled = false;
            }

        }

        private void comboBox_select_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_select.SelectedIndexChanged -= comboBox_select_SelectedIndexChanged;
            if (comboBox_select.SelectedIndex == 0)
            {
                groupBox_act.Enabled = true;
                groupBox_act.Visible = true;
                groupBox_order.Enabled = false;
                groupBox_order.Visible = false;
            }
            else
            {
                groupBox_act.Enabled = false;
                groupBox_act.Visible = false;
                groupBox_order.Enabled = true;
                groupBox_order.Visible = true;
            }
            comboBox_select.SelectedIndexChanged += comboBox_select_SelectedIndexChanged;
        }

        public bool flag_act;
        public bool flag_order;
        public string number_doc;

        private void button_get_Click(object sender, EventArgs e)
        {
            comboBox_select.SelectedIndexChanged -= comboBox_select_SelectedIndexChanged;
            if (comboBox_select.SelectedIndex == 0)
            {
               flag_act = true;
               flag_order = false;
               number_doc = comboBox_act.Text;
                if (number_doc == "Актов еще нет!")
                {
                    MessageBox.Show("Нельзя выдать по несуществующему акту", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                flag_act = false;
                flag_order = true;
                number_doc = comboBox_order.Text;
                if (number_doc == "Накладных еще нет!")
                {
                    MessageBox.Show("Нельзя выдать по несуществующей накладной", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            comboBox_select.SelectedIndexChanged += comboBox_select_SelectedIndexChanged;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
