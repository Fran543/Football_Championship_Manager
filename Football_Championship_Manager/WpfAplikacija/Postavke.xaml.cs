using DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Utils;
using Utils.Konstante;
using Utils.Kontroleri;

namespace WpfAplikacija
{
    /// <summary>
    /// Interaction logic for Postavke.xaml
    /// </summary>
    public partial class Postavke : Window
    {
        private const string HR = "hr", EN = "en";
        private string prvenstvo;


        private int pocetnoPrvenstvo;
        public Postavke()
        {
            InitializeComponent();
            try
            {
                PostavkeUtils.PodesiPostavke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska pri postavljanju postavki!\n{ex.Message}", "Error!");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PostaviKulturu(HR);
            NapuniPodatke();

        }
        private void NapuniPodatke()
        {
            switch (StaticPostavke.Prvenstvo)
            {
                case "m":
                    cbPrvenstvo.SelectedIndex = 0;
                    break;
                case "f":
                    cbPrvenstvo.SelectedIndex = 1;
                    break;
            }
            pocetnoPrvenstvo = cbPrvenstvo.SelectedIndex;
            switch (StaticPostavke.Jezik)
            {
                case "hr":
                    cbJezik.SelectedIndex = 0;
                    break;
                case "en":
                    cbJezik.SelectedIndex = 1;
                    break;
            }
            switch (StaticPostavke.DohvacanjePutanja)
            {
                case "Api":
                    cbDohvacanje.SelectedIndex = 0;
                    break;
                case "Disk":
                    cbDohvacanje.SelectedIndex = 1;
                    break;
            }
            switch (StaticPostavke.Rezolucija)
            {
                case "S":
                    cbRezolucija.SelectedIndex = 0;
                    break;
                case "M":
                    cbRezolucija.SelectedIndex = 1;
                    break;
                case "L":
                    cbRezolucija.SelectedIndex = 2;
                    break;
                case "F":
                    cbRezolucija.SelectedIndex = 3;
                    break;
            }
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
                int selectedIndexRezolucija = cbRezolucija.SelectedIndex;
                AzurirajUI();
                cbPrvenstvo.SelectedIndex = selectedIndexPrvenstvo;
                cbJezik.SelectedIndex = selectedIndexJezik;
                cbDohvacanje.SelectedIndex = selectedIndexDohvacanje;
                cbRezolucija.SelectedIndex = selectedIndexRezolucija;
        }

        private void AzurirajUI()
        {
            //this.Controls.Clear(); -> Treba staviti nesto drugo
            InitializeComponent();
        }

        private void cbJezik_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbJezik.SelectedIndex == 0)
            {
                PostaviKulturu(HR);
            }
            else
            {
               PostaviKulturu(EN);
            }
        }

        private void cbPrvenstvo_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnOK_Click(btnOK);
            }
        }

        private void btnOK_Click(Button btnOK)
        {
            if (cbPrvenstvo.SelectedIndex == -1 || cbJezik.SelectedIndex == -1 || cbDohvacanje.SelectedIndex == -1 || cbRezolucija.SelectedIndex == -1)
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "hr")
                {
                    System.Windows.MessageBox.Show("Potrebno definirati prvenstvo i jezik prije pokretanja aplikacije!");
                }
                else
                {
                    System.Windows.MessageBox.Show("You must choose Championship and language before starting application!");
                }
                return;
            }
            string rez;
            switch (cbRezolucija.SelectedIndex)
            {
                case 0:
                    rez = "S";
                    break;
                case 1:
                    rez = "M";
                    break;
                case 2:
                    rez = "L";
                    break;
                case 3:
                    rez = "F";
                    break;
                default:
                    rez = "L";
                    break;
            }
            try
            {
                Zatvori zatvori = new Zatvori();
                zatvori.ShowDialog();

                if (zatvori.DialogResult == true)
                {
                    if (pocetnoPrvenstvo != cbPrvenstvo.SelectedIndex)
                    {
                        File.WriteAllText(DatotekePutanje.OMILJENA_REPREZENTACIJA, string.Empty);
                    }
                    File.WriteAllText(DatotekePutanje.POSTAVKE_PUTANJA, string.Empty);
                    Repository.SpremiPostavke(DatotekePutanje.POSTAVKE_PUTANJA, prvenstvo, Thread.CurrentThread.CurrentUICulture.Name, cbDohvacanje.SelectedValue.ToString().Split(':')[1].Trim());
                    File.WriteAllText(DatotekePutanje.REZOLUCIJA_PUTANJA, string.Empty);
                    Repository.SpremiPostavke(DatotekePutanje.REZOLUCIJA_PUTANJA, rez);
                    DialogResult = true;
                    Close();
                } 

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {

            if (cbPrvenstvo.SelectedIndex == -1 || cbJezik.SelectedIndex == -1 || cbDohvacanje.SelectedIndex == -1 || cbRezolucija.SelectedIndex == -1)
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "hr")
                {
                    System.Windows.MessageBox.Show("Potrebno definirati prvenstvo i jezik prije pokretanja aplikacije!");
                }
                else
                {
                    System.Windows.MessageBox.Show("You must choose Championship and language before starting application!");
                }
                return;
            }
            string rez;
            switch (cbRezolucija.SelectedIndex)
            {
                case 0:
                    rez = "S";
                    break;
                case 1:
                    rez = "M";
                    break;
                case 2:
                    rez = "L";
                    break;
                case 3:
                    rez = "F";
                    break;
                default:
                    rez = "L";
                    break;
            }
            try
            {
                Zatvori zatvori = new Zatvori();
                zatvori.ShowDialog();

                if (zatvori.DialogResult == true)
                {
                    File.WriteAllText(DatotekePutanje.POSTAVKE_PUTANJA, string.Empty);
                    Repository.SpremiPostavke(DatotekePutanje.POSTAVKE_PUTANJA, prvenstvo, Thread.CurrentThread.CurrentUICulture.Name, cbDohvacanje.SelectedValue.ToString().Split(':')[1].Trim());
                    File.WriteAllText(DatotekePutanje.REZOLUCIJA_PUTANJA, string.Empty);
                    Repository.SpremiPostavke(DatotekePutanje.REZOLUCIJA_PUTANJA, rez);
                    DialogResult = true;
                    Close();
                }
               
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == Keys.Escape)
        //    {
        //        this.Close();
        //        return true;
        //    }
        //    else if (keyData == Keys.Enter)
        //    {
        //        btnOK_Click(btnOK, EventArgs.Empty);
        //        return false;
        //    }

        //    return base.ProcessCmdKey(ref msg, keyData);
        //}
    }
}
