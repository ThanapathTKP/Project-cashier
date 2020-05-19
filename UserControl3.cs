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

namespace Project1
{
    public partial class UserControl3 : UserControl
    {
        
        public UserControl3()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UserControl3_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("ลำดับที่", 70, HorizontalAlignment.Center);
            listView1.Columns.Add("รหัสสินค้า", 120, HorizontalAlignment.Center);
            listView1.Columns.Add("ชื่อสินค้า", 210, HorizontalAlignment.Center);
            listView1.Columns.Add("ราคาขาย", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("จำนวน", 90, HorizontalAlignment.Center);
            listView1.Columns.Add("ราคารวม", 120, HorizontalAlignment.Center);
            listView1.View = View.Details;
            textBox1.Focus();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                e.Handled = true;
            }
            MySqlConnection con = new MySqlConnection("host=localhost;user=nantawan_p;password=1234;database=project2 ");
            con.Open();
            string sql = "SELECT รายการ,ราคาขาย FROM product WHERE รหัสสินค้า  = '"+textBox1.Text.Trim()+"'";
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
            da.Fill(ds, "product");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "product";

        }

        private void cal()
        {
            //ราคารวม--------------------------------------------------------------------------
            double total;
            total = (double.Parse(textBox3.Text)) * int.Parse(textBox4.Text);
            textBox5.Text = total.ToString("#,##0.00");
        }
        
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //ส่งข้อมูลจาก DGV มาที่ textbox
            if (e.RowIndex == -1) return;
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            int a = int.Parse(textBox4.Text);
            
            if (a == 1)
            {
                textBox5.Text = textBox3.Text;
            }
            else
            {
                cal();
            }
            
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                e.Handled = true;
            }
            cal();
            textBox1.SelectAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        //ปุ่มเพิ่มรายการ---------------------------------------------------------------------------------------
            if ((textBox1.Text.Trim() == "") || (textBox3.Text.Trim() == ""))
            {
                textBox1.Focus();
                return;
            }
            if (int.Parse(textBox4.Text) == 0)
            {
                textBox4.Focus();
                return;
            }
            
            //คอลัมน์"ลำดับที่"---------------------------------------------------
            int n = 0;
            for (n = 0; n <= listView1.Items.Count; n++)
            {
                
            }
            //รายการที่จะแสดงใน listview----------------------------------------  
            string[] anydata;
            anydata = new string[]
            {
                n.ToString(),
                textBox1.Text,
                textBox2.Text,
                textBox3.Text,
                textBox4.Text,
                textBox5.Text,
            };
            ListViewItem lvi = new ListViewItem(anydata);
            listView1.Items.Add(lvi);
            cal_all();
            button3.Enabled = true;
            textBox1.Focus();
            textBox1.SelectAll();

        }
        private void cal_all()
        {
            //คำนวณราคารวมทั้งหมด
            int i = 0;
            double total = 0;
            for (i = 0; i <= listView1.Items.Count - 1; i++)
            {
                total += double.Parse(listView1.Items[i].SubItems[5].Text);
            }
            label7.Text = total.ToString("#,##00.00");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ปุ่มลบรายการใน listview---------------------
            
            int i = 0;
            for (i = 0; i <= listView1.SelectedItems.Count - 1; i++)
            {
                ListViewItem lvi;
                lvi = listView1.SelectedItems[i];
                listView1.Items.Remove(lvi);

            }
            cal_all();
            textBox1.Focus();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
           //ปุ่มบันทึกการขาย
            MySqlConnection con = new MySqlConnection("host=localhost;user=nantawan_p;password=1234;database=project2 ");
            con.Open();

            DateTime iDate;
            iDate = dateTimePicker1.Value;
            int i = 0;
            for (i = 0; i <= listView1.Items.Count - 1; i++)
            {
                string sql = "INSERT INTO history1 (วันที่,รหัสสินค้า,ชื่อสินค้า,ราคาขาย,จำนวน,รวม) VALUES ('"+ 
                    iDate + "','" +
                    listView1.Items[i].SubItems[1].Text + "', '" +
                    listView1.Items[i].SubItems[2].Text + "', '" +
                    listView1.Items[i].SubItems[3].Text + "', '" +
                    listView1.Items[i].SubItems[4].Text + "', '" +
                    listView1.Items[i].SubItems[5].Text + "') ";
                MySqlCommand com = new MySqlCommand(sql, con);
                com.ExecuteNonQuery();
                
            }
            MessageBox.Show("บันทึกการขายเรียบร้อยแล้ว");
            textBox1.Clear();
            textBox4.Text = "1";
            textBox2.Text = "";
            textBox3.Text = "0.00";
            textBox5.Text = "0.00";
            label7.Text = "0.00                ";
            listView1.Items.Clear();

        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
