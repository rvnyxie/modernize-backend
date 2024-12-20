﻿namespace Modernize.Application
{
    /// <summary>
    /// Product Group creation command
    /// </summary>
    public class CreateProductGroupCommand : ICommand<ProductGroupDto>
    {
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
