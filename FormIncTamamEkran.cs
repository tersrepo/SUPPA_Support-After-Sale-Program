using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace R0G_DI7
{
    public partial class FormIncTamamEkran : Form
    {
        public FormIncTamamEkran()
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
        private void FormIncTamamEkran_Load(object sender, EventArgs e)
        {
            metot();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();

            SqlDataAdapter da = new SqlDataAdapter("select urun_id as 'Bildiri ID', urun_model,urun_grup,urun_mustalep,urun_kayitacanack,urun_kayttarih from bild_listsurec JOIN bild_surec ON bild_surec.inc_bildsürid = bild_listsurec.sur_id INNER JOIN tblbild_urun ON bild_surec.inc_bildsürid = tblbild_urun.urun_id where inc_bildsürid = '3' ", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
    }
}
