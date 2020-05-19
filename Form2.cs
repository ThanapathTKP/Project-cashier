using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void สนคาToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void เพมสนคาToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userControl1.Hide();
            userControl21.Show();
            userControl31.Hide();
            userControl41.Hide();
            label1.Hide();
            pictureBox1.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            userControl1.Hide();
            userControl21.Hide();
            userControl31.Hide();
            userControl41.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void หนาจอขายToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userControl31.Show();
            userControl1.Hide();
            userControl21.Hide();
            userControl41.Hide();
            label1.Hide();
            pictureBox1.Hide();
        }

        private void userControl21_Load(object sender, EventArgs e)
        {
            
        }

        private void ขอมลผขายToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userControl1.Show();
            userControl21.Hide();
            userControl31.Hide();
            userControl41.Hide();
            label1.Hide();
            pictureBox1.Hide();
        }

        private void userControl21_Load_1(object sender, EventArgs e)
        {

        }

        private void userControl21_Load_2(object sender, EventArgs e)
        {

        }

        private void userControl21_Load_3(object sender, EventArgs e)
        {
            
        }

        private void ขายToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void รายงานยอดขายสนคาToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userControl41.Show();
            userControl1.Hide();
            userControl21.Hide();
            userControl31.Hide();
            label1.Hide();
            pictureBox1.Hide();
        }

        private void userControl41_Load(object sender, EventArgs e)
        {

        }
    }
}
