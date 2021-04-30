using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
using System.Web.Http.Filters;
//using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
//using System.Text;

namespace APIWeb.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {

        public override void OnException(HttpActionExecutedContext context)
        {
          
            
            var exceptionType = context.Exception.GetType();
            HttpResponseMessage httpResponseMessage;

            if (exceptionType == typeof(NullReferenceException))
            {
                
                httpResponseMessage = CreateHttpResponseMessage(context.Request, HttpStatusCode.NotFound,     "NullReferenceException  - - "+ context.Exception.Message + " - - "+ context.Request.ToString());
            }
            else if (exceptionType == typeof(UnauthorizedAccessException))
            {
                httpResponseMessage = CreateHttpResponseMessage(context.Request, HttpStatusCode.Unauthorized, "UnauthorizedAccessException - - " + context.Exception.Message + " - - " + context.Request.ToString());
            }
            else
            {
                httpResponseMessage = CreateHttpResponseMessage(context.Request, HttpStatusCode.InternalServerError, " Error Interno en el servidor: " + context.Exception.ToString());
            }           
            
            context.Response = httpResponseMessage;
            
        }
        public HttpResponseMessage CreateHttpResponseMessage(HttpRequestMessage request, HttpStatusCode statusCode, string error)
        {
            return request.CreateResponse(statusCode, error);

            
        }
      
    }
}
