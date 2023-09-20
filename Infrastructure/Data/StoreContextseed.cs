using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entity;

namespace Infrastructure.Data
{
    public class StoreContextseed
    {
        public static async Task SeedAsync(StoreContext context){
            if(!context.productbrands.Any()){
                var brandsdata=File.ReadAllText("../Infrastructure/Data/seeddata/brands.json");
                var brands= JsonSerializer.Deserialize<List<productbrand>>(brandsdata);
                context.productbrands.AddRange(brands);                
            }
             if(!context.producttypes.Any()){
               
                var typesdata=File.ReadAllText("../Infrastructure/Data/seeddata/types.json");
                var types= JsonSerializer.Deserialize<List<producttype>>(typesdata);
                context.producttypes.AddRange(types);                
            }
             if(!context.products.Any()){
                var productdata=File.ReadAllText("../Infrastructure/Data/seeddata/products.json");
                var product= JsonSerializer.Deserialize<List<product>>(productdata);
                context.products.AddRange(product);                
            }
            if(context.ChangeTracker.HasChanges()){
                await context.SaveChangesAsync();
            }
        }
    }
}