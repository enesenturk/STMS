using NS.STMS.DTO;
using NS.STMS.DTO.GradeLecture.Request;
using NS.STMS.Entity.Context;

namespace NS.STMS.Business.Lecture.Managers.Abstract
{
	public interface IGradeManager
	{

		#region Create

		t_grade_lecture CreateGradeLecture(CreateGradeLectureRequestDto requestDto);

		#endregion

		#region Read

		List<t_grade_lecture> GetGradeLectures();
		List<JSonDto> GetGradeLectures(int gradeId);
		List<JSonDto> GetGrades();

		#endregion

		#region Update

		#endregion

		#region Delete

		#endregion

	}
}
