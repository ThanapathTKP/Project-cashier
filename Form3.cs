using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Project1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void สินค้าBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.สินค้าBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.projectDataSet);

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM สินค้า", "server = DESKTOP-9NTCN99\\MSSQLSERVER01; database = project; UID = sa; password = 1234");  
            DataSet ds = new DataSet();
            da.Fill(ds, "สินค้า");
            dataGridView1.DataSource = ds.Tables["สินค้า"].DefaultView;
            // TODO: This line of code loads data into the 'projectDataSet.สินค้า' table. You can move, or remove it, as needed.
            //this.สินค้าTableAdapter.Fill(this.projectDataSet.สินค้า);
        }
        

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=DESKTOP-9NTCN99\MSSQLSERVER01;Initial Catalog=project;User ID=sa;Password=1234";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            MessageBox.Show("Connection Open  !");
            cnn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
