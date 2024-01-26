using System.ComponentModel.DataAnnotations;

namespace VitaminBad.Domain.ViewModel
{
    public class DrugViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
