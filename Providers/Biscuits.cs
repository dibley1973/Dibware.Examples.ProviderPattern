using System;

namespace Providers
{
    public static class Biscuits
    {
        private static BiscuitProviderCollection _providers;

        /// <summary>
        /// Initializes the <see cref="Biscuits"/> class.
        /// </summary>
        static Biscuits()
        {
            _providers = new BiscuitProviderCollection();
        }

        /// <summary>
        /// Gets or sets the default provider
        /// </summary>
        public static String DefaultProvider { get; set; }

        /// <summary>
        /// Gets the default provider.
        /// </summary>
        /// <value>
        /// The default sweet provider.
        /// </value>
        public static BiscuitProvider Provider
        {
            get { return Providers[DefaultProvider]; }
        }

        /// <summary>
        /// Gets the provider collection.
        /// </summary>
        /// <value>
        /// The collection of providers.
        /// </value>
        public static BiscuitProviderCollection Providers
        {
            get { return _providers; }
        }
    }
}