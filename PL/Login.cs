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
    public partial class Login : Form
    {
        public static int id;
        private User_Interface users_Logic = new User_Logic();
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            id = users_Logic.Sign_In(textBox1.Text, textBox2.Text);
            if(id == -1)
            {
                errorProvider1.SetError(button1, "Wrong login or password");
            }
            else
            {
                errorProvider1.Clear();
                Close();
                Sign_in f = new Sign_in();
                f.Show();
            }
        }
    }
}
