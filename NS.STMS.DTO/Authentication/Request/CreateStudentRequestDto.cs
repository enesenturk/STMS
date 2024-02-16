namespace NS.STMS.DTO.Authentication.Request
{
	public class CreateStudentRequestDto
	{

		public string name { get; set; }
		public string surname { get; set; }
		public string email { get; set; }
		public string password { get; set; }
		public DateTime dateOfBirth { get; set; }
		public int gradeId { get; set; }
		public string schoolName { get; set; }
		public int countyId { get; set; }

	}
}
