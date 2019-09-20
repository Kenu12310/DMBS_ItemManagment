using System
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Stalin\source\repos\MyDemoForm1\MyDemoForm1\MyEXDatabase.mdf;Integrated Security = True
        //Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename="\MyEXDatabase.mdf";Integrated Security = True
        //Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename="|DataDirectory|\MyEXDatabase.mdf";Integrated Security = True
        //Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\MyEXDatabase.mdf\";Integrated Security = True

        SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\MyEXDatabase.mdf\";Integrated Security = True");
        SqlCommand cmd;
        SqlDataReader dr;
        
        private String getUserNameData()
        {
            con.Open();
            String syntax = "SELECT Val FROM AdminTable WHERE MyID = 'UserName'";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            String name = dr[0].ToString();
            con.Close();
            //MessageBox.Show(dr[0].ToString());
            return name;
        }
        private String getPasswordData()
        {
            con.Open();
            String syntax = "SELECT Val FROM AdminTable WHERE MyID = 'Password'";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            String name = dr[0].ToString();
            con.Close();
            //MessageBox.Show(dr[0].ToString());
            return name;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            String UName = getUserNameData();
            String PWD = getPasswordData();
            String name, password;
            name = textBox1.Text;
            password = textBox2.Text;

            if(name.Equals(UName) && password.Equals(PWD))
            {
                //Login Success
                label3.Hide();
                //MessageBox.Show("Login Success");

                MainForm MF = new MainForm();
                this.Hide();
                MF.Show();
            }
            else{
                //Login Failure
                //MessageBox.Show("Login Failed");
                label3.Show();

            }
        }
    }
}
