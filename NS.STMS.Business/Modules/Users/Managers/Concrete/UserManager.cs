using AutoMapper;
using NS.STMS.Business.Modules.Users.Managers.Abstract;
using NS.STMS.DAL.Authentication.Accessors.Abstract;
using NS.STMS.DTO;
using NS.STMS.DTO.Users.Response;

namespace NS.STMS.Business.Modules.Users.Managers.Concrete
{
	public class UserManager : IUserManager
	{

		#region CTOR

		private readonly IUserDal _userDal;

		private readonly IMapper _mapper;

		public UserManager(
			IUserDal userDal,
			IMapper mapper
			)
		{
			_userDal = userDal;

			_mapper = mapper;
		}

		#endregion

		#region Create

		#endregion

		#region Read

		public List<UserBaseResponseDto> GetUsers()
		{
			return _mapper.Map<List<UserBaseResponseDto>>(
				_userDal.GetListWithProperties(
					x => x.name,
					new string[] { "t_property_id_user_typeNavigation" },
					filter: null
					));
		}

		#endregion

		#region Update

		#endregion

		#region Delete

		#endregion

	}
}
