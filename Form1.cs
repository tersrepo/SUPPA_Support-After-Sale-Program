using System.Windows.Forms;

namespace R0G_DI7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormMusteriKayit fmk = new FormMusteriKayit();
            fmk.MdiParent = this;
            fmk.Show();
        }
    }
}
