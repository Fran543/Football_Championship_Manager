using Utils.Konstante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Konstante;

namespace Utils
{
    public static class StaticPostavke
    {
        public static string Jezik { get; set; }
        public static string Prvenstvo { get; set; }
        public static string DohvacanjePutanja { get; set; }


        public static string Rezolucija { get; set; }
        public static string WindowState { get; set; }

        public static HashSet<string> OmiljeniIgraci { get; set; }
        public static Dictionary<string, string> SlikeIgraca { get; set; }

        public static string OmiljenaReprezentacija { get; set; }
        public static string Domacini { get; set; }
        public static string Gosti { get; set; }

                
        // postavljanje putanja

        private static string _reprezentacijePutanja;

        public static string GetReprezentacijePutanja()
        {
            return _reprezentacijePutanja;
        }

        private static void SetReprezentacijePutanja()
        {
            switch (Prvenstvo)
            {
                case "m" when DohvacanjePutanja == "Api":
                    _reprezentacijePutanja = ApiPutanje.MUSKE_REPREZENTACIJE;
                    break;
                case "f" when DohvacanjePutanja == "Api":
                    _reprezentacijePutanja = ApiPutanje.ZENSKE_REPREZENTACIJE;
                    break;
                case "m" when DohvacanjePutanja == "Disk":
                    _reprezentacijePutanja = DatotekePutanje.MUSKE_REPREZENTACIJE;
                    break;
                case "f" when DohvacanjePutanja == "Disk":
                    _reprezentacijePutanja = DatotekePutanje.ZENSKE_REPREZENTACIJE;
                    break;
                default:
                    break;
            }
        }

        private static string _sveUtakmicePutanja;

        public static string GetSveUtakmicePutanja()
        {
            return _sveUtakmicePutanja;
        }

        private static void SetSveUtakmicePutanja()
        {
            switch (Prvenstvo)
            {
                case "m" when DohvacanjePutanja == "Api":
                    _sveUtakmicePutanja = ApiPutanje.MUSKE_SVE_UTAKMICE;
                    break;
                case "f" when DohvacanjePutanja == "Api":
                    _sveUtakmicePutanja = ApiPutanje.ZENSKE_SVE_UTAKMICE;
                    break;
                case "m" when DohvacanjePutanja == "Disk":
                    _sveUtakmicePutanja = DatotekePutanje.MUSKE_SVE_UTAKMICE;
                    break;
                case "f" when DohvacanjePutanja == "Disk":
                    _sveUtakmicePutanja = DatotekePutanje.ZENSKE_SVE_UTAKMICE;
                    break;
                default:
                    break;
            }
        }

        private static string _utakmiceReprezentacijePutanja;

        public static string GetUtakmiceReprezentacijePutanja()
        {
            return _utakmiceReprezentacijePutanja;
        }

        public static void SetUtakmiceReprezentacijePutanja()
        {
            switch (Prvenstvo)
            {
                case "m" when DohvacanjePutanja == "Api":
                    _utakmiceReprezentacijePutanja = ApiPutanje.MUSKE_UTAKMICE_REPREZENTACIJE;
                    break;
                case "f" when DohvacanjePutanja == "Api":
                    _utakmiceReprezentacijePutanja = ApiPutanje.ZENSKE_UTAKMICE_REPREZENTACIJE;
                    break;
                case "m" when DohvacanjePutanja == "Disk":
                    _utakmiceReprezentacijePutanja = DatotekePutanje.MUSKE_UTAKMICE_REPREZENTACIJE;
                    break;
                case "f" when DohvacanjePutanja == "Disk":
                    _utakmiceReprezentacijePutanja = DatotekePutanje.ZENSKE_UTAKMICE_REPREZENTACIJE;
                    break;
                default:
                    break;
            }
        }

        public static void SetPutanje()
        {
            SetReprezentacijePutanja();
            SetSveUtakmicePutanja();
            SetUtakmiceReprezentacijePutanja();
        }

    }
}
