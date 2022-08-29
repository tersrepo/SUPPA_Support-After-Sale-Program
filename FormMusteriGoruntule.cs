using System;using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace R0G_DI7
{
    public partial class FormMusteriGoruntule : Form
    {
        public FormMusteriGoruntule()
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

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void FormMusteriGoruntule_Load(object sender, EventArgs e)
        {
            metot();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();

            SqlDataAdapter da = new SqlDataAdapter("select C.bild_isim 'Bildirim Sahibi', C.bild_tel 'Ulaşım Bilgisi',A.sehir 'Şehir',B.ilce 'İlçe', C.bild_acikadres 'Açıkadres',C.bild_kayit 'Sisteme Kayıt'  from tblbild_musteri C JOIN iller A on C.bild_sehir=A.id   LEFT JOIN ilceler B on C.bild_ilce=B.id  ORDER BY bild_kayit DESC", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void metot2()
        {
            StreamReader oku = new StreamReader(".\\DATABASE2.INI");
            string satir = oku.ReadLine();
            while (satir != null)
            {
                baglantiadresi2 = satir;
                satir = oku.ReadLine();
            }
        }
    }
}
