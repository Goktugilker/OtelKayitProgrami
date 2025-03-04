using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "admin") 
            {
                Form2 kayıt=new Form2();
                kayıt.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Yanlış Giriş !!!");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
    }
}
