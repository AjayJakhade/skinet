using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;

namespace Core.Specifications
{
    public class ProductwithfiltersforCountSpecifications:BaseSpecifications<product>
    {
        public ProductwithfiltersforCountSpecifications(ProductSpecParams productSpecParams):base(
            x=>
            (
                string.IsNullOrEmpty(productSpecParams.search)||x.name.ToLower().Contains(productSpecParams.search)
            )&&(
                !productSpecParams.brandId.HasValue || x.productbrandId==productSpecParams.brandId
            ) && (!productSpecParams.typeId.HasValue || x.producttypeId==productSpecParams.typeId))
        {
        }
    }
}