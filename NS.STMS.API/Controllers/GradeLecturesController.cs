﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NS.STMS.API.Models;
using NS.STMS.API.Utility;
using NS.STMS.Business.Modules.Lectures.Managers.Abstract;
using NS.STMS.DTO;
using NS.STMS.DTO.GradeLectures;
using NS.STMS.DTO.GradeLectures.Request;
using NS.STMS.DTO.GradeLectures.Response;
using NS.STMS.Entity.Context;

namespace NS.STMS.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GradeLecturesController : CustomBaseController
	{

		#region CTOR

		private readonly IGradeManager _gradeManager;
		private readonly ILectureManager _lectureManager;
		private readonly IGradeLectureManager _gradeLectureManager;

		public GradeLecturesController(
			IGradeManager gradeManager,
			IGradeLectureManager gradeLectureManager,
			ILectureManager lectureManager,

			IMapper mapper) : base(mapper)
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
		[Route("{countryId}")]
		public OkObjectResult GradeLectures(int countryId)
		{
			List<JSonDto> lectures = _lectureManager.GetLectures(countryId);
			List<JSonDto> grades = _gradeManager.GetGrades();
			List<t_grade_lecture> gradeLectures = _gradeLectureManager.GetGradeLectures(countryId);

			GetGradeLecturesResponseDto model = new GetGradeLecturesResponseDto();

			model.Grades = grades;
			model.Lectures = lectures;

			gradeLectures.ForEach(x =>
			{
				model.GradeLectures.Add(new GradeLectureDto
				{
					GradeId = x.t_grade_id,
					LectureId = x.t_lecture_id
				});
			});

			return Ok(new BaseResponseModel
			{
				Type = "S",
				ResponseModel = model
			});
		}

		[HttpGet]
		[Route("{countryId}/{gradeId}")]
		public OkObjectResult GradeLectures(int gradeId, int countryId)
		{
			List<JSonDto> response = _gradeLectureManager.GetGradeLectures(countryId, gradeId);

			return Ok(new BaseResponseModel
			{
				Type = "S",
				ResponseModel = response
			});
		}

		[HttpGet]
		[Route("/api/GradesAndLectures/{countryId}")]
		public OkObjectResult GradesAndLectures(int countryId)
		{
			List<JSonDto> grades = _gradeManager.GetGrades();
			List<JSonDto> lectures = _lectureManager.GetLectures(countryId);

			GetGradesAndLecturesResponseDto model = new GetGradesAndLecturesResponseDto
			{
				Grades = grades,
				Lectures = lectures
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
