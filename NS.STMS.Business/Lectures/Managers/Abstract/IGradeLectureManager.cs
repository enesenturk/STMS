using NS.STMS.DTO.GradeLecture.Request;
using NS.STMS.DTO;
using NS.STMS.Entity.Context;

namespace NS.STMS.Business.Lectures.Managers.Abstract
{
	public interface IGradeLectureManager
	{

		#region Create

		t_grade_lecture CreateGradeLecture(CreateGradeLectureRequestDto requestDto);

		#endregion

		#region Read

		List<t_grade_lecture> GetGradeLectures();
		List<JSonDto> GetGradeLectures(int gradeId);

		#endregion

		#region Update

		#endregion

		#region Delete

		#endregion

	}
}
