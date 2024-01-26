using System.Text.Json.Serialization;

namespace VitaminBad.Domain.Entity
{
    public class Food
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set;}
        [JsonIgnore]
        public List<Ingredients>? Ingredients {  get; set; }
        public string? NutrientDataBankNumber { get; set; }
        public string? DoseId { get; set; }
    }
}
