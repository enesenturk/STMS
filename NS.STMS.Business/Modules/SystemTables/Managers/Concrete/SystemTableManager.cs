using AutoMapper;
using NS.STMS.Business.Modules.SystemTables.Managers.Abstract;
using NS.STMS.DAL.SystemTables.Accessors.Abstract;
using NS.STMS.DTO;
using NS.STMS.DTO.SystemTables.DifficultyLevel;

namespace NS.STMS.Business.Modules.SystemTables.Managers.Concrete
{
	public class SystemTableManager : ISystemTableManager
	{

		#region CTOR

		private readonly ICityDal _cityDal;
		private readonly ICountryDal _countryDal;
		private readonly ICountyDal _countyDal;
		private readonly IDifficultyLevelDal _difficultyLevelDal;

		private readonly IMapper _mapper;

		public SystemTableManager(
			ICityDal cityDal,
			ICountryDal countryDal,
			ICountyDal countyDal,
			IDifficultyLevelDal difficultyLevelDal,

			IMapper mapper
			)
		{
			_cityDal = cityDal;
			_countryDal = countryDal;
			_countyDal = countyDal;
			_difficultyLevelDal = difficultyLevelDal;

			_mapper = mapper;
		}

		#endregion

		#region Create

		#endregion

		#region Read

		public List<JSonDto> GetCountries()
		{
			return _mapper.Map<List<JSonDto>>(
				 _countryDal.GetList(x => x.name)
				 );
		}

		public List<JSonDto> GetCities(int countryId)
		{
			return _mapper.Map<List<JSonDto>>(
				 _cityDal.GetList(x => x.name, x => x.t_country_id == countryId)
				 );
		}

		public List<JSonDto> GetCounties(int cityId)
		{
			return _mapper.Map<List<JSonDto>>(
				 _countyDal.GetList(
					 x => x.name,
					 x => x.t_city_id == cityId
					 )
				 );
		}

		public List<DifficultyLevelDto> GetDifficultyLevels()
		{
			return _mapper.Map<List<DifficultyLevelDto>>(
				 _difficultyLevelDal.GetList(x => x.id)
				 );
		}

		#endregion

		#region Update

		#endregion

		#region Delete

		#endregion

	}
}
