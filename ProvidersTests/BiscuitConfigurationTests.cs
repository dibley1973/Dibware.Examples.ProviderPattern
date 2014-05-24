using Microsoft.VisualStudio.TestTools.UnitTesting;
using Providers.Configuration;
using System;
using System.Configuration;
using System.IO;

namespace ProvidersTests
{
    // REf:
    //  http://www.cookcomputing.com/blog/archives/000589.html
    //
    //

    [TestClass]
    public class BiscuitConfigurationTests
    {
        #region Declarations

        private const String FilePathDelimiter = @"\";
        private const String ConfigFileDirectoryName = @"ConfigFiles";
        private const String BiscuitSettingsSectionName = @"biscuitSettings";
        private String _projectDirectoryPath;
        ExeConfigurationFileMap _fileMap;

        #endregion

        #region Test Initialise

        /// <summary>
        /// Initializes the tests.
        /// </summary>
        [TestInitialize]
        public void TestInit()
        {
            _projectDirectoryPath = GetProjectDirectoryPath();
            _fileMap = new ExeConfigurationFileMap();
        }

        #endregion

        #region Tests

        [TestMethod]
        public void Test_SetBiscuitSectionDefaultProviderAttribute__ResultsIn_CorrectProvider()
        {
            // Arrange
            var configFilename = @"SetBiscuitSectionDefaultProviderAttribute.config";
            var configFilePath = CreateConfigFilePath(_projectDirectoryPath, ConfigFileDirectoryName, configFilename);
            _fileMap.ExeConfigFilename = configFilePath;

            // Act
            Configuration config    /* get the configuration */
                = ConfigurationManager.OpenMappedExeConfiguration(
                    _fileMap, ConfigurationUserLevel.None);

            BiscuitsSettings section /* Get the configuration section */
                = config.GetSection(BiscuitSettingsSectionName) as BiscuitsSettings;

            // Assert
            Assert.AreEqual("testProvider", section.DefaultProvider);
        }

        [TestMethod]
        public void Test_NoProvidersAdded_ResultsIn_NoProviderElemnts()
        {
            // Arrange
            var expectedProviderCount = 0;
            var configFilename = @"NoProvidersAdded.config";
            var configFilePath = CreateConfigFilePath(_projectDirectoryPath, ConfigFileDirectoryName, configFilename);
            _fileMap.ExeConfigFilename = configFilePath;

            // Act
            Configuration config    /* get the configuration */
                = ConfigurationManager.OpenMappedExeConfiguration(
                    _fileMap, ConfigurationUserLevel.None);

            BiscuitsSettings section /* Get the configuration section */
                = config.GetSection(BiscuitSettingsSectionName) as BiscuitsSettings;

            // Assert
            Assert.AreEqual(expectedProviderCount, section.Providers.Count);
        }

        [TestMethod]
        public void Test_OneProvidersAdded_ResultsIn_OneProvidersElement()
        {
            // Arrange
            var expectedProviderCount = 1;
            var configFilename = @"OneProvidersAdded.config";
            var configFilePath = CreateConfigFilePath(_projectDirectoryPath, ConfigFileDirectoryName, configFilename);
            _fileMap.ExeConfigFilename = configFilePath;

            // Act
            Configuration config    /* get the configuration */
                = ConfigurationManager.OpenMappedExeConfiguration(
                    _fileMap, ConfigurationUserLevel.None);

            BiscuitsSettings section /* Get the configuration section */
                = config.GetSection(BiscuitSettingsSectionName) as BiscuitsSettings;

            // Assert
            Assert.AreEqual(expectedProviderCount, section.Providers.Count);
        }

        [TestMethod]
        public void Test_ThreeProvidersAdded_ResultsIn_ThreeProvidersElement()
        {
            // Arrange
            var expectedProviderCount = 3;
            var configFilename = @"ThreeProvidersAdded.config";
            var configFilePath = CreateConfigFilePath(_projectDirectoryPath, ConfigFileDirectoryName, configFilename);
            _fileMap.ExeConfigFilename = configFilePath;

            // Act
            Configuration config    /* get the configuration */
                = ConfigurationManager.OpenMappedExeConfiguration(
                    _fileMap, ConfigurationUserLevel.None);

            BiscuitsSettings section /* Get the configuration section */
                = config.GetSection(BiscuitSettingsSectionName) as BiscuitsSettings;

            // Assert
            Assert.AreEqual(expectedProviderCount, section.Providers.Count);
        }

        [TestMethod]
        public void Test_ThreeProvidersAddedThenCleared_ResultsIn_ZeroProvidersElement()
        {
            // Arrange
            var expectedProviderCount = 0;
            var configFilename = @"ThreeProvidersAddedThenCleared.config";
            var configFilePath = CreateConfigFilePath(_projectDirectoryPath, ConfigFileDirectoryName, configFilename);
            _fileMap.ExeConfigFilename = configFilePath;

            // Act
            Configuration config    /* get the configuration */
                = ConfigurationManager.OpenMappedExeConfiguration(
                    _fileMap, ConfigurationUserLevel.None);

            BiscuitsSettings section /* Get the configuration section */
                = config.GetSection(BiscuitSettingsSectionName) as BiscuitsSettings;

            // Assert
            Assert.AreEqual(expectedProviderCount, section.Providers.Count);
        }
        #endregion

        #region Helper Methods

        /// <summary>
        /// Creates the configuration file path.
        /// </summary>
        /// <param name="projectDirectoryPath">The project directory path.</param>
        /// <param name="configFileDirectoryName">Name of the configuration file directory.</param>
        /// <param name="configFilename">The name of the configuration file.</param>
        /// <returns></returns>
        private static String CreateConfigFilePath(String projectDirectoryPath, String configFileDirectoryName, String configFilename)
        {
            // Create the file path from the specified elements...
            var result = String.Concat(
                projectDirectoryPath,
                FilePathDelimiter,
                configFileDirectoryName,
                FilePathDelimiter,
                configFilename
            );

            // ... then ensure the file exists... 
            EnsureFileExists(result);

            // ... before returning it.
            return result;
        }

        /// <summary>
        /// Ensures the file at the specified path exists.
        /// </summary>
        /// <param name="filePath">The file path to check.</param>
        /// <exception cref="System.IO.FileNotFoundException">
        /// The file at the specified file path does not exist.
        /// </exception>
        private static void EnsureFileExists(String filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(filePath);
            }
        }

        /// <summary>
        /// Gets the project directory path.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NullReferenceException"></exception>
        private static String GetProjectDirectoryPath()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var parentDirectoryInfo = Directory.GetParent(currentDirectory).Parent;
            if (parentDirectoryInfo == null)
            {
                var errorMessage = "'parentDirectoryInfo' must not be null";
                throw new NullReferenceException(errorMessage);
            }
            var projectDirectory = parentDirectoryInfo.FullName;
            return projectDirectory;
        }

        #endregion
    }
}
