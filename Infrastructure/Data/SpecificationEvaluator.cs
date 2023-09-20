using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity:BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputquery,ISpecifications<TEntity> spec){
            var query=inputquery;
            if(spec.Criteria!=null){
                query=query.Where(spec.Criteria);
            }
             if(spec.Orderby!=null){
                query=query.OrderBy(spec.Orderby);
            }
             if(spec.OrderbyDesc!=null){
                query=query.OrderByDescending(spec.OrderbyDesc);
            }
            if(spec.isPagingEnabled){
                query=query.Skip(spec.Skip).Take(spec.Take);
            }
            query=spec.Includes.Aggregate(query,(current,include)=>current.Include(include));
            return query;
        }
        
    }
}