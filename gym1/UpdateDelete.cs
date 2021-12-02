using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace gym1
{
    public partial class UpdateDelete : Form
    {
        public UpdateDelete()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hp\Documents\GymDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            Con.Open();
            string query = "select * from memberTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            memberSDG.DataSource = ds.Tables[0];

            Con.Close();
        }


        int key = 0;

        private void memberSDG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key=Convert.ToInt32(memberSDG.SelectedRows[0].Cells[0].Value.ToString());
            nametb.Text =memberSDG.SelectedRows[0].Cells[1].Value.ToString();
            phonetb.Text= memberSDG.SelectedRows[0].Cells[2].Value.ToString();
            gendertb.Text= memberSDG.SelectedRows[0].Cells[3].Value.ToString();
            amounttb.Text= memberSDG.SelectedRows[0].Cells[4].Value.ToString();
            agetb.Text= memberSDG.SelectedRows[0].Cells[5].Value.ToString();
            timetb.Text= memberSDG.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void UpdateDelete_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nametb.Text = "";
            phonetb.Text = "";
            gendertb.Text = "";
            amounttb.Text = "";
            agetb.Text = "";
            timetb.Text = "";



        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mainform mainform = new Mainform();
            mainform.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the member to be deleted");

            }
            else
            {
                try
                {
                    Con.Open();

                    string query="delete from MemberTbl where Mid="+key+";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member delete successfully");
                    Con.Close();
                    populate();

                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0 || nametb.Text == "" || phonetb.Text == "" || gendertb.Text == "" || agetb.Text == "" || amounttb.Text == "" || timetb.Text == "") 
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    Con.Open();

                    string query = "update MemberTbl set MName='"+nametb.Text+"',MPhone='"+phonetb.Text+"',MGen='"+gendertb.Text+"',MAge='"+agetb.Text+"',MAmount='"+amounttb.Text+"',MTiming='"+timetb.Text+"' where MId="+key+";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member update successfully");
                    Con.Close();
                    populate();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }

        }
    }
}
