namespace NS.STMS.DTO.GradeLectures.Response
{
	public class GradeLecturesResponseDto
	{
		public List<JSonDto> Lectures { get; set; }
		public List<JSonDto> Grades { get; set; }

		public List<GradeLectureResponseDto> GradeLectures { get; set; } = new List<GradeLectureResponseDto>();
	}
}
