using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfAplikacija
{
    /// <summary>
    /// Interaction logic for Reprezentacija.xaml
    /// </summary>
    public partial class Reprezentacija : Window
    {

        public Reprezentacija(DAL.Models.Reprezentacija reprezentacija)
        {


            InitializeComponent();
            napuniPodatke(reprezentacija);
        }

        private void napuniPodatke(DAL.Models.Reprezentacija reprezentacija)
        {
            lblZemlja.Text = reprezentacija.Country;
            lblFifaKod.Content = reprezentacija.FifaCode;
            lblOdigraneUtakmice.Content = reprezentacija.GamesPlayed;
            lblDobiveneUtakmice.Content = reprezentacija.Wins;
            lblIzgubljeneUtakmice.Content = reprezentacija.Losses;
            lblNeriješeneUtakmice.Content = reprezentacija.Draws;
            lblBrZabijenihGolova.Content = reprezentacija.GoalsFor;
            lblBrPrimljenihGolova.Content = reprezentacija.GoalsAgainst;
            lblRazlika.Content = reprezentacija.GoalDifferential;
        }
    }
}
