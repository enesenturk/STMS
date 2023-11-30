using Microsoft.AspNetCore.Mvc;
using NS.STMS.API.Models;
using NS.STMS.API.Models.GradeModels;
using NS.STMS.Business.Lecture.Managers.Abstract;
using NS.STMS.DTO;
using NS.STMS.DTO.GradeLecture;
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

        public GradeLecturesController(
            IGradeManager gradeManager,
            ILectureManager lectureManager
            )
        {
            _gradeManager = gradeManager;
            _lectureManager = lectureManager;
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
        public OkObjectResult GradeLectures()
        {
            List<JSonDto> lectures = _lectureManager.GetLectures();
            List<JSonDto> grades = _gradeManager.GetGrades();
            List<t_grade_lecture> gradeLectures = _gradeManager.GetGradeLectures();

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
