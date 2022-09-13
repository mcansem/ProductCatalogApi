using ProductCatalogManagerAPI.Domain.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProductCatalogManagerAPI.Domain.Entity
{
    /// <summary>
    /// Data model for products
    /// </summary>
    public class Product : BaseEntity
    {
        /// <summary>
        /// Product Code.
        /// Must be unique and can include only alphanumeric characters
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Product Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product Picture Url.
        /// Must be a valid url.
        /// </summary>
        public string Picture { get; set; }

        /// <summary>
        /// Product Price.
        /// can be in between 0.00 and 999.00
        /// </summary>
        public decimal Price { get; set; }
    }
}