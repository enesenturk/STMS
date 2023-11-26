using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using NS.STMS.API.Models;
using System.Net;

namespace NS.STMS.API.Extentions
{
	public static class ContextExtentions
	{
		public static ActionExecutingContext ReturnContext(this ActionExecutingContext context, HttpStatusCode statusCode, BaseResponseModel response)
		{
			context.HttpContext.Response.StatusCode = (int)statusCode;
			context.Result = new JsonResult(response);

			return context;
		}

		public static ExceptionContext ReturnContext(this ExceptionContext context, HttpStatusCode statusCode, BaseResponseModel response)
		{
			context.ExceptionHandled = true;
			context.HttpContext.Response.StatusCode = (int)statusCode;
			context.Result = new JsonResult(response);

			return context;
		}

	}
}
