using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class Productreturntodtos
    {
        public int id{get;set;}
         public string name { get; set; }
        public string Description{get;set;}
        public decimal price{get;set;}
        public string pictureurl{get;set;}
        public string producttype{get;set;}
       
        public string productbrand{get;set;}
    
    }
}