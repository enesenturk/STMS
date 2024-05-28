namespace NS.STMS.Core.Utilities.ExceptionHandling
{
	[Serializable]
	public class AuthorizationException : Exception
	{

		public AuthorizationException()
		{

		}

		public AuthorizationException(string message, string code = "")
			: base(string.Format(message), new Exception($"{code}"))
		{

		}

	}
}
