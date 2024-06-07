namespace NS.STMS.DTO.Authentication.Response
{
	public class TryLoginResponseDto
	{

		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public DateOnly DateOfBirth { get; set; }
		public string ImageBase64 { get; set; }

		public string PreferredLanguage { get; set; }
		public string PreferredDateFormat { get; set; }
		public string PreferredNumberFormat { get; set; }

		public StudentLoginResponseDto Student { get; set; }

		public bool AcceptedTerms { get; set; }
		public bool EmailVerified { get; set; }
		public bool NeedsChangePassword { get; set; }
		public bool IsBlocked { get; set; }

	}
}
