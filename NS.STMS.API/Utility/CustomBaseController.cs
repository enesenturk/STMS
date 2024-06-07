using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace NS.STMS.API.Utility
{
	public class CustomBaseController : ControllerBase
	{

		#region CTOR

		public readonly IMapper _mapper;

		public CustomBaseController(IMapper mapper)
		{
			_mapper = mapper;
		}

		#endregion

	}
}
