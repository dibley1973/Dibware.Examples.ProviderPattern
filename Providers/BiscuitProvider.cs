using System;
using System.Configuration.Provider;

namespace Providers
{
    // REf:
    //  http://www.codeproject.com/Articles/18222/Provider-Pattern
    //
    //  http://manyrootsofallevilrants.blogspot.com/2011/07/nested-custom-configuration-collections.html
    //
    //

    public abstract class BiscuitProvider : ProviderBase
    {
        public virtual String Action { get { return "I provide buiscuits"; } }
        public virtual Boolean RequiresAFilling { get { return false; } }


    }
}