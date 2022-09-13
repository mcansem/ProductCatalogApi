using ProductCatalogManagerAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogManagerAPI.Domain.Entity.Common
{
    /// <summary>
    /// Generic base entity model for data models
    /// </summary>
    //[ExcludeFromCoverage]
    public class BaseEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Creation Date
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Modification date
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Rrecord status
        /// </summary>
        public DataStatus RecordStatus { get; set; }
    }
}