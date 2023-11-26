using Microsoft.AspNetCore.Mvc;
using NS.STMS.API.Models;
using NS.STMS.API.Models.GradeModels;
using NS.STMS.Business.Lecture.Managers.Abstract;
using NS.STMS.DTO;

namespace NS.STMS.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GradeLecturesController : ControllerBase
	{

		#region CTOR

		private readonly IGradeManager _gradeManager;

		public GradeLecturesController(IGradeManager gradeManager)
		{
			_gradeManager = gradeManager;
		}

		#endregion

		#region Create

		[HttpPost]
		public OkObjectResult GradeLecture(GradeLectureRequestModel model)
		{
			_gradeManager.CreateGradeLecture(model.GradeId, model.LectureId);

			return Ok(new BaseResponseModel
			{
				Type = "S"
			});
		}

		#endregion

		#region Read

		[HttpGet]
		[Route("{gradeId}")]
		public OkObjectResult GradeLectures(int gradeId)
		{
			List<JSonDto> response = _gradeManager.GetGradeLectures(gradeId);

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
