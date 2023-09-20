using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Error
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message=null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(StatusCode);
        }

       

        public int StatusCode { get; set; }
        public string Message{get;set;}

         private string GetDefaultMessageForStatusCode(int statusCode)
        {
           return statusCode switch
           {
            400=>"A bad request,you have made",
            401=>"Authorized,You are not",
            404=>"Resource Found,It was Not what you are looking",
            500=>"Error leads to dark side,Error leads to anger,anger leades to hate",
            _=>null

           };
        }
    }
}