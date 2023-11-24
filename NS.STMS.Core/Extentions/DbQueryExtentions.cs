using NS.STMS.Core.DataAccess;

namespace NS.STMS.Core.Extentions
{
	public static class DbQueryExtentions
	{

		public static IQueryable<T> DeletedFilter<T>(this IQueryable<T> source) where T : IEntity
		{
			return source.Where(x => x.is_deleted == false);
		}

	}
}
