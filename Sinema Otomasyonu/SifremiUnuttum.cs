using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Sinema_Otomasyonu
{
    public partial class SifremiUnuttum : Form
    {
        public SifremiUnuttum()
        {
            InitializeComponent();           
        }

        // Access
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Veritabanı.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        OleDbDataReader dr;

        // Kapatma
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Haraket Ettirme
        int move4;
        int Mouse_X;
        int Mouse_Y;
        private void SifremiUnuttum_MouseDown(object sender, MouseEventArgs e)
        {
            move4 = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }
        private void SifremiUnuttum_MouseUp(object sender, MouseEventArgs e)
        {
            move4 = 0;
        }
        private void SifremiUnuttum_MouseMove(object sender, MouseEventArgs e)
        {
            if (move4 == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        // Veritabanı Kontrol
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox4.Visible = false;
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM kullanici where Kullanıcı_adı='" + textBox4.Text + "' AND Eposta='" + textBox6.Text + "'";
            dr = komut.ExecuteReader();         
            if (dr.Read())
            {
                pictureBox1.Visible = true;
                pictureBox4.Visible = true;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                button2.Visible = true;
                textBox2.Visible = true;
                label2.Visible = true;
            }
            else
            {
                pictureBox1.Visible = false;
                pictureBox4.Visible = false;
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
                button2.Visible = false;
                textBox2.Visible = false;
                label2.Visible = false;
            }
            baglanti.Close();            
        }

        // Şifre Sınırı
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0 || textBox2.Text.Length < 7)
            {
                pictureBox5.Visible = true;
                label12.Visible = true;
            }
            else if (textBox2.Text.Length > 7)
            {
                pictureBox5.Visible = false;
                pictureBox6.Visible = true;
                label12.Visible = false;
            }
            else
            {
                pictureBox5.Visible = true;
                pictureBox6.Visible = false;
                label12.Visible = true;
            }
        }

        // Şifre Değiştirme
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length != 8)
            {
                MessageBox.Show("Şifreniz 8 Karakterden Kısa Olamaz.");
            }
            else
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "UPDATE kullanici set Sifre='" + textBox2.Text + "'where Kullanıcı_adı='" + textBox4.Text + "'";
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Şifre Değiştirildi");
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "") { pictureBox2.Visible = true; }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text == "") { pictureBox3.Visible = true; }
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM kullanici where Kullanıcı_adı='" + textBox4.Text + "'";
            dr = komut.ExecuteReader();
            if (dr.Read() && button2.Visible == true)
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
            }
            else if (button2.Visible == true)
            {
                pictureBox2.Visible = true;
                pictureBox1.Visible = false;
                button2.Visible = false;
                textBox2.Visible = false;
                label2.Visible = false;
            }
            baglanti.Close();
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM kullanici where Eposta='" + textBox6.Text + "'";
            dr = komut.ExecuteReader();
            if (dr.Read() && button2.Visible==true)
            {
                pictureBox4.Visible = true;
                pictureBox3.Visible = false;
            }
            else if (button2.Visible == true)
            {
                pictureBox3.Visible = true;
                pictureBox4.Visible = false;
                button2.Visible = false;
                textBox2.Visible = false;
                label2.Visible = false;
            }
            baglanti.Close();
        }   
    }
}
