using System.Linq.Expressions;

namespace NS.STMS.Core.DataAccess
{

	public interface IEntityRepository<TEntity> where TEntity : IEntity, new()
	{

		#region Create

		TEntity Add(TEntity entity);

		List<TEntity> AddRange(List<TEntity> entities);

		#endregion

		#region Read

		List<TEntity> GetList<T>(Expression<Func<TEntity, T>> OrderBy, Expression<Func<TEntity, bool>> filter = null);

		List<TEntity> GetListWithProperties<K>(Expression<Func<TEntity, K>> OrderBy,
			string[] navProperties,
			Expression<Func<TEntity, bool>> filter = null,
			bool orderByDesc = false);

		List<TEntity> GetListDistinct(Expression<Func<TEntity, bool>> filter = null);

		int GetCount(Expression<Func<TEntity, bool>> filter = null);

		TEntity Get(Expression<Func<TEntity, bool>> filter);

		TEntity GetWithProperties(Expression<Func<TEntity, bool>> filter, string[] navProperties);

		K Max<K>(Expression<Func<TEntity, K>> OrderBy, Expression<Func<TEntity, bool>> filter = null);

		bool IsUniqueEntity(Expression<Func<TEntity, bool>> filter);

		#endregion

		#region Update

		TEntity Update(TEntity entity);

		void UpdateOneField<K>(TEntity entity, Expression<Func<TEntity, K>> field);

		void BulkUpdateForOneField<K>(List<TEntity> entities, Expression<Func<TEntity, K>> field);

		void UpdateRange(List<TEntity> entities);

		#endregion

		#region Delete

		void Delete(TEntity entity);

		void DeleteRange(List<TEntity> entities);

		#endregion

	}

}