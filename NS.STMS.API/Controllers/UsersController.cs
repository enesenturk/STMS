using Microsoft.AspNetCore.Mvc;
using NS.STMS.API.Models;
using NS.STMS.Business.Modules.Users.Managers.Abstract;
using NS.STMS.DTO.Users.Response;

namespace NS.STMS.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{

		#region CTOR

		private readonly IUserManager _userManager;

		public UsersController(IUserManager userManager)
		{
			_userManager = userManager;
		}

		#endregion

		#region Create

		#endregion

		#region Read

		[HttpGet]
		public OkObjectResult Users()
		{
			List<UserBaseResponseDto> response = _userManager.GetUsers();

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
