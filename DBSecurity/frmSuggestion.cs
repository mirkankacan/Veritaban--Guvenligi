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
    public partial class frmSuggestion : Form
    {
        public frmSuggestion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(richTextBox1.Text))
            {
                SqlConnection conn = new SqlConnection("server=192.168.1.55;database=HR;user=sa;pwd=159357852");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                conn.Open();
                string sql = "INSERT INTO SUGGESTION (NAMESURNAME,DATE_,SUGGESTIONTEXT)";
                sql = sql + "VALUES('" + textBox1.Text + "',GETDATE(),'" + richTextBox1.Text + "')";
                sql = sql + "SELECT @@IDENTITY;";
                cmd.CommandText = sql;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    string id;
                    id = ds.Tables[0].Rows[0][0].ToString();
                    MessageBox.Show("Your suggestion has been posted. The ID of your suggestion: " + id);
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("Text boxes cannot be empty!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
        }
    }
}
