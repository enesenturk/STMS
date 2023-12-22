using AutoMapper;
using NS.STMS.Business.Authentication.Managers.Abstract;
using NS.STMS.Business.Authentication.Managers.Concrete;
using NS.STMS.Business.Lecture.Managers.Abstract;
using NS.STMS.Business.Lecture.Managers.Concrete;
using NS.STMS.Business.Lecture.Mappings;
using NS.STMS.Business.SystemTable.Managers.Abstract;
using NS.STMS.Business.SystemTable.Managers.Concrete;
using NS.STMS.Business.SystemTable.Mappings;
using NS.STMS.DAL.Authentication.Accessors.Abstract;
using NS.STMS.DAL.Authentication.Accessors.Concrete.EntityFramework;
using NS.STMS.DAL.Lectures.Accessors.Abstract;
using NS.STMS.DAL.Lectures.Accessors.Concrete.EntityFramework;
using NS.STMS.DAL.SystemTables.Accessors.Abstract;
using NS.STMS.DAL.SystemTables.Accessors.Concrete.EntityFramework;

namespace NS.STMS.API.Extentions
{
	public static class ServiceExtentions
	{

		public static void BindDataAccess(this IServiceCollection services)
		{

			#region Authentication

			services.AddSingleton<IUserDal, EfUserDal>();
			services.AddSingleton<IStudentDal, EfStudentDal>();

			#endregion

			#region Lecture

			services.AddSingleton<IGradeDal, EfGradeDal>();
			services.AddSingleton<IGradeLectureDal, EfGradeLectureDal>();
			services.AddSingleton<ILectureDal, EfLectureDal>();

			#endregion

			#region SystemTables

			services.AddSingleton<ICityDal, EfCityDal>();
			services.AddSingleton<ICountryDal, EfCountryDal>();
			services.AddSingleton<ICountyDal, EfCountyDal>();
			services.AddSingleton<IDifficultyLevelDal, EfDifficultyLevelDal>();

			#endregion

		}

		public static void BindManagers(this IServiceCollection services)
		{

			#region Authentication

			services.AddSingleton<IAuthenticationManager, AuthenticationManager>();
			services.AddSingleton<IStudentDal, EfStudentDal>();

			#endregion

			#region Lecture

			services.AddSingleton<ILectureManager, LectureManager>();
			services.AddSingleton<IGradeManager, GradeManager>();

			#endregion

			#region SystemTables

			services.AddSingleton<ISystemTableManager, SystemTableManager>();

			#endregion

		}

		public static void BindMapper(this IServiceCollection services)
		{
			// AutoMapper Configurations
			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new SystemTableProfile());
				mc.AddProfile(new GradeProfile());
				mc.AddProfile(new LectureProfile());
			});

			IMapper mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);

		}

	}
}
