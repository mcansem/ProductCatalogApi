using ProductCatalogManagerAPI.Application.Abstraction;
using ProductCatalogManagerAPI.Application.Repository;
using ProductCatalogManagerAPI.Domain.Entity;
using ProductCatalogManagerAPI.Persistence.Context;
using ProductCatalogManagerAPI.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogManagerAPI.Persistence.Repository
{
    /// <summary>
    /// Read repository class for product entity. Holds method definitions for read operations defined on IReadRepository
    /// </summary>
    /// <typeparam name="Product">Product entity</typeparam>
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        /// <summary>
        /// Constructor for ProductReadRepository class
        /// </summary>
        /// <param name="context"></param>
        public ProductReadRepository(BaseDbContext context) : base(context)
        {
        }
    }
}