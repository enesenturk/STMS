﻿using NS.STMS.DTO.GradeLectures.Request;
using NS.STMS.DTO;
using NS.STMS.Entity.Context;

namespace NS.STMS.Business.Modules.Lectures.Managers.Abstract
{
	public interface IGradeLectureManager
	{

		#region Create

		t_grade_lecture CreateGradeLecture(CreateGradeLectureRequestDto requestDto);

		#endregion

		#region Read

		List<t_grade_lecture> GetGradeLectures(int countryId);
		List<JSonDto> GetGradeLectures(int countryId, int gradeId);

		#endregion

		#region Update

		#endregion

		#region Delete

		#endregion

	}
}
