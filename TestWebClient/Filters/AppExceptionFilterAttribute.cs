using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace TestWebClient.Filters
{
	public class AppExceptionFilterAttribute : Attribute, IExceptionFilter
	{
		public void OnException(ExceptionContext context)
		{
			string actionName = context.ActionDescriptor.DisplayName;
			int exceptionCode = context.Exception.HResult;
			string exceptionStackTrace = context.Exception.StackTrace;
			string exceptionMessage = context.Exception.Message;

			context.Result = new ContentResult
			{
				Content = $"Method {actionName} throwed exception with code: {exceptionCode} \n Message: \n {exceptionMessage} \n {exceptionStackTrace}"
			};
			context.ExceptionHandled = true;
		}
	}
}
