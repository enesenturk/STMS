namespace NS.STMS.Core.Utilities.ExceptionHandling
{
	[Serializable]
	public class BusinessException : Exception
	{

		public BusinessException()
		{

		}

		public BusinessException(string message, string code = "")
			: base(string.Format(message), new Exception($"{code}"))
		{

		}

	}
}
