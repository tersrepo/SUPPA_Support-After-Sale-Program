using System;
using System.Drawing;
using System.Windows.Forms;

namespace R0G_DI7
{
    public partial class FormTabMenu : DevExpress.XtraEditors.XtraForm
    {
        public FormTabMenu()
        {
            InitializeComponent();
        }

        public string isim;

        private void Form1_ContextMenuStripChanged(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormMusteriKayit fmk = new FormMusteriKayit();
            fmk.isim2 = lbltabmenulog.Text;
            fmk.MdiParent = this;
            fmk.Show();
        }

        private void FormTabMenu_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1369, 729);
            lbltabmenulog.Text = isim;
            FormArizaListesi fmk = new FormArizaListesi();
            fmk.MdiParent = this;
            fmk.Show();


        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormMusteriSikayet fms = new FormMusteriSikayet();
            fms.Name = "tekform";
            if (Application.OpenForms["tekform"] == null)
            {
                fms.MdiParent = this;
                fms.Show();
            }
            
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }


        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormMailGonder fmg = new FormMailGonder();
            fmg.Name = "tekform1";
            if (Application.OpenForms["tekform1"] == null)
            {
                fmg.MdiParent = this;
                fmg.Show();
            }
           
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormKalArizaİslemAl fkais = new FormKalArizaİslemAl();
            fkais.Name = "tekform2";
            if (Application.OpenForms["tekform2"] == null)
            {
                fkais.MdiParent = this;
                fkais.Show();
            }
         
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormArizaListesi fal = new FormArizaListesi();
            fal.Name = "tekform3";
            if (Application.OpenForms["tekform3"] == null)
            {
                fal.MdiParent = this;
                fal.Show();
            }
           
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormBildirimOlustur fbo = new FormBildirimOlustur();
            fbo.Name = "tekform4";
            if (Application.OpenForms["tekform4"] == null)
            {
                fbo.isim2 = lbltabmenulog.Text;
                fbo.MdiParent = this;
                fbo.Show();
            }
          
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormMusteriGoruntule fmg = new FormMusteriGoruntule();
            fmg.Name = "tekform5";
            if(Application.OpenForms["tekform5"] == null)
            {
                fmg.MdiParent = this;
                fmg.Show();
            }
          
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormKaliteGoruntuleme fkg = new FormKaliteGoruntuleme();
            fkg.Name = "tekform6";
            if (Application.OpenForms["tekform6"] == null)
            {
                fkg.log = lbltabmenulog.Text;
                fkg.MdiParent = this;
                fkg.Show();
            }
       
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormIncelemeEkran fık = new FormIncelemeEkran();
            fık.Name = "tekform7";
            if (Application.OpenForms["tekform7"] == null)
            {
                fık.MdiParent = this;
                fık.Show();
            }
            
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormIncTamamEkran fıtk = new FormIncTamamEkran();
            fıtk.Name = "tekform8";
            if (Application.OpenForms["tekform8"] == null)

            {
                fıtk.MdiParent = this;
                fıtk.Show();
            }
           
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormAksiyonEkran fak = new FormAksiyonEkran();
            fak.Name = "tekform9";
            if (Application.OpenForms["tekform9"] == null)
            {
                fak.MdiParent = this;
                fak.Show();
            }
       
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormTamamlananEkran fte = new FormTamamlananEkran();
            fte.Name = "tekformq";
            if (Application.OpenForms["tekformq"] == null)
            {
                fte.MdiParent = this;
                fte.Show();
            }
           
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormMusteritoinsert fmti = new FormMusteritoinsert();
            fmti.Name = "tekformw";
            if (Application.OpenForms["tekformw"] == null)
            {
                fmti.MdiParent = this;
                fmti.Show();
            }

           
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormIncelemeEkran fie = new FormIncelemeEkran();
            fie.Name = "tekforme";
            if (Application.OpenForms["tekforme"] == null)
            {
                fie.log = lbltabmenulog.Text;
                fie.MdiParent = this;
                fie.Show();
            }
        
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormTamamlananEkran fte = new FormTamamlananEkran();
            fte.Name = "tekformr";
            if (Application.OpenForms["tekformr"] == null)
            {

                fte.log = lbltabmenulog.Text;
                fte.MdiParent = this;
                fte.Show();
            }
           
          
            
            
          



        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
           
                FormSsdBildTamamlanan fsbt = new FormSsdBildTamamlanan();
            fsbt.Name = "tekformt";
            if (Application.OpenForms["tekformt"] == null)
            {
                fsbt.MdiParent = this;
                fsbt.Show();
            }
               
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
