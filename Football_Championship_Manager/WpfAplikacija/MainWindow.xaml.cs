using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Utils;
using Utils.Konstante;
using Utils.Kontroleri;
using WindowsFormsAplikacija;

namespace WpfAplikacija
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HashSet<DAL.Models.Reprezentacija> reprezentacije = new HashSet<DAL.Models.Reprezentacija>();

        HashSet<DAL.Models.Igrac> igraciD = new HashSet<DAL.Models.Igrac>();
        HashSet<DAL.Models.Igrac> igraciG = new HashSet<DAL.Models.Igrac>();

        HashSet<DAL.Models.Utakmica> utakmice = new HashSet<DAL.Models.Utakmica>();

        bool updatingUI = false;

        private static Utakmica utakmica;

        public MainWindow()
        {
            if (!File.Exists(DatotekePutanje.POSTAVKE_PUTANJA) || !File.Exists(DatotekePutanje.REZOLUCIJA_PUTANJA))
            {
                new Postavke().ShowDialog();
            }
            InitializeComponent();
            PostavkeUtils.PodesiPostavke();
            PostavkeUtils.PodesiReprezentacije();
            PostavkeUtils.PodesiRezoluciju();
            PostavkeUtils.PodesiSlikeIgraca();

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //staviKulturu(StaticPostavke.Jezik);
            PostaviRezoluciju(StaticPostavke.Rezolucija);
            await NapuniDdlReprezentacijeD();
           
        }

        private void PostaviRezoluciju(string rezolucija)
        {
            switch (rezolucija)
            {
                case "S":
                    Application.Current.MainWindow.Width = 640;
                    Application.Current.MainWindow.Height = 456;
                    break;
                case "M":
                    Application.Current.MainWindow.Width = 1080;
                    Application.Current.MainWindow.Height = 712;
                    break;
                case "L":
                    Application.Current.MainWindow.Width = 1580;
                    Application.Current.MainWindow.Height = 1012;
                    break;
                case "F":
                    Application.Current.MainWindow.WindowState = WindowState.Maximized;
                    break;
            }
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
            
        private async 
        Task
NapuniDdlReprezentacijeD()
        {
            try
            {
                reprezentacije = await Repository.DohvatiReprezentacijeAsync();
                int i = 0;
                foreach (DAL.Models.Reprezentacija reprezentacija in reprezentacije)
                {
                    ddlReprezentacijeD.Items.Add(reprezentacija.ToString());
                    if (reprezentacija.FifaCode == StaticPostavke.OmiljenaReprezentacija)
                    {
                        ddlReprezentacijeD.SelectedIndex = i;
                    }
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska pri punjenju domaćina!\n{ex.Message}", "Error!");
            }
        }

        private async void ddlReprezentacijeD_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (updatingUI) return;
            PostaviRezultat(0, 0);
            try
            {
                StaticPostavke.OmiljenaReprezentacija = ddlReprezentacijeD.SelectedItem.ToString().Split('(')[1].Split(')')[0];
                ddlReprezentacijeG.SelectedIndex = -1;
                await NapuniGosteDdl(StaticPostavke.OmiljenaReprezentacija);
                await NapuniIgrace('d',ddlReprezentacijeD.SelectedItem.ToString().Split('(')[0].Trim(), StaticPostavke.OmiljenaReprezentacija);
                if (StaticPostavke.Gosti != null)
                {
                    int i = 0;
                    foreach (string reprezentacija in ddlReprezentacijeG.Items)
                    {
                        if (reprezentacija.Split('(')[1].Split(')')[0] == StaticPostavke.Gosti)
                        {
                            ddlReprezentacijeG.SelectedIndex = i;
                        }
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska pri izmjeni domaćina!\n{ex.Message}", "Error!");
            }
        }

        private async 
        Task
NapuniGosteDdl(string omiljenaReprezentacija)
        {
            if (StaticPostavke.Gosti != null || StaticPostavke.Gosti != "")
            {
                try
                {
                    ddlReprezentacijeG.Items.Clear();
                    utakmice = await Repository.DohvatiUtakmiceReprezentacijeAsync(StaticPostavke.OmiljenaReprezentacija);
                    foreach (DAL.Models.Utakmica utakmica in utakmice)
                    {
                        if (utakmica.HomeTeam.Code == StaticPostavke.OmiljenaReprezentacija)
                        {
                            ddlReprezentacijeG.Items.Add($"{utakmica.AwayTeam.Country} ({utakmica.AwayTeam.Code})");
                        }
                        else
                        {
                            ddlReprezentacijeG.Items.Add($"{utakmica.HomeTeam.Country} ({utakmica.HomeTeam.Code})");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Greska pri punjenju gosta!\n{ex.Message}", "Error!");

                }
            }

        }

        private async void ddlReprezentacijeG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ddlReprezentacijeG.SelectedIndex < 0)
            {
                return;
            }
            try
            {
                StaticPostavke.Gosti = ddlReprezentacijeG.SelectedItem.ToString().Split('(')[1].Split(')')[0];
                foreach (DAL.Models.Utakmica utakmicaN in utakmice)
                {
                    if (utakmicaN.HomeTeam.Code == StaticPostavke.Gosti || utakmicaN.AwayTeam.Code == StaticPostavke.Gosti)
                    {
                        utakmica = utakmicaN;
                        if (utakmicaN.HomeTeam.Code == StaticPostavke.Gosti)
                        {
                            PostaviRezultat((int)utakmicaN.AwayTeam.Goals, (int)utakmicaN.HomeTeam.Goals);
                        }
                        else
                        {
                            PostaviRezultat((int)utakmicaN.HomeTeam.Goals, (int)utakmicaN.AwayTeam.Goals);
                        }
                    }
                }
                await NapuniIgrace('g',ddlReprezentacijeG.SelectedItem.ToString().Split('(')[0].Trim(), StaticPostavke.Gosti);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska pri izmjeni gosta!\n{ex.Message}", "Error!");
            }
        }

        private void PostaviRezultat(int brGolovaDomacin, int brGolovaGost)
        {
            LblBrGolovaD.Content = brGolovaDomacin;
            LblBrGolovaG.Content = brGolovaGost;
        }

        private void btnPrikazi_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Name == "btnPrikaziG")
            {
                foreach (DAL.Models.Reprezentacija reprezentacija in reprezentacije)
                {
                    if (reprezentacija.FifaCode == StaticPostavke.Gosti)
                    {
                        Prikazi(reprezentacija);
                        return;
                    }
                }
            } else if (btn.Name == "btnPrikaziD")
            {
                foreach (DAL.Models.Reprezentacija reprezentacija in reprezentacije)
                {
                    if (reprezentacija.FifaCode == StaticPostavke.OmiljenaReprezentacija)
                    {
                        Prikazi(reprezentacija);
                        return;
                    }
                }
            }
        }


        private static void Prikazi(DAL.Models.Reprezentacija reprezentacija)
        {

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Start();
            timer.Tick += (o, args) =>
            {
                timer.Stop();
                new Reprezentacija(reprezentacija).ShowDialog();
            };
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;

            //Do whatever you want here..

            Zatvori zatvori = new Zatvori();
            zatvori.ShowDialog();

            // Confirm user wants to close
            switch (zatvori.DialogResult)
            {
                case false:
                    e.Cancel = true;
                    break;
                default:
                    base.OnClosing(e);
                    break;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                // Spremi omiljenu i goste reprezentaciju
                Repository.SpremiPostavke(DatotekePutanje.OMILJENA_REPREZENTACIJA, StaticPostavke.OmiljenaReprezentacija, StaticPostavke.Gosti);

                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska pri spremanju postavki!\n{ex.Message}", "Error!");
                throw;
            }
        }

        private async
   Task
NapuniIgrace(char domaciIliGosti, string drzava, string FIFA_code)
        {
            try
            {
                switch (domaciIliGosti)
                {
                    case 'd':
                        spGolmanD.Children.Clear();
                        spObranaD.Children.Clear();
                        spSredinaD.Children.Clear();
                        spNapadD.Children.Clear();
                        spGolmanG.Children.Clear();
                        spObranaG.Children.Clear();
                        spSredinaG.Children.Clear();
                        spNapadG.Children.Clear();
                        igraciD = await Repository.DohvatiIgraceReprezentacijeAsync(true, drzava, FIFA_code);
                        foreach (DAL.Models.Igrac igrac in igraciD)
                        {
                            var igracKontrola = new IgracKontrola(igrac);
                            igracKontrola.MouseDown += IgracKontrola_MouseDown;
                            switch (igrac.Position)
                            {
                                case DAL.Models.Igrac.Pozicija.Defender:
                                    spObranaD.Children.Add(igracKontrola);
                                    break;
                                case DAL.Models.Igrac.Pozicija.Forward:
                                    spNapadD.Children.Add(igracKontrola);
                                    break;
                                case DAL.Models.Igrac.Pozicija.Goalie:
                                    spGolmanD.Children.Add(igracKontrola);
                                    break;
                                case DAL.Models.Igrac.Pozicija.Midfield:
                                    spSredinaD.Children.Add(igracKontrola);
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case 'g':
                        spGolmanG.Children.Clear();
                        spObranaG.Children.Clear();
                        spSredinaG.Children.Clear();
                        spNapadG.Children.Clear();
                        igraciG = await Repository.DohvatiIgraceReprezentacijeAsync(true, drzava, FIFA_code);
                        foreach (DAL.Models.Igrac igrac in igraciG)
                        {
                            var igracKontrola = new IgracKontrola(igrac);
                            igracKontrola.MouseDown += IgracKontrola_MouseDown;
                            switch (igrac.Position)
                            {
                                case DAL.Models.Igrac.Pozicija.Defender:
                                    spObranaG.Children.Add(igracKontrola);
                                    break;
                                case DAL.Models.Igrac.Pozicija.Forward:
                                    spNapadG.Children.Add(igracKontrola);
                                    break;
                                case DAL.Models.Igrac.Pozicija.Goalie:
                                    spGolmanG.Children.Add(igracKontrola);
                                    break;
                                case DAL.Models.Igrac.Pozicija.Midfield:
                                    spSredinaG.Children.Add(igracKontrola);
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska pri punjenju gosta!\n{ex.Message}", "Error!");
            }

        }

        private void IgracKontrola_MouseDown(object sender, MouseButtonEventArgs e)
        {
          
            Poskoci(sender);
            //IgracKontrola igrackontrola = sender as IgracKontrola;
            //new Igrac(igrackontrola.GetIgrac()).ShowDialog();
        }
        private void Poskoci(object sender)
        {
            //Storyboard sb = new Storyboard();
            //DoubleAnimation animation = new DoubleAnimation(-40, TimeSpan.FromSeconds(1));
            //Storyboard.SetTargetProperty(animation, new PropertyPath("(TranslateTransform.Y)"));
            //sb.Children.Add(animation);

            //spRezultati.BeginStoryboard(sb);

            DispatcherTimer timer = new DispatcherTimer();
            lblGif.Content = new Gif();
            timer.Interval = TimeSpan.FromMilliseconds(300);
            timer.Start();
            timer.Tick += (o, args) =>
            {
                timer.Stop();
                lblGif.Content = "";
                IgracKontrola igrackontrola = sender as IgracKontrola;
                new Igrac(igrackontrola.GetIgrac()).ShowDialog();

            };
        }
        private async void imgPostavke_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Postavke postavke = new Postavke();
            postavke.ShowDialog();
            if (postavke.DialogResult == true)
            {
                try
                {
                    InitializeComponent();
                    PostavkeUtils.PodesiPostavke();
                    PostavkeUtils.PodesiReprezentacije();
                    PostavkeUtils.PodesiRezoluciju();
                    PostavkeUtils.PodesiSlikeIgraca();

                    PostaviKulturu(StaticPostavke.Jezik);
                    PostaviRezoluciju(StaticPostavke.Rezolucija);
                    //tu baca
                    if (ddlReprezentacijeD != null)
                    {
                        updatingUI = true;
                        ddlReprezentacijeD.Items.Clear();
                        updatingUI = false;
                    }
                    //ddlReprezentacijeD.Items.Clear();
                    await NapuniDdlReprezentacijeD();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Greska pri postavljanju postavki!\n{ex.Message}", "Error!");
                }
                if (StaticPostavke.Gosti != null)
                {
                    int i = 0;
                    foreach (string reprezentacija in ddlReprezentacijeG.Items)
                    {
                        if (reprezentacija.Split('(')[1].Split(')')[0] == StaticPostavke.Gosti)
                        {
                            ddlReprezentacijeG.SelectedIndex = i;
                        }
                        i++;
                    }
                }
            }
        }
    }
}
