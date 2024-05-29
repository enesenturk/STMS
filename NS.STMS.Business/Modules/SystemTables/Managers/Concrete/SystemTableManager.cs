using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NS.STMS.Business.Modules.SystemTables.Managers.Abstract;
using NS.STMS.Business.Modules.SystemTables.Rules;
using NS.STMS.Business.Modules.SystemTables.Validations.FluentValidation;
using NS.STMS.Core.Aspects.Postsharp;
using NS.STMS.DAL.SystemTables.Accessors.Abstract;
using NS.STMS.DAL.SystemTables.Accessors.Concrete.EntityFramework;
using NS.STMS.DTO;
using NS.STMS.DTO.SystemTables.DifficultyLevel;
using NS.STMS.DTO.SystemTables.Language;
using NS.STMS.Entity.Context;
using System.Security.Cryptography;

namespace NS.STMS.Business.Modules.SystemTables.Managers.Concrete
{
	public class SystemTableManager : ISystemTableManager
	{

		#region CTOR

		private readonly LanguageBusinessRules _languageBusinessRules;

		private readonly ICityDal _cityDal;
		private readonly ICountyDal _countyDal;
		private readonly IDifficultyLevelDal _difficultyLevelDal;
		private readonly ILanguageDal _languageDal;

		private readonly IMapper _mapper;

		public SystemTableManager(
			LanguageBusinessRules languageBusinessRules,

			ICityDal cityDal,
			ICountyDal countyDal,
			IDifficultyLevelDal difficultyLevelDal,
			ILanguageDal languageDal,

			IMapper mapper
			)
		{
			_languageBusinessRules = languageBusinessRules;

			_cityDal = cityDal;
			_countyDal = countyDal;
			_difficultyLevelDal = difficultyLevelDal;
			_languageDal = languageDal;

			_mapper = mapper;
		}

		#endregion

		#region Create

		[FluentValidationAspect(typeof(CreateLanguageValidator))]
		public void CreateLanguage(CreateLanguageRequestDto request)
		{
			_languageBusinessRules.LanguageKeyCanNotBeDuplicated(request.LanguageKey);

			// TODO: role check
			_languageDal.Add(new t_language
			{
				language_key = request.LanguageKey,
				tr_TR = request.trTR,
				en_US = request.enUS
			}, request.UserId);
		}

		#endregion

		#region Read

		public List<JSonDto> GetCities()
		{
			return _mapper.Map<List<JSonDto>>(
				 _cityDal.GetList(x => x.name)
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

		public List<LanguageDto> GetLanguages()
		{
			return _mapper.Map<List<LanguageDto>>(
				 _languageDal.GetList(x => x.id)
				 );
		}

		#endregion

		#region Update

		[FluentValidationAspect(typeof(UpdateLanguageValidator))]
		public void UpdateLanguage(UpdateLanguageRequestDto request)
		{
			// TODO: role check
			t_language language = _languageDal.Get(x => x.language_key == request.LanguageKey);

			language.tr_TR = request.trTR;
			language.en_US = request.enUS;

			_languageDal.Update(language, request.UserId);
		}

		#endregion

		#region Delete

		#endregion

	}
}
