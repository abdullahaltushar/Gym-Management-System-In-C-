using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gym1
{
    public partial class payment : Form
    {
        public payment()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hp\Documents\GymDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void FillName()
        {
            Con.Open();
            SqlCommand sql = new SqlCommand("select MName from MemberTbl", Con);
            SqlDataReader sdr;
            sdr = sql.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("MName", typeof(string));
            dataTable.Load(sdr);
            membertbl.ValueMember = "MName";
            membertbl.DataSource = dataTable;
            Con.Close();
        }
        private void FilterByName()
        {
            Con.Open();
            string query = "select * from paymentTbl where PMember='"+SearchName.Text+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            paymentSDG.DataSource = ds.Tables[0];

            Con.Close();
        }

        private void populate()
        {
            Con.Open();
            string query = "select * from paymentTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            paymentSDG.DataSource = ds.Tables[0];

            Con.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            membertbl.Text = "";
            amounttbl.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mainform mainform = new Mainform();
            mainform.Show();
            this.Hide();
        }

        private void membertbl_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void payment_Load(object sender, EventArgs e)
        {
            FillName();
            populate();
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            if(membertbl.Text==""|| amounttbl.Text == "")
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                string period = Period.Value.Month.ToString() + Period.Value.Year.ToString();
                Con.Open();

                SqlDataAdapter sda = new SqlDataAdapter(" select count(*) from paymentTbl where PMember='" + membertbl.SelectedValue.ToString() + "' and PMonth='" + period + "' ", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("Already paid this amount");
                }
                else
                {
                    string query=" insert into paymentTbl values('"+period+"','"+membertbl.SelectedValue.ToString()+"'," + amounttbl.Text + ")";
                    SqlCommand sql = new SqlCommand(query, Con);
                    sql.ExecuteNonQuery();
                    MessageBox.Show("Amount paid successfully");


                }

                Con.Close();
                populate();

            }
        }

        private void paymentSDG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SearchName_Click(object sender, EventArgs e)
        {
            FilterByName();
            SearchName.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            populate();
        }
    }
}
