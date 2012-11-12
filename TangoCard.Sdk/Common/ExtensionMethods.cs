//  
//  SdkConfig.cs
//  TangoCard_DotNet_SDK
//  
//  Copyright (c) 2012 Tango Card, Inc
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
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Runtime.Serialization;

namespace TangoCard.Sdk.Common
{
    internal static class ExtensionMethods
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A string extension method that queries if a null or is empty. </summary>
        ///
        /// <remarks>   Jeff, 11/12/2012. </remarks>
        ///
        /// <param name="text"> The text to act on. </param>
        ///
        /// <returns>   true if a null or is empty, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsNullOrEmpty(this string text)
        {
            return string.IsNullOrEmpty(text);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A string extension method that queries if a not null nor is empty. </summary>
        ///
        /// <remarks>   Jeff, 11/05/2012. </remarks>
        ///
        /// <param name="text"> The text to act on. </param>
        ///
        /// <returns>   true if a not null nor is empty, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsNotNullNorEmpty(this string text)
        {
            return !string.IsNullOrEmpty(text);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A JObject extension method that deserializes the given this JObject. </summary>
        ///
        /// <remarks>   Jeff, 11/12/2012. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="jObject">  The jObject to act on. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static T Deserialize<T>(this JObject jObject)
        {
            T result = default(T);

            try
            {
                DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(T));
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jObject.ToString()));

                result = (T)dcjs.ReadObject(ms);
            }
            catch (InvalidDataContractException ex)
            {
                throw new TangoCardSdkException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new TangoCardSdkException(ex.Message, ex);
            }
            return result;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A T extension method that serializes the given this T. </summary>
        ///
        /// <remarks>   Jeff, 11/12/2012. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="tObject">  The tObject to act on. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string Serialize<T>(this T tObject)
        {
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));

            ser.WriteObject(ms, tObject);

            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);

            string result = sr.ReadToEnd();
            return result;
        }

    }
}
