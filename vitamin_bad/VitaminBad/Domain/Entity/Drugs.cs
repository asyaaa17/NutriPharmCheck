using System.Text.Json.Serialization;

namespace VitaminBad.Domain.Entity
{
    public class Drugs
    {
        public long Id { get; set; }
        public string IdDrug { get; set; }
        public string Name { get; set; }

        public string? Dose { get; set; }
        public string? Effect { get; set; }
        [JsonIgnore]
        public List<Interaction>? Interactions { get; set; }

    }
}
