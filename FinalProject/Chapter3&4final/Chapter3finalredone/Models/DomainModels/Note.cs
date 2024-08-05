using System.ComponentModel.DataAnnotations;

namespace Chapter3finalredone.Models.DomainModels
{
	public class Note
	{

		public Note() => excersizeLogs = new HashSet<ExcersizeLog>(); //constructor initializes collection

		public int NoteId { get; set; }  //pk

		[Display(Name = "Notes")]
		[StringLength(100, ErrorMessage = "Notes may not exceed 100 characters.")]
		[Required(ErrorMessage = "Please enter notes.")]
		public string NotesAfterWorkout { get; set; } = string.Empty;

		public ICollection<ExcersizeLog> excersizeLogs { get; set; } //nav prop
	}
}
