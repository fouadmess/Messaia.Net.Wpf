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
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// PaginationEventArgs class.
    /// </summary>
    public class PaginationEventArgs<TEntity> : EventArgs where TEntity : class
    {
        /// <summary>
        /// Gets or sets the MyProperty
        /// </summary>
        public ICollection<TEntity> Items { get; set; }
    }
}