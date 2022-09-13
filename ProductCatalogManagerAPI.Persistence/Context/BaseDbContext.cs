using ProductCatalogManagerAPI.Domain.Entity;
using ProductCatalogManagerAPI.Domain.Entity.Common;
using ProductCatalogManagerAPI.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogManagerAPI.Persistence.Context
{
    /// <summary>
    /// BaseDbContext class
    /// </summary>
    public class BaseDbContext : DbContext
    {
        /// <summary>
        /// BaseDbContext constructor
        /// </summary>
        /// <param name="options"></param>
        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Dbset<Product> instance
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Override method for DbContext.OnmodelCreating method
        /// </summary>
        /// <see cref="DbContext.OnModelCreating(ModelBuilder)"/>
        /// <param name="modelBuilder">Model builder parameter</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Code).IsUnique();
                entity.Property(x => x.Name).IsRequired().HasMaxLength(150);
                entity.Property(x => x.Price).IsRequired().HasColumnType("decimal(5,2");
                entity.Property(x => x.CreatedAt).IsRequired().HasColumnType("datetime");
                entity.Property(x => x.UpdatedAt).IsRequired().HasColumnType("datetime");
            }
                );
        }

        /// <summary>
        /// Override method for DbContext.SaveChangesAsync method
        /// </summary>
        /// <see cref="DbContext.SaveChangesAsync(CancellationToken)"/>
        /// <param name="cancellationToken">Cancellation token parameter</param>
        /// <returns></returns>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<EntityEntry<BaseEntity>> datas = ChangeTracker.Entries<BaseEntity>();

            foreach (EntityEntry<BaseEntity> data in datas)
            {
                switch (data.State)
                {
                    case EntityState.Added:
                        {
                            data.Entity.CreatedAt = DateTime.Now;
                            data.Entity.UpdatedAt = DateTime.Now;
                            data.Entity.RecordStatus = DataStatus.Inserted;
                            break;
                        }
                    case EntityState.Modified:
                        {
                            data.Entity.UpdatedAt = DateTime.Now;
                            data.Entity.RecordStatus = DataStatus.Updated;
                            break;
                        }
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}