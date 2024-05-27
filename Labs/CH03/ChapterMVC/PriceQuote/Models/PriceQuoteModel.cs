namespace PriceQuote.Models
{
    public class PriceQuoteModel
    {
        public double Percent {  get; set; }
        public double DiscountAmount { get; set; }
        public double Total {  get; set; }
        public double Subtotal { get; set; }

        public void CalcQuote()
        {
            DiscountAmount = (Percent / 100) * Subtotal;
            Total = Subtotal - DiscountAmount;
        }
    }
}
