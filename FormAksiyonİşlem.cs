using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;


namespace R0G_DI7
{
    public partial class FormAksiyonİşlem : Form
    {
        public FormAksiyonİşlem()
        {
            InitializeComponent();
        }
        string baglantiadresi;
        public string text1,text2,text3,log;
        MailMessage eposta = new MailMessage();

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            metot();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("insert into tblbild_aksiyon (aks_bildid,aks_sorumlusu,aks_acan,aks_baslangictar,aks_termintar,aks_acilisacik) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);

            komut4.Parameters.AddWithValue("@p1", label3.Text);
            komut4.Parameters.AddWithValue("@p2", comboBox2.SelectedValue);
            komut4.Parameters.AddWithValue("@p3", label2.Text);
            komut4.Parameters.AddWithValue("@p4", DateTime.Parse(dateTimePicker8.Text));
            komut4.Parameters.AddWithValue("@p5", DateTime.Parse(dateTimePicker2.Text));
            komut4.Parameters.AddWithValue("@p6", richTextBox2.Text);


            komut4.ExecuteNonQuery();

            MessageBox.Show("[ " +(label3.Text) + " ] No'lu Bildirim Aksiyonu Oluşturuldu","AssemblyInfo");


            //eposta.From = new MailAddress("*****");
            eposta.From = new MailAddress("*****");
            //eposta.To.Add(txtotomail.Text.ToString());
            eposta.To.Add(comboBox3.Text);
            eposta.Subject = "[NOVA SSD]  " + lbllog.Text.ToString() + "  Kullanıcısı tarafından tanımlanan aksiyon!";
            eposta.Body = DateTime.Parse(dateTimePicker8.Text) + "  Tarihinde Oluşturulan Aksiyon Tanımı;  " + "[ " + richTextBox2.Text.ToString() + " ]" + "    Termin Tarihi;  " + "[ " + DateTime.Parse(dateTimePicker2.Text) + " ]" + "   Atanan Sorumlu;  "+ "[ " + comboBox2.SelectedValue + " ]" +  "  (Bu mail doğrudan yanıtlanamaz.)";
            //eposta.Body = DateTime.Parse(dateTimePicker1.Text) + "  Tarihinde kullanıcı tarafından oluşturulan açıklama;   " + txtbirimaciklama.Text.ToString() + "    Müşterinin talebi;  " + txtsikayet.Text.ToString() + "    Ürün grubu;  " + look1.Text.ToString() + "                * Bu mesaj otomatik olarak oluşturulmuş bir bildiridir *";
            //eposta.From = new MailAddress ("alperincir@voltbilgisayar.com");

            SmtpClient smtp = new SmtpClient();

            //smtp.Credentials = new System.Net.NetworkCredential("*****", "*****");
            smtp.Credentials = new System.Net.NetworkCredential("*****", "*****");
            smtp.Host = "smtp-mail.outlook.com";
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.Send(eposta);
            MessageBox.Show("Mail Gönderimi Gerçekleştirildi");

            FormKalislemeal fkai = new FormKalislemeal();
            fkai.log = lbllog.Text;
            fkai.idfocus = label3.Text;
            this.Hide();
            fkai.Show();

        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            metot();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();
            if (comboBox1.SelectedIndex != -1)
            {
                DataTable dtq = new DataTable();
                SqlDataAdapter daq = new SqlDataAdapter("select * from tbl_personel where per_depart = " +comboBox1.SelectedValue, baglanti);
                daq.Fill(dtq);
                comboBox2.ValueMember = "per_id";
                comboBox2.DisplayMember = "per_ad";
                comboBox2.DataSource = dtq;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            metot();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();
            if (comboBox2.SelectedIndex != -1)
            {
                DataTable dtq = new DataTable();
                SqlDataAdapter daq = new SqlDataAdapter("select * from tbl_personel where per_id = " + comboBox2.SelectedValue, baglanti);
                daq.Fill(dtq);
                comboBox3.ValueMember = "per_mail";
                comboBox3.DisplayMember = "per_mail";
                comboBox3.DataSource = dtq;
            }
            }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            metot();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
            baglanti.Open();
            SqlCommand incelemesil = new SqlCommand("Delete from tblbild_aksiyon where aks_id=@p1", baglanti);

            incelemesil.Parameters.AddWithValue("@p1", label1.Text);
            incelemesil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Aksiyon Silindi");

            FormKalislemeal fkai = new FormKalislemeal();
            fkai.log = lbllog.Text;
            fkai.idfocus = label3.Text;
            this.Hide();
            fkai.Show();

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
        private void FormAksiyonİşlem_Load(object sender, EventArgs e)
        {
            label1.Text = text1;//aksiyon id
            label2.Text = text2;//log per
            label3.Text = text3;//bildirim id
            lbllog.Text = log;

            metot();
            SqlConnection baglanti = new SqlConnection(baglantiadresi);
     
            try
            {
               
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select aks_acilisacik from tblbild_aksiyon where aks_id=@p1", baglanti);
                komut.Parameters.AddWithValue("@p1", label1.Text);
                SqlDataReader dr = komut.ExecuteReader();

                while (dr.Read())
                {
                    richTextBox1.Text = dr[0].ToString();
             
                }
                //baglanti.Close();
            }
            catch (Exception)
            {
                
            }
            baglanti.Close();

            baglanti.Open();
            DataTable dt4 = new DataTable();
            SqlDataAdapter da4 = new SqlDataAdapter("Select per_ad,per_id from tbl_personel", baglanti);

            da4.Fill(dt4);
            lookUpEdit2.Properties.ValueMember = ("per_id");
            lookUpEdit2.Properties.DisplayMember = "per_ad";

            lookUpEdit2.Properties.NullText = "Sorumlu Seçiniz";
            lookUpEdit2.Properties.DataSource = dt4;
            baglanti.Close();

            baglanti.Open();
         

            DataTable dtq = new DataTable();
            SqlDataAdapter daq = new SqlDataAdapter("select * from tbl_departman ORDER BY dep_id ASC", baglanti);
            daq.Fill(dtq);
            comboBox1.ValueMember = "dep_id";
            comboBox1.DisplayMember = "dep_ad";
            comboBox1.DataSource = dtq;

        }
    }
}
