using System.Text.Json.Serialization;

namespace VitaminBad.Domain.Entity
{
    public class Heabs
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string IdHear { get; set; }
        [JsonIgnore]
        public List<Ingredients>? Ingredients { get; set;}
        public string? Age { get; set; }
        public string? Dose { get; set; }
        public string? Times {  get; set; }
        public string? HowTo { get; set; }
        public string? Duration {  get; set; }
        public string? Repeat {  get; set; }
        public string? Recomendation { get; set; }
        public string? Contratindication { get; set; }
        [JsonIgnore]
        public Interaction? Interaction { get; set; }
    }
}
