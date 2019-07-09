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
    public partial class AddUserAchievement : Form
    {
        private Achievement_Interface achievement_Logic = new Achievement_Logic();
        public AddUserAchievement()
        {
            InitializeComponent();
            comboBox1.DataSource = achievement_Logic.GetAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Achievement c = (Achievement)comboBox1.SelectedItem;
            achievement_Logic.AddUserAchievement(Login.id, c.ID);
            Close();
        }
    }
}
