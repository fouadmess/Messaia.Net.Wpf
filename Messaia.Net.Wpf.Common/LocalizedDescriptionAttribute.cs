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
    using System.ComponentModel;
    using System.Resources;

    /// <summary>
    /// LocalizedDescriptionAttribute class.
    /// </summary>
    public class LocalizedDescriptionAttribute : DescriptionAttribute
    {
        /// <summary>
        /// The resource manager
        /// </summary>
        private ResourceManager resourceManager;

        /// <summary>
        /// The resource key
        /// </summary>
        private readonly string resourceKey;

        /// <summary>
        /// Initializes an instance of the <see cref="LocalizedDescriptionAttribute"/> class.
        /// </summary>        
        /// <param name="resourceKey"></param>
        /// <param name="resourceType"></param>
        public LocalizedDescriptionAttribute(string resourceKey, Type resourceType)
        {
            this.resourceManager = new ResourceManager(resourceType);
            this.resourceKey = resourceKey;
        }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        public override string Description
        {
            get
            {
                string description = resourceManager.GetString(resourceKey);
                return string.IsNullOrWhiteSpace(description) ? string.Format("[[{0}]]", resourceKey) : description;
            }
        }
    }
}