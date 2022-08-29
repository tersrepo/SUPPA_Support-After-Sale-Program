using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace R0G_DI7
{
    public partial class FormKaliteGoruntuleme : Form
    {
        public FormKaliteGoruntuleme()
        {
            InitializeComponent();
        }
        string baglantiadresi, baglantiadresi2;
        public string log;

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

        private void talebiİşlemeAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKalislemeal fkai = new FormKalislemeal();
            fkai.log = lblanalog.Text;
            fkai.idfocus = lblid.Text;
            fkai.Show();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            lblid.Text = gridView1.GetFocusedRowCellValue("Ürün ID").ToString();
        }

        private void tALToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FormKalislemeal fkai = new FormKalislemeal();
            fkai.log = lblanalog.Text;
            fkai.idfocus = lblid.Text;
            fkai.Show();
        }

        private void gridView1_QueryCustomFunctions(object sender, DevExpress.XtraGrid.Views.Grid.CustomFunctionEventArgs e)
        {

        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            FormKalislemeal fkai = new FormKalislemeal();
            fkai.idfocus = lblid.Text;
            fkai.Show();
        }

        private void FormKaliteGoruntuleme_Load(object sender, EventArgs e)
        {
            metot();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();

            //SqlDataAdapter da = new SqlDataAdapter("select urun_id 'Ürün ID',urun_grup 'Ürün Grubu',urun_model'Ürün Modeli',urun_mustalep 'Musteri Talebi Açıklama',urun_kayitacanack'Kayıt Açan Açıklama',urun_kayitacan 'Kayıt',urun_kayttarih 'Kayıt Tarihi' from tblbild_urun ORDER BY urun_kayttarih DESC", baglanti);
            SqlDataAdapter da = new SqlDataAdapter("select urun_id 'Ürün ID',bild_isim 'Bildirim Sahibi',urun_grup 'Ürün Grubu',urun_model'Ürün Modeli',urun_mustalep 'Musteri Talebi Açıklama',urun_kayitacanack'Kayıt Açan Açıklama',urun_kayitacan 'Kayıt',oncelik_tip as 'Öncelik',urun_kayttarih 'Kayıt Tarihi' from tblbild_urun JOIN tbl_oncelik on tblbild_urun.urun_oncelik=tbl_oncelik.oncelik_id join tblbild_musteri on tblbild_urun.urun_bildmustel=tblbild_musteri.bild_tel where urun_surec=1  ORDER BY urun_kayttarih DESC ", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

            lblanalog.Text = log;


        }
    }
}
