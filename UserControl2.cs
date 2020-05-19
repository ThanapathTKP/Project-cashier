using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using static Org.BouncyCastle.Math.EC.ECCurve;
using System.Data.OleDb;
using MySqlX.XDevAPI.Relational;
using System.Windows.Documents;
using System.Globalization;
using System.Threading;

namespace Project1
{
    public partial class UserControl2 : UserControl
    {
        
        public UserControl2()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void สินค้าDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void สินค้าBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            
        }

        private void UserControl2_Load_1(object sender, EventArgs e)
        {
            populateDGV();

        }

        public void populateDGV()
        {
            string sql = "SELECT * FROM product";
            MySqlConnection con = new MySqlConnection("host=localhost;user=nantawan_p;password=1234;database=project2 ");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            สินค้าDataGridView.DataSource = dt;
            con.Close();
        }




        private void bindingNavigatorCountItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            //ปุ่ม insert
            string sql = "SELECT * FROM product";
            sql = "INSERT INTO product (รหัสสินค้า,รายการ,ราคาทุน,ราคาขาย) VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" +
                textBox3.Text + "', '" + textBox4.Text + "')";

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

        }

        private void สินค้าDataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            //กด cells แล้วให้ขึ้นที่ textbox
            textBox1.Text = สินค้าDataGridView.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = สินค้าDataGridView.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = สินค้าDataGridView.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = สินค้าDataGridView.CurrentRow.Cells[3].Value.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ปุ่ม update 
            string sql = "SELECT * FROM product";
            sql = "UPDATE product SET รายการ = '" + textBox2.Text + "',ราคาทุน = '" + textBox3.Text + "',ราคาขาย = '" + textBox4.Text + "' WHERE รหัสสินค้า='" + textBox1.Text + "'";
            
            MySqlConnection con = new MySqlConnection("host=localhost;user=nantawan_p;password=1234;database=project2");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();

            cmd.ExecuteNonQuery();
            con.Close();
            populateDGV();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ปุ่ม Delete
            string sql = "SELECT * FROM product";
            sql = "DELETE FROM product WHERE รหัสสินค้า='"+textBox1.Text+"'";
            
            MySqlConnection con = new MySqlConnection("host=localhost;user=nantawan_p;password=1234;database=project2");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            
            cmd.ExecuteNonQuery();
            con.Close();
            populateDGV();
        }
    }

}
