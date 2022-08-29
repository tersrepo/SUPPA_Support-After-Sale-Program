using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace R0G_DI7
{
    public partial class FormArizaListesi : Form
    {
        public FormArizaListesi()
        {
            InitializeComponent();
        }
        string baglantiadresi, baglantiadresi2;

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

        void metot2()
        {
            StreamReader oku = new StreamReader(".\\DATABASE2.INI");
            string satir = oku.ReadLine();
            while(satir != null)
            {
                baglantiadresi2 = satir;
                satir = oku.ReadLine();
            }
        }
        private void FormArizaListesi_Load(object sender, EventArgs e)
        {
            metot();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();

            SqlDataAdapter da = new SqlDataAdapter("select bild_isim 'Bildirim Sahibi',urun_model'Ürün Modeli',urun_mustalep 'Musteri Talebi Açıklama',urun_satici'Satış Yapan Cari',urun_kayitacanack'Kayıt Açan Açıklama',urun_kayitacan 'Kayıt',urun_kayttarih 'Kayıt Tarihi',urun_id 'Kayıt ID' from tblbild_urun inner join tblbild_musteri on tblbild_urun.urun_bildmustel=tblbild_musteri.bild_tel ", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
    }
}
