using System.ComponentModel.DataAnnotations;

namespace CrackersPROJ.Models.DomainModels
{
    public class Crackers
    {
        //PK for crackers table
        public int? CrackersId { get; set; }

        [Required(ErrorMessage = "Please enter the date they were invented.")]
        public string? Invented { get; set; }

        [Required(ErrorMessage = "Please enter a price.")]
        public string? Price { get; set; }


        [Required(ErrorMessage = "Please enter the number of calories.")]
        public int? Calories { get; set; }

        [Required(ErrorMessage = "Please enter the name of the cracker.")]
        public string? Name { get; set; }

        public string? ImageFileName { get; set; }

        public string? Slug => Name?.Replace(' ', '-').ToLower() + '-' + Invented?.Replace(" ", "-").ToLower();
    }
}
