using Microsoft.AspNetCore.Mvc;
using NS.STMS.API.Models;
using NS.STMS.Business.Authentication.Managers.Abstract;
using NS.STMS.DTO.Authentication.Request;

namespace NS.STMS.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{

		#region CTOR

		private readonly IUserManager _userManager;

		public AuthenticationController(IUserManager userManager)
		{
			_userManager = userManager;
		}

		#endregion

		#region Create

		[HttpPost]
		public OkObjectResult Register(CreateStudentRequestDto requestDto)
		{
			_userManager.CreateStudent(requestDto);

			return Ok(new BaseResponseModel
			{
				Type = "S"
			});
		}

		#endregion

		#region Read

		#endregion

		#region Update

		#endregion

		#region Delete

		#endregion

	}

}
