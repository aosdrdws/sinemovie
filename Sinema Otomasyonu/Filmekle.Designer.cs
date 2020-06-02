namespace Sinema_Otomasyonu
{
    partial class Filmekle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.veritabanıDataSet = new Sinema_Otomasyonu.VeritabanıDataSet();
            this.filmekleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.filmekleTableAdapter = new Sinema_Otomasyonu.VeritabanıDataSetTableAdapters.filmekleTableAdapter();
            this.filmadıDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filmturuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yonetmenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filmsureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ıMDBpuanıDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seansgunuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seanssaatiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.veritabanıDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filmekleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(205)))), ((int)(((byte)(134)))));
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.button9.Location = new System.Drawing.Point(396, 250);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(100, 44);
            this.button9.TabIndex = 108;
            this.button9.Text = "Ekle";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(205)))), ((int)(((byte)(134)))));
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.button10.Location = new System.Drawing.Point(396, 306);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(100, 44);
            this.button10.TabIndex = 117;
            this.button10.Text = "Sil";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // comboBox4
            // 
            this.comboBox4.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "Aksiyon",
            "Macera",
            "Animasyon",
            "Komedi",
            "Dram",
            "Fantastik",
            "Korku",
            "Bilim Kurgu",
            "Gerilim"});
            this.comboBox4.Location = new System.Drawing.Point(112, 192);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(100, 24);
            this.comboBox4.TabIndex = 102;
            // 
            // comboBox3
            // 
            this.comboBox3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "1",
            "2"});
            this.comboBox3.Location = new System.Drawing.Point(308, 162);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(100, 24);
            this.comboBox3.TabIndex = 107;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.label4.Location = new System.Drawing.Point(218, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 21);
            this.label4.TabIndex = 116;
            this.label4.Text = "Salon Seç";
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "10:00",
            "12:00",
            "14:00",
            "16:00",
            "18:00",
            "20:00"});
            this.comboBox2.Location = new System.Drawing.Point(112, 342);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(100, 24);
            this.comboBox2.TabIndex = 106;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.label3.Location = new System.Drawing.Point(3, 340);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 21);
            this.label3.TabIndex = 115;
            this.label3.Text = "Seans Saati";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Pazartesi",
            "Salı",
            "Çarşamba",
            "Perşembe",
            "Cuma",
            "Cumartesi",
            "Pazar"});
            this.comboBox1.Location = new System.Drawing.Point(112, 312);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 24);
            this.comboBox1.TabIndex = 105;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.label2.Location = new System.Drawing.Point(3, 310);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 21);
            this.label2.TabIndex = 114;
            this.label2.Text = "Seans Günü";
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox5.Location = new System.Drawing.Point(112, 282);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 21);
            this.textBox5.TabIndex = 104;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox4.Location = new System.Drawing.Point(112, 252);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 21);
            this.textBox4.TabIndex = 101;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.label1.Location = new System.Drawing.Point(3, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 21);
            this.label1.TabIndex = 113;
            this.label1.Text = "Film Süresi";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox3.Location = new System.Drawing.Point(112, 222);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 21);
            this.textBox3.TabIndex = 103;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1.Location = new System.Drawing.Point(112, 162);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 100;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.label5.Location = new System.Drawing.Point(3, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 21);
            this.label5.TabIndex = 112;
            this.label5.Text = "IMDB Puanı";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.label9.Location = new System.Drawing.Point(3, 220);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 21);
            this.label9.TabIndex = 111;
            this.label9.Text = "Yönetmen";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.label10.Location = new System.Drawing.Point(3, 190);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 21);
            this.label10.TabIndex = 110;
            this.label10.Text = "Film Türü";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.label11.Location = new System.Drawing.Point(3, 160);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 21);
            this.label11.TabIndex = 109;
            this.label11.Text = "Film Adı";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.filmadıDataGridViewTextBoxColumn,
            this.filmturuDataGridViewTextBoxColumn,
            this.yonetmenDataGridViewTextBoxColumn,
            this.filmsureDataGridViewTextBoxColumn,
            this.ıMDBpuanıDataGridViewTextBoxColumn,
            this.seansgunuDataGridViewTextBoxColumn,
            this.seanssaatiDataGridViewTextBoxColumn,
            this.salonDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.filmekleBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(-2, -3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(579, 150);
            this.dataGridView1.TabIndex = 118;
            // 
            // veritabanıDataSet
            // 
            this.veritabanıDataSet.DataSetName = "VeritabanıDataSet";
            this.veritabanıDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // filmekleBindingSource
            // 
            this.filmekleBindingSource.DataMember = "filmekle";
            this.filmekleBindingSource.DataSource = this.veritabanıDataSet;
            // 
            // filmekleTableAdapter
            // 
            this.filmekleTableAdapter.ClearBeforeFill = true;
            // 
            // filmadıDataGridViewTextBoxColumn
            // 
            this.filmadıDataGridViewTextBoxColumn.DataPropertyName = "Film_adı";
            this.filmadıDataGridViewTextBoxColumn.HeaderText = "Film_adı";
            this.filmadıDataGridViewTextBoxColumn.Name = "filmadıDataGridViewTextBoxColumn";
            this.filmadıDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // filmturuDataGridViewTextBoxColumn
            // 
            this.filmturuDataGridViewTextBoxColumn.DataPropertyName = "Film_turu";
            this.filmturuDataGridViewTextBoxColumn.HeaderText = "Film_turu";
            this.filmturuDataGridViewTextBoxColumn.Name = "filmturuDataGridViewTextBoxColumn";
            this.filmturuDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // yonetmenDataGridViewTextBoxColumn
            // 
            this.yonetmenDataGridViewTextBoxColumn.DataPropertyName = "Yonetmen";
            this.yonetmenDataGridViewTextBoxColumn.HeaderText = "Yonetmen";
            this.yonetmenDataGridViewTextBoxColumn.Name = "yonetmenDataGridViewTextBoxColumn";
            this.yonetmenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // filmsureDataGridViewTextBoxColumn
            // 
            this.filmsureDataGridViewTextBoxColumn.DataPropertyName = "Film_sure";
            this.filmsureDataGridViewTextBoxColumn.HeaderText = "Film_sure";
            this.filmsureDataGridViewTextBoxColumn.Name = "filmsureDataGridViewTextBoxColumn";
            this.filmsureDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ıMDBpuanıDataGridViewTextBoxColumn
            // 
            this.ıMDBpuanıDataGridViewTextBoxColumn.DataPropertyName = "IMDB_puanı";
            this.ıMDBpuanıDataGridViewTextBoxColumn.HeaderText = "IMDB_puanı";
            this.ıMDBpuanıDataGridViewTextBoxColumn.Name = "ıMDBpuanıDataGridViewTextBoxColumn";
            this.ıMDBpuanıDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // seansgunuDataGridViewTextBoxColumn
            // 
            this.seansgunuDataGridViewTextBoxColumn.DataPropertyName = "Seans_gunu";
            this.seansgunuDataGridViewTextBoxColumn.HeaderText = "Seans_gunu";
            this.seansgunuDataGridViewTextBoxColumn.Name = "seansgunuDataGridViewTextBoxColumn";
            this.seansgunuDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // seanssaatiDataGridViewTextBoxColumn
            // 
            this.seanssaatiDataGridViewTextBoxColumn.DataPropertyName = "Seans_saati";
            this.seanssaatiDataGridViewTextBoxColumn.HeaderText = "Seans_saati";
            this.seanssaatiDataGridViewTextBoxColumn.Name = "seanssaatiDataGridViewTextBoxColumn";
            this.seanssaatiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // salonDataGridViewTextBoxColumn
            // 
            this.salonDataGridViewTextBoxColumn.DataPropertyName = "Salon";
            this.salonDataGridViewTextBoxColumn.HeaderText = "Salon";
            this.salonDataGridViewTextBoxColumn.Name = "salonDataGridViewTextBoxColumn";
            this.salonDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Filmekle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 390);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Filmekle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filmekle";
            this.Load += new System.EventHandler(this.Filmekle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.veritabanıDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filmekleBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridView1;
        private VeritabanıDataSet veritabanıDataSet;
        private System.Windows.Forms.BindingSource filmekleBindingSource;
        private VeritabanıDataSetTableAdapters.filmekleTableAdapter filmekleTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn filmadıDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn filmturuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yonetmenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn filmsureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ıMDBpuanıDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seansgunuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seanssaatiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salonDataGridViewTextBoxColumn;

    }
}