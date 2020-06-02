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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            this.MaximizeBox = false;﻿
            SlidePanel.Visible = false;
        }

        // Access
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Veritabanı.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        OleDbDataReader dr;
        OleDbCommand kmt = new OleDbCommand();
        OleDbDataReader drr;

        private void button1_Click(object sender, EventArgs e)
        {
            SlidePanel.Visible = true;
            SlidePanel.Height = button1.Height;
            SlidePanel.Top = button1.Top;
            panel5.Visible = false;
            panel7.Visible = false;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            SlidePanel.Visible = true;
            SlidePanel.Height = button8.Height;
            SlidePanel.Top = button8.Top;
            panel5.Visible = true;
            panel7.Visible = false;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            SlidePanel.Visible = true;
            SlidePanel.Height = button7.Height;
            SlidePanel.Top = button7.Top;
            panel5.Visible = true;
            panel7.Visible = true;
            pictureBox8.Visible = false;
            pictureBox7.Visible = false;
            label22.Visible = false;
            pictureBox12.Visible = false;
            pictureBox11.Visible = false;
            label23.Visible = false;
        }  
        private void button4_Click(object sender, EventArgs e)
        {
            Form Giris = new Giris();
            Giris.Show();
            this.Close();
        }

        // Küçültme
        private void button5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Kapatma
        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Haraket Ettirme
        int move2;
        int Mouse_X;
        int Mouse_Y;
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            move2 = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }
        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (move2 == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        } 
        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            move2 = 0;
        }

        // Listeleme
        void listele()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from kullanici", baglanti);
            adtr.Fill(ds, "kullanici");
            dataGridView1.DataSource = ds.Tables["kullanici"];
            adtr.Dispose();
            baglanti.Close();
        }
        void listele2()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from filmekle", baglanti);
            adtr.Fill(ds, "filmekle");
            dataGridView2.DataSource = ds.Tables["filmekle"];
            adtr.Dispose();
            baglanti.Close();
        }

        // Film Ekle
        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || comboBox4.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || dateTimePicker1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "")
            { MessageBox.Show("Boş Alan Bırakılamaz"); }
            else
            {
                OleDbCommand komut2 = new OleDbCommand();
                OleDbDataReader dr2;
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "SELECT * FROM filmekle where Film_adı='" + textBox1.Text + "' AND Seans_gunu='" + dateTimePicker1.Text + "' AND Seans_saati='" + comboBox2.Text + "' AND Salon='" + comboBox3.Text + "'";
                dr = komut.ExecuteReader();
                komut2.Connection = baglanti;
                komut2.CommandText = "SELECT * FROM filmekle where Seans_gunu='" + dateTimePicker1.Text + "' AND Seans_saati='" + comboBox2.Text + "' AND Salon='" + comboBox3.Text + "'";
                dr2 = komut2.ExecuteReader();
                if (dr.Read() || dr2.Read())
                {
                    MessageBox.Show("Bu Film Zaten Ekli veya Bu Seans Dolu");
                }
                else
                {
                    baglanti.Close();
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "Insert Into filmekle(Film_adı,Film_turu,Yonetmen,Film_suresi,IMDB_puanı,Seans_gunu,Seans_saati,Salon)Values ('" + textBox1.Text + "','" + comboBox4.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + dateTimePicker1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "')";
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                    baglanti.Close();
                    ds.Clear();
                    listele2();
                    listele();
                    MessageBox.Show("Film Eklendi");                  
                }
                baglanti.Close();
            }
        }

        // Film Sil
        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || comboBox4.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || dateTimePicker1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "")
            { MessageBox.Show("Boş Alan Bırakılamaz"); }
            else
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "Delete from filmekle where Film_adı='" + textBox1.Text + "' AND Seans_gunu='" + dateTimePicker1.Text + "' AND Seans_saati='" + comboBox2.Text + "' AND Salon='" + comboBox3.Text + "'";
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                ds.Clear();
                listele2();
                listele();
                MessageBox.Show("Film Silindi");                
            }
        }

        // Bilet Kes
        private void button13_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM filmekle where Salon='" + comboBox3.Text + "'AND Seans_Gunu='" + dateTimePicker1.Text + "'AND Seans_saati='" + comboBox2.Text + "'AND Film_adı='" + textBox1.Text + "'";
            dr = komut.ExecuteReader();
            if (textBox1.Text == "" || comboBox4.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || dateTimePicker1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "")
            { MessageBox.Show("Boş Alan Bırakılamaz"); }
            else if (dr.Read())
            {
                if (comboBox3.Text == "1")
                {
                    Salon1.filmadı = textBox1.Text;
                    Salon1.seansgunu = dateTimePicker1.Text;
                    Salon1.seanssaati = comboBox2.Text;
                    Salon1 sln1 = new Salon1();
                    sln1.Show();
                    this.Hide();
                }
                else if (comboBox3.Text == "2")
                {
                    Salon2.filmadı2 = textBox1.Text;
                    Salon2.seansgunu2 = dateTimePicker1.Text;
                    Salon2.seanssaati2 = comboBox2.Text;
                    Salon2 sln2 = new Salon2();
                    sln2.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Değerleri Değiştirmeyiniz");
            } 
            baglanti.Close();
        }        

        // Üye Sil
        private void button11_Click(object sender, EventArgs e)
        {
            if (rb_Erkek.Checked == false && rb_Kadın.Checked == false || textBox7.Text == "" || textBox6.Text == "" || textBox2.Text == "" || textBox10.Text == "" || textBox8.Text == "" || textBox9.Text == "")
            { MessageBox.Show("Boş Alan Bırakılamaz"); }
            else
            {
                baglanti.Open();
                kmt.Connection = baglanti;
                kmt.CommandText = "SELECT * FROM kullanici where Kullanıcı_adı='" + textBox2.Text + "'AND Eposta='" + textBox8.Text + "'";
                drr = kmt.ExecuteReader();
                if (!drr.Read())
                {
                    MessageBox.Show("Kullanıcı Adı ve Eposta Uyuşmuyor");
                }
                else
                {
                    baglanti.Close();
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "Delete from kullanici where Kullanıcı_adı='" + textBox2.Text + "'";
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                    baglanti.Close();
                    ds.Clear();
                    listele();
                    listele2();
                    MessageBox.Show("Kayıt Silindi");
                    pictureBox11.Visible = false;
                    pictureBox12.Visible = false;
                    label23.Visible = false;
                }
                baglanti.Close();
            }
        }

        // Üye Ekle
        private void button3_Click(object sender, EventArgs e)
        {
            if (rb_Erkek.Checked == false && rb_Kadın.Checked == false || textBox7.Text == "" || textBox6.Text == "" || textBox2.Text == "" || textBox10.Text == "" || textBox8.Text == "" || textBox9.Text == "")
            { MessageBox.Show("Boş Alan Bırakılamaz"); }            
            else
            {
                if (rb_Erkek.Checked == true)
                { cinsiyet.Text = rb_Erkek.Text; }
                else if (rb_Kadın.Checked == true)
                { cinsiyet.Text = rb_Kadın.Text; }
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "SELECT * FROM kullanici where Kullanıcı_adı='" + textBox2.Text + "'";
                dr = komut.ExecuteReader();
                kmt.Connection = baglanti;
                kmt.CommandText = "SELECT * FROM kullanici where Eposta='" + textBox8.Text + "'";
                drr = kmt.ExecuteReader();
                if (drr.Read() || dr.Read())
                {
                    pictureBox7.Visible = true;
                    label22.Visible = true;
                    pictureBox11.Visible = true;
                    label23.Visible = true;
                    MessageBox.Show("Bu Kullanıcı Adı veya Eposta Kullanılıyor");
                }
                else
                {
                    baglanti.Close();
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "Insert Into kullanici(Ad,Soyad,Kullanıcı_adı,Sifre,Eposta,Yas,Cinsiyet)Values ('" + textBox7.Text + "','" + textBox6.Text + "','" + textBox2.Text + "','" + textBox10.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + cinsiyet.Text + "')";          
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                    baglanti.Close();
                    ds.Clear();
                    listele();
                    listele2();
                    MessageBox.Show("Başarı İle Kayıt Olundu");
                }
                baglanti.Close();
            }
        }

        // Harf Yazmayı Engelleme
        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        // dataGridView 
        private void Admin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'veritabanıDataSet.Salon' table. You can move, or remove it, as needed.
            this.salonTableAdapter.Fill(this.veritabanıDataSet.Salon);
            // TODO: This line of code loads data into the 'veritabanıDataSet.filmekle' table. You can move, or remove it, as needed.
            listele2();
            // TODO: This line of code loads data into the 'veritabanıDataSet.kullanici' table. You can move, or remove it, as needed.
            listele();
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.FromArgb(41, 39, 40);
            this.dataGridView1.DefaultCellStyle.Font = new Font("Century Gothic", 8);
            this.dataGridView2.DefaultCellStyle.ForeColor = Color.FromArgb(41, 39, 40);
            this.dataGridView2.DefaultCellStyle.Font = new Font("Century Gothic", 8);
            this.dataGridView3.DefaultCellStyle.ForeColor = Color.FromArgb(41, 39, 40);
            this.dataGridView3.DefaultCellStyle.Font = new Font("Century Gothic", 8);
        }

        // Otomatik Doldurma
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();            
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            comboBox4.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            textBox3.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
            textBox4.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            dateTimePicker1.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            comboBox2.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            comboBox3.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
        }

        // Eposta Kontrol
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM kullanici where Eposta='" + textBox8.Text + "'";
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                pictureBox11.Visible = true;
                pictureBox12.Visible = false;
                label23.Visible = true;
            }
            else 
            {
                pictureBox12.Visible = true;
                pictureBox11.Visible = false;
                label23.Visible = false;
            }
            baglanti.Close();
        }

        // Kullanıcı Adı Kontrolü
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM kullanici where Kullanıcı_adı='" + textBox2.Text + "'";
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                pictureBox7.Visible = true;
                pictureBox8.Visible = false;
                label22.Visible = true;
            }
            else 
            {
                pictureBox8.Visible = true;
                pictureBox7.Visible = false;
                label22.Visible = false;
            }
            baglanti.Close();
        }               
    }
}