using BL;
using BL_Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL
{
    public partial class UpdateAchievement : Form
    {
        private Achievement_Interface achievement_Logic = new Achievement_Logic();
        public UpdateAchievement()
        {
            InitializeComponent();
            comboBox1.DataSource = achievement_Logic.GetAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Enter the title");
            }
            else
            {
                Achievement c = (Achievement)comboBox1.SelectedItem;
                achievement_Logic.Update(c.ID, textBox1.Text);
                Close();
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
