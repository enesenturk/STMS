using Microsoft.AspNetCore.Mvc.Filters;
using NS.STMS.API.Extentions;
using NS.STMS.API.Models;
using System.Net;

namespace NS.STMS.API.Filters
{
	public class ExceptionHandler : ExceptionFilterAttribute
	{

		public override Task OnExceptionAsync(ExceptionContext context)
		{
			BaseResponseModel exceptionResponse = GetResponse(context);

			context.ReturnContext(HttpStatusCode.Conflict, exceptionResponse);

			return Task.CompletedTask;
		}

		public override void OnException(ExceptionContext context)
		{
			BaseResponseModel exceptionResponse = GetResponse(context);

			context.ReturnContext(HttpStatusCode.Conflict, exceptionResponse);
		}

		public BaseResponseModel GetResponse(ExceptionContext context)
		{
			BaseResponseModel exceptionResponse = new BaseResponseModel
			{
				Message = context.Exception.Message,
				Type = "E"
			};

			//Exception exception = context.Exception;
			//Type ExceptionType = exception.GetType();

			//bool isValidationException = ExceptionType.name == "ValidationException";
			//bool isCoreException = ExceptionType.name == "CoreException";
			//bool isAuthorizationException = ExceptionType.name == "AuthorizationException";
			//bool isDateFormatException = ExceptionType.name == "FormatException" && exception.ToString().Contains("DateTime");

			//if (isDateFormatException)
			//{
			//	string errorCode = "96";

			//	exceptionResponse.ErrorCode = errorCode;
			//}
			//else if (isValidationException)
			//{
			//	string errorCode = "97";

			//	exceptionResponse.ErrorCode = errorCode;
			//}
			//else if (isCoreException)
			//{
			//	string errorCode = exception.InnerException.Message == "" ? "98" : exception.InnerException.Message;

			//	exceptionResponse.ErrorCode = errorCode;
			//}
			//else if (isAuthorizationException)
			//{
			//	exceptionResponse.Message = exception.Message;
			//}
			//else
			//{
			//	string errorCode = "99";

			//	exceptionResponse.ErrorCode = errorCode;
			//	//exceptionResponse.Message = "An error occurred. Please contact to the system admin.";
			//	exceptionResponse.Message = $"ExceptionMessage: {exception.Message}";
			//}

			return exceptionResponse;
		}

	}
}
