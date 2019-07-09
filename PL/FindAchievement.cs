using BL;
using BL_Interface;
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
    public partial class FindAchievement : Form
    {
        private Achievement_Interface achievement_Logic = new Achievement_Logic();
        public FindAchievement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Enter the title");
            }
            
            else if (achievement_Logic.Exist_thisAchievement(textBox1.Text) == 0)
            {
                errorProvider2.SetError(textBox1, "There is no such achievement");
            }
            else
            {
                dataGridView1.DataSource = achievement_Logic.Find(textBox1.Text);
            }
        }
    }
}
