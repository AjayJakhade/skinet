using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Error;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController:BaseApiController
    {
        public StoreContext _context { get; }
        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("Not found")]
        public ActionResult GetNotFound(){
            var thing=_context.products.Find(42);
            if(thing==null){
                return NotFound(new ApiResponse(404));
            }
            return Ok();

        } 
        [HttpGet("sever error")]
        public ActionResult GetServerError(){
            var thing=_context.products.Find(42);
            var thanos=thing.ToString();
            return Ok();

        }  
        [HttpGet("Bad Request")]
        public ActionResult GetBadRequest(){

            return BadRequest(new ApiResponse(400));

        }    
        
        
        [HttpGet("Bad Request/{id}")]
        public ActionResult BadRequest(int id){
            return BadRequest();

        }  
        
    }
}