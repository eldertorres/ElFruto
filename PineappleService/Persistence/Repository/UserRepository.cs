using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly DbSet<User> _dbSet;
        private readonly IDbContext _context;

        public UserRepository(IDbContext context)
        {
            _context = context;
            _dbSet = context.Set<User>();
        }
        
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<int> Add(User user)
        {
            await _dbSet.AddAsync(user);
            await _context.SaveChanges();
            return user.Id;
        }

        public async Task<int> Remove(User user)
        {
            _dbSet.Remove(user);
            await _context.SaveChanges();
            return user.Id;
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChanges();
        }
    }
}