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
    public partial class Billing : Form
    {
        public Billing()
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


        int key = 0,stock=0;

        private void BookDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BTitleTb.Text = BookDGV.SelectedRows[0].Cells[1].Value.ToString();
            //QtyTb.Text = BookDGV.SelectedRows[0].Cells[2].Value.ToString();
           // BCatCb.SelectedItem = BookDGV.SelectedRows[0].Cells[3].Value.ToString();
            //QtyTb.Text = BookDGV.SelectedRows[0].Cells[4].Value.ToString();
            PriceTb.Text = BookDGV.SelectedRows[0].Cells[5].Value.ToString();


            if (BTitleTb.Text == "")
            {
                key = 0;
                stock = 0;
            }

            else
            {

                key = Convert.ToInt32(BookDGV.SelectedRows[0].Cells[0].Value.ToString());
                stock = Convert.ToInt32(BookDGV.SelectedRows[0].Cells[4].Value.ToString());

            }


        }

        private void Billing_Load(object sender, EventArgs e)
        {

        }

        private void updateBook()
        {
            int newQty = stock - Convert.ToInt32(QtyTb.Text);

                try
                {

                DataAccess dataAccess = new DataAccess();
                string query = "update BookTbl set BQty='" + newQty + "' where BId='" + key + "';";
                dataAccess.ExecuteDMLQuery(query);
                //MessageBox.Show("Data Updated!");
                populate();
                Reset();

            }

                catch (Exception Ex)
                {

                    MessageBox.Show("Ex.message");
                }



        }

        int n = 0,Grdtotal=0;
        private void SaveBtn_Click(object sender, EventArgs e)
        {
           
            if(QtyTb.Text=="" || Convert.ToInt32(QtyTb.Text)>stock)
            {


                MessageBox.Show("Out of Stock");
            }

            else
            {

                int total = Convert.ToInt32(QtyTb.Text) * Convert.ToInt32(PriceTb.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(BillDGV);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = BTitleTb.Text;
                newRow.Cells[2].Value = QtyTb.Text;
                newRow.Cells[3].Value = PriceTb.Text;
                newRow.Cells[4].Value = total;
                BillDGV.Rows.Add(newRow);
                n++;
                updateBook();
                Grdtotal = Grdtotal + total;
                Totalbil.Text = "Taka. "+ Grdtotal;

            }


        }
        public void Reset()
        {

            BTitleTb.Text = "";
            QtyTb.Text = "";
            PriceTb.Text = "";
            

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
