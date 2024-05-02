using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace diplomatik
{
    public partial class MainForm : Form
    {
        string ct;
        int pr;
        int i;

        public MainForm()
        {
            InitializeComponent();

            try
            {
                SqlConnection con = new SqlConnection(@"Data Source = Chmonik\FUKI; Initial Catalog = DBotBoga; Integrated Security = True");
                con.Open();
                SqlCommand command = new SqlCommand("select city, price from [dbo].[CDB] where city = @City and price = @Price", con);
                command.Parameters.AddWithValue("@City", ct);
                command.Parameters.AddWithValue("Price", pr);
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    for(i = 0; i < 10; i++)
                    MessageBox.Show(ct.ToString() +  pr.ToString());
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Что-то пошло не так: " + ex.ToString());
                return;
            }

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
             
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
