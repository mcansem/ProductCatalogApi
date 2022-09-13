using Microsoft.EntityFrameworkCore;
using ProductCatalogManagerAPI.Domain.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogManagerAPI.Application.Repository
{
    /// <summary>
    /// Generic read repository interface. holds definition for DbSet<T> generic T entity
    /// </summary>
    /// <typeparam name="T">Generic T entity, based on BaseEntity class</typeparam>
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Dbset<T>, is used to query and save instances of TEntity.
        /// LINQ queries against a Microsoft.EntityFrameworkCore.DbSet`1 will be translated into queries against the database.
        /// </summary>
        DbSet<T> DbSet { get; }
    }
}