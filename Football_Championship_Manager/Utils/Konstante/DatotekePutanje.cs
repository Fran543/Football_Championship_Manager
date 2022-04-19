using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Konstante
{
    public static class DatotekePutanje
    {
        public static string POSTAVKE_PUTANJA = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Data/PocetnePostavke.txt");
        public static string REZOLUCIJA_PUTANJA = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Data/Rezolucija.txt");
        public static string SLIKE_IGRACA = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Data/SlikeIgraca.txt");
        public static string OMILJENI_IGRACI_PUTANJA = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Data/OmiljeniIgraci.txt");
        public static string OMILJENA_REPREZENTACIJA = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Data/OmiljenaReprezentacija.txt");


        public static string ZENSKE_REPREZENTACIJE = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Json/femaleTeams.json");
        public static string ZENSKE_UTAKMICE_REPREZENTACIJE = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Json/femaleMatches.json");
        public static string ZENSKE_SVE_UTAKMICE = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Json/femaleGroup_results.json");

        public static string MUSKE_REPREZENTACIJE = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Json/maleTeams.json");
        public static string MUSKE_UTAKMICE_REPREZENTACIJE = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Json/maleMatches.json");
        public static string MUSKE_SVE_UTAKMICE = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Json/maleGroup_results.json");

    }
}
