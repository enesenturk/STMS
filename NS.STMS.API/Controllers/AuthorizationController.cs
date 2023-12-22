using Microsoft.AspNetCore.Mvc;
using NS.STMS.API.Models;
using NS.STMS.Business.Authorization.Managers.Abstract;
using NS.STMS.Business.Lecture.Managers.Abstract;
using NS.STMS.Business.Lecture.Managers.Concrete;
using NS.STMS.DTO;

namespace NS.STMS.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorizationController : ControllerBase
	{

		#region CTOR

		private readonly IUserManager _userManager;

		public AuthorizationController(IUserManager userManager)
		{
			_userManager = userManager;
		}

		#endregion

		#region Create

		[HttpPost]
		public OkObjectResult Register()
		{
			_userManager.CreateStudent();

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
