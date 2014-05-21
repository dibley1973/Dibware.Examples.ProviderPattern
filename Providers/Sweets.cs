using System;

namespace Providers
{
    public static class Sweets
    {
        private static SweetProviderCollection _providers;

        /// <summary>
        /// Initializes the <see cref="Sweets"/> class.
        /// </summary>
        static Sweets()
        {
            _providers = new SweetProviderCollection();
        }



        public static String DefaultProvider { get; set; }

        /// <summary>
        /// Gets the default provider.
        /// </summary>
        /// <value>
        /// The default sweet provider.
        /// </value>
        public static SweetProvider Provider
        {
            get { return Providers[DefaultProvider]; }
        }

        /// <summary>
        /// Gets the provider collection.
        /// </summary>
        /// <value>
        /// The collection of providers.
        /// </value>
        public static SweetProviderCollection Providers
        {
            get { return _providers; }
        }

    }
}
