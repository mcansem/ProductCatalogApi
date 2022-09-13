using ProductCatalogManagerAPI.Application.Repository;
using ProductCatalogManagerAPI.Domain.Entity.Common;
using ProductCatalogManagerAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogManagerAPI.Persistence.Repository
{
    /// <summary>
    /// Generic read repository class. Holds method definitions for read operations
    /// </summary>
    /// <typeparam name="T">Generic T entity, based on BaseEntity class</typeparam>
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// BaseDbContext instance
        /// </summary>
        private readonly BaseDbContext _context;

        /// <summary>
        /// Constructor for ReadRepository class
        /// </summary>
        /// <param name="context"></param>
        public ReadRepository(BaseDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Dbset<T>, is used to query and save instances of TEntity.
        /// LINQ queries against a Microsoft.EntityFrameworkCore.DbSet`1 will be translated into queries against the database.
        /// </summary>
        public DbSet<T> DbSet => _context.Set<T>();

        /// <summary>
        /// Gets all values
        /// </summary>
        /// <param name="tracking"> Entity tracking parameter</param>
        /// <returns>Returns related value</returns>
        public IQueryable<T> GetAll(bool tracking = true)
        {
            IQueryable<T> query = DbSet.AsQueryable();
            if (!tracking == true)
                query = query.AsNoTracking();
            return query;
        }

        /// <summary>
        /// Gets values where expression is provided
        /// </summary>
        /// <param name="expression">Expression to filter values</param>
        /// <param name="tracking"> Entity tracking parameter</param>
        /// <returns>Returns related value</returns>
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            IQueryable<T> query = DbSet.Where(expression);
            if (!tracking == true)
                query = query.AsNoTracking();
            return query;
        }

        /// <summary>
        /// Gets single value where expression is provided
        /// </summary>
        /// <param name="expression">Expression to filter values</param>
        /// <param name="tracking">Entity tracking param</param>
        /// <returns>Returns related value</returns>
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            IQueryable<T> query = DbSet.AsQueryable();
            if (!tracking == true)
                query = query.AsNoTracking();
            return await query.SingleOrDefaultAsync(expression);
        }

        /// <summary>
        /// Gets value by its Id
        /// </summary>
        /// <param name="id"> Id for related value</param>
        /// <param name="tracking">Entity tracking parameter</param>
        /// <returns>Returns related value</returns>
        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            IQueryable<T> query = DbSet.AsQueryable();
            if (!tracking == true)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        }
    }
}