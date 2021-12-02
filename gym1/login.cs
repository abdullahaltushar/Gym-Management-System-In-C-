using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gym1
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void gunaCirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            nametxt.Text = "";
            passtxt.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(nametxt.Text=="" || passtxt.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else if(nametxt.Text=="abdullah" || passtxt.Text == "12345")
            {
                Mainform main = new Mainform();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Information");
            }
        }
    }
}
