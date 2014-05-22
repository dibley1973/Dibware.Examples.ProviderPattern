using System;

namespace Providers
{
    public class CustardCreamProvider : BiscuitProvider
    {
        public override String Description { get { return "I provide custard creams"; } }
        public override Boolean RequiresAFilling { get { return true; } }
    }
}