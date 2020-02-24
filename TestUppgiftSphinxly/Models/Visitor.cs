using System.ComponentModel.DataAnnotations;


namespace TestUppgiftSphinxly.Models
{
    public class Visitor
    {
        [Display(Name = "Skriv ditt namn")]
        [Required(ErrorMessage = "Namn saknas")]
        [RegularExpression("^[a-öA-Ö]*$", ErrorMessage = "Du måste skriva bokstäver.")]
        public string Name { get; set; }
    }
}