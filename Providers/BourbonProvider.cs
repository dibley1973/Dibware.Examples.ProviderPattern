using System;

namespace Providers
{
    public class BourbonProvider : BiscuitProvider
    {
        public override String Description { get { return "I provide bourbons"; } }
        public override Boolean RequiresAFilling { get { return true; } }
    }
}
