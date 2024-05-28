using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using NS.STMS.API.Extentions;
using NS.STMS.API.Models;
using NS.STMS.Core.Utilities.ExceptionHandling;
using System.Net;

namespace NS.STMS.API.Filters
{
	public class ExceptionHandler : ExceptionFilterAttribute
	{

		public override Task OnExceptionAsync(ExceptionContext context)
		{
			(HttpStatusCode, BaseResponseModel) info = GetResponseInfo(context);

			context.ReturnContext(info.Item1, info.Item2);

			return Task.CompletedTask;
		}

		public override void OnException(ExceptionContext context)
		{
			(HttpStatusCode, BaseResponseModel) info = GetResponseInfo(context);

			context.ReturnContext(info.Item1, info.Item2);
		}

		#region extracted methods

		private (HttpStatusCode, BaseResponseModel) GetResponseInfo(ExceptionContext context)
		{
			BaseResponseModel exceptionResponse = new BaseResponseModel
			{
				Message = context.Exception.Message,
				Type = "E"
			};

			Type exceptionType = GetExceptionType(context);

			bool isValidationException = exceptionType.Name == nameof(ValidationException);
			bool isBusinessException = exceptionType.Name == nameof(BusinessException);
			bool isAuthorizationException = exceptionType.Name == nameof(AuthorizationException);
			bool isAuthenticationException = exceptionType.Name == nameof(AuthenticationException);

			bool notMyException = !isValidationException && !isBusinessException && !isAuthorizationException && !isAuthenticationException;
			if (notMyException)
			{
				exceptionResponse.Message = "Error_Ocurred";
			}

			HttpStatusCode code =
				isValidationException ? HttpStatusCode.BadRequest :
				isBusinessException ? HttpStatusCode.UnprocessableEntity :
				isAuthorizationException ? HttpStatusCode.Forbidden :
				isAuthenticationException ? HttpStatusCode.Unauthorized :
				HttpStatusCode.InternalServerError;

			return (code, exceptionResponse);
		}

		public Type GetExceptionType(ExceptionContext context)
		{
			Exception exception = context.Exception;
			Type ExceptionType = exception.GetType();

			return ExceptionType;
		}

		#endregion

	}
}
