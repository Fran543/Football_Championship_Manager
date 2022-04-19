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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAplikacija
{
    /// <summary>
    /// Interaction logic for IgracKontrola.xaml
    /// </summary>
    public partial class IgracKontrola : UserControl
    {
        private DAL.Models.Igrac igrac;

        public IgracKontrola(DAL.Models.Igrac igrac)
        {
            InitializeComponent();
            this.igrac = igrac;
            NapuniKontrolu();
        }

        private void NapuniKontrolu()
        {
            imgZuti.Visibility = igrac.BrZutihKartona > 0 ? Visibility.Visible : Visibility.Hidden;
            imgKapetan.Visibility = igrac.Captain ? Visibility.Visible : Visibility.Hidden;
            lblIme.Text = igrac.Name;
            lblBrojNaDresu.Content = igrac.ShirtNumber;

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
        public DAL.Models.Igrac GetIgrac()
        {
            return igrac;
        }
    }
}
