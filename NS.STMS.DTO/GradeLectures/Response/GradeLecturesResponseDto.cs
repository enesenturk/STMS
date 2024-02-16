namespace NS.STMS.DTO.GradeLectures.Response
{
	public class GradeLecturesResponseDto
	{
		public List<JSonDto> lectures { get; set; }
		public List<JSonDto> grades { get; set; }

		public List<GradeLectureResponseDto> gradeLectures { get; set; } = new List<GradeLectureResponseDto>();
	}
}
