using ProductCatalogManagerAPI.Domain.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogManagerAPI.Application.Repository
{
    /// <summary>
    /// Generic write repository interface. Holds method definitions for write operations
    /// </summary>
    /// <typeparam name="T">Generic T entity, based on BaseEntity class</typeparam>
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Adds value
        /// </summary>
        /// <param name="entity">Entity to be added</param>
        /// <returns>Returns result as true or false</returns>
        Task<bool> AddAsync(T entity);

        /// <summary>
        /// Adds values as a list
        /// </summary>
        /// <param name="entity">Entity list to be added</param>
        /// <returns>Returns result as true or false</returns>
        Task<bool> AddRangeAsync(List<T> entity);

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
        bool Remove(T entity);

        /// <summary>
        /// Updates a value
        /// </summary>
        /// <param name="entity"> Entity to be updated</param>
        /// <returns>Returns result as true or false</returns>
        bool Update(T entity);

        /// <summary>
        /// Saves tracked data changes
        /// </summary>
        /// <returns>Returns count of saved changes</returns>
        Task<int> SaveAsync();
    }
}