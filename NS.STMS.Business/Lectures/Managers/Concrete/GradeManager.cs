using AutoMapper;
using NS.STMS.Business.Lectures.Managers.Abstract;
using NS.STMS.DAL.Lectures.Accessors.Abstract;
using NS.STMS.DTO;
using NS.STMS.DTO.GradeLecture.Request;
using NS.STMS.Entity.Context;

namespace NS.STMS.Business.Lectures.Managers.Concrete
{
	public class GradeManager : IGradeManager
	{

		#region CTOR

		private readonly IGradeDal _gradeDal;

		private readonly IMapper _mapper;

		public GradeManager(
			IGradeDal gradeDal,

			IMapper mapper
			)
		{
			_gradeDal = gradeDal;

			_mapper = mapper;
		}

		#endregion

		#region Create

		#endregion

		#region Read

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
