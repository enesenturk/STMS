using Microsoft.EntityFrameworkCore;
using NS.STMS.Core.Extentions;
using NS.STMS.Core.Helpers;
using System.Linq.Expressions;

namespace NS.STMS.Core.DataAccess.EntityFramework
{

	public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
			where TEntity : IEntity, new()
			where TContext : DbContext, new()
	{

		#region Create

		public TEntity Add(TEntity entity, int createdBy)
		{
			entity.created_at = DateTimeHelper.GetNow();
			entity.created_by = createdBy;

			using (var context = new TContext())
			{
				var addedEntity = context.Entry(entity);
				addedEntity.State = EntityState.Added;
				context.SaveChanges();
				return entity;
			}
		}

		public List<TEntity> AddRange(List<TEntity> entities, int createdBy)
		{
			int takeCount = 999;

			int counter = (entities.Count % takeCount) == 0
				? (entities.Count / takeCount)
				: (entities.Count / takeCount) + 1;

			entities.ForEach(e =>
			{
				e.created_at = DateTimeHelper.GetNow();
				e.created_by = createdBy;
			});

			for (int i = 0; i < counter; i++)
			{
				using (var context = new TContext())
				{
					List<TEntity> subList = entities.Skip(i * takeCount).Take(takeCount).ToList();

					context.ChangeTracker.AutoDetectChangesEnabled = false;

					context.Set<TEntity>().AddRange(subList);
					context.SaveChanges();
				}
			}

			return entities;
		}

		#endregion

		#region Read

		public List<TEntity> GetList<K>(
			Expression<Func<TEntity, K>> OrderBy,
			Expression<Func<TEntity, bool>> filter = null)
		{
			using (var context = new TContext())
			{
				return filter is null
				? context.Set<TEntity>().DeletedFilter().OrderByConsideringNulls(OrderBy).ToList()
				: context.Set<TEntity>().DeletedFilter().Where(filter).OrderByConsideringNulls(OrderBy).ToList();
			}
		}

		public List<TEntity> GetListWithProperties<K>(
			Expression<Func<TEntity, K>> OrderBy,
			string[] navProperties,
			Expression<Func<TEntity, bool>> filter = null,
			bool orderByDesc = false)
		{
			using (var context = new TContext())
			{
				var query = context.Set<TEntity>().DeletedFilter().IncludeProperties(navProperties);

				if (filter != null)
					query = query.Where(filter);

				if (orderByDesc)
					return query.OrderByDescending(OrderBy).ToList();
				else
					return query.OrderBy(OrderBy).ToList();
			}
		}

		public List<TEntity> GetListDistinct(Expression<Func<TEntity, bool>> filter = null)
		{
			using (var context = new TContext())
			{
				return filter is null
					? context.Set<TEntity>().DeletedFilter().Distinct().OrderBy(x => x.id).ToList()
					: context.Set<TEntity>().DeletedFilter().Where(filter).Distinct().OrderBy(x => x.id).ToList();
			}
		}

		public int GetCount(Expression<Func<TEntity, bool>> filter = null)
		{
			using (var context = new TContext())
			{
				return filter is null
					? context.Set<TEntity>().DeletedFilter().Count()
					: context.Set<TEntity>().DeletedFilter().Count(filter);
			}
		}

		public TEntity Get(Expression<Func<TEntity, bool>> filter)
		{
			using (var context = new TContext())
			{
				return context.Set<TEntity>().DeletedFilter().FirstOrDefault(filter);
			}
		}

		public TEntity GetWithProperties(Expression<Func<TEntity, bool>> filter, string[] navProperties)
		{
			using (var context = new TContext())
			{
				var query = context.Set<TEntity>().DeletedFilter().IncludeProperties(navProperties);
				return query.FirstOrDefault(filter);
			}
		}

		public K Max<K>(Expression<Func<TEntity, K>> OrderBy, Expression<Func<TEntity, bool>> filter = null)
		{
			using (var context = new TContext())
			{
				return filter is null
					? context.Set<TEntity>().DeletedFilter().Max(OrderBy)
					: context.Set<TEntity>().DeletedFilter().Where(filter).Max(OrderBy);
			}
		}

		#endregion

		#region Update

		public TEntity Update(TEntity entity, int updatedBy)
		{
			entity.created_at = DateTimeHelper.GetNow();
			entity.created_by = updatedBy;

			using (var context = new TContext())
			{
				var updatedEntity = context.Entry(entity);
				updatedEntity.State = EntityState.Modified;
				context.SaveChanges();
				return entity;
			}
		}

		public void UpdateOneField<K>(TEntity entity, Expression<Func<TEntity, K>> field, int updatedBy)
		{
			entity.created_at = DateTimeHelper.GetNow();
			entity.created_by = updatedBy;

			using (var context = new TContext())
			{
				context.Set<TEntity>().Attach(entity);
				context.Entry(entity).Property(field).IsModified = true;
				context.SaveChanges();
			}
		}

		public void BulkUpdateForOneField<K>(List<TEntity> entities, Expression<Func<TEntity, K>> field, int updatedBy)
		{
			entities.ForEach(e =>
			{
				e.created_at = DateTimeHelper.GetNow();
				e.created_by = updatedBy;
			});

			using (var context = new TContext())
			{
				try
				{
					//disable detection of changes to improve performance
					context.ChangeTracker.AutoDetectChangesEnabled = false;

					//for all the entities to update...
					foreach (TEntity entity in entities)
						context.Entry(entity).Property(field).IsModified = true;

					//then perform the update
					context.SaveChanges();
				}
				finally
				{
					//re-enable detection of changes
					context.ChangeTracker.AutoDetectChangesEnabled = true;
				}
			}
		}

		public void UpdateRange(List<TEntity> entities, int updatedBy)
		{
			entities.ForEach(e =>
			{
				e.created_at = DateTimeHelper.GetNow();
				e.created_by = updatedBy;
			});

			using (var context = new TContext())
			{
				try
				{
					//disable detection of changes to improve performance
					context.ChangeTracker.AutoDetectChangesEnabled = false;

					//for all the entities to update...
					foreach (TEntity entity in entities)
					{
						var updatedEntity = context.Entry(entity);
						updatedEntity.State = EntityState.Modified;
					}

					//then perform the update
					context.SaveChanges();
				}
				finally
				{
					//re-enable detection of changes
					context.ChangeTracker.AutoDetectChangesEnabled = true;
				}
			}
		}

		#endregion

		#region Delete

		public void Delete(TEntity entity)
		{
			using (var context = new TContext())
			{
				var deletedEntity = context.Entry(entity);
				deletedEntity.State = EntityState.Deleted;
				context.SaveChanges();
			}
		}

		public void DeleteRange(List<TEntity> entities)
		{
			using (var context = new TContext())
			{
				try
				{
					//disable detection of changes to improve performance
					context.ChangeTracker.AutoDetectChangesEnabled = false;

					//for all the entities to update...
					foreach (TEntity entity in entities)
					{
						var updatedEntity = context.Entry(entity);
						updatedEntity.State = EntityState.Deleted;
					}

					//then perform the update
					context.SaveChanges();
				}
				finally
				{
					//re-enable detection of changes
					context.ChangeTracker.AutoDetectChangesEnabled = true;
				}
			}
		}

		#endregion

	}

}