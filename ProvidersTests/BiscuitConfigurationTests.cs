using Microsoft.VisualStudio.TestTools.UnitTesting;
using Providers.Configuration;
using System.Configuration;

namespace ProvidersTests
{
    // REf:
    //  http://www.cookcomputing.com/blog/archives/000589.html
    //
    //

    [TestClass]
    public class BiscuitConfigurationTests
    {
        [TestMethod]
        public void Test_getBisucitSectionDefaultprovider_ResultsIn_CorrectProvider()
        {
            // Arrange
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            //Assembly assembly = Assembly.GetExecutingAssembly();
            fileMap.ExeConfigFilename = @"F:\Dev\Dibware.Examples.ProviderPattern\ProvidersTests\ConfigTests.config";
            Configuration config
                = ConfigurationManager.OpenMappedExeConfiguration(
                    fileMap,
                    ConfigurationUserLevel.None);

            // Act
            BiscuitsSection section
                = config.GetSection("biscuitSettings") as BiscuitsSection;

            // Assert
            Assert.AreEqual("testProvider", section.DefaultProvider);
        }
    }
}
