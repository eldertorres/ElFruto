using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities
{
    public class ShoppingCart : IBaseEntity
    {
        public ShoppingCart()
        {
            ShoppingCartItems = new List<ShoppingCartItem>();
        }
        public int Id { get; set; }

        public virtual List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public decimal Total { get; set; }
    }
}