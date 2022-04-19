using DAL.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Utils.Konstante;
using Utils.Kontroleri;

namespace DAL
{
    public static class Repository
    {
        /// POSTAVKE
        public static void SpremiPostavke(string path, params string[] parameters)
        {
            File.WriteAllText(path, string.Empty);
            var str = String.Join(",", parameters);
            using (StreamWriter writer = File.AppendText(path))
            {
                writer.WriteLine(str);
            }
        }

        // REPREZENTACIJE
        public static Task<HashSet<Reprezentacija>> DohvatiReprezentacijeAsync()
        {
            if (StaticPostavke.DohvacanjePutanja == "Api")
            {
                return Task.Run(() =>
                {
                    var apiKlijent = new RestClient(StaticPostavke.GetReprezentacijePutanja());
                    var rezultat = apiKlijent.Execute<HashSet<Reprezentacija>>(new RestRequest());
                    return JsonConvert.DeserializeObject<HashSet<Reprezentacija>>(rezultat.Content);
                });
            }
            else
            {
                return Task.Run(() =>
                {
                    using (StreamReader reader = new StreamReader(StaticPostavke.GetReprezentacijePutanja()))
                    {
                        string json = reader.ReadToEnd();
                        return JsonConvert.DeserializeObject<HashSet<Reprezentacija>>(json);
                    }
                });
            }
        }

        // UTAKMICE
        public static Task<HashSet<Utakmica>> DohvatiUtakmiceReprezentacijeAsync(string FIFA_code)
        {
            if (StaticPostavke.DohvacanjePutanja == "Api")
            {
                return Task.Run(() =>
                {
                    var apiKlijent = new RestClient(StaticPostavke.GetUtakmiceReprezentacijePutanja() + FIFA_code);
                    var rezultat = apiKlijent.Execute<HashSet<Utakmica>>(new RestRequest());
                    return JsonConvert.DeserializeObject<HashSet<Utakmica>>(rezultat.Content);
                });
            }
            else
            {
                return Task.Run(() =>
                {
                    //using (StreamReader reader = new StreamReader(StaticPostavke.GetSveUtakmicePutanja()))
                    //{
                    //    string json = reader.ReadToEnd();();
                    //    return JsonConvert.DeserializeObject<HashSet<Utakmica>>(json);
                    //}

                    HashSet<Utakmica> sveUtakmice = new HashSet<Utakmica>();
                    HashSet<Utakmica> utakmice = new HashSet<Utakmica>();
                    using (StreamReader r = new StreamReader(StaticPostavke.GetUtakmiceReprezentacijePutanja()))
                    {
                        string json = r.ReadToEnd();
                        sveUtakmice = JsonConvert.DeserializeObject<HashSet<Utakmica>>(json);
                    }
                    foreach (Utakmica utakmica in sveUtakmice)
                    {
                        if (utakmica.HomeTeam.Code == FIFA_code || utakmica.AwayTeam.Code == FIFA_code)
                        {
                            utakmice.Add(utakmica);
                        }
                    }
                    //Thread.Sleep(TimeSpan.FromSeconds(5));
                    return utakmice;
                });
            }
        }

        // IGRACI
        public static async Task<HashSet<Igrac>> DohvatiIgraceReprezentacijeAsync(bool samoPocetnuPostavu, string drzava, string FIFA_code)
        {
            HashSet<Igrac> igraci = new HashSet<Igrac>();

            HashSet<Utakmica> utakmice = await DohvatiUtakmiceReprezentacijeAsync(FIFA_code);
            Utakmica utakmica = utakmice.ToList()[0];
            if (utakmica.HomeTeam.Country == drzava)
            {
                foreach (Igrac igrac in utakmica.HomeTeamStatistics.StartingEleven)
                {
                    NapraviIgraca(utakmice, igrac);
                    igraci.Add(igrac);
                }
                if (samoPocetnuPostavu)
                {
                    return igraci;
                }
                foreach (Igrac igrac in utakmica.HomeTeamStatistics.Substitutes)
                {
                    NapraviIgraca(utakmice, igrac);
                    
                    igraci.Add(igrac);
                }
            }
            else
            {
                foreach (Igrac igrac in utakmica.AwayTeamStatistics.StartingEleven)
                {
                    NapraviIgraca(utakmice, igrac);
                    igraci.Add(igrac);
                }
                if (samoPocetnuPostavu)
                {
                    return igraci;
                }
                foreach (Igrac igrac in utakmica.AwayTeamStatistics.Substitutes)
                {
                    NapraviIgraca(utakmice, igrac);
                    igraci.Add(igrac);
                }
            }
            return igraci;
        }

        private static void NapraviIgraca(HashSet<Utakmica> utakmice, Igrac igrac)
        {

            igrac.BrGolova = 0;
            igrac.BrZutihKartona = 0;
            foreach (string OmiljeniIgrac in StaticPostavke.OmiljeniIgraci)
            {
                if (igrac.Name == OmiljeniIgrac)
                {
                    igrac.Omiljeni = true;
                }
            }
            if (StaticPostavke.SlikeIgraca.TryGetValue(igrac.Name, out string slikaPutanjna))
            {
                igrac.SlikaPutanja = slikaPutanjna;
            }
            foreach (Utakmica utakmica in utakmice)
            {
                NapuniGoloveIZuteKartone(igrac, utakmica);
            }
        }

        private static void NapuniGoloveIZuteKartone(Igrac igrac, Utakmica utakmica)
        {
            foreach (var evt in utakmica.HomeTeamEvents)
            {
                if (evt.Player == igrac.Name)
                {
                    switch (evt.TypeOfEvent)
                    {
                        //case TypeOfEvent.Goal:
                        //    igrac.BrGolova++;
                        //    break;
                        //case TypeOfEvent.GoalPenalty:
                        //    break;
                        //case TypeOfEvent.SubstitutionIn:
                        //    break;
                        //case TypeOfEvent.SubstitutionOut:
                        //    break;
                        //case TypeOfEvent.YellowCard:
                        //    igrac.BrZutihKartona++;
                        //    break;
                        //case TypeOfEvent.YellowCardSecond:
                        //    igrac.BrZutihKartona++;
                        //    break;
                        case "goal":
                            igrac.BrGolova++;
                            break;
                        case "yellow-card":
                            igrac.BrZutihKartona++;
                            break;
                        default:
                            break;
                    }
                }
            }
            foreach (var evt in utakmica.AwayTeamEvents)
            {
                if (evt.Player == igrac.Name)
                {
                    switch (evt.TypeOfEvent)
                    {
                        //case TypeOfEvent.Goal:
                        //    igrac.BrGolova++;
                        //    break;
                        //case TypeOfEvent.GoalPenalty:
                        //    break;
                        //case TypeOfEvent.SubstitutionIn:
                        //    break;
                        //case TypeOfEvent.SubstitutionOut:
                        //    break;
                        //case TypeOfEvent.YellowCard:
                        //    igrac.BrZutihKartona++;
                        //    break;
                        //case TypeOfEvent.YellowCardSecond:
                        //    igrac.BrZutihKartona++;
                        //    break;
                        case "goal":
                            igrac.BrGolova++;
                            break;
                        case "yellow-card":
                            igrac.BrZutihKartona++;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public static Task<List<string>> DohvatiOmiljeneIgrace()
        {
            if (!File.Exists(DatotekePutanje.OMILJENI_IGRACI_PUTANJA))
            {
                File.Create(DatotekePutanje.OMILJENI_IGRACI_PUTANJA);
            }
               
            return Task.Run(() =>
            {
                using (StreamReader reader = new StreamReader(DatotekePutanje.OMILJENI_IGRACI_PUTANJA))
                {
                    List <string> omiljeniIgraci = new List<string>();
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        omiljeniIgraci.Add(line); 
                    }
                    return omiljeniIgraci;
                }
            });
        }

    }
}
