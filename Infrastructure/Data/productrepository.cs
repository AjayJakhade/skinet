using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class productrepository : IProductRepositoryService
    {
        private readonly StoreContext _context;
        public productrepository(StoreContext context)
        {
            _context = context;
            
        }
        public async Task<product> GetProductByIdAsync(int id)
        {
           return await _context.products.Include(p =>p.producttype).Include(p=>p.productbrand).FirstOrDefaultAsync(p=>p.id==id);
        }

        public async Task<IReadOnlyList<product>> GetProductsAsync()
        {
            return await _context.products.Include(p=>p.producttype).Include(p=>p.productbrand).ToListAsync();
        }

        public async Task<IReadOnlyList<productbrand>> GetProductsBrandAsync()
        {
            return await _context.productbrands.ToListAsync();
        }

        public async Task<IReadOnlyList<producttype>> GetProductsTypeAsync()
        {
           return await _context.producttypes.ToListAsync();
        }
    }
}