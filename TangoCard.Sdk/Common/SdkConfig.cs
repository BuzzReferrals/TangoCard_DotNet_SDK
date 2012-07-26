//  
//  SdkConfig.cs
//  TangoCard_DotNet_SDK
//  
//  © 2012 Tango Card, Inc
//  All rights reserved.
//
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions: 
//
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software. 
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
// 

using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;

namespace TangoCard.Sdk.Common
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Sdk configuration. </summary>
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
                throw new TangoCardSdkException(message: "Error opening DLL's configuration file.", innerException: ex);
            }

            if (null == this.config)
            {
                throw new TangoCardSdkException(message: "Failed opening DLL's configuration file.");
            }

            if (!File.Exists(this.config.FilePath))
            {
                throw new TangoCardSdkException(message: "SDK Configuration file not found: " + this.config.FilePath);
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
