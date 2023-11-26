using AutoMapper;
using NS.STMS.Business.Lecture.Managers.Abstract;
using NS.STMS.DAL.Abstract.Lectures;
using NS.STMS.DTO;
using NS.STMS.Entity.Context;

namespace NS.STMS.Business.Lecture.Managers.Concrete
{
	public class GradeManager : IGradeManager
	{

		#region CTOR

		private int _id = 1;

		private readonly IGradeDal _gradeDal;
		private readonly IGradeLectureDal _gradeLectureDal;

		private readonly IMapper _mapper;

		public GradeManager(
			IGradeDal gradeDal,
			IGradeLectureDal gradeLectureDal,

			IMapper mapper
			)
		{
			_gradeDal = gradeDal;
			_gradeLectureDal = gradeLectureDal;

			_mapper = mapper;
		}

		#endregion

		#region Create

		public t_grade_lecture CreateGradeLecture(int gradeId, int lectureId)
		{
			return _gradeLectureDal.Add(new t_grade_lecture
			{
				t_grade_id = gradeId,
				t_lecture_id = lectureId
			}, _id);
		}

		#endregion

		#region Read

		public List<JSonDto> GetGradeLectures(int gradeId)
		{
			return _mapper.Map<List<JSonDto>>(
				_gradeLectureDal.GetListWithProperties(
					x => x.t_grade_id,
					new string[] { "t_lecture" },
					x => x.t_grade_id == gradeId
					)
				);
		}

		public List<JSonDto> GetGrades()
		{
			return _mapper.Map<List<JSonDto>>(
				 _gradeDal.GetList(x => x.id)
				);
		}

		#endregion

		#region Update

		#endregion

		#region Delete

		#endregion

	}
}
