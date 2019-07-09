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
    public partial class Main : Form
    {
        
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_User f = new Add_User();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Guest f = new Guest();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login f = new Login();
            f.Show();
        }
    }
}
