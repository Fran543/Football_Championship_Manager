namespace WindowsFormsAplikacija
{
    partial class PocetnePostavke
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PocetnePostavke));
            this.lblPrvenstvo = new System.Windows.Forms.Label();
            this.lblJezik = new System.Windows.Forms.Label();
            this.btnSpremiIPokreni = new System.Windows.Forms.Button();
            this.cbJezik = new System.Windows.Forms.ComboBox();
            this.cbPrvenstvo = new System.Windows.Forms.ComboBox();
            this.lblDohvacanje = new System.Windows.Forms.Label();
            this.cbDohvacanje = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblPrvenstvo
            // 
            resources.ApplyResources(this.lblPrvenstvo, "lblPrvenstvo");
            this.lblPrvenstvo.ForeColor = System.Drawing.Color.White;
            this.lblPrvenstvo.Name = "lblPrvenstvo";
            // 
            // lblJezik
            // 
            resources.ApplyResources(this.lblJezik, "lblJezik");
            this.lblJezik.ForeColor = System.Drawing.Color.White;
            this.lblJezik.Name = "lblJezik";
            // 
            // btnSpremiIPokreni
            // 
            resources.ApplyResources(this.btnSpremiIPokreni, "btnSpremiIPokreni");
            this.btnSpremiIPokreni.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSpremiIPokreni.ForeColor = System.Drawing.Color.Black;
            this.btnSpremiIPokreni.Name = "btnSpremiIPokreni";
            this.btnSpremiIPokreni.UseVisualStyleBackColor = false;
            this.btnSpremiIPokreni.Click += new System.EventHandler(this.btnSaveAndEnter_Click);
            // 
            // cbJezik
            // 
            resources.ApplyResources(this.cbJezik, "cbJezik");
            this.cbJezik.BackColor = System.Drawing.Color.LimeGreen;
            this.cbJezik.ForeColor = System.Drawing.Color.Black;
            this.cbJezik.FormattingEnabled = true;
            this.cbJezik.Items.AddRange(new object[] {
            resources.GetString("cbJezik.Items"),
            resources.GetString("cbJezik.Items1")});
            this.cbJezik.Name = "cbJezik";
            this.cbJezik.SelectedIndexChanged += new System.EventHandler(this.cbJezik_SelectedIndexChanged);
            // 
            // cbPrvenstvo
            // 
            resources.ApplyResources(this.cbPrvenstvo, "cbPrvenstvo");
            this.cbPrvenstvo.BackColor = System.Drawing.Color.LimeGreen;
            this.cbPrvenstvo.ForeColor = System.Drawing.Color.Black;
            this.cbPrvenstvo.FormattingEnabled = true;
            this.cbPrvenstvo.Items.AddRange(new object[] {
            resources.GetString("cbPrvenstvo.Items"),
            resources.GetString("cbPrvenstvo.Items1")});
            this.cbPrvenstvo.Name = "cbPrvenstvo";
            this.cbPrvenstvo.SelectedIndexChanged += new System.EventHandler(this.cbPrvenstvo_SelectedIndexChanged);
            // 
            // lblDohvacanje
            // 
            resources.ApplyResources(this.lblDohvacanje, "lblDohvacanje");
            this.lblDohvacanje.ForeColor = System.Drawing.Color.White;
            this.lblDohvacanje.Name = "lblDohvacanje";
            // 
            // cbDohvacanje
            // 
            resources.ApplyResources(this.cbDohvacanje, "cbDohvacanje");
            this.cbDohvacanje.BackColor = System.Drawing.Color.LimeGreen;
            this.cbDohvacanje.ForeColor = System.Drawing.Color.Black;
            this.cbDohvacanje.FormattingEnabled = true;
            this.cbDohvacanje.Items.AddRange(new object[] {
            resources.GetString("cbDohvacanje.Items"),
            resources.GetString("cbDohvacanje.Items1")});
            this.cbDohvacanje.Name = "cbDohvacanje";
            this.cbDohvacanje.SelectedIndexChanged += new System.EventHandler(this.cbDohvacanje_SelectedIndexChanged);
            // 
            // PocetnePostavke
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.Controls.Add(this.lblDohvacanje);
            this.Controls.Add(this.cbDohvacanje);
            this.Controls.Add(this.btnSpremiIPokreni);
            this.Controls.Add(this.lblJezik);
            this.Controls.Add(this.cbJezik);
            this.Controls.Add(this.lblPrvenstvo);
            this.Controls.Add(this.cbPrvenstvo);
            this.Name = "PocetnePostavke";
            this.Load += new System.EventHandler(this.PocetnePostavke_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PocetnePostavke_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPrvenstvo;
        private System.Windows.Forms.Label lblJezik;
        private System.Windows.Forms.Button btnSpremiIPokreni;
        private System.Windows.Forms.ComboBox cbJezik;
        private System.Windows.Forms.ComboBox cbPrvenstvo;
        private System.Windows.Forms.Label lblDohvacanje;
        private System.Windows.Forms.ComboBox cbDohvacanje;
    }
}