﻿namespace CrackersPROJ.Models.DomainModels
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }

        public Crackers Crackers { get; set; }

        public int Quantity { get; set; }
    }
}
