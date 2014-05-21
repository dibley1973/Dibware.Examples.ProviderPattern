using System;
using System.Configuration.Provider;

namespace Providers
{
    public sealed class SweetProviderCollection : ProviderCollection
    {
        /// <summary>
        /// Gets the provider with the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public new SweetProvider this[String name]
        {
            get { return base[name] as SweetProvider; }
        }
    }
}