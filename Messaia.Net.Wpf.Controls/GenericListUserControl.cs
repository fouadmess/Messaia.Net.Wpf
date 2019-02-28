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
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// GenericListUserControl class.
    /// </summary>
    public partial class GenericListUserControl<TEntity, TViewModel> : GenericUserControl<TEntity, TViewModel>
        where TEntity : BaseEntity
        where TViewModel : GenericViewModel<TEntity>, new()
    {
        #region Fields

        /// <summary>
        /// Register a dependency property with the specified property name, property type, and owner type.
        /// </summary>
        public static readonly DependencyProperty AddItemProperty = DependencyProperty.Register(nameof(AddItem), typeof(ICommand), typeof(GenericListUserControl<TEntity, TViewModel>), new UIPropertyMetadata(null));

        #endregion

        #region Properties

        /// <summary>
        /// A command to add new item
        /// </summary>
        public ICommand AddItem
        {
            get { return (ICommand)GetValue(AddItemProperty); }
            set { SetValue(AddItemProperty, value); }
        }

        #endregion
    }
}