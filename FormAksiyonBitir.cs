using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace R0G_DI7
{
    public partial class FormAksiyonBitir : Form
    {
        public FormAksiyonBitir()
        {
            InitializeComponent();
        }
        string baglantiadresi;
        public string text1, text2, text3,log;

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                metot();
                SqlConnection baglanti = new SqlConnection(baglantiadresi);
                baglanti.Open();
                SqlCommand incelemeguncelle = new SqlCommand("Update tblbild_aksiyon set aks_kapanisacik=@p1,aks_bitirmetar=@p3 where aks_id=@p2", baglanti);
                incelemeguncelle.Parameters.AddWithValue("@p1", richTextBox2.Text);
                incelemeguncelle.Parameters.AddWithValue("@p2", label1.Text);
                incelemeguncelle.Parameters.AddWithValue("@p3", DateTime.Parse(dateTimePicker8.Text));
                incelemeguncelle.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show(" [" + label1.Text + " ] No'lu Aksiyon Sonlandırıldı");
            }
            catch (Exception)
            {
                MessageBox.Show("Opss... Bir Hata Gerçekleşti");
            }

            FormKalislemeal fkai = new FormKalislemeal();
            fkai.log = lbllog.Text;
            fkai.idfocus = label3.Text;
            this.Hide();
            fkai.Show();
        }

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
        private void FormAksiyonBitir_Load(object sender, EventArgs e)
        {
            label1.Text = text1;//aksiyon id
            label2.Text = text2;//log per
            label3.Text = text3;//bildirim id
            lbllog.Text = log;

            metot();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
       

            try
            {

                baglanti.Open();
                SqlCommand komut = new SqlCommand("select aks_acilisacik,aks_termintar,aks_baslangictar from tblbild_aksiyon where aks_id=@p1", baglanti);
                komut.Parameters.AddWithValue("@p1", label1.Text);
                SqlDataReader dr = komut.ExecuteReader();

                while (dr.Read())
                {
                    richTextBox1.Text = dr[0].ToString();
                    textBox1.Text = dr[1].ToString();
                    textBox2.Text = dr[2].ToString();
          

                }
                baglanti.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show("Yeni İnceleme & Bir önceki inceleme Null");
            }
        }
    }
}
