using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using System.Linq.Dynamic.Core;
using NS.STMS.Core.DataAccess;

namespace NS.STMS.Core.Extentions
{
	public static class IQueryableExtentions
	{

		public static IQueryable<T> IncludeProperties<T>(this IQueryable<T> query, string[] navProperties)
			where T : class
		{

			foreach (var navListProperty in navProperties)
				query = query.Include(navListProperty);

			return query;
		}

		public static IOrderedQueryable<T> OrderByConsideringNulls<T, TKey>(this IQueryable<T> source, Expression<Func<T, TKey>> keySelector)
			where T : class
		{
			MemberInfo filterMember = (keySelector.Body as MemberExpression).Member;
			string filterMemberName = filterMember.Name;

			if (filterMember.ReflectedType != typeof(T))
			{
				string expressionString = keySelector.ToString();
				filterMemberName = expressionString.Substring(expressionString.IndexOf('.') + 1);
			}

			string[] nullCheck = new string[] { null };
			return source.OrderBy($"{filterMemberName}== @0", nullCheck).ThenBy(keySelector);

		}

		public static IOrderedQueryable<T> OrderByDescendingConsideringNulls<T, TKey>(this IQueryable<T> source, Expression<Func<T, TKey>> keySelector)
			where T : class
		{
			MemberInfo filterMember = (keySelector.Body as MemberExpression).Member;
			string filterMemberName = filterMember.Name;

			if (filterMember.ReflectedType != typeof(T))
			{
				string expressionString = keySelector.ToString();
				filterMemberName = expressionString.Substring(expressionString.IndexOf('.') + 1);
			}

			string[] nullCheck = new string[] { null };
			return source.OrderBy($"{filterMemberName}== @0", nullCheck).ThenByDescending(keySelector);

		}

	}
}
