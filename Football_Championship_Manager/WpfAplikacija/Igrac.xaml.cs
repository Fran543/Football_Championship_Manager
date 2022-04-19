using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace WpfAplikacija
{
    /// <summary>
    /// Interaction logic for Igrac.xaml
    /// </summary>
    public partial class Igrac : Window
    {
        private DAL.Models.Igrac igrac;
        public Igrac(DAL.Models.Igrac igrac)
        {
            InitializeComponent();
            this.igrac = igrac;
        }

        private void NapuniPodatke()
        {
            tbIme.Text = igrac.Name;
            tbBrNaDresu.Text = igrac.ShirtNumber.ToString();
            tbPozicija.Text = igrac.Position.ToString();
            tbKapetan.Text = igrac.Captain ? "Yes" : "No";
            tbGolovi.Text = igrac.BrGolova.ToString();
            tbBrZutih.Text = igrac.BrZutihKartona.ToString();

            // STAVI DEFAULT SLIKU AKO JE NE POSTOJI FILE SA TOM PUTANJOM
            try
            {
                imgIgrac.Source = igrac.SlikaPutanja == null ? imgIgrac.Source : new BitmapImage(new Uri(igrac.SlikaPutanja));

            }
            catch (Exception)
            {
                igrac.SlikaPutanja = imgIgrac.Source.ToString();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PostaviKulturu(StaticPostavke.Jezik);
            NapuniPodatke();

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
            InitializeComponent();
        }
    }
}
