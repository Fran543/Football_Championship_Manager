namespace WindowsFormsAplikacija.UserControls
{
    partial class IgracKontrola
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IgracKontrola));
            this.btnPromijeniSliku = new System.Windows.Forms.Button();
            this.lblKapetan = new System.Windows.Forms.Label();
            this.lblPozicija = new System.Windows.Forms.Label();
            this.lblBrojDresa = new System.Windows.Forms.Label();
            this.lblIme = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbStar = new System.Windows.Forms.PictureBox();
            this.pbIgrac = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIgrac)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPromijeniSliku
            // 
            resources.ApplyResources(this.btnPromijeniSliku, "btnPromijeniSliku");
            this.btnPromijeniSliku.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(26)))), ((int)(((byte)(121)))), ((int)(((byte)(64)))));
            this.btnPromijeniSliku.Name = "btnPromijeniSliku";
            this.btnPromijeniSliku.UseVisualStyleBackColor = false;
            this.btnPromijeniSliku.Click += new System.EventHandler(this.btnPromijeniSliku_Click);
            // 
            // lblKapetan
            // 
            resources.ApplyResources(this.lblKapetan, "lblKapetan");
            this.lblKapetan.ForeColor = System.Drawing.Color.White;
            this.lblKapetan.Name = "lblKapetan";
            // 
            // lblPozicija
            // 
            resources.ApplyResources(this.lblPozicija, "lblPozicija");
            this.lblPozicija.ForeColor = System.Drawing.Color.White;
            this.lblPozicija.Name = "lblPozicija";
            // 
            // lblBrojDresa
            // 
            resources.ApplyResources(this.lblBrojDresa, "lblBrojDresa");
            this.lblBrojDresa.ForeColor = System.Drawing.Color.White;
            this.lblBrojDresa.Name = "lblBrojDresa";
            // 
            // lblIme
            // 
            resources.ApplyResources(this.lblIme, "lblIme");
            this.lblIme.ForeColor = System.Drawing.Color.White;
            this.lblIme.Name = "lblIme";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // pbStar
            // 
            resources.ApplyResources(this.pbStar, "pbStar");
            this.pbStar.Image = global::WindowsFormsAplikacija.Properties.Resources.favourites;
            this.pbStar.Name = "pbStar";
            this.pbStar.TabStop = false;
            // 
            // pbIgrac
            // 
            resources.ApplyResources(this.pbIgrac, "pbIgrac");
            this.pbIgrac.Image = global::WindowsFormsAplikacija.Properties.Resources.soccer_player;
            this.pbIgrac.Name = "pbIgrac";
            this.pbIgrac.TabStop = false;
            // 
            // IgracKontrola
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(26)))), ((int)(((byte)(121)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.btnPromijeniSliku);
            this.Controls.Add(this.pbStar);
            this.Controls.Add(this.pbIgrac);
            this.Controls.Add(this.lblKapetan);
            this.Controls.Add(this.lblPozicija);
            this.Controls.Add(this.lblBrojDresa);
            this.Controls.Add(this.lblIme);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "IgracKontrola";
            this.Load += new System.EventHandler(this.IgracKontrola_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbStar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIgrac)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPromijeniSliku;
        private System.Windows.Forms.PictureBox pbStar;
        private System.Windows.Forms.PictureBox pbIgrac;
        private System.Windows.Forms.Label lblKapetan;
        private System.Windows.Forms.Label lblPozicija;
        private System.Windows.Forms.Label lblBrojDresa;
        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
