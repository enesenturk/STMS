using AutoMapper;
using NS.STMS.Business.Modules.SystemTables.EntityPropertySettings.Data.EntityProperties;
using NS.STMS.Business.Modules.Users.Managers.Abstract;
using NS.STMS.Core.Aspects.Postsharp;
using NS.STMS.Core.Helpers;
using NS.STMS.DAL.Authentication.Accessors.Abstract;
using NS.STMS.DTO.Users;
using NS.STMS.DTO.Users.Request;
using NS.STMS.Entity.Context;
using NS.STMS.Resources.Security.Encryption;
using NS.STMS.Settings;

namespace NS.STMS.Business.Modules.Users.Managers.Concrete
{
	public class UserManager : IUserManager
	{

		#region CTOR

		// TODO:
		private int _id = 1;
		private readonly IStudentDal _studentDal;
		private readonly IUserDal _userDal;

		private readonly IMapper _mapper;

		public UserManager(
			IStudentDal studentDal,
			IUserDal userDal,

			IMapper mapper
			)
		{
			_studentDal = studentDal;
			_userDal = userDal;

			_mapper = mapper;
		}

		#endregion

		#region Create

		[TransactionalOperationAspect]
		public void CreateUser(CreateUserRequestDto requestDto)
		{
			string passwordDecrypted = EncryptionHelper.Decrypt(requestDto.Password, AppSettings.EncryptionKey);

			string hash = PasswordHasher.HashPasword(passwordDecrypted, out var salt);

			t_user user = _userDal.Add(new t_user
			{
				email = requestDto.Email,
				password = hash,
				password_salt = salt,
				name = requestDto.Name,
				surname = requestDto.Surname,
				date_of_birth = DateOnly.FromDateTime(requestDto.DateOfBirth),
				t_county_id = requestDto.CountyId,
				t_property_id_user_type = UserTypes.Student
			}, _id);

			_studentDal.Add(new t_student
			{
				t_user_id = user.id,
				t_grade_id = requestDto.GradeId,
				school_name = requestDto.SchoolName,
			}, _id);

		}

		#endregion

		#region Read

		public List<UserDto> GetUsers()
		{
			return _mapper.Map<List<UserDto>>(
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
