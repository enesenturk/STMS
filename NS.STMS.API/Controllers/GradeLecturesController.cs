using Microsoft.AspNetCore.Mvc;
using NS.STMS.API.Models;
using NS.STMS.Business.Modules.Lectures.Managers.Abstract;
using NS.STMS.DTO;
using NS.STMS.DTO.GradeLectures.Request;
using NS.STMS.DTO.GradeLectures.Response;
using NS.STMS.Entity.Context;

namespace NS.STMS.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GradeLecturesController : ControllerBase
	{

		#region CTOR

		private readonly IGradeManager _gradeManager;
		private readonly ILectureManager _lectureManager;
		private readonly IGradeLectureManager _gradeLectureManager;

		public GradeLecturesController(
			IGradeManager gradeManager,
			IGradeLectureManager gradeLectureManager,
			ILectureManager lectureManager
			)
		{
			_gradeManager = gradeManager;
			_lectureManager = lectureManager;
			_gradeLectureManager = gradeLectureManager;
		}

		#endregion

		#region Create

		[HttpPost]
		public OkObjectResult GradeLecture(CreateGradeLectureRequestDto requestDto)
		{
			_gradeLectureManager.CreateGradeLecture(requestDto);

			return Ok(new BaseResponseModel
			{
				Type = "S"
			});
		}

		#endregion

		#region Read

		[HttpGet]
		public OkObjectResult GradeLectures()
		{
			List<JSonDto> lectures = _lectureManager.GetLectures();
			List<JSonDto> grades = _gradeManager.GetGrades();
			List<t_grade_lecture> gradeLectures = _gradeLectureManager.GetGradeLectures();

			GradeLecturesResponseDto response = new GradeLecturesResponseDto();

			response.Grades = grades;
			response.Lectures = lectures;

			gradeLectures.ForEach(x =>
			{
				response.GradeLectures.Add(new GradeLectureResponseDto
				{
					GradeId = x.t_grade_id,
					LectureId = x.t_lecture_id
				});
			});

			return Ok(new BaseResponseModel
			{
				Type = "S",
				ResponseModel = response
			});
		}

		[HttpGet]
		[Route("{gradeId}")]
		public OkObjectResult GradeLectures(int gradeId)
		{
			List<JSonDto> response = _gradeLectureManager.GetGradeLectures(gradeId);

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
