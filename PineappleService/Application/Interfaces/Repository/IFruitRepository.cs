using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.Repository
{
    public interface IFruitRepository
    {
        public Task<IEnumerable<Fruit>> GetAll();
        public Task<Fruit> GetById(int id);
        public Task<int> Add(Fruit fruit);
        public Task<int> Remove(Fruit fruit);
        
        public Task<int> SaveChanges();

    }
}