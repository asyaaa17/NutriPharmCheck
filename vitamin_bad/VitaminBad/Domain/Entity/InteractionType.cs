using System.Text.Json.Serialization;

namespace VitaminBad.Domain.Entity
{
    public class InteractionType
    {
        public long Id { get; set; }

        public string Title { get; set; }
        [JsonIgnore]

        public List<Interaction>? Interactions { get; set; }
    }
}
