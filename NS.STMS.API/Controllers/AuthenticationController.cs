using Microsoft.AspNetCore.Mvc;
using NS.STMS.API.Models;
using NS.STMS.Business.Authentication.Managers.Abstract;
using NS.STMS.DTO.Authentication.Request;
using NS.STMS.DTO.Authentication.Response;

namespace NS.STMS.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{

		#region CTOR

		private readonly IAuthenticationManager _authenticationManager;

		public AuthenticationController(IAuthenticationManager authenticationManager)
		{
			_authenticationManager = authenticationManager;
		}

		#endregion

		#region Create

		[HttpPost]
		[Route("Register")]
		public OkObjectResult Register(CreateStudentRequestDto requestDto)
		{
			_authenticationManager.CreateStudent(requestDto);

			return Ok(new BaseResponseModel
			{
				Type = "S"
			});
		}

		#endregion

		#region Read

		[HttpPost]
		[Route("Login")]
		public OkObjectResult Login(LoginRequestDto requestDto)
		{
			LoginResponseDto response = _authenticationManager.Login(requestDto);

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
