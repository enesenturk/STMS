using NS.STMS.DTO;
using NS.STMS.DTO.SystemTables.DifficultyLevel;
using NS.STMS.DTO.SystemTables.Language;

namespace NS.STMS.Business.Modules.SystemTables.Managers.Abstract
{
	public interface ISystemTableManager
	{

		#region Create

		void CreateLanguage(CreateLanguageRequestDto request);

		#endregion

		#region Read

		List<JSonDto> GetCities();
		List<JSonDto> GetCounties(int cityId);
		List<DifficultyLevelDto> GetDifficultyLevels();
		List<LanguageDto> GetLanguages();

		#endregion

		#region Update

		void UpdateLanguage(UpdateLanguageRequestDto request);

		#endregion

		#region Delete

		#endregion

	}
}
