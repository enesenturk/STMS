namespace NS.STMS.DTO.GradeLectures.Response
{
    public class GetGradeLecturesResponseDto
	{
		public List<JSonDto> Lectures { get; set; }
		public List<JSonDto> Grades { get; set; }

		public List<GradeLectureDto> GradeLectures { get; set; } = new List<GradeLectureDto>();
	}
}
