﻿using AutoMapper;
using NS.STMS.DTO;
using NS.STMS.Entity.Context;

namespace NS.STMS.Business.Lecture.Mappings
{
	public class LectureProfile : Profile
	{
		public LectureProfile()
		{

			CreateMap<t_lecture, JSonDto>()
				.ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.id))
				.ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.name));

		}
	}
}
