using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChanges();
    }
}