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
    using System.Collections;
    using System.Linq;

    /// <summary>
    /// IPagination class.
    /// </summary>
    public interface IPagination : IDisposable
    {
        #region Fields

        /// <summary>
        /// An event handler for loaded items
        /// </summary>
        event EventHandler ItemsLoaded;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Query
        /// </summary>
        IQueryable Query { get; set; }

        /// <summary>
        /// Gets or sets the Items
        /// </summary>
        ICollection Items { get; set; }

        /// <summary>
        /// Gets or sets the Page
        /// </summary>
        int Page { get; set; }

        /// <summary>
        /// Gets or sets the PageSize
        /// </summary>
        int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the Page
        /// </summary>
        int Total { get; set; }

        /// <summary>
        /// Gets or sets the Page
        /// </summary>
        int PageCount { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Navigates to first page
        /// </summary>
        void FirstPage();

        /// <summary>
        /// Navigates to previous page
        /// </summary>
        void PreviousPage();

        /// <summary>
        /// Navigates to next page
        /// </summary>
        void NextPage();

        /// <summary>
        /// Navigates to last page
        /// </summary>
        void LastPage();

        /// <summary>
        /// Reloads the data
        /// </summary>
        void Reload();

        /// <summary>
        /// Checks if the pagination has a previous page
        /// </summary>
        /// <returns></returns>
        bool HasPrevious();

        /// <summary>
        /// Checks if the pagination has a previous page
        /// </summary>
        /// <returns></returns>
        bool HasNext();

        #endregion
    }
}