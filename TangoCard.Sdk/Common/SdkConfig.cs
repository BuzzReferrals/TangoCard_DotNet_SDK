using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;

namespace TangoCard.Sdk.Common
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Application configuration. </summary>
    ///
    /// <remarks>   Singleton </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class SdkConfig
    {
        private Configuration config = null;
        private static SdkConfig instance;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Constructor that prevents a default instance of this class from being created.
        /// </summary>
        ///
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private SdkConfig() 
        {
            string exeConfigPath = this.GetType().Assembly.Location;
            try
            {
                this.config = ConfigurationManager.OpenExeConfiguration(exeConfigPath);
            }
            catch (Exception ex)
            {
                throw new Exception(message: "Error opening DLL's configuration file.", innerException: ex);
            }

            if (null == this.config)
            {
                throw new NullReferenceException(message: "Failed opening DLL's configuration file.");
            }

            if (!File.Exists(this.config.FilePath))
            {
                throw new FileNotFoundException(message: this.config.FilePath);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the instance. </summary>
        ///
        /// <value> The instance. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static SdkConfig Instance
        {
            get
            {
                if (SdkConfig.instance == null)
                {
                    SdkConfig.instance = new SdkConfig();
                }

                return SdkConfig.instance;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Indexer to get items within this collection using array index syntax. </summary>
        ///
        /// <returns>   The indexed item. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string this[string key]
        {
            get
            {
                return this.getAppSetting(key);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets an application setting. </summary>
        ///
        /// <param name="config">   The configuration. </param>
        /// <param name="key">      The key. </param>
        ///
        /// <returns>   The application setting. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private string getAppSetting(string key)
        {
            if (String.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(paramName: "key");
            }
            if (null == this.config)
            {
                throw new NullReferenceException(message: "config");
            }

            KeyValueConfigurationElement element = this.config.AppSettings.Settings[key];
            if (element != null)
            {
                string value = element.Value;
                if (!string.IsNullOrEmpty(value))
                    return value;
            }
            return string.Empty;
        }
    }
}
