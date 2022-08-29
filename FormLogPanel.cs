using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;

namespace R0G_DI7
{
    public partial class FormLogPanel : DevExpress.XtraBars.TabForm
    {
        public FormLogPanel()
        {
            InitializeComponent();
        }

        string baglantiadresi;
        MailMessage eposta = new MailMessage();

        void MailGonder()
        {
            eposta.From = new MailAddress("*****");
            eposta.To.Add(txtotomail.Text.ToString());
            eposta.Subject = "[*****]  " + lblfocusisim.Text.ToString() + "  SSD Şifre Yardımcısı";
            eposta.Body = DateTime.Parse(dateTimePicker1.Text) + "  Şifreniz;   " + "[ "  + "   *Bu mail doğrudan yanıtlanamaz.*    ";
      
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

        void metot ()
        {
            StreamReader oku = new StreamReader(".\\DATABASE.INI");
            string satir = oku.ReadLine();
            while(satir !=null)
            {
                baglantiadresi = satir;
                satir = oku.ReadLine();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //metot();
            //SqlConnection baglanti = new SqlConnection(baglantiadresi);
            //baglanti.Open();

            //SqlCommand komut = new SqlCommand("Select * from tbl_girispanel where kullanıcı_id=@p1 and kullanicisifre=@p2", baglanti);
            //komut.Parameters.AddWithValue("@p1", txtid.Text);
            //komut.Parameters.AddWithValue("@p2", txtpw.Text);
            //SqlDataReader dr = komut.ExecuteReader();
            //if (dr.Read()) 
            //{
            //    FormTabMenu ftm = new FormTabMenu();
            //    ftm.isim = txtid.Text;
            //    ftm.Show();
            //    this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("Hatalı Kullanıcı");
            //}
            
            //baglanti.Close();
        }

        private void FormLogPanel_Load(object sender, EventArgs e)
        {
 
            
       metot();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();

            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("Select kullanıcı_id as Kullanıcı,userid as ID from tbl_girispanel", baglanti);

            da3.Fill(dt3);
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "Kullanıcı";

            lookUpEdit1.Properties.NullText = "Kullanıcı Seçiniz";
            lookUpEdit1.Properties.DataSource = dt3;
        }

        private void txtid_MouseHover(object sender, EventArgs e)
        {
            //txtid.BackColor = Color.SkyBlue;
        }

        private void txtid_MouseLeave(object sender, EventArgs e)
        {
            //txtid.BackColor = Color.White;
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            txtid.Text = lookUpEdit1.Text;
        }

        private void txtpw_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtpw.BackColor = Color.SkyBlue;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //metot();
            //SqlConnection baglanti = new SqlConnection(baglantiadresi);
            //baglanti.Open();

            //SqlCommand komut = new SqlCommand("Select * from tbl_girispanel where kullanıcı_id=@p1 and kullanicisifre=@p2", baglanti);
            //komut.Parameters.AddWithValue("@p1", txtid.Text);
            //komut.Parameters.AddWithValue("@p2", txtpw.Text);
            //SqlDataReader dr = komut.ExecuteReader();
            //if (dr.Read())
            //{
            //    FormTabMenu ftm = new FormTabMenu();
            //    ftm.isim = txtid.Text;
            //    ftm.Show();
            //    this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("Hatalı Kullanıcı");
            //}

            //baglanti.Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            metot();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();

            SqlCommand komut = new SqlCommand("Select * from tbl_girispanel where kullanıcı_id=@p1 and kullanicisifre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", txtid.Text);
            komut.Parameters.AddWithValue("@p2", txtpw.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FormTabMenu ftm = new FormTabMenu();
                ftm.isim = txtid.Text;
                ftm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı");
            }

            baglanti.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(" [ KULLANICI SECİNİZ ] Şifreniz Kullanıcınıza Tanımlı Mail Adresinize Gönderilecektir" , "Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Question);
            MailGonder();
            
            //Localde 
        }
    }
}
