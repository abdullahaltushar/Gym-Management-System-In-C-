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
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            AddMember addMember = new AddMember();
            addMember.Show();
            this.Hide();

        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            UpdateDelete update= new UpdateDelete();
            update.Show();
            this.Hide();
        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
            payment pay = new payment();
            pay.Show();
            this.Hide();
        }

        private void viewmember_Click(object sender, EventArgs e)
        {
            ViewMember viewMember = new ViewMember();
            viewMember.Show();
            this.Hide();

        }
    }
}
