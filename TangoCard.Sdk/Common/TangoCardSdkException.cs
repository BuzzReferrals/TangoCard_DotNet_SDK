//
//  TangoCardSdkException.cs
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
//

using System;
using System.Runtime.Serialization;

namespace TangoCard.Sdk.Common
{
    /// <summary>
    /// TangoCardSdkException is thrown when the Tango Card SDK has detected an error within its code, regardless of any given Request.
    /// </summary>
    [Serializable]
    public class TangoCardSdkException : System.Exception
    {
         ////////////////////////////////////////////////////////////////////////////////////////////////////
         /// <summary>  Constructor. </summary>
         ///
         /// <param name="errorMessage">    Message describing the error. </param>
         ////////////////////////////////////////////////////////////////////////////////////////////////////

        public TangoCardSdkException(string message)
             : base(message: message)
         {

         }

         ////////////////////////////////////////////////////////////////////////////////////////////////////
         /// <summary>  Constructor. </summary>
         ///
         /// <param name="errorMessage">    Message describing the error. </param>
         /// <param name="innerExc">        The inner exc. </param>
         ////////////////////////////////////////////////////////////////////////////////////////////////////

         public TangoCardSdkException(string message, System.Exception innerException)
             : base(message: message, innerException: innerException)
         {

         }

         ////////////////////////////////////////////////////////////////////////////////////////////////////
         /// <summary>  Specialised constructor for use only by derived classes. </summary>
         ///
         /// <param name="si">  The si. </param>
         /// <param name="sc">  The screen. </param>
         ////////////////////////////////////////////////////////////////////////////////////////////////////

         protected TangoCardSdkException(SerializationInfo si,  StreamingContext sc)
             : base( info: si, context: sc)
         {

         }

         ////////////////////////////////////////////////////////////////////////////////////////////////////
         /// <summary>  Default constructor. </summary>
         ////////////////////////////////////////////////////////////////////////////////////////////////////

         public TangoCardSdkException()
             : base()
         {
         }
    }
}