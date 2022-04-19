using Utils.Konstante;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Konstante;

namespace Utils.Kontroleri
{
    public static class PostavkeUtils
    {
        public static void PodesiPostavke()
        {
            StaticPostavke.OmiljeniIgraci = new HashSet<string>();
            if (!File.Exists(DatotekePutanje.POSTAVKE_PUTANJA))
            {
                return;
            }
            string[] lines = File.ReadAllLines(DatotekePutanje.POSTAVKE_PUTANJA);
            if (lines.Length < 1 || lines[0] == "")
            {
                return;
            }
            string[] parametriPostavki = lines[0].Split(',');  // polje stringova koji su vrijednosti postavki: [0]: prvenstvo (musko/zensko); [1]: jezik (hr, en); [2]: dohvacanje (Api, Disk)
            StaticPostavke.Prvenstvo = String.IsNullOrEmpty(parametriPostavki[0]) ? "m" : parametriPostavki[0];
            StaticPostavke.Jezik = String.IsNullOrEmpty(parametriPostavki[1]) ? "hr" : parametriPostavki[1];
            StaticPostavke.DohvacanjePutanja = String.IsNullOrEmpty(parametriPostavki[2]) ? "Api" : parametriPostavki[2];
            StaticPostavke.SetPutanje();
        }
        public static void PodesiOmiljeneIgrace()
        {
            StaticPostavke.OmiljeniIgraci = new HashSet<string>();
            if (!File.Exists(DatotekePutanje.OMILJENI_IGRACI_PUTANJA))
            {
                return;
            }
            string[] lines = File.ReadAllLines(DatotekePutanje.OMILJENI_IGRACI_PUTANJA);
            if (lines.Length < 1 || lines[0] == "")
            {
                return;
            }
            string[] omiljeniIgraci = lines[0].Split(',');
            foreach  (string igrac in omiljeniIgraci)
            {
                StaticPostavke.OmiljeniIgraci.Add(igrac);
            }
        }
        public static void PodesiSlikeIgraca()
        {
            StaticPostavke.SlikeIgraca = new Dictionary<string, string>();
            if (!File.Exists(DatotekePutanje.SLIKE_IGRACA))
            {
                return;
            }
            string[] lines = File.ReadAllLines(DatotekePutanje.SLIKE_IGRACA);
            if (lines.Length < 1 || lines[0] == "")
            {
                return;
            }
            string[] slikeIgraca = lines[0].Split(',');
            foreach (string slika in slikeIgraca)
            {
                StaticPostavke.SlikeIgraca[slika.Split('|')[0]] = slika.Split('|')[1];
            }
        }
        public static void PodesiReprezentacije()
        {
            if (!File.Exists(DatotekePutanje.OMILJENA_REPREZENTACIJA))
            {
                return;
            }
            string[] lines = File.ReadAllLines(DatotekePutanje.OMILJENA_REPREZENTACIJA);
            if (lines.Length < 1 || lines[0] == "")
            {
                return;
            }
            string reprezentacijaD = lines[0].Split(',')[0];  // polje stringova koji su vrijednosti postavki: [0]: omiljenaReprezentacija; [1]: Gosti
            StaticPostavke.OmiljenaReprezentacija = String.IsNullOrEmpty(reprezentacijaD) ? "CRO" : reprezentacijaD;
            if (lines[0].Split(',').Length == 1)
            {
                return;
            }
            string reprezentacijaG = lines[0].Split(',')[1];  // polje stringova koji su vrijednosti postavki: [0]: omiljenaReprezentacija; [1]: Gosti
            StaticPostavke.Gosti = String.IsNullOrEmpty(reprezentacijaG) ? null : reprezentacijaG;

        }
        public static void PodesiRezoluciju()
        {
            if (!File.Exists(DatotekePutanje.REZOLUCIJA_PUTANJA))
            {
                return;
            }
            string[] lines = File.ReadAllLines(DatotekePutanje.REZOLUCIJA_PUTANJA);
            string rezolucija = lines[0];
            StaticPostavke.Rezolucija = rezolucija;
        }
    }
}
