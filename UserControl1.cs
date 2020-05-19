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
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        public void populateDGV()
        {
            string sql = "SELECT * FROM user";
            MySqlConnection con = new MySqlConnection("host=localhost;user=nantawan_p;password=1234;database=project2 ");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ปุ่ม insert
            string sql = "SELECT * FROM user";
            sql = "INSERT INTO user (รหัส,ประเภทธุรกิจ,ชื่อ,ที่อยู่,โทร,แฟกซ์) VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" +
                textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "')";

            MySqlConnection con = new MySqlConnection("host=localhost;user=nantawan_p;password=1234;database=project2 ");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();

            cmd.ExecuteNonQuery();
            con.Close();

            populateDGV();
            MessageBox.Show("Inserted sucessfully");

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            //กด cells แล้วให้ขึ้นที่ textbox
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ปุ่ม update 
            string sql = "SELECT * FROM user";
            sql = "UPDATE user SET ประเภทธุรกิจ = '" + textBox2.Text + "',ชื่อ = '" + textBox3.Text + "',ที่อยู่ = '" + textBox4.Text + "',โทร = '" +
                textBox5.Text + "',แฟกซ์ = '" + textBox6.Text + "' WHERE รหัส='" + textBox1.Text + "'";

            MySqlConnection con = new MySqlConnection("host=localhost;user=nantawan_p;password=1234;database=project2 ");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();

            cmd.ExecuteNonQuery();
            con.Close();
            populateDGV();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ปุ่ม Delete
            string sql = "SELECT * FROM user";
            sql = "DELETE FROM user WHERE รหัส='" + textBox1.Text + "'";

            MySqlConnection con = new MySqlConnection("host=localhost;user=nantawan_p;password=1234;database=project2 ");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();

            cmd.ExecuteNonQuery();
            con.Close();
            populateDGV();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            populateDGV();
        }
    }
}
