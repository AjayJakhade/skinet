using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T:BaseEntity
    {
       Task<T> getbyIdAsync(int id);
       Task<IReadOnlyList<T>> getlistAsync(); 
       Task<T> GetEntitywithSpec(ISpecifications<T> spec);
       Task<IReadOnlyList<T>> ListAsync(ISpecifications<T> spec);
       Task<int> countAsync(ISpecifications<T> spec);
    }
}