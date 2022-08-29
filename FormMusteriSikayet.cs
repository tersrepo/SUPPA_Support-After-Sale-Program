using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;



namespace R0G_DI7
{
    public partial class FormMusteriSikayet : Form
    {
        public FormMusteriSikayet()
        {
            InitializeComponent();
        }
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
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try 
            { 
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into tbl_sorunkayit(sor_urungrup,sor_musid,sor_kayitacanper,sor_soruntip,sor_kaystok,sor_birimaciklama,sor_ilgilisatici,sor_mustel,sor_mussikayet,sor_kyttarih,sor_resim) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", baglanti);
            komut2.Parameters.AddWithValue("@p1", look1.EditValue);
            komut2.Parameters.AddWithValue("@p2", txtid.Text);

            komut2.Parameters.AddWithValue("@p3", lblkullanici.Text);

            komut2.Parameters.AddWithValue("@p4", look3.EditValue);

            komut2.Parameters.AddWithValue("@p5", look2.EditValue);
            komut2.Parameters.AddWithValue("@p6", txtbirimaciklama.Text);
            komut2.Parameters.AddWithValue("@p7", look4.EditValue);
            komut2.Parameters.AddWithValue("@p8", txttel.Text);
            komut2.Parameters.AddWithValue("@p9", txtsikayet.Text);
            komut2.Parameters.AddWithValue("@p10", DateTime.Parse(dateTimePicker1.Text));
            komut2.Parameters.AddWithValue("@p11", Path.GetFileName(yeniyol));
            komut2.ExecuteNonQuery();


            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_sorunkayit", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Alan boş bırakılamaz veya seçim yapmadan kaydedilemez");
            }

            //MailMessage eposta = new MailMessage();
            //void MailGonder()
            //{
            //    eposta.From = new MailAddress("*****");
            //    eposta.To.Add()
            //}
        }

        private void FormMusteriSikayet_Load(object sender, EventArgs e)
        {
            metot2();
            SqlConnection baglanti2 = new SqlConnection(baglantiadresi2);
            baglanti2.Open();

            lblkullanici.Text = isim2;
            lblid.Text = yazı;

            SqlDataAdapter da2 = new SqlDataAdapter("select san_kod,san_isim from STOK_ANA_GRUPLARI", baglanti2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            look1.Properties.ValueMember = "san_kod";
            look1.Properties.DisplayMember = "san_isim";
            look1.Properties.DataSource = dt2;

            SqlDataAdapter da3 = new SqlDataAdapter("select sto_kod,sto_isim from STOKLAR", baglanti2);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            look2.Properties.ValueMember = "sto_kod";
            look2.Properties.DisplayMember = "sto_isim";
            look2.Properties.DataSource = dt3;


            metot();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_sorunkayit", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

            //SqlDataAdapter da6 = new SqlDataAdapter("select urn_grupid as 'ID',urn_grup as 'Ürün Grupları' from tbl_urungrup", baglanti);
            //DataTable dt6 = new DataTable();
            //da6.Fill(dt6);
            //lookUpEdit7.Properties.ValueMember = "ID";
            //lookUpEdit7.Properties.DisplayMember = "Ürün Grupları";
            //lookUpEdit7.Properties.DataSource = dt6;

            SqlDataAdapter da1 = new SqlDataAdapter("select * from tbl_soruntipleri", baglanti);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            look3.Properties.ValueMember = "stip_id";
            look3.Properties.DisplayMember = "stip_tanimla";
            look3.Properties.DataSource = dt1;

            SqlDataAdapter da4 = new SqlDataAdapter("select sat_id,sat_firma from tbl_satici", baglanti);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            look4.Properties.ValueMember = "sat_id";
            look4.Properties.DisplayMember = "sat_firma";
            look4.Properties.DataSource = dt4;


            SqlCommand komut3 = new SqlCommand("select mus_id from tbl_musteri where mus_tel = @p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", lblid.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                txtid.Text = dr3[0].ToString();
            }
            baglanti.Close();

            txttel.Text = lblid.Text;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*png;*nef | Tüm Dosyalar |*.*";
            dosya.ShowDialog();
            string dosyayolu = dosya.FileName;
            yeniyol = "C:\\*****\\*****\\*****" + "\\*****\\" + Guid.NewGuid().ToString() + ".jpg";
            
            File.Copy(dosyayolu, yeniyol);
            pictureBox1.ImageLocation = yeniyol;
        }
    }
}
