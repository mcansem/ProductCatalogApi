using ProductCatalogManagerAPI.Application.Repository;
using ProductCatalogManagerAPI.Domain.Entity.Common;
using ProductCatalogManagerAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace ProductCatalogManagerAPI.Persistence.Repository
{
    /// <summary>
    /// Generic write repository class. Holds method definitions for write operations
    /// </summary>
    /// <typeparam name="T">Generic T entity, based on BaseEntity class</typeparam>
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// BaseDbContext instance
        /// </summary>
        private readonly BaseDbContext _context;

        /// <summary>
        /// Constructor for WriteRepository class
        /// </summary>
        /// <param name="context"></param>
        public WriteRepository(BaseDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Dbset<T>, is used to query and save instances of TEntity.
        /// LINQ queries against a Microsoft.EntityFrameworkCore.DbSet`1 will be translated into queries against the database.
        /// </summary>
        public DbSet<T> DbSet => _context.Set<T>();

        /// <summary>
        /// Adds value
        /// </summary>
        /// <param name="entity">Entity to be added</param>
        /// <returns>Returns result as true or false</returns>
        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry = await DbSet.AddAsync(entity);
            int isSaved = await SaveAsync();
            return (isSaved > 0);
        }

        /// <summary>
        /// Adds values as a list
        /// </summary>
        /// <param name="entity">Entity list to be added</param>
        /// <returns>Returns result as true or false</returns>
        public async Task<bool> AddRangeAsync(List<T> entity)
        {
            try
            {
                await _context.AddRangeAsync(entity);
                int isSaved = await SaveAsync();
                return isSaved > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Removes value by its Id asynchronously
        /// </summary>
        /// <param name="id"> Id for related value</param>
        /// <returns>Returns result as true or false</returns>
        public async Task<bool> RemoveAsync(string id)
        {
            T model = await DbSet.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            return Remove(model);
        }

        /// <summary>
        /// Removes a value by its entity
        /// </summary>
        /// <param name="entity">Entity to be removed</param>
        /// <returns>Returns result as true or false</returns>
        public bool Remove(T entity)
        {
            EntityEntry<T> entityEntry = DbSet.Remove(entity);
            int isSaved = SaveAsync().GetAwaiter().GetResult();
            return isSaved > 0;
        }

        /// <summary>
        /// Updates a value
        /// </summary>
        /// <param name="entity"> Entity to be updated</param>
        /// <returns>Returns result as true or false</returns>
        public bool Update(T entity)
        {
            try
            {
                var query = DbSet.AsQueryable().AsNoTracking();
                var oldEntity = query.FirstOrDefault(x => x.Id == entity.Id);
                entity.CreatedAt = oldEntity.CreatedAt;
                entity.UpdatedAt = oldEntity.UpdatedAt;
                entity.RecordStatus = oldEntity.RecordStatus;
                EntityEntry<T> entityEntry = DbSet.Update(entity);
                int isSaved = SaveAsync().GetAwaiter().GetResult();
                return isSaved > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Saves tracked data changes
        /// </summary>
        /// <returns>Returns count of saved changes</returns>
        public async Task<int> SaveAsync()
           => await _context.SaveChangesAsync();
    }
}