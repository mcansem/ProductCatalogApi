using ProductCatalogManagerAPI.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogManagerAPI.Application.Repository
{
    /// <summary>
    /// Read repository interface for product entity. Holds method definitions for read operations defined on IReadRepository
    /// </summary>
    /// <typeparam name="Product">Product entity</typeparam>
    public interface IProductReadRepository : IReadRepository<Product>
    {
    }
}