using Microsoft.AspNetCore.Mvc;
using NS.STMS.API.Models;
using NS.STMS.Business.Modules.Lectures.Managers.Abstract;
using NS.STMS.DTO;
using NS.STMS.DTO.GradeLectures.Response;

namespace NS.STMS.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LecturesController : ControllerBase
	{

		#region CTOR

		private readonly ILogger<LecturesController> _logger;

		private readonly ILectureManager _lectureManager;

		public LecturesController(
			ILogger<LecturesController> logger,

			ILectureManager lectureManager
			)
		{
			_logger = logger;

			_lectureManager = lectureManager;
		}

		#endregion

		#region Create

		#endregion

		#region Read

		[HttpGet]
		public OkObjectResult Lectures()
		{
			List<JSonDto> response = _lectureManager.GetLectures();

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

		[HttpGet]
		[Route("{lectureId}")]
		public OkObjectResult Lectures(int lectureId)
		{
			JSonDto response = _lectureManager.GetLecture(lectureId);

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
