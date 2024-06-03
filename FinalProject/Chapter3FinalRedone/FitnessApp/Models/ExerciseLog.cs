using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.VisualBasic;
namespace FitnessApp.Models
{
    public class ExerciseLog
    {
        //primary
        [Key]
        public int ExerciseId { get; set; }

        [Required(ErrorMessage = "Please enter a Workout")]
        public string Workout { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Please enter a Activity")]
        public string Activity { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Please enter a number of sets")]
        [Range(1,10, ErrorMessage = "Sets must be between 1 and 10")]
        public int? Sets { get; set; }

        [Required(ErrorMessage = "Please enter a number of reps")]
        [Range(1, 10, ErrorMessage = "Reps must be between 1 and 10")]
        public int? Reps { get; set; }

        [Required(ErrorMessage = "Please enter a Weight")]
        [Range(5, 500, ErrorMessage = "Weight must be between 5 and 500")]
        public int? Weight { get; set; }

        public string Slug => Name?.Replace(' ', '-').ToLower() + '-' + Year?.ToString();

        [Required(ErrorMessage = "Please enter a Genre")]
        public string GenreId { get; set; } = string.Empty;

        [ValidateNever]
        public Genre Genre { get; set; } = null!;
    }
}
