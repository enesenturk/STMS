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

		List<TEntity> GetList<K>(
					Expression<Func<TEntity, K>> orderBy,
					Expression<Func<TEntity, bool>> filter = null,
					string[] navProperties = null,
					bool orderByDesc = false,
					int skipCount = 0,
					int takeCount = -1);

		List<TEntity> GetListDistinct(Expression<Func<TEntity, bool>> filter = null);

		int GetCount(Expression<Func<TEntity, bool>> filter = null);

		TEntity Get(Expression<Func<TEntity, bool>> filter, string[] navProperties = null);

		TEntity GetLast<K>(Expression<Func<TEntity, K>> orderBy,
			Expression<Func<TEntity, bool>> filter = null,
			string[] navProperties = null,
			bool orderByDesc = false);

		K Max<K>(Expression<Func<TEntity, K>> orderBy, Expression<Func<TEntity, bool>> filter = null);

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