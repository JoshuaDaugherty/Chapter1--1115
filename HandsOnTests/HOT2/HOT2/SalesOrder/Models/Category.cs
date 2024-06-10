using System.ComponentModel.DataAnnotations;

namespace SalesOrder.Models
{
	public class Category
	{
		public int CategoryId { get; set; }

		public string CategoryName { get; set; } = string.Empty;


	}
}
