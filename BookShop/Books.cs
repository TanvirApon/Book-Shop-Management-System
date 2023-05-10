using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BookShop
{
    public partial class Books : Form
    {
        public Books()
        {
            InitializeComponent();
            populate();
        }
       

        private void populate()
        {


            DataAccess da = new DataAccess();
            string query = "select * from BookTbl";
            DataSet ds = da.ExecuteQuery(query);
            BookDGV.DataSource = ds.Tables[0];


        }


        private void filter()
        {

            DataAccess dataAccess = new DataAccess();

            string query = "select * from BookTbl where BCat='" + CatCbSearch.SelectedItem.ToString() + "'";
            DataSet ds = dataAccess.ExecuteQuery(query);
            BookDGV.DataSource = ds.Tables[0];


        }


        public void Reset()
        {

            BTitleTb.Text ="";
            BauthTb.Text = "";
             QtyTb.Text = "";
            PriceTb.Text = "";
            BCatCb.SelectedIndex = -1;



        }

        private void Books_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(BTitleTb.Text==""||BauthTb.Text==""||QtyTb.Text==""||PriceTb.Text==""||BCatCb.SelectedIndex==-1)
            {
                MessageBox.Show("Missing Information !");
            }

            else
            {

               try
                {

                    DataAccess dataAccess = new DataAccess();
                    string query = "insert into BookTbl values('" + BTitleTb.Text + "','" + BauthTb.Text + "','" + BCatCb.SelectedItem.ToString() + "','" + QtyTb.Text + "','" + PriceTb.Text + "')";
                    int result = dataAccess.ExecuteDMLQuery(query);
                    if (result > 0)
                    {
                        MessageBox.Show("Data Inserted !");
                        populate();
                        Reset();
                    }
                    dataAccess.Sqlcon.Close();

                    populate();
                    Reset();

                }

                catch(Exception Ex)
                {

                    MessageBox.Show("Ex.message");
                }




            }




        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Users obj = new Users();
            obj.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (key==0)
            {
                MessageBox.Show("Missing Information !");
            }

            else
            {

                try
                {

                    DataAccess da = new DataAccess();
                    da.ExecuteDMLQuery("delete from BookTbl where BId=" + key + ";");
                    MessageBox.Show("Data Deleted !"); 
                    populate();
                    Reset();

                }

                catch (Exception Ex)
                {

                    MessageBox.Show("Ex.message");
                }




            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (BTitleTb.Text == "" || BauthTb.Text == "" || QtyTb.Text == "" || PriceTb.Text == "" || BCatCb.SelectedIndex == -1)
                {
                MessageBox.Show("Missing Information !");
            }

            else
            {

                try
                {

                    DataAccess da = new DataAccess();
                    string query = "update BookTbl set BTitle='" + BTitleTb.Text + "',BAuthor='" + BauthTb.Text + "',BCat='" + BCatCb.SelectedItem.ToString() + "',BQty='" + QtyTb.Text + "',BPrice='" + PriceTb.Text + "' where BId='" + key + "';";
                    da.ExecuteDMLQuery(query);
                    MessageBox.Show("Data Updated!");
                    populate();
                    Reset();

                }

                catch (Exception Ex)
                {

                    MessageBox.Show("Ex.message");
                }




            }


        }

        int key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
     
            BTitleTb.Text = BookDGV.SelectedRows[0].Cells[1].Value.ToString();
            BauthTb.Text = BookDGV.SelectedRows[0].Cells[2].Value.ToString();
            BCatCb.SelectedItem = BookDGV.SelectedRows[0].Cells[3].Value.ToString();
            QtyTb.Text = BookDGV.SelectedRows[0].Cells[4].Value.ToString();
            PriceTb.Text = BookDGV.SelectedRows[0].Cells[5].Value.ToString();


            if(BTitleTb.Text=="")
            {
                key = 0;

            }

            else
            {

                key = Convert.ToInt32(BookDGV.SelectedRows[0].Cells[0].Value.ToString());

            }




        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            populate();
            CatCbSearch.SelectedItem = -1;
        }

        private void CatCbSearch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            filter();
        }
    }
}
