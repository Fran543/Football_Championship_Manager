using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Models;
using System.Threading;
using System.Globalization;
using Utils;

namespace WindowsFormsAplikacija.UserControls
{
    public partial class IgracStatKontrola : UserControl
    {
        public IgracStatKontrola(Igrac i)
        {
            InitializeComponent();
            SetData(i);
            igrac = i;
        }

        public bool Favorit = false;

        public Igrac igrac { get; set; }
        private void SetData(Igrac i)
        {
            lblPunoIme.BringToFront();
            lblPunoIme.Text = i.Name.ToUpper();
            lblGolovi.Text = i.BrGolova.ToString();
            lblZutiKartoni.Text = i.BrZutihKartona.ToString();
            pbStar.Visible = i.Omiljeni ? true : false;
            pbIgrac.ImageLocation = i.SlikaPutanja == null ? pbIgrac.ImageLocation : i.SlikaPutanja;
        }

        public void PostaviZvijezdu()
        {
            pbStar.Visible = igrac.Omiljeni ? true : false;
        }     
        public void PromjeniSliku(string SlikaPutanja)
        {
            igrac.SlikaPutanja = SlikaPutanja;
            pbIgrac.ImageLocation = igrac.SlikaPutanja;
        }

        private void IgracStatKontrola_Load(object sender, EventArgs e)
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
    }
}
