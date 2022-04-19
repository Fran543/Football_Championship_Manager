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
using Utils;
using System.Globalization;

namespace WindowsFormsAplikacija.UserControls
{
    public partial class UtakmicaStatKontrola : UserControl
    {
        public UtakmicaStatKontrola(Utakmica u)
        {
            InitializeComponent();
            SetData(u);
            utakmica = u;
        }

        public Utakmica utakmica { get; set; }
        private void SetData(Utakmica u)
        {
            lblLokacija.BringToFront();
            lblLokacija.Text = u.Location;
            lblPosjetitelji.Text = u.Attendance.ToString();
            lblDomacin.Text = u.HomeTeam.Country;
            lblGosti.Text = u.AwayTeam.Country;
        }

        private void UtakmicaStatKontrola_Load(object sender, EventArgs e)
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
