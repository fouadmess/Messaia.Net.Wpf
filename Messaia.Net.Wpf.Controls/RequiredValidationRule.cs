///-----------------------------------------------------------------
///   Author:         fouad
///   AuthorUrl:      http://veritas-data.de
///   Date:           28.02.2019 03:03:22
///   Copyright (©)   2019, VERITAS DATA GmbH, all Rights Reserved. 
///                   No part of this document may be reproduced 
///                   without VERITAS DATA GmbH's express consent. 
///-----------------------------------------------------------------
namespace Messaia.Net.Wpf.Controls
{
    using Messaia.Net.Wpf.Controls.Properties;
    using System.Globalization;
    using System.Windows.Controls;

    /// <summary>
    /// RequiredValidationRule class.
    /// </summary>
    public class RequiredValidationRule : ValidationRule
    {
        /// <summary>
        /// Validates the input
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return string.IsNullOrWhiteSpace((value ?? "").ToString()) ? new ValidationResult(false, Resources.RequiredField) : ValidationResult.ValidResult;
        }
    }
}