﻿namespace NS.STMS.DTO.Authentication.Response
{
	public class LoginResponseDto
	{

		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public DateOnly DateOfBirth { get; set; }
		public string ImageBase64 { get; set; }

		public string PreferredLanguage { get; set; }
		public string PreferredDateFormat { get; set; }
		public string PreferredNumberFormat { get; set; }

		public StudentLoginResponseDto Student { get; set; }

	}
}
