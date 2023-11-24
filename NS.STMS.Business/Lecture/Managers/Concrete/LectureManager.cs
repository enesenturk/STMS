using AutoMapper;
using NS.STMS.Business.Lecture.Managers.Abstract;
using NS.STMS.DAL.Abstract.Lectures;
using NS.STMS.DTO;

namespace NS.STMS.Business.Lecture.Managers.Concrete
{
	public class LectureManager : ILectureManager
	{

		#region CTOR

		private readonly ILectureDal _lectureDal;

		private readonly IMapper _mapper;

		public LectureManager(
			ILectureDal lectureDal,

			IMapper mapper
			)
		{
			_lectureDal = lectureDal;
			_mapper = mapper;
		}

		#endregion

		#region Create

		#endregion

		#region Read

		public List<JSonDto> GetLectures(int gradeId)
		{
			return _mapper.Map<List<JSonDto>>(
				_lectureDal.GetList(
					x => x.name,
					x => x.t_grade_id == gradeId
					)
				);
		}

		#endregion

		#region Update

		#endregion

		#region Delete

		#endregion

	}
}
