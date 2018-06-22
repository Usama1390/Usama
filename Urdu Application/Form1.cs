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


namespace Urdu_Application
{
    public partial class UrduForm : Form
    {
        public UrduForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string qry = "Insert into EntryData(Name,FatherName) values (N'" + textBox1.Text + "',N'" + textBox2.Text + "')";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["testdb"].ConnectionString);
            SqlCommand com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.CommandText = qry;
            com.ExecuteNonQuery();
            con.Close();



            SqlCommand cmdDataBase = new SqlCommand("Select * from Entrydata", con);
           
           
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //textBox1.Text = dataGridView1.GetRowCellValue(dataGridView1.FocusedRowHandle, "Mileage").ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string qry = "UPDATE EntryData SET Name = N'" + textBox1.Text + "', FatherName= N'" + textBox2.Text + "' WHERE Id = '"+textBox3.Text+"'";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["testdb"].ConnectionString);
            SqlCommand com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.CommandText = qry;
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("اپ ڈیٹ مکمل");

            SqlCommand cmdDataBase = new SqlCommand("Select * from Entrydata", con);



            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string qry = "DELETE FROM EntryData WHERE Id='"+textBox3.Text+"'";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["testdb"].ConnectionString);
            SqlCommand com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.CommandText = qry;
            com.ExecuteNonQuery();
            con.Close();

            SqlCommand cmdDataBase = new SqlCommand("Select * from Entrydata", con);


            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["testdb"].ConnectionString);
            
            
            SqlCommand cmdDataBase= new SqlCommand("Select * from Entrydata",con);
            try{
                 SqlDataAdapter sda= new SqlDataAdapter();
                sda.SelectCommand=cmdDataBase;
                DataTable dbdataset=new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource=new BindingSource();
                bSource.DataSource=dbdataset;
                dataGridView1.DataSource=bSource;
                sda.Update(dbdataset);

            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string qry = " Select * from EntryData where Name='" + textBox1.Text + "'OR FatherName='" + textBox2.Text + "'";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["testdb"].ConnectionString);
            SqlCommand com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.CommandText = qry;
            com.ExecuteNonQuery();
            con.Close();

            SqlCommand cmdDataBase = new SqlCommand(" Select * from EntryData where Name=N'" + textBox1.Text + "'OR FatherName=N'" + textBox2.Text + "'", con);
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            textBox2.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            textBox1.Text = dataGridView1[2, e.RowIndex].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
