using NS.STMS.DTO.SystemTables.Address;

namespace NS.STMS.DTO.Authentication.Response
{
	public class LoginResponseDto
	{

		public string name { get; set; }
		public string surname { get; set; }
		public string email { get; set; }

		public DateOnly dateOfBirth { get; set; }

		public string imageBase64 { get; set; }

		public AddressDto address { get; set; }

		public bool isStudent { get; set; }

		public StudentLoginResponseDto student { get; set; }

	}
}
