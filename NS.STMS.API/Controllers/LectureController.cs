using Microsoft.AspNetCore.Mvc;
using NS.STMS.API.Models;
using NS.STMS.Business.Lecture.Managers.Abstract;
using NS.STMS.DTO;

namespace NS.STMS.API.Controllers
{
	[ApiController]
	public class LectureController : ControllerBase
	{

		#region CTOR

		private readonly ILogger<LectureController> _logger;

		private readonly ILectureManager _lectureManager;
		private readonly IGradeManager _gradeManager;

		public LectureController(
			ILogger<LectureController> logger,

			ILectureManager lectureManager,
			IGradeManager gradeManager
			)
		{
			_logger = logger;

			_lectureManager = lectureManager;
			_gradeManager = gradeManager;
		}

		#endregion

		#region Create

		#endregion

		#region Read

		[HttpGet]
		[Route("/api/grades")]
		public OkObjectResult Grades()
		{
			List<JSonDto> response = _gradeManager.GetGrades();

			return Ok(new BaseResponseModel
			{
				Type = "S",
				ResponseModel = response
			});
		}

		[HttpGet]
		[Route("/api/lectures/{gradeId}")]
		public OkObjectResult Lectures(int gradeId)
		{
			List<JSonDto> response = _lectureManager.GetLectures(gradeId);

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
