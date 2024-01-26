namespace VitaminBad.Domain.Entity
{
    public class Interaction
    {
        public long Id { get; set; }
        public string IdInteraction { get; set; }
        public long? DrugsId {  get; set; }
        public Drugs? Drugs { get; set; }
        public long? IngredientsId { get; set; }
        public Ingredients? Ingredients { get; set; }
        public string? InteractionText {  get; set; }
        public long? InteractionTypeId { get; set; }
        public InteractionType? InteractionType { get; set; }

    }
}
