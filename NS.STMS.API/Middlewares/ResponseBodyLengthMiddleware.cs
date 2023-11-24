namespace NS.STMS.API.Middlewares
{
	public class ResponseBodyLengthMiddleware
	{

		private readonly RequestDelegate _next;

		public ResponseBodyLengthMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			var originalBody = context.Response.Body;

			using (var ms = new MemoryStream())
			{
				context.Response.Body = ms;

				long length = 0;

				context.Response.OnStarting((state) =>
				{
					context.Response.Headers.ContentLength = length;
					return Task.FromResult(0);
				}, context);

				await _next(context);

				length = context.Response.Body.Length;
				context.Response.Body.Position = 0;

				await ms.CopyToAsync(originalBody);
			}
		}

	}
}
