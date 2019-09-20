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

namespace MyDemoForm1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            ShowItemsData();
        }

        SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\MyEXDatabase.mdf\";Integrated Security = True");

        private void Button1_Click(object sender, EventArgs e)
        {
            String ItemName = textBox1.Text;
            int ItemPrice = Int32.Parse(textBox2.Text);
            String ItemType = textBox4.Text;

            SqlCommand cmd = new SqlCommand("InsertItem", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@name", ItemName);
            cmd.Parameters.AddWithValue("@price", ItemPrice);
            cmd.Parameters.AddWithValue("@type", ItemType);


            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            con.Close();

            MessageBox.Show("Inserted Item");

            ShowItemsData();
        }
        private void ShowItemsData()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("ShowAllItems", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);

                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                con.Close();

                dataGridView1.DataSource = dataSet.Tables[0];

                this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
