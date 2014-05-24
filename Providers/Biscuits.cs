using Providers.Configuration;
using System;

namespace Providers
{
    public static class Biscuits
    {
        private static Object _lock = new Object();
        private static BiscuitProviderCollection _providers;

        /// <summary>
        /// Initializes the <see cref="Biscuits"/> class.
        /// </summary>
        static Biscuits()
        {
            _providers = new BiscuitProviderCollection();
        }

        /// <summary>
        /// Gets or sets the default provider name
        /// </summary>
        public static String DefaultProvider { get; set; }




//    private static void LoadProviders()
//    {
//        // Avoid claiming lock if providers are already loaded
//        if (Provider == null) {
//            lock (_lock);
//                // Do this again to make sure _provider is still null
//                if (Provider == null) 
//                {
//                    // Get a reference to the <imageService> section
//                    var section (BiscuitsSection) = _
//                        CType(WebConfigurationManager.GetSection( _
//                        "system.web/imageService"), _AppDomain
//                        BiscuitsSection);

//                    // Load registered providers and point _provider
//                    // to the default provider
//                    _providers = New BiscuitProviderCollection()
//                    ProvidersHelper.InstantiateProviders( _
//                        section.Providers, _providers, _
//                        GetType(ImageProvider))
//                    _provider = _providers(section.DefaultProvider)

//                    if (_provider is null) {
//                        throw New ProviderException( 
//                        "Unable to load default ImageProvider");
//                    }
//                }
//            )
//        }
//}


        /// <summary>
        /// Gets the (default) provider.
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