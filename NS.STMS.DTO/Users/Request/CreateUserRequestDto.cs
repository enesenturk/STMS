namespace NS.STMS.DTO.Users.Request
{
	public class CreateUserRequestDto
	{

		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public DateTime DateOfBirth { get; set; }

		public int GradeId { get; set; }
		public string SchoolName { get; set; }

		public int CountyId { get; set; }

	}
}
