using System;
using System.Configuration.Provider;

namespace Providers
{
    public class HobnobProvider : BiscuitProvider
    {
        public override String Description { get { return "I provide hob-nobs"; } }
    }
}