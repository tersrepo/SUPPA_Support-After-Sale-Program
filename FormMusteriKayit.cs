using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace R0G_DI7
{
    public partial class FormMusteriKayit : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FormMusteriKayit()
        {
            InitializeComponent();
        }
        string baglantiadresi;
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

        private void FormMusteriKayit_Load(object sender, EventArgs e)
        {
            metot();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();
            FormMusteriKayitLog.Text = isim2;

            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_musteri", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;


            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("Select sehir_ad as 'SEHİR',sehir_id AS 'ID' from tbl_sehirler", baglanti);

            da3.Fill(dt3);
            lookUpEdit1.Properties.ValueMember = ("ID");
            lookUpEdit1.Properties.DisplayMember = "SEHİR";

            lookUpEdit1.Properties.NullText = "Sehir Seçiniz";
            lookUpEdit1.Properties.DataSource = dt3;


        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into tbl_musteri(mus_isim,mus_tel,mus_sehir,mus_acikadres,mus_kyttarih,mus_kytacan) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut2.Parameters.AddWithValue("@p1", txtmusisim.Text);
            komut2.Parameters.AddWithValue("@p2", txtmustel.Text);
            komut2.Parameters.AddWithValue("@p3", lookUpEdit1.EditValue);
            komut2.Parameters.AddWithValue("@p4", richTextBox1.Text);
            komut2.Parameters.AddWithValue("@p5", DateTime.Parse(dateTimePicker1.Text));
            komut2.Parameters.AddWithValue("@p6", FormMusteriKayitLog.Text);
            komut2.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_musteri", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

            SqlCommand komut3 = new SqlCommand("select mus_id from tbl_musteri where mus_tel = @p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", txtmustel.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblfocus.Text = dr3[0].ToString();
            }
            baglanti.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void şikayetOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMusteriSikayet fms = new FormMusteriSikayet();
            fms.yazı = lblfocus.Text;
            
            fms.Show();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            lblfocus.Text = gridView1.GetFocusedRowCellValue("mus_tel").ToString();
            lblfocusisim.Text = gridView1.GetFocusedRowCellValue("mus_isim").ToString();
        }

        private void lbltelfocus_Click(object sender, EventArgs e)
        {

        }
    }
}
