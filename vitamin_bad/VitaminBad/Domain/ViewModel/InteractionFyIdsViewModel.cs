using System.ComponentModel.DataAnnotations;
using VitaminBad.Domain.Entity;

namespace VitaminBad.Domain.ViewModel
{
    public class InteractionFyIdsViewModel
    {
        [Required]
        public long IdDrug { get; set; }
        [Required]
        public long IdIngradient { get; set; }
    }
    public class InteractionByNameViewModel
    {
        [Required]
        public string Name_drug { get; set; }
        [Required]
        public string Name_bad { get; set; }
    }
    public class InteractionByNameViewModel2
    {
        
        public List<Drugs> drug { get; set; }
        
        public List<Heabs> bad { get; set; }
    }
    public class InteractionV2ViewModel
    {
        [Required]
        public long IdDrug { get; set; }
        [Required]
        public long IdHeab { get; set; }
    }

}
