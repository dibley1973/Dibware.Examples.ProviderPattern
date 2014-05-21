using System;
using System.Configuration.Provider;

namespace Providers
{
    public class CustardCreamProvider : BiscuitProvider
    {
        public override String Description { get { return "I provide custard creams"; } }
    }
}