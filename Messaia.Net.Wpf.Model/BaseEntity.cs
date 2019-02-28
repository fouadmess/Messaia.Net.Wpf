///-----------------------------------------------------------------
///   Author:         Fouad Messaia
///   AuthorUrl:      http://messaia.com
///   Date:           01.01.2016 23:16:08
///   Copyright (©)   2017, MESSAIA.NET, all Rights Reserved. 
///                   Licensed under the Apache License, Version 2.0. 
///                   See License.txt in the project root for license information.
///-----------------------------------------------------------------
namespace Messaia.Net.Wpf.Model
{
    using Messaia.Net.Wpf.Common;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// BaseEntity class.
    /// </summary>
    public class BaseEntity<TKey> : NotifyPropertyChanged, IEntity<TKey>
    {
        #region Fields

        /// <summary>
        /// The primary key of this entity
        /// </summary>
        private TKey id;

        /// <summary>
        /// A flag indicates whether an item is selected
        /// </summary>
        private bool isSelected;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public TKey Id
        {
            get => this.id;
            set
            {
                this.id = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the IsSelected
        /// </summary>
        [NotMapped]
        public virtual bool IsSelected
        {
            get => this.isSelected;
            set
            {
                this.isSelected = value;
                this.OnPropertyChanged();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Clones this object
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }
}