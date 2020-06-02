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
    public partial class Kullanıcı : Form
    {
        public Kullanıcı()
        {
            InitializeComponent();
            SlidePanel.Height = button1.Height;
            SlidePanel.Top = button1.Top;
        }
        public static string kullanc_adı { get; set; }

        // Access
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Veritabanı.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        OleDbDataReader dr;

        // Buton Atamaları
        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form Giris = new Giris();
            Giris.Show();
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SlidePanel.Height = button1.Height;
            SlidePanel.Top = button1.Top;
            panel5.Visible = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SlidePanel.Height = button2.Height;
            SlidePanel.Top = button2.Top;
            panel5.Visible = true;
            panel6.Visible = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            SlidePanel.Height = button4.Height;
            SlidePanel.Top = button4.Top;
            panel5.Visible = true;
            panel6.Visible = true;
        }

        // Haraket Ettirme
        int move3;
        int Mouse_X;
        int Mouse_Y;
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            move3 = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }
        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (move3 == 1)
            { this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y); }
        }
        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            move3 = 0;
        }

        void listele()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from filmekle", baglanti);
            adtr.Fill(ds, "filmekle");
            dataGridView1.DataSource = ds.Tables["filmekle"];
            adtr.Dispose();
            baglanti.Close();
        }
        private void Kullanıcı_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'veritabanıDataSet.Salon' table. You can move, or remove it, as needed.
            this.salonTableAdapter.Fill(this.veritabanıDataSet.Salon);
            // TODO: This line of code loads data into the 'veritabanıDataSet.Salon' table. You can move, or remove it, as needed.
            this.salonTableAdapter.Fill(this.veritabanıDataSet.Salon);
            // TODO: This line of code loads data into the 'veritabanıDataSet.filmekle' table. You can move, or remove it, as needed.
            listele();
            textBox2.Text = Kullanıcı.kullanc_adı;
            textBox12.Text = Kullanıcı.kullanc_adı;
            baglanti.Open();
            komut.CommandText = "Select * from kullanici where Kullanıcı_adı LIKE '" +textBox2.Text+"'";
            komut.Connection = baglanti;
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                textBox7.Text = dr["Ad"].ToString();
                textBox6.Text = dr["Soyad"].ToString();
                textBox10.Text = dr["Sifre"].ToString();
                textBox8.Text = dr["Eposta"].ToString();
                textBox9.Text = dr["Yas"].ToString();
                textBox1.Text = dr["Cinsiyet"].ToString();
            }
            baglanti.Close();
            dr.Dispose();

            this.dataGridView1.DefaultCellStyle.ForeColor = Color.FromArgb(41, 39, 40);
            this.dataGridView1.DefaultCellStyle.Font = new Font("Century Gothic", 8);
            this.dataGridView2.DefaultCellStyle.ForeColor = Color.FromArgb(41, 39, 40);
            this.dataGridView2.DefaultCellStyle.Font = new Font("Century Gothic", 8);
        }

        // Bilgi Güncelleme
        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "" || textBox6.Text == "" || textBox2.Text == "" || textBox10.Text == "" || textBox8.Text == "" || textBox9.Text == "")
            { MessageBox.Show("Boş Alan Bırakılamaz"); }
            else if (textBox10.Text.Length != 8)
            { MessageBox.Show("Parola 8 Karakterden Kısa Olamaz."); }
            else if (textBox8.Text.Length < 13)
            { MessageBox.Show("Eposta Bu Kadar Kısma Olamaz"); }
            else if (textBox7.Text.Length < 3)
            { MessageBox.Show("Ad Bu Kadar Kısma Olamaz"); }
            else if (textBox6.Text.Length < 3)
            { MessageBox.Show("Soyad Bu Kadar Kısma Olamaz"); }
            else if (textBox9.Text == "12" || textBox9.Text == "11" || textBox9.Text == "10" || textBox9.Text == "9" || textBox9.Text == "8" || textBox9.Text == "7" || textBox9.Text == "6" || textBox9.Text == "5" || textBox9.Text == "4" || textBox9.Text == "3" || textBox9.Text == "2" || textBox9.Text == "1" || textBox9.Text == "0" || textBox9.Text == "00")
            { MessageBox.Show("Yaş Bu Kadar Küçük Girilemez"); }
            else
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "UPDATE kullanici set Ad= '" + textBox7.Text + "' , Soyad='" + textBox6.Text + "', Sifre='" + textBox10.Text + "', Eposta='" + textBox8.Text + "', Yas='" + textBox9.Text + "', Cinsiyet='" + textBox1.Text + "'where Kullanıcı_adı='" + textBox2.Text + "'";
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                ds.Clear();
                MessageBox.Show("Kayıt Güncellendi");

                listele();
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM filmekle where Salon='" + textBox4.Text + "'AND Seans_Gunu='" + textBox5.Text + "'AND Seans_saati='" + textBox11.Text + "'AND Film_adı='" + textBox3.Text + "'";
            dr = komut.ExecuteReader();
            if (textBox11.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Bir Film Seçiniz");
            }
            else if (dr.Read())
            {
                if (textBox4.Text == "1")
                {
                    Salon1_k.filmadı = textBox3.Text;
                    Salon1_k.seansgunu = textBox5.Text;
                    Salon1_k.seanssaati = textBox11.Text;
                    Salon1_k.kllnc_adı = textBox2.Text;
                    Salon1_k sln1 = new Salon1_k();
                    sln1.Show();
                    this.Hide();                    
                }
                else if (textBox4.Text == "2")
                {
                    Salon2_k.filmadı2 = textBox3.Text;
                    Salon2_k.seansgunu2 = textBox5.Text;
                    Salon2_k.seanssaati2 = textBox11.Text;
                    Salon2_k.kllnc_adı = textBox2.Text;
                    Salon2_k sln2 = new Salon2_k();
                    sln2.Show();
                    this.Hide();                   
                }
            }
            baglanti.Close();
            
        }
        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            DataTable dt2 = new DataTable();
            OleDbDataAdapter adtr2 = new OleDbDataAdapter("Select * from Salon where kullanici_adı='" + textBox12.Text + "'", baglanti);
            adtr2.Fill(dt2);
            baglanti.Close();
            dataGridView2.DataSource = dt2;
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}