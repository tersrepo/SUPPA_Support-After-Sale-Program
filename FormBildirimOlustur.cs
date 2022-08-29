using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;

namespace R0G_DI7
{
    public partial class FormBildirimOlustur : Form
    {
        public FormBildirimOlustur()
        {
            InitializeComponent();
        }
    

        MailMessage eposta = new MailMessage();
        public string yazı;
        string baglantiadresi;
        string baglantiadresi2;
        public string yeniyol;

        public string isim2;
        void MailGonder()
        {
            eposta.From = new MailAddress("*****");
            eposta.To.Add(txtotomail.Text.ToString());
            eposta.Subject = "[*****]  " + lblfocusisim.Text.ToString() + "  Kullanıcısı tarafından yeni bir bildiriminiz var!";
            eposta.Body = DateTime.Parse(dateTimePicker1.Text) + "  Tarihinde Oluşturulan Bildirim;   " + "[ " + txtsikayet.Text.ToString() + " ]" + "    Satış Sonrası Destek Yorumu;  " + "[ " + txtbirimaciklama.Text.ToString() + " ]" + "  Ürün Modeli;  " + "[ " + lookUpEdit3.Text.ToString() + " ]" + "  Bildirilen Ürün Sayısı;  " + "[ " + txturunadet.Text.ToString() + " ]" +"   *Bu mail doğrudan yanıtlanamaz.*    ";
            //eposta.Body = DateTime.Parse(dateTimePicker1.Text) + "  Tarihinde kullanıcı tarafından oluşturulan açıklama;   " + txtbirimaciklama.Text.ToString() + "    Müşterinin talebi;  " + txtsikayet.Text.ToString() + "    Ürün grubu;  " + look1.Text.ToString() + "                * Bu mesaj otomatik olarak oluşturulmuş bir bildiridir *";
            //eposta.From = new MailAddress ("alperincir@voltbilgisayar.com");

            SmtpClient smtp = new SmtpClient();

            //smtp.Credentials = new System.Net.NetworkCredential("*****", "*****");
            smtp.Credentials = new System.Net.NetworkCredential("*****", "*****");
            smtp.Host = "smtp-mail.outlook.com";
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.Send(eposta);
            MessageBox.Show("Mail Gönderme İşlemi Gerçekleştirildi");
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

        private void FormBildirimOlustur_Load(object sender, EventArgs e)
        {
            radioButton6.Checked = true;
            // TODO: This line of code loads data into the 'db_soruntakipDataSet1.tbl_stokyangrup' table. You can move, or remove it, as needed.
            //this.tbl_stokyangrupTableAdapter.Fill(this.db_soruntakipDataSet1.tbl_stokyangrup);
            // TODO: This line of code loads data into the 'db_soruntakipDataSet.tbl_stokanagrup' table. You can move, or remove it, as needed.
            //this.tbl_stokanagrupTableAdapter.Fill(this.db_soruntakipDataSet.tbl_stokanagrup);

            //dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //dateTimePicker1.CustomFormat = "d/M/yyyy hh:mm";
            //d / M / yyyy hh: mm

            //FormMusteriKayitLog.Text = isim2;
            metot();
            metot2();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();


            SqlConnection baglanti2 = new SqlConnection(baglantiadresi2);
            baglanti2.Open();


            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("Select sehir_ad as 'SEHİR',sehir_id AS 'ID' from tbl_sehirler", baglanti);

            da3.Fill(dt3);
            lookUpEdit1.Properties.ValueMember = ("ID");
            lookUpEdit1.Properties.DisplayMember = "SEHİR";

            lookUpEdit1.Properties.NullText = "Sehir Seçiniz";
            lookUpEdit1.Properties.DataSource = dt3;


            SqlDataAdapter da4 = new SqlDataAdapter("select sat_id,sat_firma from tbl_satici", baglanti);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            look5.Properties.ValueMember = "sat_id";
            look5.Properties.DisplayMember = "sat_firma";
            look5.Properties.NullText = "Konuyu Bildiren";
            look5.Properties.DataSource = dt4;

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

            SqlDataAdapter qq1 = new SqlDataAdapter("select bild_isim,bild_tel from tblbild_musteri", baglanti);
            DataTable qt1 = new DataTable();
            qq1.Fill(qt1);
            lookUpEdit5.Properties.ValueMember = "bild_tel";
            lookUpEdit5.Properties.DisplayMember = "bild_isim";
            lookUpEdit5.Properties.DataSource = qt1;

  
            SqlDataAdapter das = new SqlDataAdapter("select ana_stokisim, ana_kod from tbl_stokanagrup", baglanti);
            DataTable dts = new DataTable();
            das.Fill(dts);
            look1.Properties.ValueMember = "ana_kod";
            look1.Properties.DisplayMember = "ana_stokisim";
            //look1.Properties.DisplayMember = "ana_stokisim";
            look1.Properties.NullText = "Ürün grubu; örn/FLATÖR";
            look1.Properties.DataSource = dts;
           

            SqlDataAdapter dar = new SqlDataAdapter("select * from tbl_sehirler ORDER BY sehir_id ASC", baglanti);
            DataTable dtr = new DataTable();
            dar.Fill(dtr);
            lookUpEdit2.Properties.ValueMember ="sehir_id";
            lookUpEdit2.Properties.DisplayMember = "sehir_ad";
            lookUpEdit2.Properties.DataSource = dtr;


            DataTable dtq = new DataTable();
            SqlDataAdapter daq = new SqlDataAdapter("select * from iller ORDER BY id ASC", baglanti);
            daq.Fill(dtq);
            comboBox3.ValueMember = "id";
            comboBox3.DisplayMember = "sehir";
            comboBox3.DataSource = dtq;

            SqlDataAdapter da = new SqlDataAdapter("select bild_isim 'Bildirim Sahibi' , bild_tel 'Ulaşım Bilgisi',sehir 'Şehir',bild_kayit 'Sisteme Kayıt' from tblbild_musteri JOIN iller on tblbild_musteri.bild_sehir=iller.id", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl2.DataSource = dt;
            baglanti.Close();

            if (label10.Text == "1")
            {
                groupControl1.Visible = true;
            }
            else if (label10.Text == "2")
            {
                groupControl1.Visible = false;
            }
            

            






            lblfocusisim.Text = isim2;





          
        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            if (label10.Text == "1")
            {
                metot();
                metot2();


                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("insert into tblbild_musteri(bild_isim,bild_tel,bild_sehir,bild_acikadres,bild_kayit,bild_ilce,bild_mustip) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", baglanti);

                komut2.Parameters.AddWithValue("@p1", txtmusisim.Text);
                komut2.Parameters.AddWithValue("@p2", txtmustel.Text);
                komut2.Parameters.AddWithValue("@p3", comboBox3.SelectedValue);
                komut2.Parameters.AddWithValue("@p4", richTextBox1.Text);
                komut2.Parameters.AddWithValue("@p5", DateTime.Parse(dateTimePicker1.Text));
                komut2.Parameters.AddWithValue("@p6", comboBox4.SelectedValue);
                komut2.Parameters.AddWithValue("@p7", look5.EditValue);
                komut2.ExecuteNonQuery();
                //baglanti.Open();

                //try
                {
                    SqlCommand komut3 = new SqlCommand("insert into tblbild_urun(urun_grup,urun_model,urun_mustalep,urun_satici,urun_kayitacanack,urun_kayitacan,urun_kayttarih,urun_bildmustel,urun_garanti,urun_oncelik,urun_surec,urun_adet) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)", baglanti);
                    komut3.Parameters.AddWithValue("@p1", look1.EditValue);
                    komut3.Parameters.AddWithValue("@p2", lookUpEdit3.EditValue);

                    komut3.Parameters.AddWithValue("@p3", txtsikayet.Text);
                    komut3.Parameters.AddWithValue("@p4", look4.EditValue);
                    komut3.Parameters.AddWithValue("@p5", txtbirimaciklama.Text);
                    komut3.Parameters.AddWithValue("@p6", lblfocusisim.Text);
                    komut3.Parameters.AddWithValue("@p7", DateTime.Parse(dateTimePicker1.Text));
                    komut3.Parameters.AddWithValue("@p8", txtmustel.Text);

         



                    komut3.Parameters.AddWithValue("@p9", lblgaranti.Text);
                    komut3.Parameters.AddWithValue("@p10", lbloncelik.Text);
                    komut3.Parameters.AddWithValue("@p11", lblsurec.Text);
                    komut3.Parameters.AddWithValue("@p12", txturunadet.Text);
                    //komut3.Parameters.AddWithValue("@p13", txtmusisim.Text);
                    //komut3.Parameters.AddWithValue("@p14", txtmustel.Text);

                    komut3.ExecuteNonQuery();

                    MessageBox.Show("Bildirim Oluşturuldu");
                    //SqlConnection baglanti = new SqlConnection(baglantiadresi);
                    //baglanti.Open();

                    SqlCommand komut9 = new SqlCommand("insert into bild_surec (inc_bildid) values (@p1)", baglanti);
                    komut9.Parameters.AddWithValue("@p1", label7.Text);
                    //komut9.Parameters.AddWithValue("@p2", DateTime.Parse(dateTimePicker1.Text));
                    komut9.ExecuteNonQuery();

                    MailGonder();
                }
          
            }
            else if(label10.Text == "2")
            {
                //try
                {
                    
                    baglanti.Open();
                    SqlCommand komut3 = new SqlCommand("insert into tblbild_urun(urun_grup,urun_model,urun_mustalep,urun_satici,urun_kayitacanack,urun_kayitacan,urun_kayttarih,urun_bildmustel,urun_garanti,urun_oncelik,urun_surec,urun_adet) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)", baglanti);
                    komut3.Parameters.AddWithValue("@p1", look1.EditValue);
                    komut3.Parameters.AddWithValue("@p2", lookUpEdit3.EditValue.ToString());

                    komut3.Parameters.AddWithValue("@p3", txtsikayet.Text);
                    komut3.Parameters.AddWithValue("@p4", look4.EditValue);
                    komut3.Parameters.AddWithValue("@p5", txtbirimaciklama.Text);
                    komut3.Parameters.AddWithValue("@p6", lblfocusisim.Text);
                    komut3.Parameters.AddWithValue("@p7", DateTime.Parse(dateTimePicker1.Text));
                    komut3.Parameters.AddWithValue("@p8", txtmustel.Text);

             



                    komut3.Parameters.AddWithValue("@p9", lblgaranti.Text);
                    komut3.Parameters.AddWithValue("@p10", lbloncelik.Text);
                    komut3.Parameters.AddWithValue("@p11", lblsurec.Text);
                    komut3.Parameters.AddWithValue("@p12", txturunadet.Text);
                    //komut3.Parameters.AddWithValue("@p13", txtmusisim.Text);
                    //komut3.Parameters.AddWithValue("@p14", txtmustel.Text);

                    komut3.ExecuteNonQuery();

                    MessageBox.Show("Bildirim Oluşturuldu");
                    //SqlConnection baglanti = new SqlConnection(baglantiadresi);
                    //baglanti.Open();

                    SqlCommand komut9 = new SqlCommand("insert into bild_surec (inc_bildid) values (@p1)", baglanti);
                    komut9.Parameters.AddWithValue("@p1", label7.Text);
                    //komut9.Parameters.AddWithValue("@p2", DateTime.Parse(dateTimePicker1.Text));
                    komut9.ExecuteNonQuery();

                    MailGonder();
                }
                //catch (Exception)
                //{
                //    MessageBox.Show("Boş değer bırakıldı & Null değer");
                //}
            }
            // else
            //{
            //    Application.Exit();
            //}

            //KANKA BURADAN ---------------------------------

            //SqlConnection baglanti = new SqlConnection(baglantiadresi);
            //baglanti.Open();
            //SqlCommand komut2 = new SqlCommand("insert into tblbild_musteri(bild_isim,bild_tel,bild_sehir,bild_acikadres,bild_kayit,bild_ilce) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);

            //komut2.Parameters.AddWithValue("@p1", txtmusisim.Text);
            //komut2.Parameters.AddWithValue("@p2", txtmustel.Text);
            //komut2.Parameters.AddWithValue("@p3", comboBox3.SelectedValue);
            //komut2.Parameters.AddWithValue("@p4", richTextBox1.Text);
            //komut2.Parameters.AddWithValue("@p5", DateTime.Parse(dateTimePicker1.Text));
            //komut2.Parameters.AddWithValue("@p6", comboBox4.SelectedValue);
            //komut2.ExecuteNonQuery();
            ////baglanti.Open();

            //try
            //{
            //    SqlCommand komut3 = new SqlCommand("insert into tblbild_urun(urun_grup,urun_model,urun_mustalep,urun_satici,urun_kayitacanack,urun_kayitacan,urun_kayttarih,urun_bildmustel,urun_garanti,urun_oncelik,urun_surec,urun_adet,urun_musisim,urun_mustel) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14)", baglanti);
            //    komut3.Parameters.AddWithValue("@p1", look1.EditValue);
            //    komut3.Parameters.AddWithValue("@p2", lookUpEdit3.Text);

            //    komut3.Parameters.AddWithValue("@p3", txtsikayet.Text);
            //    komut3.Parameters.AddWithValue("@p4", look4.EditValue);
            //    komut3.Parameters.AddWithValue("@p5", txtbirimaciklama.Text);
            //    komut3.Parameters.AddWithValue("@p6", lblfocusisim.Text);
            //    komut3.Parameters.AddWithValue("@p7", DateTime.Parse(dateTimePicker1.Text));
            //    komut3.Parameters.AddWithValue("@p8", txtmustel.Text);

            //    //if (txtmusisim == null)
            //    //{
            //    //    komut3.Parameters.AddWithValue("@p8", txtsecmus.Text);
            //    //}
            //    //else
            //    //{
            //    //    komut3.Parameters.AddWithValue("@p8", txtmusisim.Text);
            //    //}



            //    komut3.Parameters.AddWithValue("@p9", lblgaranti.Text);
            //    komut3.Parameters.AddWithValue("@p10", lbloncelik.Text);
            //    komut3.Parameters.AddWithValue("@p11", lblsurec.Text);
            //    komut3.Parameters.AddWithValue("@p12", txturunadet.Text);
            //    //komut3.Parameters.AddWithValue("@p13", txtmusisim.Text);
            //    //komut3.Parameters.AddWithValue("@p14", txtmustel.Text);

            //    komut3.ExecuteNonQuery();
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Boş değer bırakıldı & Null değer");
            //}

            // KANKA BURAYA KADAR------------------------------------------------

            //baglanti.Open();

            //SqlCommand komut8 = new SqlCommand("select urun_id from tblbild_urun where urun_kayttarih = @p1", baglanti);
            //komut8.Parameters.AddWithValue("@p1", dateTimePicker2.Value.ToString());
            //SqlDataReader dr8 = komut8.ExecuteReader();
            //while (dr8.Read())
            //{
            //   label7.Text = dr8[0].ToString();
            //}

            //SqlCommand k1 = new SqlCommand("select urun_id from tblbild_urun where urun_kayitacanack = @p1", baglanti);
            //k1.Parameters.AddWithValue("@p1",txtbirimaciklama.Text);
            //SqlDataReader dr1 = k1.ExecuteReader();
            //while (dr1.Read()) 
            //{
            //    label7.Text = dr1[0].ToString();
            //}

            //dr1.Close();



            //KANKA BURADAN
            //MessageBox.Show("Bildirim Oluşturuldu");
            ////SqlConnection baglanti = new SqlConnection(baglantiadresi);
            //baglanti.Open();

            //SqlCommand komut9 = new SqlCommand("insert into bild_surec (inc_bildid) values (@p1)", baglanti);
            //komut9.Parameters.AddWithValue("@p1", label7.Text);
            ////komut9.Parameters.AddWithValue("@p2", DateTime.Parse(dateTimePicker1.Text));
            //komut9.ExecuteNonQuery();

            //BURAYA











            //komut3.ExecuteNonQuery();

            //KANKAN BURADAN
            /*MailGonder();*/ //AÇ TEKRAR!!!!!!!!!!!!!!!!!!!!
                              //BURAYA
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            lblgaranti.Text = "2";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            lblgaranti.Text = "1";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            lbloncelik.Text = "1";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            lbloncelik.Text = "2";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            lbloncelik.Text = "3";
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();

            if (comboBox3.SelectedIndex != -1)
            {
                DataTable dtz = new DataTable();
                SqlDataAdapter daz = new SqlDataAdapter("select * from ilceler where sehir= " + comboBox3.SelectedValue,baglanti);
                daz.Fill(dtz);
                comboBox4.ValueMember = "id";
                comboBox4.DisplayMember = "ilce";
                
                comboBox4.DataSource = dtz;
            }
        }

        private void lookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();

            if (lookUpEdit2.Properties.EditValueChangedDelay !=1) 
            {
                DataTable dtz = new DataTable();
                SqlDataAdapter daz = new SqlDataAdapter("select * from tbl_ilceler where ilce_sehri= " + lookUpEdit2.EditValue, baglanti);
                daz.Fill(dtz);
                lookUpEdit4.Properties.ValueMember="ilce_id" ;
                lookUpEdit4.Properties.DisplayMember= "ilce_ad";
                lookUpEdit4.Properties.NullText = "İlçe Seçiniz";
                lookUpEdit4.Properties.DataSource= dtz;
                //comboBox4.DisplayMember = "ilce_ad";
                //comboBox4.DataSource = dtz;
            }
        }

        private void look1_EditValueChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();
            if(look1.Properties.EditValueChangedDelay != 1)
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select stoyan_isim,stoyan_kod from tbl_stokyangrup where stoyan_ana=" + look1.EditValue, baglanti);
                da.Fill(dt);
                lookUpEdit3.Properties.ValueMember = "stoyan_kod";
                lookUpEdit3.Properties.DisplayMember = "stoyan_isim";
                lookUpEdit3.Properties.NullText = "Ürün modeli; örn/KOMPAKT FLATÖR";
                //lookUpEdit3.Properties.DisplayMember = "stoyan_kod";
                lookUpEdit3.Properties.DataSource = (dt);

            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (groupControl4.Visible == false)
            {
                groupControl4.Visible = true;
            }
            else if (groupControl4.Visible == true)
            {

                groupControl4.Visible = false;
            }
            lblmustel.Visible = true;
            lblisim.Visible = true;
            label8.Visible = true;
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //lblaksiyonid.Text = gridView4.GetFocusedRowCellValue("ID").ToString();
            //comboBox3.Text = gridView1.RowClick("Şehir").ToString();
                //select bild_isim 'Bildirim Sahibi', bild_tel 'Ulaşım Bilgisi',bild_sehir 'Şehir',bild_acikadres 'Açıkadres',bild_kayit 'Sisteme Kayıt' from tblbild_musteri ORDER BY bild_kayit DESC
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //comboBox3.Text = gridView1.GetFocusedRowCellValue("Şehir").ToString();
            //comboBox4.Text = gridView1.GetFocusedRowCellValue("İlçe").ToString();
            //txtsectel.Text = gridView1.GetFocusedRowCellValue("Ulaşım Bilgisi").ToString();
            //txtsecmus.Text = gridView1.GetFocusedRowCellValue("Bildirim Sahibi").ToString();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            label10.Text = "1";

            if (label10.Text == "1")
            {
                groupControl1.Visible = true;
            }
            if (label10.Text == "1")
            {
                groupControl3.Visible = false;
            }
            //else
            //{
            //    groupControl1.Visible = false;
            //}
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            label10.Text = "2";

            if (label10.Text == "2")
            {
                groupControl1.Visible = false;
            }
            if(label10.Text == "2")
            {
                groupControl3.Visible = true;
            }
            //else
            //{
            //    groupControl3.Visible = false;
            //}

        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //try
            //{
            //    txtsectel.Text = gridView2.GetFocusedRowCellValue("Ulaşım Bilgisi").ToString();
            //    txtsecmus.Text = gridView2.GetFocusedRowCellValue("Bildirim Sahibi").ToString();
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Hata");
            //}
        
        }

        private void lookUpEdit5_EditValueChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();

            SqlCommand komut = new SqlCommand("select bild_isim,bild_tel from tblbild_musteri where bild_isim=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", lookUpEdit5.Text);
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                txtmusisim.Text = dr[0].ToString();
                txtmustel.Text = dr[1].ToString();
                //txtdepartman.Text = dr[2].ToString();
                //txtdemirbas.Text = dr[3].ToString();

            }
            baglanti.Close();
        }
    }
}
