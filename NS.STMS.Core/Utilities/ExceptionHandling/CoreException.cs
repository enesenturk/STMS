namespace NS.STMS.Core.Utilities.ExceptionHandling
{
	[Serializable]
	public class CoreException : Exception
	{

		public CoreException()
		{

		}

		public CoreException(string message, string code = "")
			: base(String.Format(message), new Exception($"{code}"))
		{

		}

	}
}
