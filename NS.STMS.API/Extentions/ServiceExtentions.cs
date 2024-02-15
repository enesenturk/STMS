using AutoMapper;
using NS.STMS.Business.Lectures.Mappings;
using NS.STMS.Business.Modules.Authentication.Managers.Abstract;
using NS.STMS.Business.Modules.Authentication.Managers.Concrete;
using NS.STMS.Business.Modules.Lectures.Managers.Abstract;
using NS.STMS.Business.Modules.Lectures.Managers.Concrete;
using NS.STMS.Business.Modules.SystemTables.EntityPropertySettings;
using NS.STMS.Business.Modules.SystemTables.Managers.Abstract;
using NS.STMS.Business.Modules.SystemTables.Managers.Concrete;
using NS.STMS.Business.SystemTables.Mappings;
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
			services.AddSingleton<IPropertyDal, EfPropertyDal>();
			services.AddSingleton<IPropertyTypeDal, EfPropertyTypeDal>();

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
			services.AddSingleton<IGradeLectureManager, GradeLectureManager>();

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

		public static void RegisterEntityProperties(this IApplicationBuilder app)
		{
			IPropertyTypeDal propertyTypeDal = app.ApplicationServices.GetService<IPropertyTypeDal>();
			IPropertyDal propertyDal = app.ApplicationServices.GetService<IPropertyDal>();

			EntityPropertyHelper.SetEntityProperties(propertyTypeDal, propertyDal);
		}

	}
}
