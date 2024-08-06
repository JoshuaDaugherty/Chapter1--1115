using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Chapter3finalredone.Models.DomainModels
{
    public class WorkoutLog
    {
        public int WorkoutLogId { get; set; }

        public DateOnly Date { get; set; }

        public int UserId { get; set; } //FK
        [ValidateNever]
        public User? User { get; set; } // navigation property

        public string Notes { get; set; } = string.Empty;

        public ICollection<User> Users { get; set; }//A user can have many workout logs

        public ICollection<WorkoutLogExercize> WorkoutLogExercizes { get; set; } //A workout log can have many exercises
    }
}
