using Microsoft.AspNetCore.Mvc;
using NS.STMS.API.Models;
using NS.STMS.Business.Modules.SystemTables.Managers.Abstract;
using NS.STMS.DTO;
using NS.STMS.DTO.SystemTables.Address;
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
		[Route("/api/Cities/{countryId}")]
		public OkObjectResult Cities(int countryId)
		{
			List<JSonDto> response = _systemTableManager.GetCities(countryId);

			GetCitiesResponseDto model = new GetCitiesResponseDto
			{
				Cities = response
			};

			return Ok(new BaseResponseModel
			{
				Type = "S",
				ResponseModel = model
			});
		}

		[HttpGet]
		[Route("/api/Counties/{cityId}")]
		public OkObjectResult Counties(int cityId)
		{
			List<JSonDto> response = _systemTableManager.GetCounties(cityId);

			GetCountiesResponseDto model = new GetCountiesResponseDto
			{
				Counties = response
			};

			return Ok(new BaseResponseModel
			{
				Type = "S",
				ResponseModel = model
			});
		}

		[HttpGet]
		[Route("/api/DifficultyLevels")]
		public OkObjectResult DifficultyLevels()
		{
			List<DifficultyLevelDto> response = _systemTableManager.GetDifficultyLevels();

			GetDifficultyLevelsResponseDto model = new GetDifficultyLevelsResponseDto
			{
				DifficultyLevels = response
			};

			return Ok(new BaseResponseModel
			{
				Type = "S",
				ResponseModel = model
			});
		}

		#endregion

		#region Update

		#endregion

		#region Delete

		#endregion

	}
}