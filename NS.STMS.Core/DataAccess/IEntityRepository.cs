using System.Linq.Expressions;

namespace NS.STMS.Core.DataAccess
{

	public interface IEntityRepository<TEntity> where TEntity : IEntity, new()
	{

		#region Create

		TEntity Add(TEntity entity, int createdBy);

		List<TEntity> AddRange(List<TEntity> entities, int createdBy);

		#endregion

		#region Read

		List<TEntity> GetList<T>(
			Expression<Func<TEntity, T>> OrderBy,
			Expression<Func<TEntity, bool>> filter = null);

		List<TEntity> GetListWithProperties<K>(
			Expression<Func<TEntity, K>> OrderBy,
			string[] navProperties,
			Expression<Func<TEntity, bool>> filter = null,
			bool orderByDesc = false);

		List<TEntity> GetListDistinct(Expression<Func<TEntity, bool>> filter = null);

		int GetCount(Expression<Func<TEntity, bool>> filter = null);

		TEntity Get(Expression<Func<TEntity, bool>> filter);

		TEntity GetWithProperties(Expression<Func<TEntity, bool>> filter, string[] navProperties);

		K Max<K>(Expression<Func<TEntity, K>> OrderBy, Expression<Func<TEntity, bool>> filter = null);

		#endregion

		#region Update

		TEntity Update(TEntity entity, int updatedBy);

		void UpdateOneField<K>(TEntity entity, Expression<Func<TEntity, K>> field, int updatedBy);

		void BulkUpdateForOneField<K>(List<TEntity> entities, Expression<Func<TEntity, K>> field, int updatedBy);

		void UpdateRange(List<TEntity> entities, int updatedBy);

		#endregion

		#region Delete

		void Delete(TEntity entity);

		void DeleteRange(List<TEntity> entities);

		#endregion

	}

}