using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace R0G_DI7
{
    public partial class Formİncelemeİşlem : Form
    {
        public Formİncelemeİşlem()
        {
            InitializeComponent();
        }
        string baglantiadresi;
        public string isim2, idfocus;
        public string yazı, yazı2,yazı3,log;
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

        private void simpleButton19_Click(object sender, EventArgs e)
        {
            metot();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();
            SqlCommand komut7 = new SqlCommand("insert into tblbild_inceleme (bildinc_bildid,bildinc_aciklama,bildinc_tarih,bildinc_log) values (@p1,@p2,@p3,@p4)", baglanti);

            komut7.Parameters.AddWithValue("@p1", label3.Text);
            komut7.Parameters.AddWithValue("@p2", richTextBox6.Text);
            komut7.Parameters.AddWithValue("@p3", DateTime.Parse(dateTimePicker3.Text));
            komut7.Parameters.AddWithValue("@p4", label2.Text);
            komut7.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show(" [" + label3.Text +" ] No'lu Bildirim Değerlendirme Kaydedildi");

            baglanti.Open();
            SqlCommand incelemeguncelle = new SqlCommand("Update tblbild_urun set urun_surec=@p1 where urun_id=@p2", baglanti);
            incelemeguncelle.Parameters.AddWithValue("@p1","2");
            incelemeguncelle.Parameters.AddWithValue("@p2", label3.Text);
            incelemeguncelle.ExecuteNonQuery();
            baglanti.Close();
            this.Hide();

            FormKalislemeal fkai = new FormKalislemeal();
            fkai.log = lbllog.Text;
            fkai.idfocus = label3.Text;
            fkai.Show();





        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            //metot();
            //SqlConnection baglanti = new SqlConnection(baglantiadresi);
            //baglanti.Open();
            //SqlCommand komut7 = new SqlCommand("insert into tblbild_inceleme (bildinc_bildid,bildinc_aciklama,bildinc_tarih,bildinc_log) values (@p1,@p2,@p3,@p4)", baglanti);

            //komut7.Parameters.AddWithValue("@p1", label3.Text);
            //komut7.Parameters.AddWithValue("@p2", richTextBox6.Text);
            //komut7.Parameters.AddWithValue("@p3", DateTime.Parse(dateTimePicker5.Text));
            //komut7.Parameters.AddWithValue("@p4", label2.Text);
            //komut7.ExecuteNonQuery();
            //baglanti.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            metot();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();
            SqlCommand incelemeguncelle = new SqlCommand("Update tblbild_inceleme set bildinc_aciklama=@p1 where bildinc_id=@p2", baglanti);
            incelemeguncelle.Parameters.AddWithValue("@p1", txtincelemeview.Text);
            incelemeguncelle.Parameters.AddWithValue("@p2", label1.Text);
            incelemeguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show(" [" + label1.Text + " ] No'lu Bildirim Değerlendirme Güncellendi");
            this.Hide();

            FormKalislemeal fkai = new FormKalislemeal();
            fkai.log = lbllog.Text;
            fkai.idfocus = label3.Text;
            fkai.Show();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            metot();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();
            try
            {
                SqlCommand incelemesil = new SqlCommand("Delete from tblbild_inceleme where bildinc_id=@p1", baglanti);

                incelemesil.Parameters.AddWithValue("@p1", label1.Text);
                incelemesil.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Değerlendirme Silindi");
            }
            catch (Exception)
            {
                MessageBox.Show("Opss...Bir hata dönüyor");
            }
            this.Hide();
            FormKalislemeal fkai = new FormKalislemeal();
            fkai.log = lbllog.Text;
            fkai.idfocus = label3.Text;
            fkai.Show();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupControl4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            metot();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("insert into tblbild_inceleme (bildinc_bildid,bildinc_aciklama,bildinc_tarih,bildinc_log) values (@p1,@p2,@p3,@p4)", baglanti);

            komut4.Parameters.AddWithValue("@p1", label3.Text);
            komut4.Parameters.AddWithValue("@p2", richTextBox1.Text);
            komut4.Parameters.AddWithValue("@p3", DateTime.Parse(dateTimePicker1.Text));
            komut4.Parameters.AddWithValue("@p4", label2.Text);
      
            komut4.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("[ " + label3.Text + " ] No'lu Bildirim İncelemesi Kaydedildi");
        }

        private void Formİncelemeİşlem_Load(object sender, EventArgs e)
        {
            label1.Text = yazı;//INCELEME ID
            label2.Text = yazı2;//LOG AD
            label3.Text = yazı3; //BİLDİRİM İD
            lbllog.Text = log;//login
       
            Formİncelemeİşlem fii = new Formİncelemeİşlem();
            fii.Hide();

            try
            {
                metot();
                SqlConnection baglanti = new SqlConnection(baglantiadresi);
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select bildinc_aciklama,bildinc_log,bildinc_tarih from tblbild_inceleme where bildinc_id=@p1", baglanti);
                komut.Parameters.AddWithValue("@p1", label1.Text);
                SqlDataReader dr = komut.ExecuteReader();

                while (dr.Read())
                {
                    txtincelemeview.Text = dr[0].ToString();
                    txtincelemelog.Text = dr[1].ToString();
                    textBox1.Text = dr[2].ToString();
              

                }
                baglanti.Close();
            }
            catch (Exception)
            {
                
            }


        }
    }
}
