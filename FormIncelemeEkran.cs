using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace R0G_DI7
{
    public partial class FormIncelemeEkran : Form
    {
        public FormIncelemeEkran()
        {
            InitializeComponent();
        }
        string baglantiadresi;
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
        private void FormIncelemeEkran_Load(object sender, EventArgs e)
        {
            metot();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();

            //SqlDataAdapter da = new SqlDataAdapter("select urun_id as 'Bildiri ID', urun_model,urun_grup,urun_mustalep,urun_kayitacanack,urun_kayttarih from bild_listsurec JOIN bild_surec ON bild_surec.inc_bildsürid = bild_listsurec.sur_id INNER JOIN tblbild_urun ON bild_surec.inc_bildsürid = tblbild_urun.urun_id where inc_bildsürid = '2' ", baglanti);
            SqlDataAdapter da = new SqlDataAdapter("select urun_id 'Ürün ID',urun_grup 'Ürün Grubu',urun_model'Ürün Modeli',urun_mustalep 'Musteri Talebi Açıklama',urun_kayitacanack'Kayıt Açan Açıklama',urun_kayitacan 'Kayıt',urun_kayttarih 'Kayıt Tarihi' from tblbild_urun where urun_surec=2  ORDER BY urun_kayttarih DESC ", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

            lblanalog.Text = log;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            lblid.Text = gridView1.GetFocusedRowCellValue("Ürün ID").ToString();
        }

        private void işlemeAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKalislemeal fkai = new FormKalislemeal();
            fkai.log = lblanalog.Text;
            fkai.idfocus = lblid.Text;
            fkai.Show();
        }
    }
}
