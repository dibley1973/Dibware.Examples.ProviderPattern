﻿using Providers.Resources;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Providers.Configuration
{
    // Ref:
    //  http://www.cookcomputing.com/blog/archives/000589.html
    //
    //
    //
    //


    /// <summary>
    /// Defines configuration settings to support the infrastructure for 
    /// configuring and managing buiscuit details. This class cannot be 
    /// inherited.
    /// </summary>
    public sealed class BiscuitsSection : ConfigurationSection
    {
        #region Declarations

        private static ConfigurationPropertyCollection _properties;
        private readonly static ConfigurationProperty _providers;
        private readonly static ConfigurationProperty _defaultProvider;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the <see cref="BiscuitsSection"/> class.
        /// </summary>
        static BiscuitsSection()
        {
            BiscuitsSection._providers = 
                new ConfigurationProperty(
                    "providers",
                    typeof(BiscuitProviderElementCollection));

            BiscuitsSection._defaultProvider = 
                new ConfigurationProperty(
                    "defaultProvider", 
                    typeof(String));

            BiscuitsSection._properties = 
                new ConfigurationPropertyCollection()
            {
                BiscuitsSection._providers,
                BiscuitsSection._defaultProvider
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Web.Configuration.MembershipSection" /> class.
        /// </summary>
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public BiscuitsSection() {}

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
                return (string)base[BiscuitsSection._defaultProvider];
            }
            set
            {
                base[BiscuitsSection._defaultProvider] = value;
            }
        }

        /// <summary>
        /// Gets the collection of properties.
        /// </summary>
        /// <returns>The <see cref="T:System.Configuration.ConfigurationPropertyCollection" /> of properties for the element.</returns>
        protected override ConfigurationPropertyCollection Properties
        {
            [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
            get
            {
                return BiscuitsSection._properties;
            }
        }

        #endregion



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
        public BiscuitProviderElementCollection Providers
        {
            get
            {
                return (BiscuitProviderElementCollection)base[BiscuitsSection._providers];
            }
        }

    }
}