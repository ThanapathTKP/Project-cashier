using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Project1
{
    public partial class UserControl4 : UserControl
    {
        public UserControl4()
        {
            InitializeComponent();
        }

        private void UserControl4_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM history1";
            MySqlConnection con = new MySqlConnection("host=localhost;user=nantawan_p;password=1234;database=project2 ");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //คำนวณเงินรวมสุทธิ
            int sum= 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sum = sum + Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value.ToString());
                label2.Text = sum.ToString("#,##00.00");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM history1";
            MySqlConnection con = new MySqlConnection("host=localhost;user=nantawan_p;password=1234;database=project2 ");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            //คำนวณเงินรวมสุทธิ
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sum = sum + Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value.ToString());
                label2.Text = sum.ToString("#,##00.00");
            }
        }
    }
}
