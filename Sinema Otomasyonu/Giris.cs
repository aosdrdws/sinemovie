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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
            this.MaximizeBox = false;﻿
        }
        
        //Minimize
        private void button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Kapatma
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Haraket Ettirme
        int move;
        int Mouse_X;
        int Mouse_Y;
        private void Giris_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }
        private void Giris_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        }
        private void Giris_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        // Access
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Veritabanı.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbCommand komut2 = new OleDbCommand();
        OleDbDataReader dr;
        OleDbDataReader drr;
        
        private void button1_Click(object sender, EventArgs e)
        {          
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM kullanici where Kullanıcı_adı='" + textBox1.Text + "' AND Sifre='" + textBox2.Text + "'";
            dr = komut.ExecuteReader();
            komut2.Connection = baglanti;
            komut2.CommandText = "SELECT * FROM admin where admink='" + textBox1.Text + "' AND admins='" + textBox2.Text + "'";
            drr = komut2.ExecuteReader();
            if (dr.Read())
            {
                Kullanıcı.kullanc_adı = textBox1.Text;
                Kullanıcı kllnc = new Kullanıcı();
                kllnc.Show();
                this.Hide();
            }
            else if (drr.Read())
            {
                Form Admin = new Admin();
                Admin.Show();
                this.Hide();
            }
            else if (textBox1.Text == "" || textBox2.Text == "") { MessageBox.Show("Boş Alan Bırakılamaz"); }
            else { MessageBox.Show("Kullanıcı adı ya da şifre yanlış"); }

            baglanti.Close();     
        }

        // Kayıt Ol
        private void button2_Click(object sender, EventArgs e)
        {
            Form KayıtOl = new KayıtOl();
            KayıtOl.ShowDialog();
        }
        private void button6_MouseDown(object sender, MouseEventArgs e)
        { 
            textBox2.UseSystemPasswordChar = false; 
        }
        private void button6_MouseUp(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        // Misafir
        private void button3_Click(object sender, EventArgs e)
        {
            Form MisafirKoltukSec = new Misafir();
            MisafirKoltukSec.Show();
            this.Hide();
        }
      
        // Textbox a Göre label
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 1) { label3.Visible = false; }
            else if (textBox1.Text.Length == 0) { label3.Visible = true; }
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 1) { label3.Visible = true; }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length >= 1) { label4.Visible = false; }
            else if (textBox2.Text.Length == 0) { label4.Visible = true; }
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Length < 1) { label4.Visible = true; }
        }
        private void Giris_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox1, "En az 8 karakter.");
            toolTip2.SetToolTip(textBox2, "En az 8 karakter.");
        }

        // Şifremi Unuttum
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form SifremiUnuttum = new SifremiUnuttum();
            SifremiUnuttum.ShowDialog();
        }       
    }
}
