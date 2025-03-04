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

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection bağlan = new SqlConnection("Data Source = sql server ismi; Initial Catalog = kisiler; Integrated Security = True");
        private void veriler()
        {
            listView1.Items.Clear();
            bağlan.Open();
            SqlCommand komut = new SqlCommand("Select *from otel1", bağlan);
            SqlDataReader oku = komut.ExecuteReader();
            while(oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["giris"].ToString();
                ekle.SubItems.Add(oku["kimlikno"].ToString());
                ekle.SubItems.Add(oku["adsoyad"].ToString());
                ekle.SubItems.Add(oku["oda"].ToString());
                listView1.Items.Add(ekle);
            }
            bağlan.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            veriler();
        }

        private void müşteriGörüntulemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button3.Visible = true;
            listView1.Visible = true;
            button4.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            dateTimePicker1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            comboBox1.Visible = false;
            button2.Visible = false;
            label5.Visible = false;
        }

        private void kayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button3.Visible = false;
            listView1.Visible = false;
            button4.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible=true;
            label4.Visible=true;
            dateTimePicker1.Visible=true;
            textBox2.Visible=true;
            textBox3.Visible=true;
            comboBox1.Visible = true;
            button2.Visible=true;
            label5.Visible=false;
        }

        int oda;
        DateTime giris;
        
        //double kimlikno;
        //string adsoyad;
        private void button3_Click(object sender, EventArgs e)
        {
            bağlan.Open();

            // Parametrik sorgu kullanımı
            SqlCommand komut = new SqlCommand("DELETE FROM otel1 WHERE oda = @oda AND giris = @giris", bağlan);
            komut.Parameters.AddWithValue("@oda", oda);
            komut.Parameters.AddWithValue("@giris", giris);

            komut.ExecuteNonQuery();
            bağlan.Close();
            veriler();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            oda = int.Parse(listView1.SelectedItems[0].SubItems[3].Text);
            giris= DateTime.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            //adsoyad = listView1.SelectedItems[0].SubItems[2].Text;
            //kimlikno= double.Parse(listView1.SelectedItems[0].SubItems[1].Text);
            dateTimePicker1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text= listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
            // label5.Text = dateTimePicker1.Text;
            // giris = label5.Text;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "" || dateTimePicker1.Text == "" || textBox2.Text.Length < 11)
            {
                MessageBox.Show("Boş Alan Bıraktınız veya Eksik girdiniz!!!");
            }
            else
            {
                DateTime giris1 = dateTimePicker1.Value;

                bağlan.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO otel1 (giris, kimlikno, adsoyad, oda) VALUES (@giris, @kimlikno, @adsoyad, @oda)", bağlan);

                komut.Parameters.AddWithValue("@giris", giris1);
                komut.Parameters.AddWithValue("@kimlikno", textBox2.Text);
                komut.Parameters.AddWithValue("@adsoyad", textBox3.Text);
                komut.Parameters.AddWithValue("@oda", comboBox1.Text);

                komut.ExecuteNonQuery();
                bağlan.Close();

                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.Text = "";
                veriler();
                label5.Text = "Kayıt Düzeltildi.";
                label5.Visible = true;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "" || dateTimePicker1.Text == "" || textBox2.Text.Length < 11)
            {
                MessageBox.Show("Boş Alan Bıraktınız veya Eksik girdiniz!!!");
            }
            else if (textBox2.Text.Length == 11)
            {
                bağlan.Open();
                SqlCommand komut = new SqlCommand("Insert into otel1 (giris,kimlikno,adsoyad,oda)Values('" + Convert.ToDateTime(dateTimePicker1.Text) + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + comboBox1.Text.ToString() + "')", bağlan);
                komut.ExecuteNonQuery();
                bağlan.Close();
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.Text = "";
                veriler();
                label5.Text = "Kayıt Başarılı";
                label5.Visible = true;
            }
            else
            {
                MessageBox.Show("Hatalı Tc Kimlik Dayıoğlu");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
