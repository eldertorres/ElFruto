using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repository
{
    public class FruitRepository : IFruitRepository
    {
        private readonly DbSet<Fruit> _dbSet;
        private readonly IDbContext _context;

        public FruitRepository(IDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Fruit>();
        }
        
        public async Task<IEnumerable<Fruit>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Fruit> GetById(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<int> Add(Fruit fruit)
        {
            await _dbSet.AddAsync(fruit);
            await _context.SaveChanges();
            return fruit.Id;
        }

        public async Task<int> Remove(Fruit fruit)
        {
            _dbSet.Remove(fruit);
            await _context.SaveChanges();
            return fruit.Id;
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChanges();
        }
    }
}