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
    using System.Windows.Markup;

    /// <summary>
    /// EnumBindingSourceExtension class.
    /// </summary>
    public class EnumBindingSourceExtension : MarkupExtension
    {
        /// <summary>
        /// The type of the enum
        /// </summary>
        private Type enumType;

        /// <summary>
        /// Gets or sets the EnumType
        /// </summary>
        public Type EnumType
        {
            get { return this.enumType; }
            set
            {
                if (value != this.enumType)
                {
                    if (null != value)
                    {
                        Type enumType = Nullable.GetUnderlyingType(value) ?? value;

                        if (!enumType.IsEnum)
                            throw new ArgumentException("Type must be for an Enum.");
                    }

                    this.enumType = value;
                }
            }
        }

        /// <summary>
        /// Initializes an instance of the <see cref="EnumBindingSourceExtension"/> class.
        /// </summary>
        public EnumBindingSourceExtension() { }

        /// <summary>
        /// Initializes an instance of the <see cref="EnumBindingSourceExtension"/> class.
        /// </summary>
        /// <param name="enumType"></param>
        public EnumBindingSourceExtension(Type enumType)
        {
            this.EnumType = enumType;
        }

        /// <summary>
        /// When implemented in a derived class, returns an object that is provided as the 
        /// value of the target property for this markup extension.
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (this.enumType == null)
            {
                throw new InvalidOperationException("The EnumType must be specified.");
            }

            var actualEnumType = Nullable.GetUnderlyingType(this.enumType) ?? this.enumType;
            var enumValues = Enum.GetValues(actualEnumType);

            if (actualEnumType == this.enumType)
            {
                return enumValues;
            }

            var tempArray = Array.CreateInstance(actualEnumType, enumValues.Length + 1);
            enumValues.CopyTo(tempArray, 1);
            return tempArray;
        }
    }
}