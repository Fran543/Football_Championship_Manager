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
using Utils;
using System.Threading;
using System.Globalization;

namespace WindowsFormsAplikacija.UserControls
{
    public partial class IgracKontrola : UserControl
    {
        public Igrac igrac { get; set; }

        public IgracKontrola(Igrac i)
        {
            InitializeComponent();
            SetData(i);
            igrac = i;
        }

        private void SetData(Igrac i)
        {
            lblIme.BringToFront();
            lblIme.Text = i.Name.ToUpper();
            lblPozicija.Text = i.Position.ToString();
            lblKapetan.Text = i.Captain ? "Yes" : "No";
            lblBrojDresa.Text = i.ShirtNumber.ToString();
            pbStar.Visible = i.Omiljeni ? true : false;
            pbIgrac.ImageLocation = i.SlikaPutanja == null ? pbIgrac.ImageLocation : i.SlikaPutanja;
        }
        public void PostaviZvijezdu()
        {
            if (igrac.Omiljeni)
            {
                igrac.Omiljeni = false;
            }
            else
            {
                igrac.Omiljeni = true;
            }
            pbStar.Visible = igrac.Omiljeni ? true : false;
        }

        public event EventHandler OnPromijenaSlike;

        private void btnPromijeniSliku_Click(object sender, EventArgs e)
        {
            var promjenaForma = new PromjenaSlikeForma(pbIgrac);

            if (promjenaForma.ShowDialog() == DialogResult.OK)
            {
                PictureBox azuriranaSlika = promjenaForma.GetAzuriranaSlika();
                pbIgrac.Image = azuriranaSlika.Image;
                igrac.SlikaPutanja = azuriranaSlika.ImageLocation;
                StaticPostavke.SlikeIgraca[igrac.Name] = azuriranaSlika.ImageLocation;
                OnPromijenaSlike?.Invoke(this, null);
            }
        }
        
        private void IgracKontrola_Load(object sender, EventArgs e)
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
