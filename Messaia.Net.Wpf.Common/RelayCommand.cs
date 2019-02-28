///-----------------------------------------------------------------
///   Author:         Fouad Messaia
///   AuthorUrl:      http://messaia.com
///   Date:           01.01.2016 23:16:08
///   Copyright (©)   2017, MESSAIA.NET, all Rights Reserved. 
///                   Licensed under the Apache License, Version 2.0. 
///                   See License.txt in the project root for license information.
///-----------------------------------------------------------------
namespace Messaia.Net.Wpf.Common
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// The RelayCommand Class
    /// </summary>
    public class RelayCommand<T> : ICommand where T : class
    {
        #region Fields

        /// <summary>
        /// A pointer to a method that can be executed.
        /// </summary>
        readonly Action<T> execute;

        /// <summary>
        /// A delegate to the method, it returns a boolean indicate whether the method can be executed.
        /// </summary>
        readonly Predicate<object> canExecute;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new command that can always execute.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public RelayCommand(Action<T> execute) : this(execute, null) { }

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<T> execute, Predicate<object> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException("execute");
            this.canExecute = canExecute;
        }

        #endregion

        #region ICommand Members
        /// <summary>
        /// Check whether the method can be executed
        /// </summary>
        /// <param name="parameter">The parameters to the predicate</param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute(parameter);
        }

        /// <summary>
        /// The CanExecuteChanged evenet handler
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Execute the method
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            execute((T)parameter);
        }

        #endregion
    }

    /// <summary>
    /// The RelayCommand Class
    /// </summary>
    public class RelayCommand : RelayCommand<object>
    {
        /// <summary>
        /// Create a new command that can always execute.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public RelayCommand(Action<object> execute) : base(execute, null) { }

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute) : base(execute, canExecute) { }
    }
}