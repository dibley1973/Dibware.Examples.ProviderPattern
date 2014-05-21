using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Providers;

namespace ProvidersTests
{
    [TestClass]
    public class BiscuitProviderTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_AddNullProvider_ResultsIn_ArgumentNullExceptionThrown()
        {
            // Arrange
            BiscuitProvider provider = null;  

            // Act
            Biscuits.Providers.Add(provider);

            // Assert
            // Should not get here as exception should be thrown
        }


        [TestMethod]
        public void Test_SetNoDefultProvider_ResultsIn_NullReturned()
        {
            // Arrange
            var bourbonProvider = new BourbonProvider();
            bourbonProvider.Initialize("bourbon", null);

            var custardCreamProvider = new CustardCreamProvider();
            custardCreamProvider.Initialize("custard cream", null);

            var hobnobProvider = new HobnobProvider();
            hobnobProvider.Initialize("hobnob", null);

            // Act
            Biscuits.Providers.Add(bourbonProvider);
            Biscuits.Providers.Add(custardCreamProvider);
            Biscuits.Providers.Add(hobnobProvider);
            
            // Assert
            Assert.IsNull(Biscuits.Provider);
        }


        [TestMethod]
        public void Test_SetDefultProvider_ResultsIn_ProviderNameMatchingDefault()
        {
            // Arrange
            var bourbonProvider = new BourbonProvider();
            bourbonProvider.Initialize("bourbon", null);

            var custardCreamProvider = new CustardCreamProvider();
            custardCreamProvider.Initialize("custard cream", null);

            var hobnobProvider = new HobnobProvider();
            hobnobProvider.Initialize("hobnob", null);

            var defaultProviderName = "hobnob";

            // Act
            Biscuits.Providers.Add(bourbonProvider);
            Biscuits.Providers.Add(custardCreamProvider);
            Biscuits.Providers.Add(hobnobProvider);
            Biscuits.DefaultProvider = defaultProviderName;

            // Assert
            Assert.AreEqual(defaultProviderName, Biscuits.Provider.Name);
        }
    }
}