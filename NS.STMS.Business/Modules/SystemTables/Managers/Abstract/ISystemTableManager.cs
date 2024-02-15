using NS.STMS.DTO;
using NS.STMS.DTO.SystemTables.DifficultyLevel;

namespace NS.STMS.Business.Modules.SystemTables.Managers.Abstract
{
    public interface ISystemTableManager
    {

        #region Create

        #endregion

        #region Read

        List<DifficultyLevelResponseDto> GetDifficultyLevels();
        List<JSonDto> GetCities();
        List<JSonDto> GetCounties(int cityId);

        #endregion

        #region Update

        #endregion

        #region Delete

        #endregion

    }
}
