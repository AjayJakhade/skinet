using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entity
{
  
    public class product:BaseEntity
    {
        public string name { get; set; }
        public string Description{get;set;}
        public decimal price{get;set;}
        public string pictureurl{get;set;}
        public producttype producttype{get;set;}
        public int producttypeId{get;set;}
        public productbrand productbrand{get;set;}
        public int productbrandId{get;set;}
    }
}