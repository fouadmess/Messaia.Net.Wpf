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
    using Messaia.Net.Wpf.Common;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// The Pagination class
    /// </summary>
    public class Pagination<TEntity> : NotifyPropertyChanged, IPagination<TEntity> where TEntity : class
    {
        #region Fields

        /// <summary>
        /// The number pf tecords per page
        /// </summary>
        private int pageSize = 20;

        /// <summary>
        /// The current page
        /// </summary>
        private int page = 1;

        /// <summary>
        /// The total records in the database
        /// </summary>
        private int total;

        /// <summary>
        /// The number of page found
        /// </summary>
        private int pageCount;

        /// <summary>
        /// The query to paginate
        /// </summary>
        private IQueryable<TEntity> query;

        /// <summary>
        /// The item list
        /// </summary>
        private ICollection<TEntity> items = new List<TEntity>();

        /// <summary>
        /// An event handler for loaded items
        /// </summary>
        public event EventHandler ItemsLoaded;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Items
        /// </summary>
        ICollection IPagination.Items { get; set; }

        /// <summary>
        /// Gets or sets the Query
        /// </summary>
        IQueryable IPagination.Query { get; set; }

        /// <summary>
        /// Gets or sets the Query
        /// </summary>
        public IQueryable<TEntity> Query
        {
            get => this.query;
            set
            {
                this.query = value;
                this.Page = 1;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the Items
        /// </summary>
        public ICollection<TEntity> Items
        {
            get => this.items;
            set
            {
                this.items = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the Page
        /// </summary>
        public int Page
        {
            get => this.page;
            set
            {
                this.page = Math.Max(1, value);
                this.Build();
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the PageSize
        /// </summary>
        public int PageSize
        {
            get => this.pageSize;
            set
            {
                this.pageSize = Math.Max(1, value);
                this.Build();
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the Total
        /// </summary>
        public int Total
        {
            get => this.total;
            set
            {
                this.total = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the PageCount
        /// </summary>
        public int PageCount
        {
            get => this.pageCount;
            set
            {
                this.pageCount = value;
                this.OnPropertyChanged();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Builds the pagination
        /// </summary>
        /// <param name="query"></param>
        public void Build()
        {
            Task.Run(async () =>
            {
                this.Total = await this.Query.CountAsync();
                this.PageCount = (int)Math.Ceiling(this.Total / (double)this.pageSize);

                /* Load the data asyncly. */
                return await this.Query
                    .Skip((this.Page - 1) * this.pageSize)
                    .Take(this.pageSize)
                    .ToListAsync();
            })
            .ContinueWith((t) =>
            {
                if (t.IsCompleted)
                {
                    /* Set the items */
                    this.Items = t.Result.ToObservableCollection();

                    /* Invoke the OnItemsLoaded event */
                    this.ItemsLoaded?.Invoke(this, new PaginationEventArgs<TEntity> { Items = this.Items });
                }
            });
        }

        /// <summary>
        /// Navigates to first page
        /// </summary>
        public void FirstPage()
        {
            if (this.Page > 1)
            {
                this.Page = 1;
            }
        }

        /// <summary>
        /// Navigates to previous page
        /// </summary>
        public void PreviousPage()
        {
            if (this.Page > 1)
            {
                this.Page--;
            }
        }

        /// <summary>
        /// Navigates to next page
        /// </summary>
        public void NextPage()
        {
            if (this.Page < this.PageCount)
            {
                this.Page++;
            }
        }

        /// <summary>
        /// Navigates to last page
        /// </summary>
        public void LastPage()
        {
            if (this.Page < this.PageCount)
            {
                this.Page = this.PageCount;
            }
        }

        /// <summary>
        /// Reloads the data
        /// </summary>
        public void Reload()
        {
            this.Page = this.Page;
        }

        /// <summary>
        /// Checks if the pagination has a previous page
        /// </summary>
        /// <returns></returns>
        public bool HasPrevious() => this.Page > 1;

        /// <summary>
        /// Checks if the pagination has a previous page
        /// </summary>
        /// <returns></returns>
        public bool HasNext() => this.Page < this.PageCount;

        /// <summary>
        /// Dispose() calls Dispose(true)
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The bulk of the clean-up code is implemented in Dispose(bool)
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            /* free managed resources */
            if (disposing)
            {
                this.items.Clear();
                this.items = null;
            }
        }

        #endregion

        #region Destructors

        /// <summary>
        /// Destructor
        /// </summary>
        ~Pagination()
        {
            /* Finalizer calls Dispose(false) */
            Dispose(false);
        }

        #endregion
    }
}