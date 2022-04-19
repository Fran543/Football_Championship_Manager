namespace WindowsFormsAplikacija
{
    partial class GlavnaForma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GlavnaForma));
            this.ddlReprezentacije = new System.Windows.Forms.ComboBox();
            this.lblReprezentacija = new System.Windows.Forms.Label();
            this.lblSviIgraci = new System.Windows.Forms.Label();
            this.lblOmiljeniIgraci = new System.Windows.Forms.Label();
            this.cbGolovi = new System.Windows.Forms.CheckBox();
            this.cbZuti = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.flpUtakmice = new System.Windows.Forms.FlowLayoutPanel();
            this.flpSviIgraci = new System.Windows.Forms.FlowLayoutPanel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.prebaciUOmiljeneIgraceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flpOmiljeniIgraci = new System.Windows.Forms.FlowLayoutPanel();
            this.flpIgraciRang = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.postavkeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spremiIIzađiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownBtnIspis = new System.Windows.Forms.ToolStripDropDownButton();
            this.ispisPodatakaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odaberiPrinterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.pbLoad = new System.Windows.Forms.PictureBox();
            this.progressUC1 = new WindowsFormsAplikacija.UserControls.ProgressUC();
            this.contextMenuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlReprezentacije
            // 
            this.ddlReprezentacije.BackColor = System.Drawing.Color.LimeGreen;
            this.ddlReprezentacije.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.ddlReprezentacije, "ddlReprezentacije");
            this.ddlReprezentacije.ForeColor = System.Drawing.Color.Black;
            this.ddlReprezentacije.FormattingEnabled = true;
            this.ddlReprezentacije.Name = "ddlReprezentacije";
            this.ddlReprezentacije.SelectedIndexChanged += new System.EventHandler(this.ddlReprezentacije_SelectedIndexChanged);
            // 
            // lblReprezentacija
            // 
            resources.ApplyResources(this.lblReprezentacija, "lblReprezentacija");
            this.lblReprezentacija.BackColor = System.Drawing.Color.Transparent;
            this.lblReprezentacija.ForeColor = System.Drawing.Color.White;
            this.lblReprezentacija.Name = "lblReprezentacija";
            // 
            // lblSviIgraci
            // 
            resources.ApplyResources(this.lblSviIgraci, "lblSviIgraci");
            this.lblSviIgraci.BackColor = System.Drawing.Color.Transparent;
            this.lblSviIgraci.ForeColor = System.Drawing.Color.White;
            this.lblSviIgraci.Name = "lblSviIgraci";
            // 
            // lblOmiljeniIgraci
            // 
            resources.ApplyResources(this.lblOmiljeniIgraci, "lblOmiljeniIgraci");
            this.lblOmiljeniIgraci.BackColor = System.Drawing.Color.Transparent;
            this.lblOmiljeniIgraci.ForeColor = System.Drawing.Color.White;
            this.lblOmiljeniIgraci.Name = "lblOmiljeniIgraci";
            // 
            // cbGolovi
            // 
            resources.ApplyResources(this.cbGolovi, "cbGolovi");
            this.cbGolovi.BackColor = System.Drawing.Color.Transparent;
            this.cbGolovi.ForeColor = System.Drawing.Color.White;
            this.cbGolovi.Name = "cbGolovi";
            this.cbGolovi.UseVisualStyleBackColor = false;
            this.cbGolovi.CheckedChanged += new System.EventHandler(this.cbGolovi_CheckedChanged);
            // 
            // cbZuti
            // 
            resources.ApplyResources(this.cbZuti, "cbZuti");
            this.cbZuti.BackColor = System.Drawing.Color.Transparent;
            this.cbZuti.ForeColor = System.Drawing.Color.White;
            this.cbZuti.Name = "cbZuti";
            this.cbZuti.UseVisualStyleBackColor = false;
            this.cbZuti.CheckedChanged += new System.EventHandler(this.cbZuti_CheckedChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Name = "label5";
            // 
            // flpUtakmice
            // 
            resources.ApplyResources(this.flpUtakmice, "flpUtakmice");
            this.flpUtakmice.BackColor = System.Drawing.Color.Transparent;
            this.flpUtakmice.Name = "flpUtakmice";
            // 
            // flpSviIgraci
            // 
            this.flpSviIgraci.AllowDrop = true;
            resources.ApplyResources(this.flpSviIgraci, "flpSviIgraci");
            this.flpSviIgraci.BackColor = System.Drawing.Color.Transparent;
            this.flpSviIgraci.ContextMenuStrip = this.contextMenuStrip;
            this.flpSviIgraci.Name = "flpSviIgraci";
            this.flpSviIgraci.DragDrop += new System.Windows.Forms.DragEventHandler(this.flpSviIgraci_DragDrop);
            this.flpSviIgraci.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel_DragEnter);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prebaciUOmiljeneIgraceToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip, "contextMenuStrip");
            // 
            // prebaciUOmiljeneIgraceToolStripMenuItem
            // 
            this.prebaciUOmiljeneIgraceToolStripMenuItem.Name = "prebaciUOmiljeneIgraceToolStripMenuItem";
            resources.ApplyResources(this.prebaciUOmiljeneIgraceToolStripMenuItem, "prebaciUOmiljeneIgraceToolStripMenuItem");
            this.prebaciUOmiljeneIgraceToolStripMenuItem.Click += new System.EventHandler(this.prebaciUOmiljeneIgraceToolStripMenuItem_Click);
            // 
            // flpOmiljeniIgraci
            // 
            this.flpOmiljeniIgraci.AllowDrop = true;
            resources.ApplyResources(this.flpOmiljeniIgraci, "flpOmiljeniIgraci");
            this.flpOmiljeniIgraci.BackColor = System.Drawing.Color.Transparent;
            this.flpOmiljeniIgraci.ContextMenuStrip = this.contextMenuStrip;
            this.flpOmiljeniIgraci.Name = "flpOmiljeniIgraci";
            this.flpOmiljeniIgraci.DragDrop += new System.Windows.Forms.DragEventHandler(this.flpOmiljeniIgraci_DragDrop);
            this.flpOmiljeniIgraci.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel_DragEnter);
            // 
            // flpIgraciRang
            // 
            resources.ApplyResources(this.flpIgraciRang, "flpIgraciRang");
            this.flpIgraciRang.BackColor = System.Drawing.Color.Transparent;
            this.flpIgraciRang.Name = "flpIgraciRang";
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.Green;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripSeparator1,
            this.toolStripDropDownBtnIspis});
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Name = "toolStrip";
            // 
            // toolStripDropDownButton1
            // 
            resources.ApplyResources(this.toolStripDropDownButton1, "toolStripDropDownButton1");
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.postavkeToolStripMenuItem,
            this.spremiIIzađiToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::WindowsFormsAplikacija.Properties.Resources.settings;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            // 
            // postavkeToolStripMenuItem
            // 
            this.postavkeToolStripMenuItem.BackColor = System.Drawing.Color.DarkGreen;
            this.postavkeToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.postavkeToolStripMenuItem.Name = "postavkeToolStripMenuItem";
            resources.ApplyResources(this.postavkeToolStripMenuItem, "postavkeToolStripMenuItem");
            this.postavkeToolStripMenuItem.Click += new System.EventHandler(this.postavkeToolStripMenuItem_Click);
            // 
            // spremiIIzađiToolStripMenuItem
            // 
            this.spremiIIzađiToolStripMenuItem.BackColor = System.Drawing.Color.DarkGreen;
            this.spremiIIzađiToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.spremiIIzađiToolStripMenuItem.Name = "spremiIIzađiToolStripMenuItem";
            resources.ApplyResources(this.spremiIIzađiToolStripMenuItem, "spremiIIzađiToolStripMenuItem");
            this.spremiIIzađiToolStripMenuItem.Click += new System.EventHandler(this.spremiIIzađiToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripDropDownBtnIspis
            // 
            this.toolStripDropDownBtnIspis.BackColor = System.Drawing.Color.Green;
            this.toolStripDropDownBtnIspis.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownBtnIspis.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ispisPodatakaToolStripMenuItem,
            this.odaberiPrinterToolStripMenuItem});
            this.toolStripDropDownBtnIspis.Image = global::WindowsFormsAplikacija.Properties.Resources.printer;
            resources.ApplyResources(this.toolStripDropDownBtnIspis, "toolStripDropDownBtnIspis");
            this.toolStripDropDownBtnIspis.Name = "toolStripDropDownBtnIspis";
            // 
            // ispisPodatakaToolStripMenuItem
            // 
            this.ispisPodatakaToolStripMenuItem.BackColor = System.Drawing.Color.DarkGreen;
            this.ispisPodatakaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ispisPodatakaToolStripMenuItem.Name = "ispisPodatakaToolStripMenuItem";
            resources.ApplyResources(this.ispisPodatakaToolStripMenuItem, "ispisPodatakaToolStripMenuItem");
            this.ispisPodatakaToolStripMenuItem.Click += new System.EventHandler(this.ispisPodatakaToolStripMenuItem_Click);
            // 
            // odaberiPrinterToolStripMenuItem
            // 
            this.odaberiPrinterToolStripMenuItem.BackColor = System.Drawing.Color.DarkGreen;
            this.odaberiPrinterToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.odaberiPrinterToolStripMenuItem.Name = "odaberiPrinterToolStripMenuItem";
            resources.ApplyResources(this.odaberiPrinterToolStripMenuItem, "odaberiPrinterToolStripMenuItem");
            this.odaberiPrinterToolStripMenuItem.Click += new System.EventHandler(this.OdaberiPrinterToolStripMenuItem_Click);
            // 
            // printDocument
            // 
            this.printDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument_EndPrint);
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // printPreviewDialog
            // 
            resources.ApplyResources(this.printPreviewDialog, "printPreviewDialog");
            this.printPreviewDialog.Document = this.printDocument;
            this.printPreviewDialog.Name = "printPreviewDialog";
            // 
            // lblStatus
            // 
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Name = "lblStatus";
            resources.ApplyResources(this.lblStatus, "lblStatus");
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.Green;
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // pbLoad
            // 
            resources.ApplyResources(this.pbLoad, "pbLoad");
            this.pbLoad.Image = global::WindowsFormsAplikacija.Properties.Resources.tenor;
            this.pbLoad.Name = "pbLoad";
            this.pbLoad.TabStop = false;
            // 
            // progressUC1
            // 
            resources.ApplyResources(this.progressUC1, "progressUC1");
            this.progressUC1.BackColor = System.Drawing.Color.Green;
            this.progressUC1.ForeColor = System.Drawing.Color.Black;
            this.progressUC1.Name = "progressUC1";
            this.progressUC1.Postotak = 0;
            // 
            // GlavnaForma
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.Controls.Add(this.pbLoad);
            this.Controls.Add(this.progressUC1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.flpIgraciRang);
            this.Controls.Add(this.flpOmiljeniIgraci);
            this.Controls.Add(this.flpSviIgraci);
            this.Controls.Add(this.flpUtakmice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbGolovi);
            this.Controls.Add(this.cbZuti);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblOmiljeniIgraci);
            this.Controls.Add(this.lblSviIgraci);
            this.Controls.Add(this.lblReprezentacija);
            this.Controls.Add(this.ddlReprezentacije);
            this.Name = "GlavnaForma";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GlavnaForma_FormClosing);
            this.Load += new System.EventHandler(this.GlavnaForma_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlReprezentacije;
        private System.Windows.Forms.Label lblReprezentacija;
        private System.Windows.Forms.Label lblSviIgraci;
        private System.Windows.Forms.Label lblOmiljeniIgraci;
        private System.Windows.Forms.CheckBox cbGolovi;
        private System.Windows.Forms.CheckBox cbZuti;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flpUtakmice;
        private System.Windows.Forms.FlowLayoutPanel flpSviIgraci;
        private System.Windows.Forms.FlowLayoutPanel flpOmiljeniIgraci;
        private System.Windows.Forms.FlowLayoutPanel flpIgraciRang;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem prebaciUOmiljeneIgraceToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownBtnIspis;
        private System.Windows.Forms.ToolStripMenuItem ispisPodatakaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odaberiPrinterToolStripMenuItem;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.StatusStrip statusStrip;
        private UserControls.ProgressUC progressUC1;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.PictureBox pbLoad;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem postavkeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spremiIIzađiToolStripMenuItem;
    }
}

