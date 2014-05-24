using Providers.Resources;
using System;
using System.Configuration;
using System.Runtime;

namespace Providers.Configuration
{
    // Ref:
    //  http://www.cookcomputing.com/blog/archives/000589.html
    //
    //  Schemas
    //  http://stackoverflow.com/questions/1127315/how-do-i-make-an-extension-xsd-for-the-web-app-config-schema/7977168#7977168
    //  http://stackoverflow.com/questions/5303476/how-to-fix-error-could-not-find-schema-information-for-the-attribute-element
    //


    /// <summary>
    /// Defines configuration settings to support the infrastructure for 
    /// configuring and managing buiscuit details. This class cannot be 
    /// inherited.
    /// </summary>
    public sealed class BiscuitsSettings : ConfigurationSection
    {
        #region Declarations

        private static ConfigurationPropertyCollection _properties;
        private readonly static ConfigurationProperty _providers;
        private readonly static ConfigurationProperty _defaultProvider;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the <see cref="BiscuitsSettings"/> class.
        /// </summary>
        static BiscuitsSettings()
        {
            BiscuitsSettings._providers =
                new ConfigurationProperty(
                    "providers",
                    typeof(BiscuitProviderElementCollection));

            BiscuitsSettings._defaultProvider =
                new ConfigurationProperty(
                    "defaultProvider",
                    typeof(String));

            BiscuitsSettings._properties =
                new ConfigurationPropertyCollection()
            {
                BiscuitsSettings._providers,
                BiscuitsSettings._defaultProvider
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Web.Configuration.MembershipSection" /> class.
        /// </summary>
        public BiscuitsSettings() { }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name of the default provider that is used to manage biscuits.
        /// </summary>
        [ConfigurationProperty(ConfigurationKeys.DefaultProvider)]
        [StringValidator(MinLength = 1)]
        public string DefaultProvider
        {
            get
            {
                return (String)base[BiscuitsSettings._defaultProvider];
            }
            set
            {
                base[BiscuitsSettings._defaultProvider] = value;
            }
        }

        /// <summary>
        /// Gets the collection of properties.
        /// </summary>
        /// <returns>The <see cref="T:System.Configuration.ConfigurationPropertyCollection" /> of properties for the element.</returns>
        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                return BiscuitsSettings._properties;
            }
        }

        /// <summary>
        /// Gets the <see cref="T:Providers.Configuration.BiscuitProviderElementCollection" /> 
        /// of <see cref="T:Providers.Configuration.BiscuitProviderElement" /> objects.
        /// </summary>
        /// <value>
        /// The collection of providers elements.
        /// </value>
        [ConfigurationProperty(ConfigurationKeys.Providers, IsRequired = true, IsDefaultCollection = true)]
        //[ConfigurationCollection(
        //    typeof(BiscuitProviderElement),
        //    CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap,
        //    AddItemName = "add",
        //    ClearItemsName = "clear",
        //    RemoveItemName = "remove")]
        public BiscuitProviderElementCollection Providers
        {
            get
            {
                return (BiscuitProviderElementCollection)base[BiscuitsSettings._providers];
            }
        }

        #endregion

        ///// <summary>
        ///// Gets the default provider.
        ///// </summary>
        ///// <value>
        ///// The default sweet provider.
        ///// </value>
        //[ConfigurationProperty(ConfigurationKeys.Provider)]
        //public BiscuitProvider Provider
        //{
        //    get { return (BiscuitProvider)base[ConfigurationKeys.Provider]; }
        //}
    }
}