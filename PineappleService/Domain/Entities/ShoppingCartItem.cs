using Domain.Common;

namespace Domain.Entities
{
    public class ShoppingCartItem : IBaseEntity
    {
        public int Id { get; set; }

        public int ShoppingCartId { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }

        public int FruitId { get; set; }
        public virtual Fruit Fruit { get; set; }
        
        public decimal Quantity { get; set; }
        public decimal UnityPrice { get; set; }
        
        public decimal Total { get; set; }
    }
}