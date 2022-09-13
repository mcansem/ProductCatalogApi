using ProductCatalogManagerAPI.Domain.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogManagerAPI.Application.Repository
{
    /// <summary>
    /// Generic read repository interface. Holds method definitions for read operations
    /// </summary>
    /// <typeparam name="T">Generic T entity, based on BaseEntity class</typeparam>
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Gets all values
        /// </summary>
        /// <param name="tracking"> Entity tracking parameter</param>
        /// <returns>Returns related value</returns>
        IQueryable<T> GetAll(bool tracking = true);

        /// <summary>
        /// Gets values where expression is provided
        /// </summary>
        /// <param name="expression">Expression to filter values</param>
        /// <param name="tracking"> Entity tracking parameter</param>
        /// <returns>Returns related value</returns>
        IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool tracking = true);

        /// <summary>
        /// Gets single value where expression is provided
        /// </summary>
        /// <param name="expression">Expression to filter values</param>
        /// <param name="tracking">Entity tracking param</param>
        /// <returns>Returns related value</returns>
        Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool tracking = true);

        /// <summary>
        /// Gets value by its Id
        /// </summary>
        /// <param name="id"> Id for related value</param>
        /// <param name="tracking">Entity tracking parameter</param>
        /// <returns>Returns related value</returns>
        Task<T> GetByIdAsync(string id, bool tracking = true);
    }
}