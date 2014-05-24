using Providers.Configuration;
using Providers.Resources;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Compilation;
using System.Web.Configuration;
using System.Web.Hosting;

namespace Providers
{
    // REf:
    //  http://msdn.microsoft.com/en-us/library/aa479028.aspx

    public static class Biscuits
    {
        #region Declarations
       
        private static Object _lock = new Object();
        private static BiscuitProviderCollection _providers;
        private static BiscuitProvider _provider;

        private static bool s_Initialized;
        private static bool s_InitializedDefaultProvider;
        private static Exception s_InitializeException;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the <see cref="Biscuits"/> class.
        /// </summary>
        static Biscuits()
        {
            Biscuits._lock = new Object();
            //_providers = new BiscuitProviderCollection();
            Biscuits.s_Initialized = false;
            Biscuits.s_InitializedDefaultProvider = false;
            Biscuits.s_InitializeException = null;
        }
        
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the default provider name
        /// </summary>
        public static String DefaultProvider { get; set; }

        /// <summary>
        /// Gets the (default) provider.
        /// </summary>
        /// <value>
        /// The default sweet provider.
        /// </value>
        public static BiscuitProvider Provider
        {
            get
            {
                Biscuits.Initialize();
                if (Biscuits._provider == null)
                {
                    throw new InvalidOperationException(ExceptionMessages.DefaultBiscuitProviderNotFound);
                } 
                return Biscuits._provider;
                //return _providers[DefaultProvider]; 
            }
        }

        /// <summary>
        /// Gets the provider collection.
        /// </summary>
        /// <value>
        /// The collection of providers.
        /// </value>
        public static BiscuitProviderCollection Providers
        {
            get
            {
                Biscuits.Initialize();
                return _providers;
            }
        }

        #endregion

        #region Methods

        private static void Initialize()
        {
            bool initializedSettings;
            bool flag1;
            if (Biscuits.s_Initialized && Biscuits.s_InitializedDefaultProvider)
            {
                return;
            }
            if (Biscuits.s_InitializeException != null)
            {
                throw Biscuits.s_InitializeException;
            }
            //if (HostingEnvironment.IsHosted)
            //{
            //    HttpRuntime.CheckAspNetHostingPermission(AspNetHostingPermissionLevel.Low, "Feature_not_supported_at_this_level");
            //}
            lock (Biscuits._lock)
            {
                if (!Biscuits.s_Initialized || !Biscuits.s_InitializedDefaultProvider)
                {
                    if (Biscuits.s_InitializeException != null)
                    {
                        throw Biscuits.s_InitializeException;
                    }
                    bool sInitialized = !Biscuits.s_Initialized;
                    if (Biscuits.s_InitializedDefaultProvider)
                    {
                        flag1 = false;
                    }
                    else
                    {
                        flag1 = true;
                        //flag1 = (!HostingEnvironment.IsHosted ? true : BuildManager.PreStartInitStage == PreStartInitStage.AfterPreStartInit);
                    }
                    bool initializeDefaultProvider = flag1;
                    if (initializeDefaultProvider || sInitialized)
                    {
                        bool initializedDefaultProvider = false;
                        try
                        {
                            //Configuration config    /* get the configuration */
                            //    = ConfigurationManager.OpenMappedExeConfiguration(
                            //        _fileMap, ConfigurationUserLevel.None);

                            BiscuitsSettings biscuitSettings /* Get the configuration section */
                                = ConfigurationManager.GetSection(ConfigSectionNames.BiscuitsSettings)
                                as BiscuitsSettings;
                                //= config.GetSection(BiscuitSettingsSectionName) as BiscuitsSettings;

                            if(biscuitSettings == null)
                            {
                                throw new ProviderException(ExceptionMessages.BiscuitSettingsSectionNotFound);
                            }

                             //var section (BiscuitsSection) = _
                             //   CType(WebConfigurationManager.GetSection( _
                             //   "system.web/imageService"), _AppDomain
                             //   BiscuitsSection);


                            //RuntimeConfig appConfig = RuntimeConfig.GetAppConfig();
                            //BiscuitsSettings membership = appConfig.Biscuits;

                            initializedSettings = Biscuits.InitializeSettings(sInitialized, biscuitSettings);
                            initializedDefaultProvider = Biscuits.InitializeDefaultProvider(initializeDefaultProvider, biscuitSettings);
                        }
                        catch (Exception exception)
                        {
                            Biscuits.s_InitializeException = exception;
                            throw;
                        }
                        if (initializedSettings)
                        {
                            Biscuits.s_Initialized = true;
                        }
                        if (initializedDefaultProvider)
                        {
                            Biscuits.s_InitializedDefaultProvider = true;
                        }
                    }
                }
            }
        }

        private static bool InitializeDefaultProvider(bool initializeDefaultProvider, BiscuitsSettings settings)
        {
            if (!initializeDefaultProvider)
            {
                return false;
            }
            Biscuits._providers.SetReadOnly();
            if (settings.DefaultProvider == null || Biscuits._providers.Count < 1)
            {
                throw new ProviderException(ExceptionMessages.DefaultBiscuitProviderNotSpecified);
            }
            Biscuits._provider = Biscuits._providers[settings.DefaultProvider];
            if (Biscuits._provider == null)
            {
                throw new ConfigurationErrorsException(
                    ExceptionMessages.DefaultBiscuitProviderNotFound, 
                    settings.ElementInformation.Properties["defaultProvider"].Source, 
                    settings.ElementInformation.Properties["defaultProvider"].LineNumber);
            }
            return true;
        }

        /// <summary>
        /// Initializes the settings.
        /// </summary>
        /// <param name="initializeGeneralSettings">if set to <c>true</c> [initialize general settings].</param>
        /// <param name="settings">The settings.</param>
        /// <returns></returns>
        private static bool InitializeSettings(bool initializeGeneralSettings, BiscuitsSettings settings)
        {
            if (!initializeGeneralSettings)
            {
                return false;
            }
            Biscuits._providers = new BiscuitProviderCollection();
            //if (!HostingEnvironment.IsHosted)
            //{
            //    foreach (ProviderSettings provider in settings.Providers)
            //    {
            //        Type type = Type.GetType(provider.Type, true, true);
            //        if (!typeof(BiscuitsProvider).IsAssignableFrom(type))
            //        {
            //            object[] str = new object[] { typeof(BiscuitsProvider).ToString() };
            //            throw new ArgumentException(SR.GetString("Provider_must_implement_type", str));
            //        }
            //        BiscuitsProvider membershipProvider = (BiscuitsProvider)Activator.CreateInstance(type);
            //        NameValueCollection parameters = provider.Parameters;
            //        NameValueCollection nameValueCollection = new NameValueCollection(parameters.Count, StringComparer.Ordinal);
            //        foreach (string parameter in parameters)
            //        {
            //            nameValueCollection[parameter] = parameters[parameter];
            //        }
            //        membershipProvider.Initialize(provider.Name, nameValueCollection);
            //        Biscuits.s_Providers.Add(membershipProvider);
            //    }
            //}
            //else
            //{
            //    ProvidersHelper.InstantiateProviders(
            //        settings.Providers, 
            //        Biscuits._providers, 
            //        typeof(BiscuitProvider));
            //    _provider = _providers(settings.DefaultProvider)
            //}

            foreach (BiscuitProviderElement provider in settings.Providers)
            {
                Type type = Type.GetType(provider.Type, true, true);
                if (!typeof(BiscuitProvider).IsAssignableFrom(type))
                {
                    object[] str = new object[] { typeof(BiscuitProvider).ToString() };
                    throw new ArgumentException(String.Format("Provider_must_implement_type {0}", str));
                }
                BiscuitProvider biscuitProvider = (BiscuitProvider)Activator.CreateInstance(type);
                NameValueCollection parameters = provider.Parameters;
                NameValueCollection nameValueCollection = new NameValueCollection(parameters.Count, StringComparer.Ordinal);
                foreach (string parameter in parameters)
                {
                    nameValueCollection[parameter] = parameters[parameter];
                }
                biscuitProvider.Initialize(provider.Name, nameValueCollection);
                Biscuits._providers.Add(biscuitProvider);
            }

            
            return true;
        }

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


        #endregion

    }
}