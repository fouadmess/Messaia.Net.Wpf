///-----------------------------------------------------------------
///   Author:         Fouad Messaia
///   AuthorUrl:      http://messaia.com
///   Date:           01.01.2016 02:01:32
///   Copyright (©)   2016, MESSAIA.NET, all Rights Reserved. 
///                   Licensed under the Apache License, Version 2.0. 
///                   See License.txt in the project root for license information.
///-----------------------------------------------------------------
namespace Messaia.Net.Wpf.Model
{
    /// <summary>
    /// Address class.
    /// </summary>
    public class Address<TKey> : BaseEntity<TKey>
    {
        #region Fields

        /// <summary>        
        /// </summary>
        private Salutation salutation;

        /// <summary>        
        /// </summary>
        private string firstName;

        /// <summary>        
        /// </summary>
        private string lastName;

        /// <summary>        
        /// </summary>
        private string address1;

        /// <summary>        
        /// </summary>
        private string address2;

        /// <summary>        
        /// </summary>
        private string address3;

        /// <summary>        
        /// </summary>
        private string postalCode;

        /// <summary>        
        /// </summary>
        private string city;

        /// <summary>        
        /// </summary>
        private string state;

        /// <summary>        
        /// </summary>
        private string country;

        #endregion

        /// <summary>
        /// Gets or sets the Salutation
        /// </summary>
        public virtual Salutation Salutation { get => this.salutation; set { this.salutation = value; this.OnPropertyChanged(); } }

        /// <summary>
        /// Gets or sets the FirstName
        /// </summary>
        public virtual string FirstName { get => this.firstName; set { this.firstName = value; this.OnPropertyChanged(); } }

        /// <summary>
        /// Gets or sets the LastName
        /// </summary>
        public virtual string LastName { get => this.lastName; set { this.lastName = value; this.OnPropertyChanged(); } }

        /// <summary>
        /// Gets or sets the Address1
        /// </summary>
        public virtual string Address1 { get => this.address1; set { this.address1 = value; this.OnPropertyChanged(); } }

        /// <summary>
        /// Gets or sets the Address2
        /// </summary>
        public virtual string Address2 { get => this.address2; set { this.address2 = value; this.OnPropertyChanged(); } }

        /// <summary>
        /// Gets or sets the Address3
        /// </summary>
        public virtual string Address3 { get => this.address3; set { this.address3 = value; this.OnPropertyChanged(); } }

        /// <summary>
        /// Gets or sets the PostalCode
        /// </summary>
        public virtual string PostalCode { get => this.postalCode; set { this.postalCode = value; this.OnPropertyChanged(); } }

        /// <summary>
        /// Gets or sets the City
        /// </summary>
        public virtual string City { get => this.city; set { this.city = value; this.OnPropertyChanged(); } }

        /// <summary>
        /// Gets or sets the State
        /// </summary>
        public virtual string State { get => this.state; set { this.state = value; this.OnPropertyChanged(); } }

        /// <summary>
        /// Gets or sets the Country
        /// </summary>
        public virtual string Country { get => this.country; set { this.country = value; this.OnPropertyChanged(); } }
    }
}