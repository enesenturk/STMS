﻿namespace NS.STMS.Core.Utilities.ExceptionHandling
{
	[Serializable]
	public class FatalException : Exception
	{

		public FatalException()
		{

		}

		public FatalException(string message, string code = "")
			: base(string.Format(message), new Exception($"{code}"))
		{

		}

	}

}
