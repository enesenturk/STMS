using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NS.STMS.API.Models;
using NS.STMS.API.Utility;
using NS.STMS.Business.Modules.Lectures.Managers.Abstract;
using NS.STMS.DTO;
using NS.STMS.DTO.GradeLectures.Response;

namespace NS.STMS.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LecturesController : CustomBaseController
	{

		#region CTOR

		private readonly ILectureManager _lectureManager;

		public LecturesController(ILectureManager lectureManager,

			IMapper mapper) : base(mapper)
		{
			_lectureManager = lectureManager;
		}

		#endregion

		#region Create

		#endregion

		#region Read

		[HttpGet]
		[Route("{countryId}")]
		public OkObjectResult Lectures(int countryId)
		{
			List<JSonDto> response = _lectureManager.GetLectures(countryId);

			GetLecturesResponseDto model = new GetLecturesResponseDto
			{
				Lectures = response
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
