using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace R0G_DI7
{
    public partial class FormSonlandırmaInceleme : Form
    {
        public FormSonlandırmaInceleme()
        {
            InitializeComponent();
        }
        string baglantiadresi;
        public string isim2, idfocus, log;
        int sayac = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            timer1.Interval = 1300;
            if (sayac % 1 == 0)
            {
                this.bildsayi.BackColor = Color.White;
                this.bildsayi.ForeColor = Color.DarkSlateGray;
                this.aksiyonsayi.BackColor = Color.White;
                this.aksiyonsayi.ForeColor = Color.DarkSlateGray;
                this.pictureBox1.Visible = true;
                this.pictureBox3.Visible = true;
            }
            
            if (sayac % 3 == 0)
            {
                //this.bildsayi.BackColor = Color.Black;
                this.bildsayi.ForeColor = Color.White;
                //this.aksiyonsayi.BackColor = Color.Black;
                this.aksiyonsayi.ForeColor = Color.White;
                this.pictureBox1.Visible = false;
                this.pictureBox3.Visible = true;
            }
        }


        //public string idfocus;

        void metot()
        {
            StreamReader oku = new StreamReader(".\\DATABASE.INI");
            string satir = oku.ReadLine();
            while (satir != null)
            {
                baglantiadresi = satir;
                satir = oku.ReadLine();
            }
        }
        private void FormSonlandırmaInceleme_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Enabled = true;

            metot();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();
            textBox1.Text = idfocus;
            lbllog.Text = log;

        
           
          
            lbllog.Text = log;

            SqlCommand komut = new SqlCommand("select urun_grup,urun_model,urun_mustalep,urun_kayitacanack,urun_kayitacan,urun_kayttarih,urun_sonlandiracik,urun_sonlandirtar,urun_sonladiran from tblbild_urun where urun_id=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                txtgrup.Text = dr[0].ToString();
                txtmodel.Text = dr[1].ToString();
                txttalep.Text = dr[2].ToString();
                txtaciklama.Text = dr[3].ToString();
                txttalepacan.Text = dr[4].ToString();
                txttaleptarihi.Text = dr[5].ToString();
                richTextBox1.Text = dr[6].ToString();
                textBox2.Text = dr[7].ToString();
                textBox3.Text = dr[8].ToString();

            }
            baglanti.Close();
            
            baglanti.Open();

            SqlCommand komut7 = new SqlCommand("select count(*) from tblbild_inceleme where bildinc_bildid=@p1", baglanti);
            komut7.Parameters.AddWithValue("@p1", textBox1.Text);
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                bildsayi.Text = " " + textBox1.Text + " Numaralı Bildirim İçin Sistemdeki Değerlendirme Tanımı  " + dr7[0].ToString();

            }
            baglanti.Close();

            baglanti.Open();

            SqlCommand komut6 = new SqlCommand("select count(*) from tblbild_aksiyon where aks_bildid=@p1", baglanti);
            komut6.Parameters.AddWithValue("@p1", textBox1.Text);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                aksiyonsayi.Text = " " + textBox1.Text + " Numaralı Bildirim İçin Sistemdeki Aksiyon Tanımı   " + dr6[0].ToString();

            }
            baglanti.Close();

        

           

        }
    }
}
