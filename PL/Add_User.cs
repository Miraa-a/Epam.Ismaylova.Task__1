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
    public partial class Add_User : Form
    {
        private User_Interface users_Logic = new User_Logic();
        public Add_User()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider2.Clear();
            if (String.IsNullOrWhiteSpace(textBox1.Text) || String.IsNullOrWhiteSpace(textBox2.Text) || String.IsNullOrWhiteSpace(textBox3.Text))
            {

                errorProvider2.SetError(button1, "Fill in all the fields");

            }
            else
            {
                TimeSpan age = DateTime.Now - dateTimePicker1.Value;
                var user = new User(textBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Value, age.Days / 365);
                try
                {
                    errorProvider1.Clear();
                    users_Logic.Add(user);
                    Close();
                }
                catch 
                {
                    errorProvider1.SetError(textBox1, "Such login already exist");
                }
                
            }
           
           
        }
    }
}
