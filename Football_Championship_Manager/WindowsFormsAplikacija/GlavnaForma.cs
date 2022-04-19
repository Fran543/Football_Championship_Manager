using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;
using Utils.Konstante;
using Utils.Kontroleri;
using WindowsFormsAplikacija.UserControls;

namespace WindowsFormsAplikacija
{
    public partial class GlavnaForma : Form
    {

        Reprezentacija omiljenaReprezentacija = new Reprezentacija();
        HashSet<Reprezentacija> reprezentacije = new HashSet<Reprezentacija>();
        HashSet<Igrac> igraci = new HashSet<Igrac>();
        HashSet<Utakmica> utakmice = new HashSet<Utakmica>();
        
        List<IgracKontrola> oznaceneKontrole = new List<IgracKontrola>();
        List<IgracStatKontrola> igraciStat = new List<IgracStatKontrola>();

        bool updatingUI = false;

        public GlavnaForma()
        {
            if (!File.Exists(DatotekePutanje.POSTAVKE_PUTANJA))
            {
                var pp = new PocetnePostavke();
                Application.Run(pp);
                pp.Close();
            }
            InitializeComponent();
            try
            {
                PostavkeUtils.PodesiPostavke();
                PostavkeUtils.PodesiReprezentacije();
                PostavkeUtils.PodesiOmiljeneIgrace();
                PostavkeUtils.PodesiSlikeIgraca();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska pri postavljanju postavki!\n{ex.Message}", "Error!");
            }
        }

        // Dohvacanje reprezentacija
        private void GlavnaForma_Load(object sender, EventArgs e)
        {
            try
            {
                PostaviKulturu(StaticPostavke.Jezik);
                NapuniDDL();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska pri Punjenju liste reprezentacija!\n{ex.Message}", "Error!");
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
            Controls.Clear();
            InitializeComponent();
        }

        private async void NapuniDDL()
        {
            lblStatus.Text = "Dohvaćam podatke...";
            pbLoad.Visible = true;
            reprezentacije = await Repository.DohvatiReprezentacijeAsync();
            int i = 0;
            foreach (Reprezentacija reprezentacija in reprezentacije)
            {
                ddlReprezentacije.Items.Add(reprezentacija.ToString());
                if (reprezentacija.FifaCode == StaticPostavke.OmiljenaReprezentacija)
                {
                    ddlReprezentacije.SelectedIndex = i;
                }
                i++;
            }
            pbLoad.Visible = false;
            lblStatus.Text = "...";
        }


        // Mjenjanje reprezentacija
        private void ddlReprezentacije_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                StaticPostavke.OmiljenaReprezentacija = ddlReprezentacije.SelectedItem.ToString().Split('(')[1].Split(')')[0];
                NapuniPodatke(ddlReprezentacije.SelectedItem.ToString().Split('(')[0].Trim(), StaticPostavke.OmiljenaReprezentacija);

                updatingUI = true;
                cbGolovi.Checked = false;
                cbZuti.Checked = false;
                updatingUI = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska pri Punjenju liste igraca!\n{ex.Message}", "Error!");
            }
        }


        // Dohvacanje igraca i utakmica
        private async void NapuniPodatke(string drzava, string FIFA_code)
        {
            await NapuniIgrace(drzava, FIFA_code);
            NapuniStatistiku();
        }

        private void NapuniStatistiku()
        {
            try
            {
                lblStatus.Text = "Dohvaćam podatke...";
                NapuniUtakmice();
                NapuniIgraceRang();         

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska pri Punjenju statistike!\n{ex.Message}", "Error!");
            }
        }

        private async 
        Task
NapuniIgrace(string drzava, string FIFA_code)
        {
            try
            {
                pbLoad.Visible = true;
                lblStatus.Text = "Dohvaćam podatke...";
                flpSviIgraci.Controls.Clear();
                flpOmiljeniIgraci.Controls.Clear();
                igraci = await Repository.DohvatiIgraceReprezentacijeAsync(false, drzava, FIFA_code);
                foreach (Igrac igrac in igraci)
                {
                    var igracKontrola = new IgracKontrola(igrac);
                    igracKontrola.OnPromijenaSlike += IgracKontrola_OnPromijenaSlike;
                    igracKontrola.MouseDown += IgracKontrola_MouseDown;
                    if (igrac.Omiljeni)
                    {
                        flpOmiljeniIgraci.Controls.Add(igracKontrola);
                    } else
                    {
                        flpSviIgraci.Controls.Add(igracKontrola);
                    }
                }
                lblStatus.Text = "...";
                pbLoad.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska pri Punjenju igraca!\n{ex.Message}", "Error!");
            }
        }

        private void IgracKontrola_OnPromijenaSlike(object sender, EventArgs e)
        {
            IgracKontrola kontrola = sender as IgracKontrola;
            foreach (Igrac igrac in igraci)
            {
                if (igrac.Name == kontrola.igrac.Name)
                {
                    igrac.SlikaPutanja = kontrola.igrac.SlikaPutanja;
                    break;
                }
            }
            foreach (IgracStatKontrola statKontrola in flpIgraciRang.Controls)
            {
                if (statKontrola.igrac.Name == kontrola.igrac.Name)
                {
                    statKontrola.PromjeniSliku(kontrola.igrac.SlikaPutanja);
                    return;
                }
            }

        }

        private async void NapuniUtakmice()
        {
            try
            {
                flpUtakmice.Controls.Clear();
                utakmice = await Repository.DohvatiUtakmiceReprezentacijeAsync(StaticPostavke.OmiljenaReprezentacija);
                IEnumerable<Utakmica> rangUtakmice = utakmice.OrderBy(u => -u.Attendance).ToList();
                foreach (Utakmica utakmica in rangUtakmice)
                {
                    var igracStatKontrola = new UtakmicaStatKontrola(utakmica);
                    flpUtakmice.Controls.Add(igracStatKontrola);
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska pri Punjenju utakmica!\n{ex.Message}", "Error!");
            }
        }
        private void NapuniIgraceRang()
        {
            progressUC1.RestetirajPostotak();
            flpIgraciRang.Controls.Clear();
            foreach (Igrac igrac in igraci)
            {
                var igracStatKontrola = new IgracStatKontrola(igrac);
                flpIgraciRang.Controls.Add(igracStatKontrola);
                progressUC1.PovecajPostotak(50);
            }
        }
        

        // Prebacivanje Igraca Events
        private void IgracKontrola_MouseDown(object sender, MouseEventArgs e)
        {
               if (e.Button == MouseButtons.Left)
            {
                OznaciKontrolu(sender);

                if (oznaceneKontrole == null) return;
                List<IgracKontrola> kontrole = new List<IgracKontrola>();
                foreach (var item in oznaceneKontrole)
                {
                    kontrole.Add(item);
                }
                DoDragDrop(kontrole, DragDropEffects.Move);
            }
        }

        private void OznaciKontrolu(object sender)
        {
            IgracKontrola igracKontrola = sender as IgracKontrola;
            if (igracKontrola.BackColor == Color.LightSkyBlue)
            {
                igracKontrola.BackColor = Color.Transparent;
                oznaceneKontrole.Remove(igracKontrola);
            }
            else
            {
                igracKontrola.BackColor = Color.LightSkyBlue;
                oznaceneKontrole.Add(igracKontrola);
            }
        }

        private void prebaciUOmiljeneIgraceToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (oznaceneKontrole == null) return;
            foreach (var card in oznaceneKontrole)
            {
                card.BackColor = Color.Transparent;
                if (card.Parent == flpSviIgraci)
                {
                    if (flpOmiljeniIgraci.Controls.Count < 3)
                    {
                        ToggleOmiljeni(card);
                        flpOmiljeniIgraci.Controls.Add(card);
                        flpSviIgraci.Controls.Remove(card);
                    }
                }
                else if (card.Parent == flpOmiljeniIgraci)
                {
                    ToggleOmiljeni(card);
                    flpSviIgraci.Controls.Add(card);
                    flpOmiljeniIgraci.Controls.Remove(card);
                }
                
            }
            oznaceneKontrole.Clear();
        }

        private void flpSviIgraci_DragDrop(object sender, DragEventArgs e)
        {
            var igracKontrole = (List<IgracKontrola>)e.Data.GetData(typeof(List<IgracKontrola>));


            foreach (var card in igracKontrole)
            {
                if (card.Parent == flpOmiljeniIgraci)
                {
                    lblStatus.Text = "...";
                    ToggleOmiljeni(card);
                    flpSviIgraci.Controls.Add(card);
                    flpOmiljeniIgraci.Controls.Remove(card);
                    OznaciKontrolu(card);
                }
            }


        }


        private void flpOmiljeniIgraci_DragDrop(object sender, DragEventArgs e)
        {
             var igracKontrole = (List<IgracKontrola>)e.Data.GetData(typeof(List<IgracKontrola>));

            foreach (IgracKontrola card in igracKontrole)
            {
                if (flpOmiljeniIgraci.Controls.Count > 2)
                {
                    lblStatus.Text = "Maksimalno 3 omiljena igraca.";
                    return;
                }
                else
                {
                    lblStatus.Text = "...";
                    ToggleOmiljeni(card);
                    flpOmiljeniIgraci.Controls.Add(card);
                    flpSviIgraci.Controls.Remove(card);
                    OznaciKontrolu(card);
                }
            }
        }
        private void ToggleOmiljeni(IgracKontrola card)
        {
            card.PostaviZvijezdu();
            foreach (Igrac igrac in igraci)
            {
                if (igrac.Name == card.igrac.Name)
                {
                    igrac.Omiljeni = card.igrac.Omiljeni;
                    break;
                }
            }
            foreach (IgracStatKontrola igracStatKontrola in flpIgraciRang.Controls)
            {
                if (igracStatKontrola.igrac.Name == card.igrac.Name)
                {
                    igracStatKontrola.PostaviZvijezdu();
                    return;
                }
            }
        }
        private void panel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.KeyState == 1)
            {
                e.Effect = DragDropEffects.Move;
            }
        }


        // Sortiranje Igraca
        private void cbZuti_CheckedChanged(object sender, EventArgs e)
        {
            if (updatingUI) return;
            flpIgraciRang.Controls.Clear();
            if (cbZuti.Checked)
            {
                updatingUI = true;
                cbGolovi.Checked = false;
                updatingUI = false;

                progressUC1.RestetirajPostotak();
                foreach (var item in igraci.OrderBy(i => -i.BrZutihKartona))
                {
                    flpIgraciRang.Controls.Add(new IgracStatKontrola(item));
                    igraciStat.Add(new IgracStatKontrola(item));
                    progressUC1.PovecajPostotak(50);
                }
            }
            else
            {
                NapuniIgraceRang();
                igraciStat.Clear();
            }
        }
        private void cbGolovi_CheckedChanged(object sender, EventArgs e)
        {
            if (updatingUI) return;
            flpIgraciRang.Controls.Clear();
            if (cbGolovi.Checked)
            {
                updatingUI = true;
                cbZuti.Checked = false;
                updatingUI = false;

                progressUC1.RestetirajPostotak();
                foreach (var item in igraci.OrderBy(i => -i.BrGolova))
                {
                    flpIgraciRang.Controls.Add(new IgracStatKontrola(item));
                    igraciStat.Add(new IgracStatKontrola(item));
                    progressUC1.PovecajPostotak(50);
                }
            }
            else
            {
                NapuniIgraceRang();
                igraciStat.Clear();
            }
        }


        // Tool Strip Events

            //Postavke
        private void OtvoriPostavke_Click(object sender, EventArgs e)
        {
            PocetnePostavke pocetnePostavke = new PocetnePostavke();
            if (pocetnePostavke.ShowDialog() == DialogResult.Yes)
            {
                PostavkeUtils.PodesiPostavke();
                Controls.Clear();
                InitializeComponent();
                try
                {
                    PostavkeUtils.PodesiPostavke();
                    PostavkeUtils.PodesiReprezentacije();
                    PostavkeUtils.PodesiOmiljeneIgrace();
                    PostavkeUtils.PodesiSlikeIgraca();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Greska pri postavljanju postavki!\n{ex.Message}", "Error!");
                }
                try
                {
                    PostaviKulturu(StaticPostavke.Jezik);
                    NapuniDDL();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Greska pri Punjenju liste reprezentacija!\n{ex.Message}", "Error!");
                }
            }
            
        }

            //Ispis
        private void ispisPodatakaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog.ShowDialog();
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (flpIgraciRang.Controls.Count == 0) return;

           e.PageSettings.PaperSize = new PaperSize("A4", 850, 1100);
           float pageWidth = e.PageSettings.PrintableArea.Width;
           float pageHeight = e.PageSettings.PrintableArea.Height;

            Bitmap bmp = new Bitmap(this.Width, this.Height);


            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            int x = 40;
            int y = 40;
            int y2 = 40;
            e.Graphics.DrawString(Properties.Resources.Igraci, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, x, y);
            int i = 0;
            foreach (IgracStatKontrola igracStatKontrola in flpIgraciRang.Controls)
            {
                //e.Graphics.DrawImage(, 650, y += 100, Height / 9, Width / 9);
                //var data = $"{igracStatKontrola.igrac.Name}, Goals: {igracStatKontrola.igrac.BrGolova}, Yellow Cards: {igracStatKontrola.igrac.BrZutihKartona}";
                //e.Graphics.DrawString(data, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, x, y += 30);




                Rectangle rect = new Rectangle(0, 0, igracStatKontrola.Width, igracStatKontrola.Height);


                //aquire image of yourControl
                Bitmap bitmap = new Bitmap(igracStatKontrola.Width, igracStatKontrola.Height);
                igracStatKontrola.DrawToBitmap(bitmap, rect);
                if (i > 11)
                {
                    //e.Graphics.DrawImage(bitmap,x + 400, y2 += 80, igracStatKontrola.Height / 2, igracStatKontrola.Width / 2); //place image on right position istead of (0, 0)
                    e.Graphics.DrawImage(bitmap, new Point(x + 400, y2 += 60)); //place image on right position istead of (0, 0)
                }
                else
                {
                    e.Graphics.DrawImage(bitmap, new Point(x, y += 60)); //place image on right position istead of (0, 0)
                }

                i++;
                //if (y >= pageHeight)
                //{
                //    e.HasMorePages = true;
                //    y = 0;
                //}
                //else
                //{
                //    e.HasMorePages = false;
                //}

            }

            e.Graphics.DrawString(Properties.Resources.Utakmice, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, x, y += 80);
            i = 0;
            y2 = y - 10;
            foreach (UtakmicaStatKontrola utakmicaStatKontrola in flpUtakmice.Controls)
                {
                Rectangle rect = new Rectangle(0, 0, utakmicaStatKontrola.Width, utakmicaStatKontrola.Height);


                //aquire image of yourControl
                Bitmap bitmap = new Bitmap(utakmicaStatKontrola.Width, utakmicaStatKontrola.Height);
                utakmicaStatKontrola.DrawToBitmap(bitmap, rect);
                if (i == 0)
                {
                    e.Graphics.DrawImage(bitmap, new Point(x - 20, y += 40));
                }
                else if (i > 3)
                {
                    e.Graphics.DrawImage(bitmap, new Point(x + 400, y2 += 50));
                }  else
                {
                    e.Graphics.DrawImage(bitmap, new Point(x - 20, y += 50));
                }

                //if (y >= pageHeight)
                //{
                //    e.HasMorePages = true;
                //    y = 0;
                //}
                //else
                //{
                //    e.HasMorePages = false;
                //}
                i++;
            }
        }

        private void printDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            MessageBox.Show(Properties.Resources.IspisZavrsio);
        }

        private void OdaberiPrinterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog.ShowDialog();
        }



        // Zatvaranje aplikacije
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            Zatvori zatvori = new Zatvori();
            zatvori.ShowDialog();

            // Confirm user wants to close
            switch (zatvori.DialogResult)
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }
        private void GlavnaForma_FormClosing(object sender, FormClosingEventArgs e)
        {
                try
                {
                    // Spremi omiljenu reprezentaciju

                    Repository.SpremiPostavke(DatotekePutanje.OMILJENA_REPREZENTACIJA, StaticPostavke.OmiljenaReprezentacija);


                    // Spremi Slike

                    string[] slikeIgraca = new string[StaticPostavke.SlikeIgraca.Count];
                    int i = 0;
                    foreach (KeyValuePair<string, string> kvp in StaticPostavke.SlikeIgraca)
                    {
                        slikeIgraca[i] = $"{kvp.Key}|{kvp.Value}";
                        i++;
                    }
                    Repository.SpremiPostavke(DatotekePutanje.SLIKE_IGRACA, slikeIgraca);


                    // Spremi omiljene igrace

                    string[] omiljeniIgraci = new string[flpOmiljeniIgraci.Controls.Count];
                    int j = 0;
                    foreach (IgracKontrola control in flpOmiljeniIgraci.Controls)
                    {
                        omiljeniIgraci[j] = control.igrac.Name;
                        j++;
                    }
                    Repository.SpremiPostavke(DatotekePutanje.OMILJENI_IGRACI_PUTANJA, omiljeniIgraci);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Greska pri spremanju omiljenih reprezentacije i igraca!\n{ex.Message}", "Error!");
                }
        }

        private void postavkeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PocetnePostavke pocetnePostavke = new PocetnePostavke();
            if (pocetnePostavke.ShowDialog() == DialogResult.Yes)
            {
                PostavkeUtils.PodesiPostavke();
                Controls.Clear();
                InitializeComponent();
                try
                {
                    PostavkeUtils.PodesiPostavke();
                    PostavkeUtils.PodesiReprezentacije();
                    PostavkeUtils.PodesiOmiljeneIgrace();
                    PostavkeUtils.PodesiSlikeIgraca();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Greska pri postavljanju postavki!\n{ex.Message}", "Error!");
                }
                try
                {
                    PostaviKulturu(StaticPostavke.Jezik);
                    NapuniDDL();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Greska pri Punjenju liste reprezentacija!\n{ex.Message}", "Error!");
                }
            }

        }

        private void spremiIIzađiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();

            }
            catch (Exception)
            {

                Dispose();
            }
        }
    }
}
