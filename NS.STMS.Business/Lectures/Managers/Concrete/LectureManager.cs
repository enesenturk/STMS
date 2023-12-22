using AutoMapper;
using NS.STMS.Business.Lectures.Managers.Abstract;
using NS.STMS.DAL.Lectures.Accessors.Abstract;
using NS.STMS.DTO;

namespace NS.STMS.Business.Lectures.Managers.Concrete
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

		public JSonDto GetLecture(int lectureId)
		{
			return _mapper.Map<JSonDto>(
				_lectureDal.Get(x => x.id == lectureId)
				);
		}

		public List<JSonDto> GetLectures()
		{
			return _mapper.Map<List<JSonDto>>(
				_lectureDal.GetList(
					x => x.name
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
