using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repository
{
    public class ShoppingCartRepository: IShoppingCartRepository
    {
        private readonly DbSet<ShoppingCart> _dbSet;
        private readonly IDbContext _context;

        public ShoppingCartRepository(IDbContext context)
        {
            _context = context;
            _dbSet = context.Set<ShoppingCart>();
        }

        public async Task<IEnumerable<ShoppingCart>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<ShoppingCart> GetById(int id)
        {
            return await _dbSet
                .Include(d => d.ShoppingCartItems)
                .ThenInclude(i => i.Fruit)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<int> Add(ShoppingCart shoppingCart)
        {
            await _dbSet.AddAsync(shoppingCart);
            await _context.SaveChanges();
            return shoppingCart.Id;
        }

        public async Task<int> Remove(ShoppingCart shoppingCart)
        {
            _dbSet.Remove(shoppingCart);
            await _context.SaveChanges();
            return shoppingCart.Id;
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChanges();
        }
    }
}