﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Providers;
using System;
using System.Configuration;

namespace ProvidersTests
{
    [TestClass]
    public class BiscuitProviderTests
    {
        [TestMethod]
        public void Test_VerifyAppDomainHasConfigurationSettings()
        {
            // Arrange
            String value;

            // Act
            value = ConfigurationManager.AppSettings["TestValue"];
            
            // Assert
            Assert.IsFalse(String.IsNullOrEmpty(value), "No App.Config found.");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_AddNullProvider_ResultsIn_ArgumentNullExceptionThrown()
        {
            // Arrange
            BiscuitProvider provider = null;

            // Act
            Biscuits.Providers.Clear();
            Biscuits.Providers.Add(provider);

            // Assert
            // Should not get here as exception should be thrown
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_SetNoDefultProvider_ResultsIn_ArgumentNullExceptionThrown()
        {
            // Arrange
            var bourbonProvider = new BourbonProvider();
            bourbonProvider.Initialize("bourbon", null);

            var custardCreamProvider = new CustardCreamProvider();
            custardCreamProvider.Initialize("custard cream", null);

            var hobnobProvider = new HobnobProvider();
            hobnobProvider.Initialize("hobnob", null);

            // Act
            Biscuits.Providers.Clear();
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
            Biscuits.Providers.Clear();
            Biscuits.Providers.Add(bourbonProvider);
            Biscuits.Providers.Add(custardCreamProvider);
            Biscuits.Providers.Add(hobnobProvider);
            Biscuits.DefaultProvider = defaultProviderName;

            // Assert
            Assert.AreEqual(defaultProviderName, Biscuits.Provider.Name);
        }

        [TestMethod]
        public void Test_SetDefultProvider_ResultsIn_ExpectingFillingRequired()
        {
            // Arrange
            var bourbonProvider = new BourbonProvider();
            bourbonProvider.Initialize("bourbon", null);

            var custardCreamProvider = new CustardCreamProvider();
            custardCreamProvider.Initialize("custard cream", null);

            var hobnobProvider = new HobnobProvider();
            hobnobProvider.Initialize("hobnob", null);

            var defaultProviderName = "custard cream";
            var expectedRequiresAFilling = true;

            // Act
            Biscuits.Providers.Clear();
            Biscuits.Providers.Add(bourbonProvider);
            Biscuits.Providers.Add(custardCreamProvider);
            Biscuits.Providers.Add(hobnobProvider);
            Biscuits.DefaultProvider = defaultProviderName;

            // Assert
            Assert.AreEqual(expectedRequiresAFilling, Biscuits.Provider.RequiresAFilling);
        }
    }
}