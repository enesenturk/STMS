using AutoMapper;
using NS.STMS.DAL.Lectures.Accessors.Abstract;
using NS.STMS.DTO.GradeLecture.Request;
using NS.STMS.DTO;
using NS.STMS.Entity.Context;
using NS.STMS.Business.Modules.Lectures.Managers.Abstract;

namespace NS.STMS.Business.Modules.Lectures.Managers.Concrete
{
    public class GradeLectureManager : IGradeLectureManager
    {

        #region CTOR

        private int _id = 1;

        private readonly IGradeLectureDal _gradeLectureDal;

        private readonly IMapper _mapper;

        public GradeLectureManager(
            IGradeLectureDal gradeLectureDal,

            IMapper mapper
            )
        {
            _gradeLectureDal = gradeLectureDal;

            _mapper = mapper;
        }

        #endregion

        #region Create

        public t_grade_lecture CreateGradeLecture(CreateGradeLectureRequestDto requestDto)
        {
            return _gradeLectureDal.Add(new t_grade_lecture
            {
                t_grade_id = requestDto.GradeId,
                t_lecture_id = requestDto.LectureId
            }, _id);
        }

        #endregion

        #region Read

        public List<t_grade_lecture> GetGradeLectures()
        {
            return _gradeLectureDal.GetList(x => x.t_grade_id);
        }

        public List<JSonDto> GetGradeLectures(int gradeId)
        {
            return _mapper.Map<List<JSonDto>>(
                _gradeLectureDal.GetListWithProperties(
                    x => x.t_grade_id,
                    new string[] { "t_lecture" },
                    x => x.t_grade_id == gradeId
                    )
                );
        }

        #endregion

        #region Update

        #endregion

        #region Delete

        #endregion

    }
}
