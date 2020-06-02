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
    public partial class KayıtOl : Form
    {
        public KayıtOl()
        {
            InitializeComponent();
            this.MaximizeBox = false;﻿
        }

        // Access
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Veritabanı.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        OleDbDataReader dr;

        // Kapatma
        private void button5_Click(object sender, EventArgs e) { this.Close(); }

        // Haraket Ettirme
        int move1;
        int Mouse_X;
        int Mouse_Y;
        private void KayıtOl_MouseDown(object sender, MouseEventArgs e)
        {
            move1 = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }
        private void KayıtOl_MouseUp(object sender, MouseEventArgs e) { move1 = 0; }

        private void KayıtOl_MouseMove(object sender, MouseEventArgs e)
        {
            if (move1 == 1) { this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y); }
        }

        // Textbox
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox1.Text.Length < 3) { pictureBox2.Visible = true; }
            else if (textBox1.Text.Length > 2)
            {
                pictureBox2.Visible = false;
                pictureBox1.Visible = true;
            }
            else
            {
                pictureBox2.Visible = true;
                pictureBox1.Visible = false;
            }
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0) { pictureBox2.Visible = true; }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0 || textBox2.Text.Length < 3) { pictureBox3.Visible = true; }
            else if (textBox2.Text.Length > 2)
            {
                pictureBox3.Visible = false;
                pictureBox4.Visible = true;
            }
            else
            {
                pictureBox3.Visible = true;
                pictureBox4.Visible = false;
            }
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0) { pictureBox3.Visible = true; }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length == 0 || textBox4.Text.Length < 7)
            {
                pictureBox7.Visible = true;
                label3.Visible = true;
            }
            else if (textBox4.Text.Length > 7)
            {
                pictureBox7.Visible = false;
                pictureBox8.Visible = true;
                label3.Visible = false;
            }
            else
            {
                pictureBox8.Visible = false;
                pictureBox7.Visible = true;
                label3.Visible = true;
            }
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM kullanici where Kullanıcı_adı='" + textBox4.Text + "'";
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                pictureBox7.Visible = true;
                pictureBox8.Visible = false;
                label16.Visible = true;
                label3.Visible = false;
            }
            else { label16.Visible = false; }
            baglanti.Close();
        }
        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text.Length == 0) { pictureBox7.Visible = true; }
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Length == 0 || textBox5.Text.Length < 7)
            {
                pictureBox9.Visible = true;
                label12.Visible = true;
            }
            else if (textBox5.Text.Length > 7)
            {
                pictureBox9.Visible = false;
                pictureBox10.Visible = true;
                label12.Visible = false;
            }
            else
            {
                pictureBox9.Visible = true;
                pictureBox10.Visible = false;
                label12.Visible = true;
            }
        }
        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text.Length == 0) { pictureBox9.Visible = true; }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 0 || textBox3.Text.Length < 1) { pictureBox5.Visible = true; }
            else if (textBox3.Text.Length > 0)
            {
                pictureBox5.Visible = false;
                pictureBox6.Visible = true;
            }
            else
            {
                pictureBox5.Visible = true;
                pictureBox6.Visible = false;
            }
        }       
        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 0) { pictureBox5.Visible = true; }
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text.Length == 0 || textBox6.Text.Length < 14) { pictureBox11.Visible = true; }
            else if (textBox6.Text.Length > 13)
            {
                pictureBox11.Visible = false;
                pictureBox12.Visible = true;
            }
            else
            {
                pictureBox11.Visible = true;
                pictureBox12.Visible = false;
            }
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM kullanici where Eposta='" + textBox6.Text + "'";
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                pictureBox11.Visible = true;
                pictureBox12.Visible = false;
                label17.Visible = true;
            }
            else { label17.Visible = false; }
            baglanti.Close();
        }
        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text.Length == 0) { pictureBox11.Visible = true; }
        }

        // Veritabanı
        private void button3_Click(object sender, EventArgs e)
        {
            if (rb_Erkek.Checked == false && rb_Kadın.Checked == false || textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox3.Text == "" || textBox6.Text == "")
            { MessageBox.Show("Boş Alan Bırakılamaz"); }
            else if (textBox4.Text.Length != 8 || textBox5.Text.Length != 8)
            { MessageBox.Show("Kullanıcı Adı veya Parola 8 Karakterden Kısa Olamaz."); }
            else if (textBox6.Text.Length < 13)
            { MessageBox.Show("Eposta Bu Kadar Kısma Olamaz"); }
            else if (textBox1.Text.Length < 3)
            { MessageBox.Show("Ad Bu Kadar Kısma Olamaz"); }
            else if (textBox2.Text.Length < 3)
            { MessageBox.Show("Soyad Bu Kadar Kısma Olamaz"); }
            else if (textBox3.Text == "12" || textBox3.Text == "11" || textBox3.Text == "10" || textBox3.Text == "9" || textBox3.Text == "8" || textBox3.Text == "7" || textBox3.Text == "6" || textBox3.Text == "5" || textBox3.Text == "4" || textBox3.Text == "3" || textBox3.Text == "2" || textBox3.Text == "1" || textBox3.Text == "0" || textBox3.Text == "00")
            { MessageBox.Show("Bu Sisteme Kaydolmak İçin Yaşınız Çok Küçük"); }
            else
            {
                OleDbCommand komut2 = new OleDbCommand();
                OleDbDataReader dr2;
                if (rb_Erkek.Checked==true)
                { cinsiyet.Text=rb_Erkek.Text; }
                else if(rb_Kadın.Checked==true)
                { cinsiyet.Text=rb_Kadın.Text; }
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "SELECT * FROM kullanici where Kullanıcı_adı='" + textBox4.Text + "'";
                komut2.Connection = baglanti;
                komut2.CommandText = "SELECT * FROM kullanici where Eposta='" + textBox6.Text + "'";
                dr2 = komut2.ExecuteReader();
                dr = komut.ExecuteReader();
                if (dr.Read() || dr2.Read())
                {
                    MessageBox.Show("Bu Kullanıcı Adı veya Eposta Kullanılıyor");                  
                }
                else
                {
                    baglanti.Close();
                    komut.Connection = baglanti;
                    komut.CommandText = "Insert Into kullanici(Ad,Soyad,Kullanıcı_adı,Sifre,Eposta,Yas,Cinsiyet)Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox3.Text + "','" + cinsiyet.Text + "')";
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                    baglanti.Close();
                    ds.Clear();
                    MessageBox.Show("Başarı İle Kayıt Olundu");
                }
                baglanti.Close();
            }
        }

        // Tip
        private void KayıtOl_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(label9, "Zorunlu");
            toolTip2.SetToolTip(label11, "Zorunlu");
            toolTip3.SetToolTip(label13, "Zorunlu");
            toolTip4.SetToolTip(label14, "Zorunlu");
            toolTip5.SetToolTip(label15, "Zorunlu");
            toolTip6.SetToolTip(label6, "Zorunlu");
            toolTip7.SetToolTip(label8, "Zorunlu");
        }         
    }
}
