using System;
using System.Configuration.Provider;

namespace Providers
{
    public class BourbonProvider : BiscuitProvider
    {
        public override String Description { get { return "I provide bourbons"; } }
    }
}
