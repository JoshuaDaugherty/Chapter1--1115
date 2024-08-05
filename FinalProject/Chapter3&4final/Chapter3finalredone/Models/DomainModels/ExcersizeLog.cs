using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Chapter3finalredone.Models.DomainModels
{
	public class ExcersizeLog
	{
		public int ExcersizeLogId { get; set; }

		[StringLength(20,ErrorMessage = "The Log name may not exceed 20 characters.")]
		[Required(ErrorMessage = "Please enter a Log name.")]
		public string ExcersizeLogName { get; set; } = string.Empty;

		[Display(Name = "Time")]
		[RegularExpression("^[0-9]*$", ErrorMessage = "Please enter number only for a log time.")]
		[StringLength(4, MinimumLength = 4, ErrorMessage = "Log time must be 4 characters long.")]
		[Required(ErrorMessage = "Please enter a log time (in military time format).")]
		public string MilitaryTime { get; set; } = string.Empty;
		
		public int DateId { get; set; } //fk
		[ValidateNever]
		public Date Date { get; set; } = null!; //nav prop

		public int NoteId { get; set; }  //fk
		[ValidateNever]
		public Note Note { get; set; } = null!; //nav prop
	}
}
