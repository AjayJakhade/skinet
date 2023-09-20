using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Error
{
    public class ApiValidationerrorResponse : ApiResponse
    {
        public ApiValidationerrorResponse() : base(400)
        {

        }
        public IEnumerable<string> Errors{get;set;}
    }
}