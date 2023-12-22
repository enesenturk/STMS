using NS.STMS.DTO;

namespace NS.STMS.Business.Lectures.Managers.Abstract
{
	public interface ILectureManager
	{

		#region Create

		#endregion

		#region Read

		JSonDto GetLecture(int lectureId);
		List<JSonDto> GetLectures();

		#endregion

		#region Update

		#endregion

		#region Delete

		#endregion

	}
}
