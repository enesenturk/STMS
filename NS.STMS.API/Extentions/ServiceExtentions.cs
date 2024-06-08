using AutoMapper;
using NS.STMS.Business.Modules.Authentication.Extracteds;
using NS.STMS.Business.Modules.Authentication.Managers.Abstract;
using NS.STMS.Business.Modules.Authentication.Managers.Concrete;
using NS.STMS.Business.Modules.Authentication.Mappings;
using NS.STMS.Business.Modules.Authentication.Rules;
using NS.STMS.Business.Modules.Lectures.Managers.Abstract;
using NS.STMS.Business.Modules.Lectures.Managers.Concrete;
using NS.STMS.Business.Modules.Lectures.Mappings;
using NS.STMS.Business.Modules.SystemTables.EntityPropertySettings;
using NS.STMS.Business.Modules.SystemTables.Managers.Abstract;
using NS.STMS.Business.Modules.SystemTables.Managers.Concrete;
using NS.STMS.Business.Modules.SystemTables.Mappings;
using NS.STMS.Business.Modules.Users.Managers.Abstract;
using NS.STMS.Business.Modules.Users.Managers.Concrete;
using NS.STMS.Business.Modules.Users.Mappings;
using NS.STMS.Business.ServiceAdapters.Adapters.Abstract;
using NS.STMS.Business.ServiceAdapters.Adapters.Concrete.DotNetAdapters;
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

		public static void BindBusinessRules(this IServiceCollection services)
		{

			#region Authentication

			services.AddSingleton<AuthenticationRules>();

			#endregion

		}

		public static void BindDataAccess(this IServiceCollection services)
		{

			#region GradeLectures

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

			#region Users

			services.AddSingleton<IStudentDal, EfStudentDal>();
			services.AddSingleton<IUserDal, EfUserDal>();
			services.AddSingleton<IUserActivityHistory, EfUserActivityHistory>();
			services.AddSingleton<IUserLoginHistoryDal, EfUserLoginHistoryDal>();
			services.AddSingleton<IUserForgotPassword, EfUserForgotPassword>();

			#endregion

		}

		public static void BindExtracteds(this IServiceCollection services)
		{
			#region Authentication

			services.AddSingleton<AuthenticationExtracteds>();

			#endregion
		}

		public static void BindManagers(this IServiceCollection services)
		{

			#region Authentication

			services.AddSingleton<IAuthenticationManager, AuthenticationManager>();

			#endregion

			#region GradeLectures

			services.AddSingleton<ILectureManager, LectureManager>();
			services.AddSingleton<IGradeManager, GradeManager>();
			services.AddSingleton<IGradeLectureManager, GradeLectureManager>();

			#endregion

			#region SystemTables

			services.AddSingleton<ISystemTableManager, SystemTableManager>();

			#endregion

			#region Users

			services.AddSingleton<IStudentDal, EfStudentDal>();
			services.AddSingleton<IUserManager, UserManager>();

			#endregion

		}

		public static void BindMapper(this IServiceCollection services)
		{
			// AutoMapper Configurations
			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new AuthenticationProfile());
				mc.AddProfile(new GradeProfile());
				mc.AddProfile(new LectureProfile());
				mc.AddProfile(new SystemTableProfile());
				mc.AddProfile(new UserProfile());
			});

			IMapper mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);

		}

		public static void BindServiceAdapters(this IServiceCollection services)
		{

			services.AddSingleton<IEmailServiceAdapter, DotNetEmailServiceAdapter>();

		}

		public static void RegisterEntityProperties(this IApplicationBuilder app)
		{
			IPropertyTypeDal propertyTypeDal = app.ApplicationServices.GetService<IPropertyTypeDal>();
			IPropertyDal propertyDal = app.ApplicationServices.GetService<IPropertyDal>();

			EntityPropertyHelper.SetEntityProperties(propertyTypeDal, propertyDal);
		}

	}
}
