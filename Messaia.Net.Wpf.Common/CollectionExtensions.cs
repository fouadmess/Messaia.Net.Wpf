///-----------------------------------------------------------------
///   Author:         Fouad Messaia
///   AuthorUrl:      http://messaia.com
///   Date:           01.01.2016 23:16:08
///   Copyright (©)   2017, MESSAIA.NET, all Rights Reserved. 
///                   Licensed under the Apache License, Version 2.0. 
///                   See License.txt in the project root for license information.
///-----------------------------------------------------------------
namespace System.Linq
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// CollectionExtensions class.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Converts an IEnumerable to ObservableCollection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerableList"></param>
        /// <returns></returns>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerableList)
        {
            /* Create an emtpy observable collection object */
            var observableCollection = new ObservableCollection<T>();

            /* Loop through all the records and add to observable collection object */
            foreach (var item in enumerableList)
            {
                observableCollection.Add(item);
            }

            /* Return the populated observable collection */
            return observableCollection;
        }

        /// <summary>
        /// Clones a list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list to clone</param>
        /// <returns></returns>
        public static IEnumerable<T> Clone<T>(this IEnumerable<T> list) where T : ICloneable
        {
            return list.Select(item => (T)item.Clone()).ToList();
        }
    }
}