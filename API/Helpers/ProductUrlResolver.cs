using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Core.Entity;

namespace API.Helpers
{
    public class ProductUrlResolver : IValueResolver<product, Productreturntodtos, string>
    {
        private readonly IConfiguration _config;
        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(product source, Productreturntodtos destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.pictureurl)){
                  return _config["AppUrl"]+source.pictureurl;
            }
            return null;
           
        }
    }
}