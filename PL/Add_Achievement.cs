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
    public partial class Add_Achievement : Form
    {
        private Achievement_Interface achievement_Logic = new Achievement_Logic();
        public Add_Achievement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Enter the title");
            }
            else
            {
                achievement_Logic.Add(new Achievement(textBox1.Text));
                Close();
            }
        }
    }
}
