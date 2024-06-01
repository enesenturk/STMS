using AutoMapper;
using NS.STMS.Business.Modules.Lectures.Managers.Abstract;
using NS.STMS.DAL.Lectures.Accessors.Abstract;
using NS.STMS.DTO;

namespace NS.STMS.Business.Modules.Lectures.Managers.Concrete
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

		public List<JSonDto> GetLectures(int countryId)
		{
			return _mapper.Map<List<JSonDto>>(
				_lectureDal.GetList(x => x.language_key, x => x.t_country_id == countryId)
				);
		}

		#endregion

		#region Update

		#endregion

		#region Delete

		#endregion

	}
}
