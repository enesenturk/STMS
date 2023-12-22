using Microsoft.AspNetCore.Mvc;
using NS.STMS.API.Models;
using NS.STMS.Business.SystemTables.Managers.Abstract;
using NS.STMS.DTO;
using NS.STMS.DTO.SystemTables.DifficultyLevel;

namespace NS.STMS.API.Controllers
{
	[ApiController]
	public class SystemTablesController : ControllerBase
	{

		#region CTOR

		private readonly ISystemTableManager _systemTableManager;

		public SystemTablesController(ISystemTableManager systemTableManager)
		{
			_systemTableManager = systemTableManager;
		}

		#endregion

		#region Create

		#endregion

		#region Read

		[HttpGet]
		[Route("/api/DifficultyLevels")]
		public OkObjectResult DifficultyLevels()
		{
			List<DifficultyLevelResponseDto> response = _systemTableManager.GetDifficultyLevels();

			return Ok(new BaseResponseModel
			{
				Type = "S",
				ResponseModel = response
			});
		}

		[HttpGet]
		[Route("/api/Cities")]
		public OkObjectResult Cities()
		{
			List<JSonDto> response = _systemTableManager.GetCities();

			return Ok(new BaseResponseModel
			{
				Type = "S",
				ResponseModel = response
			});
		}

		[HttpGet]
		[Route("/api/Counties/{cityId}")]
		public OkObjectResult Counties(int cityId)
		{
			List<JSonDto> response = _systemTableManager.GetCounties(cityId);

			return Ok(new BaseResponseModel
			{
				Type = "S",
				ResponseModel = response
			});
		}

		#endregion

		#region Update

		#endregion

		#region Delete

		#endregion

	}
}