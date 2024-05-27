namespace Distance___Order.Models
{
	public class OrderForm
	{
		public double Quantity { get; set; }
		public double DiscountCode { get; set; }
		public double DiscountMessage { get; set; }
		public double PricePerShirt { get; set; }
		public double Subtotal { get; set; }
		public double Tax { get; set; }
		public double Total { get; set; }

		public void CalcOrder()
		{
			const double Shirt = 15.00;
			const double Taxes = 0.08;

			Subtotal = Quantity * Shirt;

			Tax = Subtotal * Taxes;

			Total = Subtotal + Tax;

			
		}
	}
}
