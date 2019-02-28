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
    using System;
    using System.Windows.Controls;
    using System.Windows.Data;

    /// <summary>
    /// CaseConverter class.
    /// </summary>
    public class CaseConverter : IValueConverter
    {
        public CharacterCasing Case { get; set; }

        /// <summary>
        /// Initializes an instance of the <see cref="CaseConverter"/> class.
        /// </summary>        
        public CaseConverter()
        {
            this.Case = CharacterCasing.Upper;
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string str)
            {
                switch (Case)
                {
                    case CharacterCasing.Lower: return str.ToLower();
                    case CharacterCasing.Normal: return str;
                    case CharacterCasing.Upper: return str.ToUpper();
                    default: return str;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}