///-----------------------------------------------------------------
///   Author:         Fouad Messaia
///   AuthorUrl:      http://messaia.com
///   Date:           01.01.2016 23:16:08
///   Copyright (©)   2017, MESSAIA.NET, all Rights Reserved. 
///                   Licensed under the Apache License, Version 2.0. 
///                   See License.txt in the project root for license information.
///-----------------------------------------------------------------
namespace SchoolManagementSystem.ViewModels
{
    using Messaia.Net.Wpf.Common;
    using Messaia.Net.Wpf.Model;
    using Messaia.Net.Wpf.Pagination;
    using Messaia.Net.Wpf.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// GenericListViewModel class.
    /// </summary>
    public class GenericListViewModel<TEntity, TDbContext, TCreateControl, TUpdateControl> : GenericViewModel<TEntity>
        where TEntity : BaseEntity, new()
        where TDbContext : DbContext, new()
        where TCreateControl : Control, new()
        where TUpdateControl : Control, new()
    {
        #region Fields

        /// <summary>
        /// The selected item in the grid
        /// </summary>
        private TEntity selectedItem;

        /// <summary>
        /// A flag indicating whether all items are selected
        /// </summary>
        private bool? isAllSelected = false;

        /// <summary>
        /// A flag indicating whether all items beeing selected
        /// </summary>
        private bool allSelectedChanging;

        /// <summary>
        /// Database instance
        /// </summary>
        protected readonly TDbContext dbContext = new TDbContext();

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the DbSet
        /// </summary>
        protected DbSet<TEntity> DbSet { get; }

        /// <summary>
        /// Gets or sets the PageSizes
        /// </summary>
        public virtual ICollection<int> PageSizes { get; set; } = new int[] { 10, 15, 20, 30, 50, 100 };

        /// <summary>
        /// Gets or sets the Pagination
        /// </summary>
        public virtual IPagination<TEntity> Pagination { get; set; } = new Pagination<TEntity>();

        /// <summary>
        /// Gets or sets the SelectedItem
        /// </summary>
        public virtual TEntity SelectedItem
        {
            get => this.selectedItem;
            set
            {
                this.selectedItem = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the IsAllSelected
        /// </summary>
        public virtual bool? IsAllSelected
        {
            get => this.isAllSelected;
            set
            {
                if (value != this.isAllSelected)
                {
                    /* Set the flag */
                    this.isAllSelected = value;

                    /* Return if this change has been caused by some other change */
                    if (!this.allSelectedChanging)
                    {
                        this.allSelectedChanging = true;

                        /* Select/unselect all items */
                        this.Pagination?.Items?.All(x => { x.IsSelected = value.GetValueOrDefault(); return true; });

                        this.allSelectedChanging = false;
                    }

                    /* Fire property changed event */
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the CreateItemCommand
        /// </summary>     
        public virtual ICommand CreateItemCommand { get; set; }

        /// <summary>
        /// Gets or sets the UpdateItemCommand
        /// </summary>     
        public virtual ICommand UpdateItemCommand { get; set; }

        /// <summary>
        /// Gets or sets the DeleteItemCommand
        /// </summary>     
        public virtual ICommand DeleteItemCommand { get; set; }

        /// <summary>
        /// Gets or sets the DeleteSelectedCommand
        /// </summary>     
        public virtual ICommand DeleteSelectedCommand { get; set; }

        /// <summary>
        /// Gets or sets the FirstPageCommand
        /// </summary>     
        public virtual ICommand FirstPageCommand { get; set; }

        /// <summary>
        /// Gets or sets the PreviousPageCommand
        /// </summary>     
        public virtual ICommand PreviousPageCommand { get; set; }

        /// <summary>
        /// Gets or sets the NextPageCommand
        /// </summary>     
        public virtual ICommand NextPageCommand { get; set; }

        /// <summary>
        /// Gets or sets the LastPageCommand
        /// </summary>     
        public virtual ICommand LastPageCommand { get; set; }

        /// <summary>
        /// Gets or sets the ReloadCommand
        /// </summary>     
        public virtual ICommand ReloadCommand { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an instance of the <see cref="BaseViewModel<>"/> class.
        /// </summary>
        public GenericListViewModel()
        {
            /* Set dbSet object */
            this.DbSet = this.dbContext.Set<TEntity>();

            /* Make sure to listen to changes */
            this.Pagination.ItemsLoaded += (s, e) =>
            {
                (e as PaginationEventArgs<TEntity>).Items.All(x => { x.PropertyChanged += this.OnEntityPropertyChanged; return true; });
            };

            /* Set the query in the pagination */
            this.Pagination.Query = this.GetQuery();

            /* A command to add a new item */
            this.CreateItemCommand = new RelayCommand(async _ =>
            {
                /* Create the control */
                var control = new TCreateControl();

                /* Set some properties */
                if (control.DataContext is GenericFormViewModel<TEntity, TDbContext> viewModel)
                {
                    viewModel.DbContext = this.dbContext;
                    viewModel.Loaded?.Invoke(viewModel, EventArgs.Empty);
                    await this.OpenCreateControlAsync(control);
                }
            });

            /* A command to update an existing item */
            this.UpdateItemCommand = new RelayCommand(async entity =>
            {
                /* Create the control */
                var control = new TUpdateControl();

                /* Set some properties */
                if (control.DataContext is GenericFormViewModel<TEntity, TDbContext> viewModel)
                {
                    viewModel.DbContext = this.dbContext;
                    viewModel.Entity = entity as TEntity;
                    viewModel.Loaded?.Invoke(viewModel, EventArgs.Empty);
                    await this.OpenUpdateControlAsync(control);
                }
            });

            /* A command to delete an item */
            this.DeleteItemCommand = new RelayCommand(async param => await this.DeleteItemAsync(param), _ => this.SelectedItem != null);

            /* A command to delete selected items */
            this.DeleteSelectedCommand = new RelayCommand(async param => await this.DeleteSelectedAsync(param), _ => this.Pagination?.Items?.Any(x => x.IsSelected) == true);

            /* A command to navigate to the first page */
            this.FirstPageCommand = new RelayCommand(_ => this.Pagination.FirstPage(), _ => this.Pagination.HasPrevious());

            /* A command to navigate to the previous page, if any */
            this.PreviousPageCommand = new RelayCommand(_ => this.Pagination.PreviousPage(), _ => this.Pagination.HasPrevious());

            /* A command to navigate to the next page, if any */
            this.NextPageCommand = new RelayCommand(_ => this.Pagination.NextPage(), _ => this.Pagination.HasNext());

            /* A command to navigate to the last page */
            this.LastPageCommand = new RelayCommand(_ => this.Pagination.LastPage(), _ => this.Pagination.HasNext());

            /* A command to reload the items */
            this.ReloadCommand = new RelayCommand(_ => this.Pagination.Reload(), _ => true);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get the base query
        /// </summary>
        /// <returns></returns>
        protected virtual IQueryable<TEntity> GetQuery() => dbContext.Set<TEntity>().OrderBy(x => x.Id);

        /// <summary>
        /// Opens a user control to create a new item
        /// </summary>
        /// <param name="control">The control to open</param>
        protected virtual async Task OpenCreateControlAsync(TCreateControl control) { await Task.CompletedTask; }

        /// <summary>
        /// Opens a user control to update an item
        /// </summary>
        /// <param name="control">The control to open</param>
        protected virtual async Task OpenUpdateControlAsync(TUpdateControl control) { await Task.CompletedTask; }

        /// <summary>
        /// Saves the enitity in the database
        /// </summary>
        /// <param name="entity">The entity to save</param>
        /// <returns></returns>
        protected virtual Task<int> CreateItemAsync(TEntity entity)
        {
            this.DbSet.Add(entity);
            return this.dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Updates the enitity in the database
        /// </summary>
        /// <param name="entity">The entity to update</param>
        /// <returns></returns>
        protected virtual Task<int> UpdateItemAsync(TEntity entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            return this.dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes an item
        /// </summary>
        /// <param name="param"></param>
        protected virtual async Task<int> DeleteItemAsync(object param)
        {
            if (this.SelectedItem != null)
            {
                /* Delete the item */
                this.DbSet.Remove(this.SelectedItem);
                var result = await this.dbContext.SaveChangesAsync();
                if (result > 0)
                {
                    this.Pagination.Page = 1;
                    this.IsAllSelected = false;
                }

                return result;
            }

            return 0;
        }

        /// <summary>
        /// Deletes the selected items
        /// </summary>
        /// <param name="param"></param>
        protected virtual async Task<int> DeleteSelectedAsync(object param)
        {
            /* Get selected items IDs */
            var selectedItems = this.Pagination?.Items?.Where(x => x.IsSelected).ToList();

            /* Delete the items */
            this.DbSet.RemoveRange(selectedItems);
            var result = await this.dbContext.SaveChangesAsync();
            if (result > 0)
            {
                this.Pagination.Page = 1;
                this.IsAllSelected = false;
            }

            return result;
        }

        /// <summary>
        /// Listens for entity's property changes
        /// </summary>
        /// <param name="propertyname"></param>
        protected virtual void OnEntityPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            /* 
             Only re-check if the IsSelected property changed and this change has not 
             been caused by some other change 
             */
            if (args.PropertyName == nameof(BaseEntity.IsSelected) && !allSelectedChanging)
            {
                this.allSelectedChanging = true;

                if (this.Pagination?.Items?.All(e => e.IsSelected) == true)
                {
                    this.IsAllSelected = true;
                }
                else if (this.Pagination?.Items?.All(e => !e.IsSelected) == true)
                {
                    this.IsAllSelected = false;
                }
                else
                {
                    this.IsAllSelected = null;
                }

                this.allSelectedChanging = false;
            }
        }

        /// <summary>
        /// The bulk of the clean-up code is implemented in Dispose(bool)
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            /* free managed resources */
            if (disposing)
            {
                this.Pagination.Dispose();
                this.dbContext.Dispose();
            }
        }

        #endregion
    }
}