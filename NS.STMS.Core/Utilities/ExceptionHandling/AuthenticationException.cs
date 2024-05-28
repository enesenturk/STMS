namespace NS.STMS.Core.Utilities.ExceptionHandling
{
	[Serializable]
	public class AuthenticationException : Exception
	{

		public AuthenticationException()
		{

		}

		public AuthenticationException(string message, string code = "")
			: base(string.Format(message), new Exception($"{code}"))
		{

		}

	}
}
