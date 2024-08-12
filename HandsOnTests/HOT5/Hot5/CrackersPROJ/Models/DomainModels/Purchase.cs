namespace CrackersPROJ.Models.DomainModels
{
    public class Purchase
    {
        public int Id { get; set; }
        public int? CrackersId { get; set; }//FK

        public Crackers Crackers { get; set; }//Navigation property

        public int? Quantity { get; set; }

        public DateTime? PurchaseDate { get; set; }

        public decimal? Total { get; set; }
    }
}
