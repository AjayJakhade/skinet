using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class BaseSpecifications<T> : ISpecifications<T>
    {
        public BaseSpecifications()
        {

        }

        public BaseSpecifications(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
            
        }

        public Expression<Func<T, bool>> Criteria {get;}

        public List<Expression<Func<T, object>>> Includes {get;}=new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> Orderby {get;private set;}

        public Expression<Func<T, object>> OrderbyDesc {get;private set;}

        public int Take {get;private set;}

        public int Skip {get;private set;}

        public bool isPagingEnabled {get;private set;}

        protected void AddInclude(Expression<Func<T,Object>> includeexpression){
            Includes.Add(includeexpression);
        }
        protected void AddOrderby(Expression<Func<T,object>> orderbyexpression){
            Orderby=orderbyexpression;
        }
         protected void AddOrderbyDesc(Expression<Func<T,object>> orderbydescexpression){
            OrderbyDesc=orderbydescexpression;
        }
        protected void ApplyPaging(int skip,int take){
              Skip = skip;
              Take = take;
              isPagingEnabled=true;
        }
    }
}