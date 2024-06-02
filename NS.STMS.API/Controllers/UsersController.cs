using Microsoft.AspNetCore.Mvc;
using NS.STMS.API.Models;
using NS.STMS.Business.Modules.Lectures.Managers.Abstract;
using NS.STMS.Business.Modules.SystemTables.Managers.Abstract;
using NS.STMS.Business.Modules.Users.Managers.Abstract;
using NS.STMS.DTO;
using NS.STMS.DTO.Users;
using NS.STMS.DTO.Users.Response;

namespace NS.STMS.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{

		#region CTOR

		private readonly IGradeManager _gradeManager;
		private readonly ISystemTableManager _systemTableManager;
		private readonly IUserManager _userManager;

		public UsersController(IGradeManager gradeManager, ISystemTableManager systemTableManager, IUserManager userManager)
		{
			_gradeManager = gradeManager;
			_systemTableManager = systemTableManager;
			_userManager = userManager;
		}

		#endregion

		#region Create

		#endregion

		#region Read

		[HttpGet]
		public OkObjectResult Users()
		{
			List<UserDto> response = _userManager.GetUsers();

			GetUsersResponseDto model = new GetUsersResponseDto
			{
				Users = response
			};

			return Ok(new BaseResponseModel
			{
				Type = "S",
				ResponseModel = model
			});
		}

		[HttpGet]
		[Route("/api/Users/AddUserOptions")]
		public OkObjectResult AddUserOptions()
		{
			List<JSonDto> countries = _systemTableManager.GetCountries();
			List<JSonDto> grades = _gradeManager.GetGrades();

			GetAddUserOptionsResponseDto model = new GetAddUserOptionsResponseDto
			{
				Countries = countries,
				Grades = grades
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
