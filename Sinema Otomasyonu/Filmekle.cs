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
    public partial class Filmekle : Form
    {
        public Filmekle()
        {
            InitializeComponent();
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
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from kullanici", baglanti);
            adtr.Fill(ds, "kullanici");
            dataGridView1.DataSource = ds.Tables["kullanici"];
            adtr.Dispose();
            baglanti.Close();
        }
        private void Filmekle_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'veritabanıDataSet.filmekle' table. You can move, or remove it, as needed.
            this.filmekleTableAdapter.Fill(this.veritabanıDataSet.filmekle);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || comboBox4.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "")
            { MessageBox.Show("Boş Alan Bırakılamaz"); }
            else
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "SELECT * FROM filmekle where Film_adı='" + textBox1.Text + "'";
                dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Bu Film Zaten Ekli");
                }
                else
                {
                    baglanti.Close();
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "Insert Into filmekle(Film_adı,Film_turu,Yonetmen,Film_suresi,IMDB_puanı,Seans_gunu,Seans_saati,Salon)Values ('" + textBox1.Text + "','" + comboBox4.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "')";
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                    baglanti.Close();
                    ds.Clear();
                    MessageBox.Show("Film Eklendi");
                    listele();
                }
                baglanti.Close();
                listele();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || comboBox4.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "")
            { MessageBox.Show("Boş Alan Bırakılamaz"); }
            else
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "Delete from filmekle where Film_adı='" + textBox1.Text + "'";
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                ds.Clear();
                MessageBox.Show("Film Silindi");
            }
        }
    }
}
