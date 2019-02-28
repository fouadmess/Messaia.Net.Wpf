///-----------------------------------------------------------------
///   Author:         Fouad Messaia
///   AuthorUrl:      http://messaia.com
///   Date:           01.01.2016 01:58:09
///   Copyright (©)   2016, MESSAIA.NET, all Rights Reserved. 
///                   Licensed under the Apache License, Version 2.0. 
///                   See License.txt in the project root for license information.
///-----------------------------------------------------------------
namespace Messaia.Net.Wpf.Model
{
    using Messaia.Net.Wpf.Common;
    using Messaia.Net.Wpf.Model.Properties;
    using System.ComponentModel;

    /// <summary>
    /// Salutation enum
    /// </summary>
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum Salutation
    {
        [LocalizedDescription("Ms", typeof(Resources))]
        Female = 1,
        [LocalizedDescription("Mr", typeof(Resources))]
        Male
    }
}