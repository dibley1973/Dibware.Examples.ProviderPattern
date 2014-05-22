using Providers.Resources;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providers.Configuration
{
    public class BiscuitsConfiguration : ConfigurationSection
    {
        /// <summary>
        /// Gets or sets the default provider name
        /// </summary>
        [ConfigurationProperty(ConfigurationKeys.DefaultProvider)]
        public string DefaultProvider
        {
            get
            {
                return (string)base[ConfigurationKeys.DefaultProvider];
            }
            set
            {
                base[ConfigurationKeys.DefaultProvider] = value;
            }
        }

        /// <summary>
        /// Gets the default provider.
        /// </summary>
        /// <value>
        /// The default sweet provider.
        /// </value>
        [ConfigurationProperty(ConfigurationKeys.Provider)]
        public BiscuitProvider Provider
        {
            get { return (BiscuitProvider)base[ConfigurationKeys.Provider]; }
        }

        /// <summary>
        /// Gets the provider collection.
        /// </summary>
        /// <value>
        /// The collection of providers.
        /// </value>
        [ConfigurationProperty(ConfigurationKeys.Providers)]
        public BiscuitProviderCollection Providers
        {
            get
            {
                return (BiscuitProviderCollection)base[ConfigurationKeys.Providers];
            }
        }

    }
}