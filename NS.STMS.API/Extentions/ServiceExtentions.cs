using AutoMapper;
using NS.STMS.Business.Lecture.Managers.Abstract;
using NS.STMS.Business.Lecture.Managers.Concrete;
using NS.STMS.Business.Lecture.Mappings;
using NS.STMS.Business.SystemTable.Managers.Abstract;
using NS.STMS.Business.SystemTable.Managers.Concrete;
using NS.STMS.Business.SystemTable.Mappings;
using NS.STMS.DAL.Abstract.Lectures;
using NS.STMS.DAL.Abstract.SystemTable;
using NS.STMS.DAL.Concrete.EntityFramework.Lecture;
using NS.STMS.DAL.Concrete.EntityFramework.SystemTable;

namespace NS.STMS.API.Extentions
{
	public static class ServiceExtentions
	{

		public static void BindDataAccess(this IServiceCollection services)
		{

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
