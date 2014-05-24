using System;
using System.Collections.Specialized;
using System.Configuration;

namespace Providers.Configuration
{
    /// <summary>
    /// Represents the configuration elements associated with a biscuit provider.
    /// </summary>
    public sealed class BiscuitProviderElement : ConfigurationElement
    {
        private NameValueCollection _propertyNameCollection;

        #region Declarations

        private readonly ConfigurationProperty _propName =
            new ConfigurationProperty(
                "name",
                typeof(string),
                null,
                ConfigurationPropertyOptions.IsRequired |
                ConfigurationPropertyOptions.IsKey);

        private readonly ConfigurationProperty _propType =
            new ConfigurationProperty(
                "type",
                typeof(string),
                "",
                ConfigurationPropertyOptions.IsRequired |
                ConfigurationPropertyOptions.IsTypeStringTransformationRequired);

        private ConfigurationPropertyCollection _properties;

        //private NameValueCollection _PropertyNameCollection;

        #endregion

        #region Constructors


        /// <summary>
        /// Initializes a new instance of the <see cref="T:Providers.Configuration.BiscuitProvider.Element" /> class. 
        /// </summary>
        public BiscuitProviderElement()
        {
            this._properties = new ConfigurationPropertyCollection()
            {
                this._propName,
                this._propType
            };
            //this._PropertyNameCollection = null;
        }

        #endregion

        #region Properties


        /// <summary>Gets a collection of user-defined parameters for the provider.</summary>
        /// <returns>A <see cref="T:System.Collections.Specialized.NameValueCollection" /> of parameters for the provider.</returns>
        public NameValueCollection Parameters
        {
            get
            {
                if (this._propertyNameCollection == null)
                {
                    lock (this)
                    {
                        if (this._propertyNameCollection == null)
                        {
                            this._propertyNameCollection = new NameValueCollection(StringComparer.Ordinal);
                            foreach (object _property in this._properties)
                            {
                                ConfigurationProperty configurationProperty = (ConfigurationProperty)_property;
                                if (!(configurationProperty.Name != "name") || !(configurationProperty.Name != "type"))
                                {
                                    continue;
                                }
                                this._propertyNameCollection.Add(configurationProperty.Name, (string)base[configurationProperty]);
                            }
                        }
                    }
                }
                return this._propertyNameCollection;
            }
        }


        /// <summary>
        /// Gets or sets the name of the provider configured by this class.
        /// </summary>
        /// <returns>The name of the provider.</returns>
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public String Name
        {
            get
            {
                return (String)base[this._propName];
            }
            set
            {
                base[this._propName] = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of the provider configured by this class.
        /// </summary>
        /// <returns>
        /// The fully qualified namespace and class name for the type of provider 
        /// configured by this <see cref="T:Providers.Configuration.BiscuitProvider.Element" /> instance.
        /// </returns>
        [ConfigurationProperty("type", IsRequired = true)]
        public String Type
        {
            get
            {
                return (String)base[this._propType];
            }
            set
            {
                base[this._propType] = value;
            }
        }

        #endregion

    }
}
