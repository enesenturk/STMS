namespace NS.STMS.DTO.Authentication.Request
{
	public class ResetPasswordRequestDto
	{

		public string Password { get; set; }
		public Guid Token { get; set; }

	}
}
