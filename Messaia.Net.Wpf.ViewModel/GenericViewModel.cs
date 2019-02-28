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
    using Messaia.Net.Wpf.Common;
    using Messaia.Net.Wpf.Model;
    using System;
    using System.Windows.Controls;

    /// <summary>
    /// GenericViewModel class.
    /// </summary>
    public class GenericViewModel<TEntity> : NotifyPropertyChanged, IDisposable where TEntity : BaseEntity
    {
        #region Fields

        /// <summary>
        /// The control to display
        /// </summary>
        private Control control;

        /// <summary>
        /// Occurs when the view model get loaded
        /// </summary>
        public EventHandler Loaded;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Control
        /// </summary>
        public Control Control
        {
            get => this.control;
            set
            {
                this.control = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructors


        #endregion

        #region Methods

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
            if (disposing) { }
        }

        #endregion

        #region Destructors

        /// <summary>
        /// Destructor
        /// </summary>
        ~GenericViewModel()
        {
            /* Finalizer calls Dispose(false) */
            Dispose(false);
        }

        #endregion
    }
}