using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;

namespace R0G_DI7
{
    public partial class FormKalislemeal : Form
    {
        public FormKalislemeal()
        {
            InitializeComponent();
        }
        string baglantiadresi;
        public string isim2,idfocus,log;
        
        MailMessage eposta = new MailMessage();
        //public string idfocus;

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

        
        
            
        
        void MailGonder()
        {
            //eposta.From = new MailAddress("*****");
            //eposta.To.Add(textBox1.Text.ToString());
            //eposta.Subject = "[*****]  " + lbllog.Text.ToString() + "  Kullanıcısı tarafından toplantı talebi !";
            //eposta.Body = txttaleptarihi.Text + "   [Tarihinde oluşturulan musteri talebi]   " + txttalep.Text.ToString() + "    [Kullanıcı açıklaması]  " + txtaciklama.Text.ToString() + "                            [Ürün Model]   " + txtmodel.Text.ToString() + "       [Toplantı Talebi Açıklama]  " +richTextBox1.Text + "       [Talep Edilen Toplantı Saati]   " + DateTime.Parse(dateTimePicker1.Text)+ "                               * Bu mail doğrudan yanıtlanamaz. Do not directly reply to this email to comment and CC your teammates to add them as collaborators. *";
            ////eposta.Body = DateTime.Parse(dateTimePicker1.Text) + "  Tarihinde kullanıcı tarafından oluşturulan açıklama;   " + txtbirimaciklama.Text.ToString() + "    Müşterinin talebi;  " + txtsikayet.Text.ToString() + "    Ürün grubu;  " + look1.Text.ToString() + "                * Bu mesaj otomatik olarak oluşturulmuş bir bildiridir *";
            ////eposta.From = new MailAddress ("*****");

            //SmtpClient smtp = new SmtpClient();

            //smtp.Credentials = new System.Net.NetworkCredential("*****", "*****");
            //smtp.Host = "*****";
            //smtp.EnableSsl = true;
            //smtp.Port = 587;
            //smtp.Send(eposta);
            //MessageBox.Show("İşleminiz Gerçekleştirildi");
            //devamkee
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            

            //if (İnceleme.Visible==false)
            //{
            //    İnceleme.Visible = true;
            //}
            //else if (İnceleme.Visible==true)
            //{
                
            //    İnceleme.Visible = false;
            //}


       
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //metot();
            //SqlConnection baglanti = new SqlConnection(baglantiadresi);
            //baglanti.Open();
            //SqlCommand komut5 = new SqlCommand("insert into tblbild_toplanti (top_bildid,top_aciklama,top_tarih) values (@p1,@p2,@p3)", baglanti);

            //komut5.Parameters.AddWithValue("@p1", txtfocusid.Text);
            //komut5.Parameters.AddWithValue("@p2", richTextBox1.Text);
            //komut5.Parameters.AddWithValue("@p3", DateTime.Parse(dateTimePicker1.Text));
            //komut5.ExecuteNonQuery();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            metot();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("insert into tblbild_toplanti (top_bildid,top_aciklama,top_tarih) values (@p1,@p2,@p3)", baglanti);

            //komut5.Parameters.AddWithValue("@p1", txtfocusid.Text);
            //komut5.Parameters.AddWithValue("@p2", textBox1.Text);
            //komut5.Parameters.AddWithValue("@p3", DateTime.Parse(dateTimePicker1.Text));
            //komut5.ExecuteNonQuery();

            MailGonder();
            //devamkee
        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            //metot();
            //SqlConnection baglanti = new SqlConnection(baglantiadresi);
            //baglanti.Open();
            //SqlCommand komut4 = new SqlCommand("insert into tblbild_aksplan (aks_planbildid,aks_planaciklama,aks_plantarih) values (@p1,@p2,@p3)", baglanti);

            //komut4.Parameters.AddWithValue("@p1", txtfocusid.Text);
            //komut4.Parameters.AddWithValue("@p2", txttoptalep.Text);
            //komut4.Parameters.AddWithValue("@p3", DateTime.Parse(dateTimePicker2.Text));
            //komut4.ExecuteNonQuery();

        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //textBox1.Text = gridView1.GetFocusedRowCellValue("per_mail").ToString();

            
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //textBox2.Text = gridView2.GetFocusedRowCellValue("per_mail").ToString();
            //devamkee
            
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
     
            metot();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("insert into tblbild_aksiyon (aks_bildid,aks_sorumlusu,aks_acan,aks_baslangictar,aks_termintar,aks_acilisacik) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);

            komut4.Parameters.AddWithValue("@p1", txtfocusid.Text);
            komut4.Parameters.AddWithValue("@p2", lookUpEdit2.EditValue);
            komut4.Parameters.AddWithValue("@p3", lbllog.Text);
            komut4.Parameters.AddWithValue("@p4", DateTime.Parse(dateTimePicker8.Text));
            komut4.Parameters.AddWithValue("@p5", DateTime.Parse(dateTimePicker2.Text));
            komut4.Parameters.AddWithValue("@p6", richTextBox2.Text);
     

            komut4.ExecuteNonQuery();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            metot();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();
            SqlCommand komutx = new SqlCommand("insert into tblbild_aksplanbitir (aksplanbitir_aciklama,aksplanbitir_bildid,aksplanbitir_tarih) values (@p1,@p2,@p3)", baglanti);

            komutx.Parameters.AddWithValue("@p1", richTextBox4.Text);
            komutx.Parameters.AddWithValue("@p2", txtfocusid.Text);
            komutx.Parameters.AddWithValue("@p3", DateTime.Parse(dateTimePicker4.Text));
            komutx.ExecuteNonQuery();

            //label9.Text = "Süreci Tamamlandı !";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (xtraTabControl2.Visible == false)
            //{
            //    xtraTabControl2.Visible = true;
            //}
            //else if (xtraTabControl2.Visible == true)
            //{

            //    xtraTabControl2.Visible = false;
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.Visible == false)
            {
                xtraTabControl1.Visible = true;
            }
            else if (xtraTabControl1.Visible == true)
            {

                xtraTabControl1.Visible = false;
            }
        }

        private void simpleButton19_Click(object sender, EventArgs e)
        {
            metot();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("insert into tblbild_inceleme (bildinc_bildid,bildinc_aciklama,bildinc_tarih,bildinc_log) values (@p1,@p2,@p3,@p4)", baglanti);

            komut4.Parameters.AddWithValue("@p1", txtfocusid.Text);
            komut4.Parameters.AddWithValue("@p2", richTextBox6.Text);
            komut4.Parameters.AddWithValue("@p3", DateTime.Parse(dateTimePicker5.Text));
            komut4.Parameters.AddWithValue("@p4", lbllog.Text);
          

            komut4.ExecuteNonQuery();
        }

        private void simpleButton16_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            xtraTabControl3.Visible = true;
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //string v = string.Empty;
            //v = (String)gridView2.GetFocusedRowCellValue("bildinc_id").ToString();
            //txtincelemeid.Text = v;



            //if (v == null)
            //{
            //    v = txtfocusid.Text;
            //}

            //txtincelemeacik.Text = gridView2.GetFocusedRowCellValue("İnceleme Acıklama").ToString();
            //if (txtincelemeacik.Text == null)
            //{
            //    txtincelemeacik.Text = lbllog.Text;
            //}



            //metot();
            //SqlConnection baglanti = new SqlConnection(baglantiadresi);
            //baglanti.Open();

            //try
            //{
            //    DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            //    lblincelemeid.Text = row["bildinc_id"].ToString();
            //    txtincelemeview.Text = row["İnceleme Acıklama"].ToString();

            //}
            //catch 
            //{
            //    MessageBox.Show("basaramadık");
            //}





            //try
            //{
            //    if (lblincelemeid.Text == null)
            //    {
            //        lblincelemeid.Text = txtfocusid.Text;
            //    }

            //    else
            //    {
            //        //txtincelemeview.Text = gridView2.GetFocusedRowCellValue("İnceleme Acıklama").ToString();
            //        lblincelemeid.Text = gridView2.GetFocusedRowCellValue("bildinc_id").ToString();
            //    }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("e");
            //}
            //DEVAMKEEE


            //if (lblincelemeid.Text == null)
            //{
            //    lblincelemeid.Text = txtfocusid.Text;
            //}
            //else if (txtincelemeview.Text == null)
            //{
            //    txtincelemeview.Text = txtfocusid.Text;

            //}
            //else
            //{
            //    txtincelemeview.Text = gridView2.GetFocusedRowCellValue("İnceleme Acıklama").ToString();
            //    lblincelemeid.Text = gridView2.GetFocusedRowCellValue("bildinc_id").ToString();
            //}

            txtincelemeview.Text = gridView2.GetFocusedRowCellValue("İnceleme Acıklama").ToString();
            lblincelemeid.Text = gridView2.GetFocusedRowCellValue("bildinc_id").ToString();



        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            metot();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();
            SqlCommand incelemeguncelle = new SqlCommand("Update tblbild_inceleme set bildinc_aciklama=@p1 where bildinc_id=@p2", baglanti);
            incelemeguncelle.Parameters.AddWithValue("@p1", txtincelemeview.Text);
            incelemeguncelle.Parameters.AddWithValue("@p2", lblincelemeid.Text);
            incelemeguncelle.ExecuteNonQuery();
            baglanti.Close();
            
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            metot();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();
            SqlCommand incelemesil = new SqlCommand("Delete from tblbild_inceleme where bildinc_id=@p1", baglanti);
           
            incelemesil.Parameters.AddWithValue("@p1", lblincelemeid.Text);
            incelemesil.ExecuteNonQuery();
            baglanti.Close();
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {

        }

        private void incelemeGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formİncelemeİşlem fki = new Formİncelemeİşlem();
            fki.log = lbllog.Text;
            fki.yazı = lblincelemeid.Text;
            fki.yazı2 = lbllog.Text;
            fki.yazı3 = txtfocusid.Text;

            this.Hide();
            fki.Show();

            //Formİncelemeİşlem fki = new Formİncelemeİşlem();
            ////FormKalislemeal fuck = new FormKalislemeal();

            //fki.yazı = lblincelemeid.Text;
            //fki.yazı2 = lbllog.Text;
            //fki.yazı3 = txtfocusid.Text;
            //this.Hide();
            //fki.Show();
            ////fuck.Hide();

        }

        private void incelemeSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //metot();
            //SqlConnection baglanti = new SqlConnection(baglantiadresi);
            //baglanti.Open();
            //try
            //{
            //    SqlCommand incelemesil = new SqlCommand("Delete from tblbild_inceleme where bildinc_id=@p1", baglanti);

            //    incelemesil.Parameters.AddWithValue("@p1", lblincelemeid.Text);
            //    incelemesil.ExecuteNonQuery();
            //    baglanti.Close();
            //    MessageBox.Show("Değerlendirme Silindi");
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Opss...Bir hata dönüyor");
            //}

            ////SqlCommand komut8 = new SqlCommand("select bildinc_id, bildinc_aciklama as 'İnceleme Acıklama',bildinc_tarih as 'Başlama Tarihi' from tblbild_inceleme where bildinc_bildid = @P1", baglanti);
            ////komut8.Parameters.AddWithValue("@P1", txtfocusid.Text);

            ////SqlDataAdapter da8 = new SqlDataAdapter(komut8);
            ////DataTable dt8 = new DataTable();
            ////da8.Fill(dt8);
            ////gridControl2.DataSource = dt8;

        }

        private void gridView4_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                lblaksiyonid.Text = gridView4.GetFocusedRowCellValue("ID").ToString();

                if (lblaksiyonid == null)
                {
                    lblaksiyonid.Text ="0";
                }
                //lblincelemeid.Text = gridView2.GetFocusedRowCellValue("bildinc_id").ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Dönebilir");
            }
        }

        private void aksiyonGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAksiyonİşlem fai = new FormAksiyonİşlem();
            fai.text1 = lblaksiyonid.Text;
            fai.text2 = lbllog.Text;
            fai.text3 = txtfocusid.Text;
            fai.log = lbllog.Text;
            this.Hide();
            fai.Show();

            //FormAksiyonİşlem fai = new FormAksiyonİşlem();
            //fai.text1 = lblaksiyonid.Text;
            //fai.text2= lbllog.Text;
            //fai.text3 = txtfocusid.Text;
            //fai.log = lbllog.Text;
            //this.Hide();
            //fai.Show();
        }

        private void aksiyonBitirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAksiyonBitir fab = new FormAksiyonBitir();
            fab.text1 = lblaksiyonid.Text;
            fab.text2 = lbllog.Text;
            fab.text3 = txtfocusid.Text;
            fab.log = lbllog.Text;
            this.Hide();
            fab.Show();

        }

        private void aksiyonSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
     
        }

        private void simpleButton10_Click_1(object sender, EventArgs e)
        {
            if (xtraTabControl4.Visible == false)
            {
                xtraTabControl4.Visible = true;
            }
            else if (xtraTabControl4.Visible == true)
            {

                xtraTabControl4.Visible = false;
            }
        }

        private void simpleButton21_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            if (xtraTabControl2.Visible == false)
            {
                xtraTabControl2.Visible = true;
            }
            else if (xtraTabControl2.Visible == true)
            {

                xtraTabControl2.Visible = false;
            }
        }

        private void simpleButton25_Click(object sender, EventArgs e)
        {
            metot();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();
            
            SqlCommand bildirimsonlandır = new SqlCommand("Update tblbild_urun set urun_surec=@p1,urun_sonlandiracik=@p3,urun_sonlandirtar=@p4,urun_grup=@p5,urun_model=@p6,urun_sonladiran=@p7,urun_adet=@p8,urun_sortip=@p9 where urun_id=@p2", baglanti);
            bildirimsonlandır.Parameters.AddWithValue("@p1", "3");
            bildirimsonlandır.Parameters.AddWithValue("@p2", txtfocusid.Text);
            bildirimsonlandır.Parameters.AddWithValue("@p3", richTextBox3.Text);
            bildirimsonlandır.Parameters.AddWithValue("@p4", DateTime.Parse(dateTimePicker1.Text));
            bildirimsonlandır.Parameters.AddWithValue("@p5", lookUpEdit3.EditValue);
            bildirimsonlandır.Parameters.AddWithValue("@p6", lookUpEdit4.EditValue);
            bildirimsonlandır.Parameters.AddWithValue("@p7", lbllog.Text);
            bildirimsonlandır.Parameters.AddWithValue("@p8", txtadet.Text);
            bildirimsonlandır.Parameters.AddWithValue("@p9", lookUpEdit5.EditValue);
            bildirimsonlandır.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show(" Bildirim Sonlandırma Tamamlandı");
        }

        private void lookUpEdit4_EditValueChanged(object sender, EventArgs e)
        {
            //SqlConnection baglanti = new SqlConnection(baglantiadresi);
            //baglanti.Open();
            //if (lookUpEdit3.Properties.EditValueChangedDelay != 1)
            //{
            //    DataTable dt = new DataTable();
            //    SqlDataAdapter da = new SqlDataAdapter("select stoyan_isim,stoyan_kod from tbl_stokyangrup where stoyan_ana=" + lookUpEdit3.EditValue, baglanti);
            //    da.Fill(dt);
            //    lookUpEdit4.Properties.ValueMember = "stoyan_kod";
            //    lookUpEdit4.Properties.DisplayMember = "stoyan_isim";
            //    lookUpEdit4.Properties.NullText = "Ürün modeli; örn/KOMPAKT FLATÖR";
            //    //lookUpEdit3.Properties.DisplayMember = "stoyan_kod";
            //    lookUpEdit4.Properties.DataSource = (dt);

            //}
        }

        private void lookUpEdit3_EditValueChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();
            if (lookUpEdit3.Properties.EditValueChangedDelay != 1)
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select stoyan_isim,stoyan_kod from tbl_stokyangrup where stoyan_ana=" + lookUpEdit3.EditValue, baglanti);
                da.Fill(dt);
                lookUpEdit4.Properties.ValueMember = "stoyan_kod";
                lookUpEdit4.Properties.DisplayMember = "stoyan_isim";
                lookUpEdit4.Properties.NullText = "Model Seçiniz";
                //lookUpEdit3.Properties.DisplayMember = "stoyan_kod";
                lookUpEdit4.Properties.DataSource = (dt);

            }
        }

        private void gridView5_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //txtincelemeview.Text = gridView2.GetFocusedRowCellValue("İnceleme Acıklama").ToString();
            textBox2.Text = gridView5.GetFocusedRowCellValue("per_mail").ToString();
        }

        private void simpleButton22_Click(object sender, EventArgs e)
        {
            eposta.From = new MailAddress("*****");
            eposta.To.Add(textBox2.Text.ToString());
            eposta.Subject = "[*****]  " + lbllog.Text.ToString() + "  Kullanıcısı tarafından toplantı talebi !";
            eposta.Body = txttaleptarihi.Text + "   TARİHİNDE OLUŞTURULAN MÜŞTERİ BİLDİRİMİ;  " + "[ "+ txttalep.Text.ToString() +" ]"+  "   SATIŞ SONRASI DESTEK AÇIKLAMASI;   " +"[ "+ txtaciklama.Text.ToString() +" ]"+ "   ÜRÜN MODELİ;   " +"[ "+ txtmodel.Text.ToString() +" ]"+ "   TOPLANTI TALEP NEDENİ;   " + "[ "+ richTextBox1.Text + " ]" +   "   TOPLANTI SAATİ;   " + DateTime.Parse(dateTimePicker6.Text) + "         (Bu mail doğrudan yanıtlanamaz)";
            //eposta.Body = DateTime.Parse(dateTimePicker1.Text) + "  Tarihinde kullanıcı tarafından oluşturulan açıklama;   " + txtbirimaciklama.Text.ToString() + "    Müşterinin talebi;  " + txtsikayet.Text.ToString() + "    Ürün grubu;  " + look1.Text.ToString() + "                * Bu mesaj otomatik olarak oluşturulmuş bir bildiridir *";
            //eposta.From = new MailAddress ("*****");

            SmtpClient smtp = new SmtpClient();

            //smtp.Credentials = new System.Net.NetworkCredential("*****", "*****");
            smtp.Credentials = new System.Net.NetworkCredential("*****", "*****");
            smtp.Host = "smtp-mail.outlook.com";
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.Send(eposta);
            MessageBox.Show("Toplantı Talebiniz Gönderildi");

          
        }

        private void simpleButton20_MouseHover(object sender, EventArgs e)
        {
            //simpleButton20.BackColor = Color.Red;
        }

        private void simpleButton20_Click(object sender, EventArgs e)
        {
            Formİncelemeİşlem fki = new Formİncelemeİşlem();
            fki.log = lbllog.Text;
            fki.yazı = lblincelemeid.Text;
            fki.yazı2 = lbllog.Text;
            fki.yazı3 = txtfocusid.Text;

            this.Hide();
            fki.Show();
        }

        private void simpleButton21_Click_1(object sender, EventArgs e)
        {
            FormAksiyonİşlem fai = new FormAksiyonİşlem();
            fai.text1 = lblaksiyonid.Text;
            fai.text2 = lbllog.Text;
            fai.text3 = txtfocusid.Text;
            fai.log = lbllog.Text;
            this.Hide();
            fai.Show();
        }

        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //try
            //{
            //    txtincelemeview.Text = gridView2.GetFocusedRowCellValue("İnceleme Acıklama").ToString();
            //    lblincelemeid.Text = gridView2.GetFocusedRowCellValue("bildinc_id").ToString();

            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Bir Hata Dönebilir");
            //}
        }

        private void simpleButton26_Click(object sender, EventArgs e)
        {
            //metot();
            //SqlConnection baglanti = new SqlConnection(baglantiadresi);
            //baglanti.Open();
            //try
            //{
            //    SqlCommand incelemesil = new SqlCommand("Delete from tblbild_inceleme where bildinc_id=@p1", baglanti);

            //    incelemesil.Parameters.AddWithValue("@p1", txtincelemeid.Text);
            //    incelemesil.ExecuteNonQuery();
            //    baglanti.Close();
            //    MessageBox.Show("Değerlendirme Silindi");
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Opss...Bir hata dönüyor");
            //}

            //SqlCommand komut8 = new SqlCommand("select bildinc_id, bildinc_aciklama as 'İnceleme Acıklama',bildinc_tarih as 'Başlama Tarihi' from tblbild_inceleme where bildinc_bildid = @P1", baglanti);
            //komut8.Parameters.AddWithValue("@P1", txtfocusid.Text);

            //SqlDataAdapter da8 = new SqlDataAdapter(komut8);
            //DataTable dt8 = new DataTable();
            //da8.Fill(dt8);
            //gridControl2.DataSource = dt8;
        }

        private void gridControl2_DataSourceChanged(object sender, EventArgs e)
        {
           
        }

        private void gridView2_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //txtincelemeview.Text = gridView2.GetFocusedRowCellValue("İnceleme Acıklama").ToString();
            //lblincelemeid.Text = gridView2.GetFocusedRowCellValue("bildinc_id").ToString();
            
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }

        //sayfa güncelleme
        private void simpleButton24_Click(object sender, EventArgs e)
        {
            metot();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();

            SqlCommand komut8 = new SqlCommand("select bildinc_id, bildinc_aciklama as 'İnceleme Acıklama',bildinc_tarih as 'Başlama Tarihi' from tblbild_inceleme where bildinc_bildid = @P1", baglanti);
            komut8.Parameters.AddWithValue("@P1", txtfocusid.Text);

            SqlDataAdapter da8 = new SqlDataAdapter(komut8);
            DataTable dt8 = new DataTable();
            da8.Fill(dt8);
            gridControl2.DataSource = dt8;

            SqlCommand komut5 = new SqlCommand("select aks_id as'ID',aks_baslangictar as'Baslangic Tarihi' ,per_ad as 'Aksiyon Sorumlusu',aks_acilisacik as 'Aksiyon Tanımı',(DATEDIFF (DAY,GETDATE(), aks_termintar)) as 'Kalan Gün',aks_kapanisacik as 'Kapanış Açıklama',aks_bitirmetar as 'Kapanış Tarihi' from tblbild_aksiyon JOIN tbl_personel on tblbild_aksiyon.aks_sorumlusu=tbl_personel.per_id where aks_bildid = @P1", baglanti);
            komut5.Parameters.AddWithValue("@P1", txtfocusid.Text);

            SqlDataAdapter da5 = new SqlDataAdapter(komut5);
            DataTable dt5 = new DataTable();
            da5.Fill(dt5);
            gridControl4.DataSource = dt5;
        }

        private void FormKalislemeal_Load(object sender, EventArgs e)
        {
            metot();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();
            txtfocusid.Text = idfocus;
            lbllog.Text = log;

            SqlCommand komut = new SqlCommand("select urun_grup,urun_model,urun_mustalep,urun_kayitacanack,urun_kayitacan,urun_kayttarih,urun_bildmustel from tblbild_urun where urun_id=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", txtfocusid.Text);
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                txtgrup.Text = dr[0].ToString();
                txtmodel.Text = dr[1].ToString();
                txttalep.Text = dr[2].ToString();
                txtaciklama.Text = dr[3].ToString();
                txttalepacan.Text = dr[4].ToString();
                txttaleptarihi.Text = dr[5].ToString();
                lblmustel.Text = dr[6].ToString();

            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut01 = new SqlCommand("select bild_isim,sat_firma from tblbild_urun INNER JOIN tblbild_musteri on tblbild_urun.urun_bildmustel=tblbild_musteri.bild_tel INNER JOIN tbl_satici on tblbild_musteri.bild_mustip=tbl_satici.sat_id where urun_bildmustel=@p1", baglanti);
            komut01.Parameters.AddWithValue("@p1", lblmustel.Text);
            
            SqlDataReader dr01 = komut01.ExecuteReader();
            while (dr01.Read())
            {
                txtmusisim.Text = dr01[0].ToString();
                txtmusteritip.Text = dr01[1].ToString();
            }
            baglanti.Close();

            //SqlCommand komut8 = new SqlCommand("select top_aciklama as 'Toplantı Acıklama',top_katilimci as 'Toplantı Katılımcılar',top_tarih as 'Oluşturulan Toplantı Tarihi' from tblbild_toplanti where top_bildid = @P1", baglanti);
            //komut8.Parameters.AddWithValue("@P1", txtfocusid.Text);

            //SqlDataAdapter da8 = new SqlDataAdapter(komut8);
            //DataTable dt8 = new DataTable();
            //da8.Fill(dt8);
            //gridControl2.DataSource = dt8;
            SqlCommand komut8 = new SqlCommand("select bildinc_id, bildinc_aciklama as 'İnceleme Acıklama',bildinc_tarih as 'Başlama Tarihi' from tblbild_inceleme where bildinc_bildid = @P1", baglanti);
            komut8.Parameters.AddWithValue("@P1", txtfocusid.Text);

            SqlDataAdapter da8 = new SqlDataAdapter(komut8);
            DataTable dt8 = new DataTable();
            da8.Fill(dt8);
            gridControl2.DataSource = dt8;

            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("Select dep_ad,dep_id from tbl_departman", baglanti);

            da3.Fill(dt3);
            lookUpEdit1.Properties.ValueMember = ("dep_id");
            lookUpEdit1.Properties.DisplayMember = "dep_ad";

            lookUpEdit1.Properties.NullText = "Departman Seçiniz";
            lookUpEdit1.Properties.DataSource = dt3;

            DataTable dt4 = new DataTable();
            SqlDataAdapter da4 = new SqlDataAdapter("Select per_ad,per_id from tbl_personel", baglanti);

            da4.Fill(dt4);
            lookUpEdit2.Properties.ValueMember = ("per_id");
            lookUpEdit2.Properties.DisplayMember = "per_ad";

            

            lookUpEdit2.Properties.NullText = "Sorumlu Seçiniz";
            lookUpEdit2.Properties.DataSource = dt4;

            if (txtgrup.Text == "152.01")
            {
                lookUpEdit5.Visible = true;
            }
            else if (txtgrup.Text == "152.00")
            {
                lookUpEdit5.Visible = true;
            }
          

            DataTable dt22 = new DataTable();
            SqlDataAdapter da22 = new SqlDataAdapter("  select stip_id,stip_tanimla from tbl_soruntipleri", baglanti);

            da22.Fill(dt22);
            lookUpEdit5.Properties.ValueMember = ("stip_id");
            lookUpEdit5.Properties.DisplayMember = ("stip_tanimla");
            lookUpEdit5.Properties.NullText = "Arıza Tespitini Belirtin";
            lookUpEdit5.Properties.DataSource = dt22;

            SqlDataAdapter da = new SqlDataAdapter("select per_ad,per_mail from tbl_personel", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl5.DataSource = dt;
            //gridControl1.DataSource = gridControl1;
            //devamkee

            //SqlDataAdapter da1 = new SqlDataAdapter("select top_aciklama,top_tarih from tblbild_toplanti", baglanti);
            //DataTable dt1 = new DataTable();
            //da1.Fill(dt1);
            //gridControl2.DataSource = dt1;

            //SqlDataAdapter da2 = new SqlDataAdapter("select aks_planaciklama,aks_plantarih from tblbild_aksplan", baglanti);
            //DataTable dt2 = new DataTable();
            //da2.Fill(dt2);
            //gridControl3.DataSource = dt2;
            //SqlCommand komut9 = new SqlCommand("select bildinc_bitirmeacik as 'İnceleme Sonlandırma Acıklama',bildinc_bitirmetar as 'İnceleme Sonlandırma Tarihi' from tblbild_inceleme where bildinc_bildid = @P1", baglanti);
            //komut9.Parameters.AddWithValue("@P1", txtfocusid.Text);

            //SqlDataAdapter da9 = new SqlDataAdapter(komut9);
            //DataTable dt9 = new DataTable();
            //da9.Fill(dt9);
            //gridControl3.DataSource = dt9;

            //SqlDataAdapter da5 = new SqlDataAdapter("select * from tblbild_tester", baglanti);
            //DataTable dt5 = new DataTable();
            //da5.Fill(dt5);
            //gridControl4.DataSource = dt5;

            //SqlCommand komut5 = new SqlCommand("select aks_id as ID, aks_baslangictar as 'Baslangic Tarihi' ,aks_acilisacik as 'Aksiyon Tanımı',aks_sorumlusu as 'Aksiyon Sorumlusu',aks_termintar as 'Sorumlu Test Süresi',aks_bitirmetar as 'Kapanış Tarihi',aks_kapanisacik as 'Kapanış Açıklama'from tblbild_aksiyon where aks_bildid = @P1", baglanti);
            SqlCommand komut5 = new SqlCommand("select aks_id as'ID',aks_baslangictar as'Baslangic Tarihi' ,per_ad as 'Aksiyon Sorumlusu',aks_acilisacik as 'Aksiyon Tanımı',(DATEDIFF (DAY,GETDATE(), aks_termintar)) as 'Kalan Gün',aks_kapanisacik as 'Kapanış Açıklama',aks_bitirmetar as 'Kapanış Tarihi' from tblbild_aksiyon JOIN tbl_personel on tblbild_aksiyon.aks_sorumlusu=tbl_personel.per_id where aks_bildid = @P1", baglanti);
            komut5.Parameters.AddWithValue("@P1", txtfocusid.Text);

            SqlDataAdapter da5 = new SqlDataAdapter(komut5);
            DataTable dt5 = new DataTable();
            da5.Fill(dt5);
            gridControl4.DataSource = dt5;

            //SqlCommand komut8 = new SqlCommand("select top_aciklama,top_tarih,top_katilimci,top_tarih from tblbild_toplanti where top_bildid = @P1", baglanti);
            //komut8.Parameters.AddWithValue("@P1", txtfocusid.Text);

            //SqlDataAdapter da8 = new SqlDataAdapter(komut);
            //DataTable dt8 = new DataTable();
            //da8.Fill(dt8);
            //gridControl2.DataSource = dt8;
            //komut3.ExecuteNonQuery();


            //baglanti.Open();

            SqlDataAdapter das = new SqlDataAdapter("select ana_stokisim, ana_kod from tbl_stokanagrup", baglanti);
            DataTable dts = new DataTable();
            das.Fill(dts);
            lookUpEdit3.Properties.ValueMember = "ana_kod";
            lookUpEdit3.Properties.DisplayMember = "ana_stokisim";
            //look1.Properties.DisplayMember = "ana_stokisim";
            lookUpEdit3.Properties.NullText = "Ürün grubu seçiniz";
            lookUpEdit3.Properties.DataSource = dts;

            lookUpEdit4.Properties.NullText = "Model Seçiniz";







        }
    }
}




















































































































































































































































































































































































































































































































































































































































































































































































































































