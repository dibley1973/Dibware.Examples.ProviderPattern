//using System.Configuration;
//using System.Configuration;
//using System.Configuration.Provider;

namespace Providers.Helpers
{
    public static class ProvidersHelper
    {
        ///// <summary>Initializes and returns a single provider of the given type using the supplied settings.</summary>
        ///// <returns>A new provider of the given type using the supplied settings.</returns>
        ///// <param name="providerSettings">The settings to be passed to the provider upon initialization.</param>
        ///// <param name="providerType">The <see cref="T:System.Type" /> of the provider to be initialized.</param>
        ///// <exception cref="T:System.ArgumentException">The provider type defined in configuration was null or an empty string ("").- or -The provider type defined in configuration is not compatible with the type used by the feature that is attempting to create a new instance of the provider.</exception>
        ///// <exception cref="T:System.Configuration.ConfigurationErrorsException">The provider threw an exception while it was being initialized.- or -An error occurred while attempting to resolve a <see cref="T:System.Type" /> instance for the provider specified in <paramref name="providerSettings" />.</exception>
        //public static ProviderBase InstantiateBiscuitProvider(Providers.Configuration.Base.ProviderSettings providerSettings, Type providerType)
        //{
        //    string str;
        //    ProviderBase providerBase = null;
        //    try
        //    {
        //        if (providerSettings.Type == null)
        //        {
        //            str = null;
        //        }
        //        else
        //        {
        //            str = providerSettings.Type.Trim();
        //        }
        //        string str1 = str;
        //        if (string.IsNullOrEmpty(str1))
        //        {
        //            throw new ArgumentException(SR.GetString("Provider_no_type_name"));
        //        }

        //        Type type = ConfigUtil.GetType(str1, "type", providerSettings, true, true);
        //        if (!providerType.IsAssignableFrom(type))
        //        {
        //            object[] objArray = new object[] { providerType.ToString() };
        //            throw new ArgumentException(SR.GetString("Provider_must_implement_type", objArray));
        //        }
        //        providerBase = (ProviderBase)HttpRuntime.CreatePublicInstance(type);
        //        NameValueCollection parameters = providerSettings.Parameters;
        //        NameValueCollection nameValueCollection = new NameValueCollection(parameters.Count, StringComparer.Ordinal);
        //        foreach (string parameter in parameters)
        //        {
        //            nameValueCollection[parameter] = parameters[parameter];
        //        }
        //        providerBase.Initialize(providerSettings.Name, nameValueCollection);
        //    }
        //    catch (Exception exception1)
        //    {
        //        Exception exception = exception1;
        //        if (!(exception is ConfigurationException))
        //        {
        //            throw new ConfigurationErrorsException(exception.Message, exception, providerSettings.ElementInformation.Properties["type"].Source, providerSettings.ElementInformation.Properties["type"].LineNumber);
        //        }
        //        throw;
        //    }
        //    return providerBase;
        //}

        ///// <summary>Initializes a collection of providers of the given type using the supplied settings.</summary>
        ///// <param name="configProviders">A collection of settings to be passed to the provider upon initialization.</param>
        ///// <param name="providers">The collection used to contain the initialized providers after the method returns.</param>
        ///// <param name="providerType">The <see cref="T:System.Type" /> of the providers to be initialized.</param>
        //public static void InstantiateProviders(Providers.Configuration.Base.ProviderSettingsCollection configProviders, ProviderCollection providers, Type providerType)
        //{
        //    foreach (Providers.Configuration.Base.ProviderSettings configProvider in configProviders)
        //    {
        //        providers.Add(ProvidersHelper.InstantiateProvider(configProvider, providerType));
        //    }
        //}
    }
}
