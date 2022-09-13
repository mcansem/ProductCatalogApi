using ProductCatalogManagerAPI.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogManagerAPI.Application.Abstraction
{
    /// <summary>
    /// Product service interface
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets all values
        /// </summary>
        /// <param name="tracking"> Entity tracking parameter</param>
        /// <returns>Returns related value</returns>
        IQueryable<Product> GetAll(bool tracking = true);

        /// <summary>
        /// Gets values where expression is provided
        /// </summary>
        /// <param name="expression">Expression to filter values</param>
        /// <param name="tracking"> Entity tracking parameter</param>
        /// <returns>Returns related value</returns>
        IQueryable<Product> GetWhere(Expression<Func<Product, bool>> expression, bool tracking = true);

        /// <summary>
        /// Gets single value where expression is provided
        /// </summary>
        /// <param name="expression">Expression to filter values</param>
        /// <param name="tracking">Entity tracking param</param>
        /// <returns>Returns related value</returns>
        Task<Product> GetSingleAsync(Expression<Func<Product, bool>> expression, bool tracking = true);

        /// <summary>
        /// Gets value by its Id
        /// </summary>
        /// <param name="id"> Id for related value</param>
        /// <param name="tracking">Entity tracking parameter</param>
        /// <returns>Returns related value</returns>
        Task<Product> GetByIdAsync(string id, bool tracking = true);

        /// <summary>
        /// Adds value
        /// </summary>
        /// <param name="entity">Entity to be added</param>
        /// <returns>Returns result as true or false</returns>
        Task<bool> AddAsync(Product entity);

        /// <summary>
        /// Adds values as a list
        /// </summary>
        /// <param name="entity">Entity list to be added</param>
        /// <returns>Returns result as true or false</returns>
        Task<bool> AddRangeAsync(List<Product> entity);

        /// <summary>
        /// Removes value by its Id asynchronously
        /// </summary>
        /// <param name="id"> Id for related value</param>
        /// <returns>Returns result as true or false</returns>
        Task<bool> RemoveAsync(string id);

        /// <summary>
        /// Removes a value by its entity
        /// </summary>
        /// <param name="entity">Entity to be removed</param>
        /// <returns>Returns result as true or false</returns>
        bool Remove(Product entity);

        /// <summary>
        /// Updates a value
        /// </summary>
        /// <param name="entity"> Entity to be updated</param>
        /// <returns>Returns result as true or false</returns>
        bool Update(Product entity);

        /// <summary>
        /// Saves tracked data changes
        /// </summary>
        /// <returns>Returns count of saved changes</returns>
        Task<int> SaveAsync();

        /// <summary>
        /// Searches values
        /// </summary>
        /// <param name="query"> Query to be  searched</param>
        /// <param name="tracking">Entity tracking parameter</param>
        /// <returns>Returns related value</returns>
        public IQueryable<Product> Search(string query, bool tracking = true);
    }
}