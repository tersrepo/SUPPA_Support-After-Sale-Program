using System;
using System.Windows.Forms;
using System.Net.Mail;

namespace R0G_DI7
{
    public partial class FormMailGonder : Form
    {
        public FormMailGonder()
        {
            InitializeComponent();
        }
        MailMessage eposta = new MailMessage();

      
        void MailGonder()
        {
            eposta.From = new MailAddress("novassdtakipexe.bildirim@outlook.com");
            eposta.To.Add(textBox1.Text.ToString());
            eposta.Subject = ("Yeni bir bildiriminiz var" + textBox2.Text.ToString());
            eposta.Body = ("Belirtilen Açıklama" + textBox3.Text.ToString());
            //eposta.From = new MailAddress ("alperincir@novaplastik.com");

            SmtpClient smtp = new SmtpClient();

            smtp.Credentials = new System.Net.NetworkCredential("novassdtakipexe.bildirim@outlook.com", "Nov@744!");
            smtp.Host = "smtp-mail.outlook.com";
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.Send(eposta);
            MessageBox.Show("Talebiniz İşleme Alındı");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MailGonder();
  
            }

        private void FormMailGonder_Load(object sender, EventArgs e)
        {

        }
    }
}
