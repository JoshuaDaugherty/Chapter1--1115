using System.ComponentModel.DataAnnotations;

namespace ContactPROJ.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}
