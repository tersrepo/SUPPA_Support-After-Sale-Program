
namespace R0G_DI7
{
    partial class FormTamamlananEkran
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.işlemeAlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sonlandırmayıİnceleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblid = new System.Windows.Forms.Label();
            this.lblanalog = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.Location = new System.Drawing.Point(-4, -3);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1369, 516);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.işlemeAlToolStripMenuItem,
            this.sonlandırmayıİnceleToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(196, 48);
            // 
            // işlemeAlToolStripMenuItem
            // 
            this.işlemeAlToolStripMenuItem.Name = "işlemeAlToolStripMenuItem";
            this.işlemeAlToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.işlemeAlToolStripMenuItem.Text = "Bildirimi İncelemeye Al";
            this.işlemeAlToolStripMenuItem.Click += new System.EventHandler(this.işlemeAlToolStripMenuItem_Click);
            // 
            // sonlandırmayıİnceleToolStripMenuItem
            // 
            this.sonlandırmayıİnceleToolStripMenuItem.Name = "sonlandırmayıİnceleToolStripMenuItem";
            this.sonlandırmayıİnceleToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.sonlandırmayıİnceleToolStripMenuItem.Text = "Sonlandırmayı İncele";
            this.sonlandırmayıİnceleToolStripMenuItem.Click += new System.EventHandler(this.sonlandırmayıİnceleToolStripMenuItem_Click);
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 284;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Location = new System.Drawing.Point(872, 537);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(35, 13);
            this.lblid.TabIndex = 7;
            this.lblid.Text = "label1";
            this.lblid.Visible = false;
            // 
            // lblanalog
            // 
            this.lblanalog.AutoSize = true;
            this.lblanalog.Location = new System.Drawing.Point(794, 538);
            this.lblanalog.Name = "lblanalog";
            this.lblanalog.Size = new System.Drawing.Size(35, 13);
            this.lblanalog.TabIndex = 6;
            this.lblanalog.Text = "label1";
            this.lblanalog.Visible = false;
            // 
            // FormTamamlananEkran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 559);
            this.Controls.Add(this.lblid);
            this.Controls.Add(this.lblanalog);
            this.Controls.Add(this.gridControl1);
            this.Name = "FormTamamlananEkran";
            this.Text = "Sonlandırılmış Bildirimler";
            this.Load += new System.EventHandler(this.FormTamamlananEkran_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label lblid;
        private System.Windows.Forms.Label lblanalog;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem işlemeAlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sonlandırmayıİnceleToolStripMenuItem;
    }
}