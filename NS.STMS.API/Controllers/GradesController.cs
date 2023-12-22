using Microsoft.AspNetCore.Mvc;
using NS.STMS.API.Models;
using NS.STMS.Business.Lecture.Managers.Abstract;
using NS.STMS.DTO;

namespace NS.STMS.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GradesController : ControllerBase
	{

		#region CTOR

		private readonly IGradeManager _gradeManager;

		public GradesController(IGradeManager gradeManager)
		{
			_gradeManager = gradeManager;
		}

		#endregion

		#region Create

		#endregion

		#region Read

		[HttpGet]
		public OkObjectResult Grades()
		{
			List<JSonDto> response = _gradeManager.GetGrades();

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
