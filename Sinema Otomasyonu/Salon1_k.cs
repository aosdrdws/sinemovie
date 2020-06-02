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
    public partial class Salon1_k : Form
    {
        public Salon1_k()
        {
            InitializeComponent();
        }

        public static string kllnc_adı { get; set; }

        // Access
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Veritabanı.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        OleDbDataReader dr;

        // Kapatma
        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // Minimize
        private void button5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        // Geri Dönme
        private void button4_Click(object sender, EventArgs e)
        {
            if (label15.Text == "Misafir")
            {
                Misafir msfr = new Misafir();
                msfr.Show();
                this.Hide();
            }
            else
            {
                Kullanıcı klnc = new Kullanıcı();
                klnc.Show();
                this.Hide();
            }
        }

        // Form Haraket Ettirme
        int movesk;
        int Mouse_X;
        int Mouse_Y;
        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            movesk = 0;
        }
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            movesk = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }
        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (movesk == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }


        void ReloadForm()
        {
            Salon1_k sln1 = new Salon1_k();
            sln1.Show();
            this.Close();
        }

        

        // Admin Kısmından Çekilen Veriler
        public static string filmadı { get; set; }
        public static string seansgunu { get; set; }
        public static string seanssaati { get; set; }

        // Access Koltuk Kontrol
        OleDbCommand komutkoltuk = new OleDbCommand();
        OleDbDataReader dreader;

        private void KoltukSec(string sorgu)
        {
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
        }
        private void Salon1_k_Load(object sender, EventArgs e)
        {

            label15.Text = Salon1_k.kllnc_adı;
            label4.Text = Salon1_k.filmadı;
            label5.Text = Salon1_k.seansgunu;
            label6.Text = Salon1_k.seanssaati;
            if (label15.Text == "Misafir")
            {
                rb_2.Visible = false;
                label8.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                textBox2.Visible = false;
                button2.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
            }
            else
            {
                rb_1.Visible = false;
                label7.Visible = false;
            }
            if (label15.Text == "")
            {
                label16.Text = "";
            }
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Select Koltuk_no FROM Salon Where Seans_gunu LIKE @seans_gunu AND Seans_saati LIKE @seans_saati AND Salon_no LIKE @salon_no";
            komut.Parameters.AddWithValue("@seans_gunu", label5.Text);
            komut.Parameters.AddWithValue("@seans_saati", label6.Text);
            komut.Parameters.AddWithValue("@salon_no", "Salon 1");
            dr = komut.ExecuteReader();
            List<string> Koltuk = new List<string>();

            while (dr.Read())
            {
                Koltuk.Add(dr.GetString(0));
            }
            foreach (string koltuk_no in Koltuk)
            {
                

                komutkoltuk.Connection = baglanti;
                

                if (koltuk_no == bttn32.Text)
                {
                    bttn32.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn32.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn32.Enabled = true; }
                    else { bttn32.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn32.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn31.Text)
                {
                    bttn31.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn31.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text +"'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn31.Enabled = true; }
                    else { bttn31.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn31.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn30.Text)
                {
                    bttn30.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn30.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn30.Enabled = true; }
                    else { bttn30.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn30.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn29.Text)
                {
                    bttn29.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn29.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn29.Enabled = true; }
                    else { bttn29.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn29.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn28.Text)
                {
                    bttn28.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn28.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn28.Enabled = true; }
                    else { bttn28.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn28.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn27.Text)
                {
                    bttn27.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn27.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn27.Enabled = true; }
                    else { bttn27.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn27.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn26.Text)
                {
                    bttn26.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn26.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn26.Enabled = true; }
                    else { bttn26.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn26.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn25.Text)
                {
                    bttn25.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn25.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn25.Enabled = true; }
                    else { bttn25.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn25.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn24.Text)
                {
                    bttn24.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn24.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn24.Enabled = true; }
                    else { bttn24.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn24.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn23.Text)
                {
                    bttn23.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn23.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn23.Enabled = true; }
                    else { bttn23.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn23.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn22.Text)
                {
                    bttn22.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn22.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn22.Enabled = true; }
                    else { bttn22.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn22.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn21.Text)
                {
                    bttn21.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn21.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn21.Enabled = true; }
                    else { bttn21.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn21.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn20.Text)
                {
                    bttn20.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn20.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn20.Enabled = true; }
                    else { bttn20.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn20.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn19.Text)
                {
                    bttn19.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn19.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn18.Enabled = true; }
                    else { bttn19.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn19.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn18.Text)
                {
                    bttn18.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn18.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn18.Enabled = true; }
                    else { bttn18.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn18.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn17.Text)
                {
                    bttn17.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn17.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn17.Enabled = true; }
                    else { bttn17.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn17.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn16.Text)
                {
                    bttn16.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn16.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn16.Enabled = true; }
                    else { bttn16.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn16.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn15.Text)
                {
                    bttn15.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn15.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn15.Enabled = true; }
                    else { bttn15.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn15.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn14.Text)
                {
                    bttn14.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn14.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn14.Enabled = true; }
                    else { bttn14.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn14.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn13.Text)
                {
                    bttn13.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn13.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn13.Enabled = true; }
                    else { bttn13.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn13.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn12.Text)
                {
                    bttn12.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn12.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn12.Enabled = true; }
                    else { bttn12.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn12.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn11.Text)
                {
                    bttn11.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn11.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn11.Enabled = true; }
                    else { bttn11.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn11.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn10.Text)
                {
                    bttn10.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn10.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn10.Enabled = true; }
                    else { bttn10.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn10.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn9.Text)
                {
                    bttn9.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn9.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn9.Enabled = true; }
                    else { bttn9.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn9.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn8.Text)
                {
                    bttn8.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn8.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn8.Enabled = true; }
                    else { bttn8.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn8.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn7.Text)
                {
                    bttn7.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn7.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn7.Enabled = true; }
                    else { bttn7.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn7.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn6.Text)
                {
                    bttn6.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn6.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn6.Enabled = true; }
                    else { bttn6.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn6.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn5.Text)
                {
                    bttn5.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn5.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn5.Enabled = true; }
                    else { bttn5.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn5.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn4.Text)
                {
                    bttn4.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn4.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn4.Enabled = true; }
                    else { bttn4.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn4.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn3.Text)
                {
                    bttn3.BackColor = Color.FromArgb(238, 17, 17);
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn3.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    if (dreader.Read())
                    { bttn3.Enabled = true; }
                    else { bttn3.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn3.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn2.Text)
                {
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn2.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    bttn2.BackColor = Color.FromArgb(238, 17, 17);
                    if (dreader.Read())
                    { bttn2.Enabled = true; }
                    else { bttn2.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn2.Enabled = false; }
                    dreader.Dispose();
                }
                else if (koltuk_no == bttn1.Text)
                {
                    komutkoltuk.CommandText = "Select * from Salon where Koltuk_no='" + bttn1.Text + "'And Seans_gunu='" + label5.Text + "'And Seans_saati='" + label6.Text + "'And Salon_no='" + label3.Text + "'And kullanici_adı='" + label15.Text + "'And filmadı='" + label4.Text + "'";
                    dreader = komutkoltuk.ExecuteReader();
                    bttn1.BackColor = Color.FromArgb(238, 17, 17);
                    if (dreader.Read())
                    { bttn1.Enabled = true; }
                    else { bttn1.Enabled = false; }
                    if (label15.Text == "Misafir")
                    { bttn1.Enabled = false; }
                    dreader.Dispose();
                }
            }
            komut.Dispose();
            dr.Dispose();
            baglanti.Close();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            if (rb_1.Checked == false && rb_2.Checked == false || textBox1.Text == "")
            { MessageBox.Show("Boş Alan Bırakılamaz"); }
            else
            {
                OleDbCommand komut2 = new OleDbCommand();
                OleDbDataReader dr2;
                if (rb_1.Checked == true)
                { ucret.Text = rb_1.Text; }
                else if (rb_2.Checked == true)
                { ucret.Text = rb_2.Text; }
                baglanti.Open();
                komut2.Connection = baglanti;
                komut2.CommandText = "SELECT * FROM Salon where Koltuk_no='" + textBox1.Text + "'AND Seans_gunu='" + label5.Text + "'AND Seans_saati='" + label6.Text + "'AND Salon_no='" + label3.Text + "'";
                dr2 = komut2.ExecuteReader();
                if (dr2.Read())
                {
                    MessageBox.Show("Dolu Koltuk Seçtiniz");
                }
                else
                {
                    OleDbCommand komut3 = new OleDbCommand();
                    baglanti.Close();
                    komut3.Connection = baglanti;
                    string koltuklar = textBox1.Text;
                    List<string> koltuk_list = koltuklar.Split(' ').ToList();
                    baglanti.Open();
                    foreach (string i in koltuk_list)
                    {
                        if (i != "")
                        {
                            //komut.CommandText = "Insert Into Salon(Koltuk_no,Seans_gunu,Seans_saati,Salon_no,Ucret)Values ('" @koltuk "','" + label5.Text + "','" + label6.Text + "','" + label3.Text + "','" + ucret.Text + "')";
                            komut3.CommandText = "INSERT INTO Salon(Koltuk_no,Seans_gunu,Seans_saati,Salon_no,Ucret,kullanici_adı,filmadı)Values (@koltuk,@seans_gunu,@seans_saati,@salon_no,@ucret,@Kullanici_adı,@film)";
                            komut3.Parameters.Clear();
                            komut3.Parameters.AddWithValue("@koltuk", i);
                            komut3.Parameters.AddWithValue("@seans_gunu", label5.Text);
                            komut3.Parameters.AddWithValue("@seans_saati", label6.Text);
                            komut3.Parameters.AddWithValue("@salon_no", label3.Text);
                            komut3.Parameters.AddWithValue("@ucret", ucret.Text);
                            komut3.Parameters.AddWithValue("@Kullanici_adı", label15.Text);
                            komut3.Parameters.AddWithValue("@film", label4.Text);
                            komut3.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Başarılı");
                }
                dr2.Dispose();
                baglanti.Close();
                ReloadForm();
            }
            baglanti.Close();
        }

        private void btn_click(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor == Color.FromKnownColor(KnownColor.Control))
            {
                ((Button)sender).BackColor = Color.FromArgb(255, 196, 13);
                Button btn = (Button)sender;
                textBox1.Text = btn.Text + " " + textBox1.Text;
            }
            else if (((Button)sender).BackColor == Color.FromArgb(255, 196, 13))
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.FromKnownColor(KnownColor.Control);
                textBox1.Text = "";
                Koltukseciptal();
            }
            else if (((Button)sender).BackColor == Color.FromArgb(238, 17, 17))
            {
                ((Button)sender).BackColor = Color.FromArgb(30, 113, 69);
                Button btn = (Button)sender;
                textBox2.Text = btn.Text + " " + textBox2.Text;
            }
            else if (((Button)sender).BackColor == Color.FromArgb(30, 113, 69))
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.FromArgb(238, 17, 17);
                textBox2.Text = "";
                Koltukiptal();
            }
        }
        void Koltukseciptal()
        {
            if (bttn1.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn1.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn2.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn2.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn3.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn3.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn4.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn4.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn5.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn5.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn6.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn6.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn7.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn7.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn8.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn8.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn9.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn9.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn10.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn10.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn11.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn11.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn12.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn12.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn13.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn13.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn14.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn14.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn15.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn15.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn16.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn16.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn17.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn17.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn18.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn18.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn19.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn19.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn20.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn20.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn21.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn21.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn22.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn22.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn23.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn23.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn24.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn24.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn25.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn25.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn26.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn26.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn27.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn27.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn28.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn28.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn29.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn29.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn30.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn30.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn31.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn31.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (bttn32.BackColor == Color.FromArgb(255, 196, 13))
            {
                bttn32.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }
        void Koltukiptal()
        {
            if (bttn1.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn1.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn2.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn2.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn3.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn3.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn4.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn4.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn5.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn5.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn6.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn6.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn7.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn7.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn8.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn8.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn9.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn9.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn10.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn10.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn11.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn11.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn12.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn12.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn13.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn13.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn14.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn14.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn15.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn15.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn16.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn16.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn17.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn17.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn18.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn18.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn19.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn19.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn20.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn20.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn21.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn21.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn22.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn22.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn23.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn23.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn24.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn24.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn25.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn25.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn26.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn26.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn27.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn27.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn28.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn28.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn29.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn29.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn30.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn30.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn31.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn31.BackColor = Color.FromArgb(238, 17, 17);
            }
            if (bttn32.BackColor == Color.FromArgb(30, 113, 69))
            {
                bttn32.BackColor = Color.FromArgb(238, 17, 17);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbCommand komut2 = new OleDbCommand();
            if (textBox2.Text == "")
            { MessageBox.Show("Boş Alan Bırakılamaz"); }
            else
            {
                string koltuklar = textBox2.Text;
                List<string> koltuk_list = koltuklar.Split(' ').ToList();
                baglanti.Open();
                foreach (string i in koltuk_list)
                {
                    if (i != "")
                    {
                        komut2.Connection = baglanti;
                        komut2.CommandText = "Delete From Salon where Koltuk_no='" + i + "'AND Seans_gunu='" + label5.Text + "'AND Seans_saati='" + label6.Text + "'AND Salon_no='" + label3.Text + "'";
                        komut2.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Koltuk İptal Edildi");
                komut2.Dispose();
                baglanti.Close();
            }
            ReloadForm();
        }
    }
}
