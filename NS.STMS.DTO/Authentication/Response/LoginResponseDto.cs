using NS.STMS.DTO.SystemTables.Address;

namespace NS.STMS.DTO.Authentication.Response
{
	public class LoginResponseDto
	{

		public string Name { get; set; }

		public string Surname { get; set; }

		public string EMail { get; set; }

		public DateOnly DateOfBirth { get; set; }

		public string ImageBase64 { get; set; }

		public AddressDto Address { get; set; }

		public bool IsStudent { get; set; }

		public StudentLoginResponseDto Student { get; set; }

	}
}
