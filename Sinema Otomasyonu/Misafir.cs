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
    public partial class Misafir : Form
    {
        public Misafir()
        {
            InitializeComponent();
        }

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
        // Access
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Veritabanı.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        OleDbDataReader dr;
        void listele()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from filmekle", baglanti);
            adtr.Fill(ds, "filmekle");
            dataGridView1.DataSource = ds.Tables["filmekle"];
            adtr.Dispose();
            baglanti.Close();
        }

        int move5;
        int Mouse_X;
        int Mouse_Y;

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            move5 = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }
        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (move5 == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }       
        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            move5 = 0;
        }

        private void Misafir_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'veritabanıDataSet.filmekle' table. You can move, or remove it, as needed.
            listele();
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.FromArgb(41, 39, 40);
            this.dataGridView1.DefaultCellStyle.Font = new Font("Century Gothic", 8);
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
            if (textBox11.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "") { MessageBox.Show("Bir Film Seçiniz"); }
            else if (dr.Read())
            {
                if (textBox4.Text == "1")
                {
                    Salon1_k.filmadı = textBox3.Text;
                    Salon1_k.seansgunu = textBox5.Text;
                    Salon1_k.seanssaati = textBox11.Text;
                    Salon1_k.kllnc_adı = label4.Text;
                    Salon1_k sln1 = new Salon1_k();
                    sln1.Show();
                    this.Hide();
                }
                else if (textBox4.Text == "2")
                {
                    Salon2_k.filmadı2 = textBox3.Text;
                    Salon2_k.seansgunu2 = textBox5.Text;
                    Salon2_k.seanssaati2 = textBox11.Text;
                    Salon2_k.kllnc_adı = label4.Text;
                    Salon2_k sln2 = new Salon2_k();
                    sln2.Show();
                    this.Hide();
                }
            }
            baglanti.Close();
        }
    }
}