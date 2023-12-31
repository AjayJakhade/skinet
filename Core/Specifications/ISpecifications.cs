using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public interface ISpecifications<T>
    {
        Expression<Func<T,bool>> Criteria{get;}
        List<Expression<Func<T,object>>> Includes{get;}
        Expression<Func<T,object>> Orderby{get;}
        Expression<Func<T,object>> OrderbyDesc{get;}
        int Take{get;}
        int Skip{get;}
        bool isPagingEnabled{get;}
    }
}