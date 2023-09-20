using API.DTOs;
using API.Error;
using API.Helpers;
using AutoMapper;
using Core.Entity;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    public class ProductsController: BaseApiController
    {
    //     public IProductRepositoryService _repo { get; }
    //    public ProductsController(IProductRepositoryService repo)
    //    {
    //         _repo = repo;
        private readonly IGenericRepository<product> _productrepo;
        public readonly IGenericRepository<productbrand> _Productbrandrepo ;
        private readonly IGenericRepository<producttype> _producttyperepo;
        public IMapper _Mapper { get; }
        
    //    }
    public ProductsController(IGenericRepository<product> productrepo,IGenericRepository<productbrand> productbrandrepo,IGenericRepository<producttype> producttyperepo,IMapper mapper)
    {
            _Mapper = mapper;
            _producttyperepo = producttyperepo;
            _Productbrandrepo = productbrandrepo;
            _productrepo = productrepo;
        
    }
        [HttpGet]
        public async Task<ActionResult<Pagination<Productreturntodtos>>> getproducts([FromQuery]ProductSpecParams productSpecParams){
        // var product=await _repo.GetProductsAsync();
        var spec= new productwithTypesandBrandsSpecification(productSpecParams);
        var countspec=new ProductwithfiltersforCountSpecifications(productSpecParams);
        var totalitems=await _productrepo.countAsync(spec);
        var product=await _productrepo.ListAsync(spec);
        var data=_Mapper.Map<IReadOnlyList<product>,IReadOnlyList<Productreturntodtos>>(product);
         return Ok(new Pagination<Productreturntodtos>(productSpecParams.PageIndex,productSpecParams.PageSize,totalitems,data));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Productreturntodtos>> getoneproduct(int id){
            // return await _repo.GetProductByIdAsync(id);
            var spec=new productwithTypesandBrandsSpecification(id);
            var product= await _productrepo.GetEntitywithSpec(spec);
            if(product==null) return NotFound(new ApiResponse(400));
            return _Mapper.Map<product,Productreturntodtos>(product);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<productbrand>>>getproductbrand(){
            // return Ok(await _repo.GetProductsBrandAsync());
            return Ok(await _Productbrandrepo.getlistAsync());
        }
        [HttpGet("Types")]
         public async Task<ActionResult<IReadOnlyList<producttype>>>getproducttype(){
            // return Ok(await _repo.GetProductsTypeAsync());
            return Ok(await _producttyperepo.getlistAsync());
        }
        
    }
}