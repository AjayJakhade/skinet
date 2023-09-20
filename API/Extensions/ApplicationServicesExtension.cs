using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Error;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection ApplicationService(this IServiceCollection services,IConfiguration configuration){
            services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

 services.AddDbContext<StoreContext>(opt  =>
{
    opt.UseSqlite(configuration.GetConnectionString("defaultconnection"));
    
});
services.AddScoped<IProductRepositoryService,productrepository>();
services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
services.Configure<ApiBehaviorOptions>(options =>{
    options.InvalidModelStateResponseFactory=actioncontext=>{
    var errors=actioncontext.ModelState.Where(e=>e.Value.Errors.Count>0).SelectMany(x=>x.Value.Errors).Select(x=>x.ErrorMessage).ToArray();
    var errorresponse=new ApiValidationerrorResponse{
        Errors=errors
    };
    return new BadRequestObjectResult(errorresponse);
    };

    
});
services.AddCors(opt=>{
    opt.AddPolicy("corspolicy",policy=>{
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
    });
});
            return services;
        }
    }
}