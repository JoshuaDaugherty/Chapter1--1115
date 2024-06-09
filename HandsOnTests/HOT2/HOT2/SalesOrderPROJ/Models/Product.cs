using System.ComponentModel.DataAnnotations;
namespace SalesOrderPROJ.Models
{
	public class Product
	{
		public int ProductID { get; set; }

		[Required(ErrorMessage = "Please enter a product name")]
		public string ProductName { get; set; } = string.Empty;

		public string ProductDescShort { get; set; } = string.Empty;

		public string ProductDescLong { get; set;} = string.Empty;

		[Required(ErrorMessage = "Please enter a product image")]
		public string ProductImage { get; set; } = string.Empty;

		[Range(1,100000, ErrorMessage = "Please enter a price between 1-100000")]
		public decimal? ProductPrice { get; set; }

		[Range(1,1000, ErrorMessage = "Please enter a price between 1-1000")]
		public int? ProductQty { get; set; }



	}
}
