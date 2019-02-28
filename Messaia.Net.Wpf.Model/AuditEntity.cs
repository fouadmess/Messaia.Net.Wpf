///-----------------------------------------------------------------
///   Author:         Fouad Messaia
///   AuthorUrl:      http://messaia.com
///   Date:           01.01.2016
///   Copyright (©)   2016, MESSAIA.NET, all Rights Reserved. 
///                   Licensed under the Apache License, Version 2.0. 
///                   See License.txt in the project root for license information.
///-----------------------------------------------------------------
namespace Messaia.Net.Wpf.Model
{
    using System;

    /// <summary>
    /// AuditEntity class.
    /// </summary>
    /// <typeparam name="TKey">The primary key type</typeparam>
    public class AuditEntity<TKey> : BaseEntity<TKey>, IAuditEntity
    {
        #region Fields

        /// <summary>
        /// The user who creates this entity
        /// </summary>
        private string createdBy;

        /// <summary>
        /// The creation date of this enity
        /// </summary>
        private DateTime createdDate;

        /// <summary>
        /// The user who creates this entity
        /// </summary>
        private string updatedBy;

        /// <summary>
        /// The update date of this enity
        /// </summary>
        private DateTime? updatedDate;

        #endregion

        /// <summary>
        /// Gets or sets the CreatedBy
        /// </summary>
        public string CreatedBy
        {
            get => this.createdBy;
            set
            {
                this.createdBy = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the CreatedDate
        /// </summary>
        public DateTime CreatedDate
        {
            get => this.createdDate;
            set
            {
                this.createdDate = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the UpdatedBy
        /// </summary>
        public string UpdatedBy
        {
            get => this.updatedBy;
            set
            {
                this.updatedBy = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the UpdatedDate
        /// </summary>
        public DateTime? UpdatedDate
        {
            get => this.updatedDate;
            set
            {
                this.updatedDate = value;
                this.OnPropertyChanged();
            }
        }
    }
}