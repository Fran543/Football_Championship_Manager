using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils.Konstante;

namespace WindowsFormsAplikacija
{
    public partial class PocetnePostavke : Form
    {
        private static string SETTINGS_PATH = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Data/pocetnePostavke.txt");
        private const string HR = "hr", EN = "en";
        private string prvenstvo;
        public PocetnePostavke()
        {
            InitializeComponent();
            cbDohvacanje.SelectedIndex = 0;
        }
        private void PocetnePostavke_Load(object sender, EventArgs e)
        {
            PostaviKulturu(HR);
        }

        private void PostaviKulturu(string nazivKulture)
        {
            if (Thread.CurrentThread.CurrentUICulture.Name == nazivKulture)
            {
                return;
            }

            CultureInfo kultura = new CultureInfo(nazivKulture);


            // Globalizacija
            Thread.CurrentThread.CurrentCulture = kultura;
            
            // Lokalizacija
            Thread.CurrentThread.CurrentUICulture = kultura;
            
            // Azuriraj UI jer se inace nece promijeniti tekst na gumbu
            int selectedIndexPrvenstvo = cbPrvenstvo.SelectedIndex;
            int selectedIndexJezik = cbJezik.SelectedIndex;
            int selectedIndexDohvacanje = cbDohvacanje.SelectedIndex;
            AzurirajUI();
            cbPrvenstvo.SelectedIndex = selectedIndexPrvenstvo;
            cbJezik.SelectedIndex = selectedIndexJezik;
            cbDohvacanje.SelectedIndex = selectedIndexDohvacanje;

        }

        private void AzurirajUI()
        {
            this.Controls.Clear();
            InitializeComponent();
        }

      

        private void cbJezik_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbJezik.SelectedIndex == 0)
            {
                PostaviKulturu(HR);
            } else
            {
                PostaviKulturu(EN);
            }
        }

        private void cbPrvenstvo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPrvenstvo.SelectedIndex == 0)
            {
                prvenstvo = "m";
            }
            else
            {
                prvenstvo = "f";
            }
        }

        private void btnSaveAndEnter_Click(object sender, EventArgs e)
        {
            if (cbPrvenstvo.SelectedIndex == -1 || cbJezik.SelectedIndex == -1 || cbDohvacanje.SelectedIndex == -1)
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "hr")
                {
                    MessageBox.Show("Potrebno definirati prvenstvo i jezik prije pokretanja aplikacije!");
                }
                else
                {
                    MessageBox.Show("You must choose Championship and language before starting application!");
                }
                return;
            }
            try
            {
                Repository.SpremiPostavke(DatotekePutanje.POSTAVKE_PUTANJA, prvenstvo, Thread.CurrentThread.CurrentUICulture.Name, cbDohvacanje.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }
    }
}
