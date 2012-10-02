//  
//  Program.cs
//  TangoCard_DotNet_SDK
//  
//  Example program using Tango Card SDK
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
using System.Collections.Generic;
using System.Configuration;

using System.Text;
using System.Net;

////////////////////////////////////////////////////////////////////////////////////////////////////
// namespace: TangoCard.Sdk.Examples
//
// summary:	Tango Card SDK Examples.
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace TangoCard.Sdk.Examples
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Example Console Application. </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class Program
    {
        static void Main(string[] args)
        {
            TangoCard_Store_Example.Execute();

            TangoCard_Failures_Example.Execute();

            Console.WriteLine("Press Any Key to Close this program.");

            Console.ReadLine();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tango Card store using application configuration. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
