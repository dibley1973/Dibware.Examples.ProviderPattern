using System;
using System.Configuration.Provider;

namespace Providers
{
    public abstract class BiscuitProvider : ProviderBase
    {
        public virtual String Action { get { return "I provide buiscuits"; } }
        public virtual Boolean RequiresAFilling { get { return false; } }
    }
}