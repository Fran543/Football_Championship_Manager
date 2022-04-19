using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Igrac
    {
        public enum Pozicija { Defender, Forward, Goalie, Midfield };

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public long ShirtNumber { get; set; }

        [JsonProperty("position")]
        public Pozicija Position { get; set; }

        public bool Omiljeni { get; set; }
        public int BrGolova { get; set; }
        public int BrZutihKartona { get; set; }

        //ako treba brisi stvara bugove
        public string SlikaPutanja { get; set; }

        public override string ToString() => $"Name: {Name}; Captain: {Captain}; Shirt Number: {ShirtNumber}; Position: {Position}; Omiljeni: {Omiljeni}";
    }
}
