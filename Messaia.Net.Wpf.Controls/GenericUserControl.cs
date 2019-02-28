///-----------------------------------------------------------------
///   Author:         Fouad Messaia
///   AuthorUrl:      http://messaia.com
///   Date:           01.01.2016 23:16:08
///   Copyright (©)   2017, MESSAIA.NET, all Rights Reserved. 
///                   Licensed under the Apache License, Version 2.0. 
///                   See License.txt in the project root for license information.
///-----------------------------------------------------------------
namespace Messaia.Net.Wpf.Controls
{
    using Messaia.Net.Wpf.Model;
    using Messaia.Net.Wpf.ViewModel;
    using System;
    using System.Windows.Controls;

    /// <summary>
    /// GenericUserControl class.
    /// </summary>
    public partial class GenericUserControl<TEntity, TViewModel> : UserControl
        where TEntity : BaseEntity
        where TViewModel : GenericViewModel<TEntity>, new()
    {
        #region Fields


        #endregion

        #region Properties


        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an instance of the <see cref="BaseControl"/> class.
        /// </summary>
        public GenericUserControl()
        {
            /* Instanziate the view model */
            this.Loaded += (s, e) => { this.DataContext = new TViewModel(); };

            /* Clean-up  */
            this.Unloaded += (s, e) => this.CleanUp();
            this.Dispatcher.ShutdownStarted += (s, e) => this.CleanUp();
        }

        #endregion

        #region Methods

        /// <summary>
        /// A method to frees some resources
        /// </summary>
        protected void CleanUp()
        {
            /* Dispose the ViewModel */
            if (this.DataContext is IDisposable disposable)
            {
                disposable.Dispose();
                this.DataContext = null;
            }
        }

        #endregion
    }
}