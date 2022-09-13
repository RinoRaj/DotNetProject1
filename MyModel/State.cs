
using System.ComponentModel.DataAnnotations;


namespace MyModel
{
    public class State
    {
        [Key]
        public int id { get; set; }
        [Display(Name ="State")]
        [Required(ErrorMessage ="Name of the state is required")]
        [StringLength(ContactManagerConstants.MaxStateNameLength)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Name of the state abbreviation is required")]
        [StringLength(ContactManagerConstants.StateAbbrLength)]
        public string Abbreviation { get; set; }
    }
}
