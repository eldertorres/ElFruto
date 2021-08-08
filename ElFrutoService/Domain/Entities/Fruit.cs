using Domain.Common;

namespace Domain.Entities
{
    public class Fruit : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}