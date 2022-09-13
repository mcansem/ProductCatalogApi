using ProductCatalogManagerAPI.Application.Abstraction;
using ProductCatalogManagerAPI.Application.Repository;
using ProductCatalogManagerAPI.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogManagerAPI.Persistence.Concrete
{
    /// <summary>
    /// Product service class
    /// </summary>
    public class ProductService : IProductService
    {
        /// <summary>
        /// IProductReadRepository interface instance
        /// </summary>
        private readonly IProductReadRepository _productReadRepository;

        /// <summary>
        /// IProductWriteRepository interface instance
        /// </summary>
        private readonly IProductWriteRepository _productWriteRepository;

        /// <summary>
        /// Constructor for ProductService class
        /// </summary>
        /// <param name="productReadRepository">IProductReadRepository interface instance</param>
        /// <param name="productWriteRepository">IProductWriteRepository interface instance</param>
        public ProductService(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        /// <summary>
        /// Gets all values
        /// </summary>
        /// <param name="tracking"> Entity tracking parameter</param>
        /// <returns>Returns related value</returns>
        public IQueryable<Product> GetAll(bool tracking)
        {
            return _productReadRepository.GetAll(tracking);
        }

        /// <summary>
        /// Gets values where expression is provided
        /// </summary>
        /// <param name="expression">Expression to filter values</param>
        /// <param name="tracking"> Entity tracking parameter</param>
        /// <returns>Returns related value</returns>
        public IQueryable<Product> GetWhere(Expression<Func<Product, bool>> expression, bool tracking)
        {
            return _productReadRepository.GetWhere(expression, tracking);
        }

        /// <summary>
        /// Gets single value where expression is provided
        /// </summary>
        /// <param name="expression">Expression to filter values</param>
        /// <param name="tracking">Entity tracking param</param>
        /// <returns>Returns related value</returns>
        public Task<Product> GetSingleAsync(Expression<Func<Product, bool>> expression, bool tracking)
        {
            return _productReadRepository.GetSingleAsync(expression, tracking);
        }

        /// <summary>
        /// Gets value by its Id
        /// </summary>
        /// <param name="id"> Id for related value</param>
        /// <param name="tracking">Entity tracking parameter</param>
        /// <returns>Returns related value</returns>
        public Task<Product> GetByIdAsync(string id, bool tracking)
        {
            return _productReadRepository.GetByIdAsync(id, tracking);
        }

        /// <summary>
        /// Adds value
        /// </summary>
        /// <param name="entity">Entity to be added</param>
        /// <returns>Returns result as true or false</returns>
        public Task<bool> AddAsync(Product entity)
        {
            return _productWriteRepository.AddAsync(entity);
        }

        /// <summary>
        /// Adds values as a list
        /// </summary>
        /// <param name="entity">Entity list to be added</param>
        /// <returns>Returns result as true or false</returns>
        public Task<bool> AddRangeAsync(List<Product> entity)
        {
            return _productWriteRepository.AddRangeAsync(entity);
        }

        /// <summary>
        /// Removes value by its Id asynchronously
        /// </summary>
        /// <param name="id"> Id for related value</param>
        /// <returns>Returns result as true or false</returns>
        public Task<bool> RemoveAsync(string id)
        {
            return _productWriteRepository.RemoveAsync(id);
        }

        public bool Remove(Product entity)
        {
            return _productWriteRepository.Remove(entity);
        }

        /// <summary>
        /// Updates a value
        /// </summary>
        /// <param name="entity"> Entity to be updated</param>
        /// <returns>Returns result as true or false</returns>
        public bool Update(Product entity)
        {
            return _productWriteRepository.Update(entity);
        }

        /// <summary>
        /// Saves tracked data changes
        /// </summary>
        /// <returns>Returns count of saved changes</returns>
        public Task<int> SaveAsync()
        {
            return _productWriteRepository.SaveAsync();
        }

        /// <summary>
        /// Searches values
        /// </summary>
        /// <param name="query"> Query to be  searched</param>
        /// <param name="tracking">Entity tracking parameter</param>
        /// <returns>Returns related value</returns>
        public IQueryable<Product> Search(string query, bool tracking)
        {
            return GetWhere(x =>
            x.Name.ToLower().Contains(query.ToLower()) || x.Code.ToLower().Contains(query.ToLower()), tracking);
        }
    }
}