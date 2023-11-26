using NS.STMS.DTO;
using NS.STMS.Entity.Context;

namespace NS.STMS.Business.Lecture.Managers.Abstract
{
	public interface IGradeManager
	{

		#region Create

		t_grade_lecture CreateGradeLecture(int gradeId, int lectureId);

		#endregion

		#region Read

		List<JSonDto> GetGradeLectures(int gradeId);
		List<JSonDto> GetGrades();

		#endregion

		#region Update

		#endregion

		#region Delete

		#endregion

	}
}
