namespace NS.STMS.DTO.GradeLecture
{
	public class GradeLecturesResponseDto
	{
		public List<string> Lectures { get; set; }
		public List<string> Grades { get; set; }

		public List<GradeLectureResponseDto> GradeLectures { get; set; } = new List<GradeLectureResponseDto>();
	}
}
