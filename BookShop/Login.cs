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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        public static string User = "";
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UserTb.Text == "admin" || PassTb.Text == "admin555")
            {
                Books obj = new Books();
                obj.Show();
                this.Hide();
            }


            else if(UserTb.Text == "" || PassTb.Text == "admin")
            {


                MessageBox.Show("Invalid User or Password !");



            }





            else
            {

                DataAccess da = new DataAccess();
                DataTable dt = da.ExecuteQueryTable("select count(*) From UserTbl where UName='" + UserTb.Text + "' and UPass='" + PassTb.Text + "'");
                if (dt.Rows[0][0].ToString()=="1")
                {
                    User = UserTb.Text;
                    Billing obj = new Billing();
                    obj.Show();
                    this.Hide();
                
                }

                else
                {
                    MessageBox.Show("Invalid User or Password !");



                }

                

            }
        }

        private void UserTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
          
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PassTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
