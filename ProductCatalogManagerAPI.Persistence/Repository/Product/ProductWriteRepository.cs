using ProductCatalogManagerAPI.Application.Abstraction;
using ProductCatalogManagerAPI.Application.Repository;
using ProductCatalogManagerAPI.Domain.Entity;
using ProductCatalogManagerAPI.Persistence;
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
    /// Read repository interface for product entity. Holds method definitions for read operations defined on IWriteRepository
    /// </summary>
    /// <typeparam name="Product">Product entity</typeparam>
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        /// <summary>
        /// Constructor for ProductWriteRepository class
        /// </summary>
        /// <param name="context"></param>
        public ProductWriteRepository(BaseDbContext context) : base(context)
        {
        }
    }
}