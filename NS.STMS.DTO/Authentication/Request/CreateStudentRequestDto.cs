namespace NS.STMS.DTO.Authentication.Request
{
	public class CreateStudentRequestDto
	{

		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public DateTime DateOfBirth { get; set; }
		public int GradeId { get; set; }
		public string SchoolName { get; set; }
		public int CountyId { get; set; }

	}
}
