using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Core.Entity;

namespace API.Helpers
{
    public class productmapper : Profile
    {
        
        public productmapper()
        {
            CreateMap<product,Productreturntodtos>().ForMember(p=>p.productbrand,o=>o.MapFrom(s=>s.productbrand.name))
            .ForMember(p=>p.producttype,o=>o.MapFrom(s=>s.producttype.name))
            .ForMember(p =>p.pictureurl,o=>o.MapFrom<ProductUrlResolver>());
        }
    }
}