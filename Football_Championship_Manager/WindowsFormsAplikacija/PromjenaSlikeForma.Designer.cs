namespace WindowsFormsAplikacija
{
    partial class PromjenaSlikeForma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PromjenaSlikeForma));
            this.label2 = new System.Windows.Forms.Label();
            this.btnPromijeniSliku = new System.Windows.Forms.Button();
            this.pbSlika = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlika)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // btnPromijeniSliku
            // 
            this.btnPromijeniSliku.BackColor = System.Drawing.Color.LimeGreen;
            this.btnPromijeniSliku.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnPromijeniSliku, "btnPromijeniSliku");
            this.btnPromijeniSliku.Name = "btnPromijeniSliku";
            this.btnPromijeniSliku.UseVisualStyleBackColor = false;
            this.btnPromijeniSliku.Click += new System.EventHandler(this.btnPromijeniSliku_Click);
            // 
            // pbSlika
            // 
            resources.ApplyResources(this.pbSlika, "pbSlika");
            this.pbSlika.Name = "pbSlika";
            this.pbSlika.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.LimeGreen;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = false;
            // 
            // btnOdustani
            // 
            this.btnOdustani.BackColor = System.Drawing.Color.LimeGreen;
            this.btnOdustani.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOdustani.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnOdustani, "btnOdustani");
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.UseVisualStyleBackColor = false;
            // 
            // PromjenaSlikeForma
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.pbSlika);
            this.Controls.Add(this.btnPromijeniSliku);
            this.Controls.Add(this.label2);
            this.Name = "PromjenaSlikeForma";
            this.Load += new System.EventHandler(this.PromjenaSlikeForma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSlika)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPromijeniSliku;
        private System.Windows.Forms.PictureBox pbSlika;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnOdustani;
    }
}