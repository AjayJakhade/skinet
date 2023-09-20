using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Error
{
    public class APIException : ApiResponse
    {
        public APIException(int statusCode, string message = null,string details=null) : base(statusCode, message)
        {
             Details=details;
        }
        public string Details{get;set;}
    }
}