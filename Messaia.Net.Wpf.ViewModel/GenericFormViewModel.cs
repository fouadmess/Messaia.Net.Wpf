///-----------------------------------------------------------------
///   Author:         Fouad Messaia
///   AuthorUrl:      http://messaia.com
///   Date:           01.01.2016 23:16:08
///   Copyright (©)   2017, MESSAIA.NET, all Rights Reserved. 
///                   Licensed under the Apache License, Version 2.0. 
///                   See License.txt in the project root for license information.
///-----------------------------------------------------------------
namespace Messaia.Net.Wpf.ViewModel
{
    using Messaia.Net.Wpf.Model;
    using System.Data.Entity;

    /// <summary>
    /// GenericFormViewModel class.
    /// </summary>
    public class GenericFormViewModel<TEntity, TDbContext> : GenericViewModel<TEntity>
        where TEntity : BaseEntity, new()
        where TDbContext : DbContext, new()
    {
        #region Fields

        /// <summary>
        /// The mnodel to bind
        /// </summary>
        private TEntity entity = new TEntity();

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the DbContext
        /// </summary>
        public TDbContext DbContext { get; set; }

        /// <summary>
        /// Gets or sets the DbSet
        /// </summary>
        public DbSet<TEntity> DbSet { get => this.DbContext?.Set<TEntity>(); }

        /// <summary>
        /// Gets or sets the Entity
        /// </summary>
        public TEntity Entity
        {
            get => this.entity;
            set
            {
                this.entity = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}