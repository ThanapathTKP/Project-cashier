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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pass.PasswordChar = '';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string u = user.Text;
            string p = pass.Text;
            Form2 pa = new Form2();
            if (u=="admin")
            {
                if(p=="1234")
                {
                    pa.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            else
            {
                MessageBox.Show("Error");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void user_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void pass_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void user_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void user_Enter(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
