namespace WindowsFormsAplikacija.UserControls
{
    partial class IgracStatKontrola
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IgracStatKontrola));
            this.lblZutiKartoni = new System.Windows.Forms.Label();
            this.lblGolovi = new System.Windows.Forms.Label();
            this.lblPunoIme = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pbIgrac = new System.Windows.Forms.PictureBox();
            this.pbStar = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIgrac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblZutiKartoni
            // 
            resources.ApplyResources(this.lblZutiKartoni, "lblZutiKartoni");
            this.lblZutiKartoni.Name = "lblZutiKartoni";
            // 
            // lblGolovi
            // 
            resources.ApplyResources(this.lblGolovi, "lblGolovi");
            this.lblGolovi.Name = "lblGolovi";
            // 
            // lblPunoIme
            // 
            resources.ApplyResources(this.lblPunoIme, "lblPunoIme");
            this.lblPunoIme.Name = "lblPunoIme";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblPunoIme);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblGolovi);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.lblZutiKartoni);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // pbIgrac
            // 
            this.pbIgrac.Image = global::WindowsFormsAplikacija.Properties.Resources.soccer_player;
            resources.ApplyResources(this.pbIgrac, "pbIgrac");
            this.pbIgrac.Name = "pbIgrac";
            this.pbIgrac.TabStop = false;
            // 
            // pbStar
            // 
            this.pbStar.Image = global::WindowsFormsAplikacija.Properties.Resources.favourites;
            resources.ApplyResources(this.pbStar, "pbStar");
            this.pbStar.Name = "pbStar";
            this.pbStar.TabStop = false;
            // 
            // IgracStatKontrola
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbStar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbIgrac);
            this.Name = "IgracStatKontrola";
            this.Load += new System.EventHandler(this.IgracStatKontrola_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIgrac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblZutiKartoni;
        private System.Windows.Forms.Label lblGolovi;
        private System.Windows.Forms.Label lblPunoIme;
        private System.Windows.Forms.PictureBox pbIgrac;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pbStar;
    }
}
