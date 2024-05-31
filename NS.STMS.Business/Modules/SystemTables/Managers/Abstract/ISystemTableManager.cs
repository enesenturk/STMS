using NS.STMS.DTO;
using NS.STMS.DTO.SystemTables.DifficultyLevel;

namespace NS.STMS.Business.Modules.SystemTables.Managers.Abstract
{
	public interface ISystemTableManager
	{

		#region Read

		List<JSonDto> GetCities();
		List<JSonDto> GetCounties(int cityId);
		List<DifficultyLevelDto> GetDifficultyLevels();

		#endregion

		#region Delete

		#endregion

	}
}
