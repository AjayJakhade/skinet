using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;

namespace Core.Interfaces
{
    public interface IProductRepositoryService
    {
        Task<product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<product>> GetProductsAsync();
         Task<IReadOnlyList<producttype>> GetProductsTypeAsync();
         Task<IReadOnlyList<productbrand>> GetProductsBrandAsync();
        
        
    }
}