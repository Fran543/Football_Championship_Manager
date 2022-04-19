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
    public partial class PromjenaSlikeForma : Form
    {
        public PromjenaSlikeForma(PictureBox slika)
        {
            InitializeComponent();
            PostaviFormu(slika);
        }
        private void PromjenaSlikeForma_Load(object sender, EventArgs e)
        {
            PostaviKulturu(StaticPostavke.Jezik);
        }

        private void PostaviKulturu(string jezik)
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

        private void AzurirajUI()
        {
            Controls.Clear();
            InitializeComponent();
        }

     
        private void PostaviFormu(PictureBox slika)
        {
            pbSlika.Image = slika.Image;
        }

        private void btnPromijeniSliku_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Slike|*.jpg;*.jpeg;*.png;*.bmp|Sve datoteke|*.*";
            openFileDialog.InitialDirectory = Application.StartupPath;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbSlika.ImageLocation = openFileDialog.FileName;
            }
        }

        public PictureBox GetAzuriranaSlika()
        {
            return pbSlika;
        }

    }
}
