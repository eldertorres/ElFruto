using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.Repository
{
    public interface IShoppingCartRepository
    {
        public Task<IEnumerable<ShoppingCart>> GetAll();
        public Task<ShoppingCart> GetById(int id);
        public Task<int> Add(ShoppingCart shoppingCart);
        public Task<int> Remove(ShoppingCart shoppingCart);
        public Task<int> SaveChanges();
    }
}