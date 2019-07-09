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
    public partial class Guest : Form
    {
        private User_Interface users_Logic = new User_Logic();
        private Achievement_Logic achievement_Logic = new Achievement_Logic();
        public Guest()
        {
            InitializeComponent();
            comboBox1.DataSource = users_Logic.GetAll();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            User a = (User)comboBox1.SelectedItem;
            dataGridView1.DataSource = users_Logic.GetInfoUser(a.ID);
            dataGridView2.DataSource = achievement_Logic.YourAchievement(a.ID);
        }
    }
}
