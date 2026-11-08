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
    public partial class Section : Form
    {
        private List<string> Sections;
        public Section(List<string> sections)
        {
            InitializeComponent();
            Sections = sections;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        public string nameSection;
        public int countCells;
        private void add_Click(object sender, EventArgs e)
        {
            nameSection =textBox_sectionName.Text;
            for (int i = 0; i < Sections.Count(); i++)
            {
                if (Sections[i] == nameSection)
                {
                    MessageBox.Show("Секция с таким названием уже существует.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_sectionName.Text = "";
                    return;
                }
            }
            countCells=Convert.ToInt32(numericUpDown_countCells.Value);
            DialogResult= DialogResult.OK;  
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

        private void add_MouseEnter(object sender, EventArgs e)
        {
            add.BackColor = Color.Green;
           add.Cursor = Cursors.Hand;
        }

        private void add_MouseLeave(object sender, EventArgs e)
        {
            add.BackColor = SystemColors.Control;
            add.Cursor = Cursors.Default;
        }

    }
}
