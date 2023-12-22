using NS.STMS.Business.Authorization.Managers.Abstract;
using NS.STMS.DAL.Abstract.Authorization;

namespace NS.STMS.Business.Authorization.Managers.Concrete
{
	public class UserManager : IUserManager
	{

		#region CTOR

		private readonly IUserDal _userDal;

		public UserManager(IUserDal userDal)
		{
			_userDal = userDal;
		}

		#endregion

		#region Create

		#endregion

		#region Read

		#endregion

		#region Update

		#endregion

		#region Delete

		#endregion

	}
}
