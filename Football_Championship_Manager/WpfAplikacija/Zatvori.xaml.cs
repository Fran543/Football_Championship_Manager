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
    /// Interaction logic for Zatvori.xaml
    /// </summary>
    public partial class Zatvori : Window
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

            btnOK.IsTabStop = false;
            btnCancel.IsTabStop = false;
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
            InitializeComponent();
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                DialogResult = false;
                Close();
            }
            else if (e.Key == Key.Enter)
            {
                DialogResult = true;
                Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
