using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Utakmica
    {

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("attendance")]
        public long Attendance { get; set; }

        [JsonProperty("home_team")]
        public Team HomeTeam { get; set; }

        [JsonProperty("away_team")]
        public Team AwayTeam { get; set; }

        [JsonProperty("home_team_events")]
        public TeamEvent[] HomeTeamEvents { get; set; }

        [JsonProperty("away_team_events")]
        public TeamEvent[] AwayTeamEvents { get; set; }

        [JsonProperty("home_team_statistics")]
        public TeamStatistics HomeTeamStatistics { get; set; }

        [JsonProperty("away_team_statistics")]
        public TeamStatistics AwayTeamStatistics { get; set; }
    }
    public partial class TeamEvent
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("type_of_event")]
        public string TypeOfEvent { get; set; }

        [JsonProperty("player")]
        public string Player { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }
    }
    public partial class Team
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("goals")]
        public long Goals { get; set; }

        [JsonProperty("penalties")]
        public long Penalties { get; set; }
    }
    public partial class TeamStatistics
    {
        [JsonProperty("starting_eleven")]
        public Igrac[] StartingEleven { get; set; }

        [JsonProperty("substitutes")]
        public Igrac[] Substitutes { get; set; }
    }
    //public enum TypeOfEvent { Goal, GoalPenalty, SubstitutionIn, SubstitutionOut, YellowCard, YellowCardSecond };

    //internal static class Converter
    //{
    //    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    //    {
    //        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
    //        DateParseHandling = DateParseHandling.None,
    //        Converters =
    //        {
    //            TypeOfEventConverter.Singleton
    //        },
    //    };
    //}


    //internal class TypeOfEventConverter : JsonConverter
    //{
    //    public override bool CanConvert(Type t) => t == typeof(TypeOfEvent) || t == typeof(TypeOfEvent?);

    //    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    //    {
    //        if (reader.TokenType == JsonToken.Null) return null;
    //        var value = serializer.Deserialize<string>(reader);
    //        switch (value)
    //        {
    //            case "goal":
    //                return TypeOfEvent.Goal;
    //            case "goal-penalty":
    //                return TypeOfEvent.GoalPenalty;
    //            case "substitution-in":
    //                return TypeOfEvent.SubstitutionIn;
    //            case "substitution-out":
    //                return TypeOfEvent.SubstitutionOut;
    //            case "yellow-card":
    //                return TypeOfEvent.YellowCard;
    //            case "yellow-card-second":
    //                return TypeOfEvent.YellowCardSecond;
    //        }
    //        throw new Exception("Cannot unmarshal type TypeOfEvent");
    //    }

    //    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    //    {
    //        if (untypedValue == null)
    //        {
    //            serializer.Serialize(writer, null);
    //            return;
    //        }
    //        var value = (TypeOfEvent)untypedValue;
    //        switch (value)
    //        {
    //            case TypeOfEvent.Goal:
    //                serializer.Serialize(writer, "goal");
    //                return;
    //            case TypeOfEvent.GoalPenalty:
    //                serializer.Serialize(writer, "goal-penalty");
    //                return;
    //            case TypeOfEvent.SubstitutionIn:
    //                serializer.Serialize(writer, "substitution-in");
    //                return;
    //            case TypeOfEvent.SubstitutionOut:
    //                serializer.Serialize(writer, "substitution-out");
    //                return;
    //            case TypeOfEvent.YellowCard:
    //                serializer.Serialize(writer, "yellow-card");
    //                return;
    //            case TypeOfEvent.YellowCardSecond:
    //                serializer.Serialize(writer, "yellow-card-second");
    //                return;
    //        }
    //        throw new Exception("Cannot marshal type TypeOfEvent");
    //    }

    //    public static readonly TypeOfEventConverter Singleton = new TypeOfEventConverter();
    //}
}
