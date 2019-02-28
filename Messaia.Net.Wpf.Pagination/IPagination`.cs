///-----------------------------------------------------------------
///   Author:         Fouad Messaia
///   AuthorUrl:      http://messaia.com
///   Date:           01.01.2016 23:16:08
///   Copyright (©)   2017, MESSAIA.NET, all Rights Reserved. 
///                   Licensed under the Apache License, Version 2.0. 
///                   See License.txt in the project root for license information.
///-----------------------------------------------------------------
namespace Messaia.Net.Wpf.Pagination
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// IPagination class.
    /// </summary>
    public interface IPagination<TEntity> : IPagination where TEntity : class
    {
        /// <summary>
        /// Gets or sets the Query
        /// </summary>
        new IQueryable<TEntity> Query { get; set; }

        /// <summary>
        /// Gets or sets the Items
        /// </summary>
        new ICollection<TEntity> Items { get; set; }
    }
}