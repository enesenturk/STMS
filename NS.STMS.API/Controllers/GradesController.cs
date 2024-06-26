﻿using AutoMapper;
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
	public class GradesController : CustomBaseController
	{

		#region CTOR

		private readonly IGradeManager _gradeManager;

		public GradesController(IGradeManager gradeManager,

			IMapper mapper) : base(mapper)
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

			GetGradesResponseDto model = new GetGradesResponseDto
			{
				Grades = response
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
