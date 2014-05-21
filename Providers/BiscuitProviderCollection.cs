using System;
using System.Configuration.Provider;

namespace Providers
{
    public sealed class BiscuitProviderCollection : ProviderCollection
    {
        /// <summary>
        /// Gets the provider with the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public new BiscuitProvider this[String name]
        {
            get { return base[name] as BiscuitProvider; }
        }

        /// <summary>
        /// Adds a provider to the collection.
        /// </summary>
        /// <param name="provider">The provider to be added</param>
        /// <exception cref="System.ArgumentNullException">provider is null</exception>
        /// <exception cref="System.NotSupportedException">provider is of wrong type</exception>
        public void Add(BiscuitProvider provider)
        {
            // Validate arguments
            if(provider == null)
            {
                throw new ArgumentNullException("provider");
            }
            if(!provider.GetType().IsSubclassOf(typeof(BiscuitProvider)))
            {
                throw new  NotSupportedException("provider must inherit from BiscuitProvider");
            }

            // Add the provider to the base class
            base.Add((BiscuitProvider)provider);
        }
    }
}