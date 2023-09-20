using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entity;

namespace Core.Specifications
{
    public class productwithTypesandBrandsSpecification : BaseSpecifications<product>
    {
        public productwithTypesandBrandsSpecification(ProductSpecParams productSpecParams):base(
            x=>(
                string.IsNullOrEmpty(productSpecParams.search)||x.name.ToLower().Contains(productSpecParams.search)
            )&&
            (

                !productSpecParams.brandId.HasValue || x.productbrandId==productSpecParams.brandId
            ) && (!productSpecParams.typeId.HasValue || x.producttypeId==productSpecParams.typeId)
        )
        {
            AddInclude(x=>x.producttype);
            AddInclude(x=>x.productbrand);
            AddOrderby(x=>x.name);
            ApplyPaging(productSpecParams.PageSize *(productSpecParams.PageIndex-1),productSpecParams.PageSize);
            if(!string.IsNullOrEmpty(productSpecParams.sort)){
                switch(productSpecParams.sort){
                    case "priceasc":
                    AddOrderby(p=>p.price);
                    break;
                    case "pricedesc":
                    AddOrderbyDesc(p=>p.price);
                    break;
                    default:
                    AddOrderby(n=>n.name);
                    break;
                }
            }
        }

        public productwithTypesandBrandsSpecification(int id) : base(x =>x.id==id)
        {
            AddInclude(x=>x.producttype);
            AddInclude(x=>x.productbrand);
        }
    }
}