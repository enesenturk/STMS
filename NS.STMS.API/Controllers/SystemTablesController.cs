using Microsoft.AspNetCore.Mvc;
using NS.STMS.API.Models;
using NS.STMS.Business.Modules.SystemTables.Managers.Abstract;
using NS.STMS.DTO;
using NS.STMS.DTO.SystemTables.Address;
using NS.STMS.DTO.SystemTables.DifficultyLevel;
using NS.STMS.DTO.SystemTables.Language;

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

		[HttpPost]
		[Route("/api/Language")]
		public OkObjectResult Languages(CreateLanguageRequestDto request)
		{
			_systemTableManager.CreateLanguage(request);

			return Ok(new BaseResponseModel
			{
				Type = "S"
			});
		}

		#endregion

		#region Read

		[HttpGet]
		[Route("/api/Cities")]
		public OkObjectResult Cities()
		{
			List<JSonDto> response = _systemTableManager.GetCities();

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

		[HttpGet]
		[Route("/api/Languages")]
		public OkObjectResult Languages()
		{
			List<LanguageDto> response = _systemTableManager.GetLanguages();

			GetLanguagesResponseDto model = new GetLanguagesResponseDto
			{
				Languages = response
			};

			return Ok(new BaseResponseModel
			{
				Type = "S",
				ResponseModel = model
			});
		}

		#endregion

		#region Update

		[HttpPut]
		[Route("/api/Language")]
		public OkObjectResult Languages(UpdateLanguageRequestDto request)
		{
			_systemTableManager.UpdateLanguage(request);

			return Ok(new BaseResponseModel
			{
				Type = "S"
			});
		}

		#endregion

		#region Delete

		#endregion

	}
}