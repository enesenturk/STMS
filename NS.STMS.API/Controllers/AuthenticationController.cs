using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NS.STMS.API.Models;
using NS.STMS.API.Utility;
using NS.STMS.Business.Modules.Authentication.Managers.Abstract;
using NS.STMS.DTO.Authentication.Request;
using NS.STMS.DTO.Authentication.Response;
using System.Net;

namespace NS.STMS.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : CustomBaseController
	{

		#region CTOR

		private readonly IAuthenticationManager _authenticationManager;

		public AuthenticationController(IAuthenticationManager authenticationManager,

			IMapper mapper) : base(mapper)
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
		public ActionResult Login(LoginRequestDto requestDto)
		{
			TryLoginResponseDto response = _authenticationManager.Login(requestDto);

			if (response is null)
			{
				return StatusCode((int)HttpStatusCode.NotFound);
			}
			else if (response.IsBlocked)
			{
				return StatusCode((int)HttpStatusCode.Locked);
			}
			else if (!response.EmailVerified)
			{
				return StatusCode(212);
			}
			// successful login
			else
			{
				LoginResponseDto successfulLogin = _mapper.Map<LoginResponseDto>(response);

				BaseResponseModel responseModel = new BaseResponseModel
				{
					Type = "S",
					ResponseModel = successfulLogin
				};

				if (!response.AcceptedTerms)
				{
					return StatusCode((int)HttpStatusCode.Found, responseModel);
				}
				else if (response.NeedsChangePassword)
				{
					return StatusCode((int)HttpStatusCode.NonAuthoritativeInformation, responseModel);
				}
				else
				{
					return Ok(responseModel);
				}
			}
		}

		#endregion

		#region Update

		[HttpPut]
		[Route("AcceptTermsAndConditions")]
		public OkObjectResult AcceptTermsAndConditions(AcceptTermsAndConditionsRequestDto requestDto)
		{
			_authenticationManager.AcceptTermsAndConditions(requestDto);

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
