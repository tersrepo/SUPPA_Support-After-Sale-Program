using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;

namespace R0G_DI7
{
    public partial class FormMusteritoinsert : Form
    {
        public FormMusteritoinsert()
        {
            InitializeComponent();
        }
        MailMessage eposta = new MailMessage();
        public string yazı;
        string baglantiadresi;
        string baglantiadresi2;
        public string yeniyol;

        public string isim2;

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
            while (satir != null)
            {
                baglantiadresi2 = satir;
                satir = oku.ReadLine();
            }
        }
        private void FormMusteritoinsert_Load(object sender, EventArgs e)
        {
            metot();
            metot2();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();


            SqlConnection baglanti2 = new SqlConnection(baglantiadresi2);
            baglanti2.Open();


            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("Select sehir_ad as 'SEHİR',sehir_id AS 'ID' from tbl_sehirler", baglanti);

           

      

          

            SqlDataAdapter da44 = new SqlDataAdapter("select CARIISMI,CARIKODU from CARI_HESAP_ISIMLERI where CARIKODU LIKE '120.01%'", baglanti2);
            DataTable dt44 = new DataTable();
            da44.Fill(dt44);
            look4.Properties.ValueMember = "CARIKODU";
            look4.Properties.DisplayMember = "CARIISMI";
            look4.Properties.NullText = "Cari bilinmiyorsa 'NOVA YURTİÇİ STOK' seçiniz.";
            look4.Properties.DataSource = dt44;

            SqlDataAdapter da1 = new SqlDataAdapter("select * from tbl_soruntipleri", baglanti);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            look3.Properties.ValueMember = "stip_id";
            look3.Properties.DisplayMember = "stip_tanimla";
            look3.Properties.DataSource = dt1;

            //SqlDataAdapter da2 = new SqlDataAdapter("select san_kod,san_isim from STOK_ANA_GRUPLARI", baglanti2);
            //DataTable dt2 = new DataTable();
            //da2.Fill(dt2);
            //look1.Properties.ValueMember = "san_kod";
            //look1.Properties.DisplayMember = "san_isim";
            //look1.Properties.NullText = "Örn:/Flatör";
            //look1.Properties.DataSource = dt2;
            SqlDataAdapter das = new SqlDataAdapter("select ana_stokisim, ana_kod from tbl_stokanagrup", baglanti);
            DataTable dts = new DataTable();
            das.Fill(dts);
            look1.Properties.ValueMember = "ana_kod";
            look1.Properties.DisplayMember = "ana_stokisim";
            //look1.Properties.DisplayMember = "ana_stokisim";
            look1.Properties.NullText = "Ürün grubu; örn/FLATÖR";
            look1.Properties.DataSource = dts;


       


         

            SqlDataAdapter da = new SqlDataAdapter("select bild_isim 'Bildirim Sahibi', bild_tel 'Müşteri Telefon' from tblbild_musteri ORDER BY bild_kayit DESC", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
