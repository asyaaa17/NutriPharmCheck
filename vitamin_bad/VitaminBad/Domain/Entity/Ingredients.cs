using System.Text.Json.Serialization;

namespace VitaminBad.Domain.Entity
{
    public class Ingredients
    {
        public long Id { get; set; }
        public string IdIng { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Rec_dose { get; set; }
        public string? Upper_Level { get; set; }
        [JsonIgnore]
        public List<Heabs>? Heabs { get; set; }
        [JsonIgnore]
        public List<Interaction>? Interactions { get; set; }
        [JsonIgnore]
        public List<Food>? Foods { get; set; }
    }
}
