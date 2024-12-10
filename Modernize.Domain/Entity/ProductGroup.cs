using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modernize.Domain
{
    /// <summary>
    /// Product group entity
    /// </summary>
    public class ProductGroup : BaseEntity
    {
        /// <summary>
        /// Product group's ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product group's name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Product group's description
        /// </summary>
        public string? Description { get; set; }
    }
}
