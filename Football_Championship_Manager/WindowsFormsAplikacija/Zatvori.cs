using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace WindowsFormsAplikacija
{
    public partial class Zatvori : Form
    {
        public Zatvori()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            if (StaticPostavke.Jezik != null || StaticPostavke.Jezik != "")
            {
                PostaviKulturu(StaticPostavke.Jezik);
            }

            btnPotvrdi.TabStop = false;
            btnOdustani.TabStop = false;
        }
        private void PostaviKulturu(string jezik)
        {

            try
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == jezik)
                {
                    return;
                }

                CultureInfo kultura = new CultureInfo(jezik);


                // Globalizacija
                Thread.CurrentThread.CurrentCulture = kultura;

                // Lokalizacija
                Thread.CurrentThread.CurrentUICulture = kultura;

                // Azuriraj UI jer se inace nece promijeniti tekst na gumbu
                AzurirajUI();

            }
            catch (Exception)
            {

            }
        }

        private void AzurirajUI()
        {
            Controls.Clear();
            InitializeComponent();
        }

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            Close();
        }
        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            Close();
        }
        private void Zatvori_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.No;
                Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                this.DialogResult = DialogResult.Yes;
                Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
