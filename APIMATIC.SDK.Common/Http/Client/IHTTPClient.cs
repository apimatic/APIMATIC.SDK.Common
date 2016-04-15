/*****************************************************************************
The MIT License (MIT)

Copyright (c) 2016 APIMATIC Limited ( https://apimatic.io )

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*****************************************************************************/

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIMATIC.SDK.Http.Request;
using APIMATIC.SDK.Http.Response;

namespace APIMATIC.SDK.Http.Client
{
    public interface IHttpClient
    {
        /// <summary>
        /// Event raised before an Http request is sent over the network
        /// This event can be used for logging, request modification, appending
        /// additional headers etc.
        /// </summary>        
        event OnBeforeHttpRequestEventHandler OnBeforeHttpRequestEvent;

        /// <summary>
        /// Event raised after an Http response is recieved from the network.
        /// This event can be used for logging, response modification, extracting
        /// additional information etc.
        /// </summary>
        event OnAfterHttpResponseEventHandler OnAfterHttpResponseEvent;

        /// <summary>
        /// Execute a given HttpRequest to get string response back
        /// </summary>
        /// <param name="request">The given HttpRequest to execute</param>
        /// <returns> HttpResponse containing raw information</returns>
        HttpResponse ExecuteAsString(HttpRequest request);

        /// <summary>
        /// Execute a given HttpRequest to get binary response back
        /// </summary>
        /// <param name="request">The given HttpRequest to execute</param>
        /// <returns> HttpResponse containing raw information</returns>
        HttpResponse ExecuteAsBinary(HttpRequest request);

        /// <summary>
        /// Execute a given HttpRequest to get async string response back
        /// </summary>
        /// <param name="request">The given HttpRequest to execute</param>
        /// <returns> HttpResponse containing raw information</returns>
        Task<HttpResponse> ExecuteAsStringAsync(HttpRequest request);

        /// <summary>
        /// Execute a given HttpRequest to get async binary response back
        /// </summary>
        /// <param name="request">The given HttpRequest to execute</param>
        /// <returns> HttpResponse containing raw information</returns>
        Task<HttpResponse> ExecuteAsBinaryAsync(HttpRequest request);

        /// <summary>
        /// Create a simple HTTP GET request given the URL
        /// </summary>
        /// <param name="queryUrl">Url the request should be sent to</param>
        /// <returns>HttpRequest initialised with the url specified</returns>
        HttpRequest Get(string queryUrl);

        /// <summary>
        /// Create a simple HTTP POST request given the URL
        /// </summary>
        /// <param name="queryUrl">Url the request should be sent to</param>
        /// <returns> HttpRequest initialised with the url specified</returns>
        HttpRequest Post(string queryUrl);

        /// <summary>
        /// Create a simple HTTP PUT request given the URL
        /// </summary>
        /// <param name="queryUrl">Url the request should be sent to</param>
        /// <returns> HttpRequest initialised with the url specified</returns>
        HttpRequest Put(string queryUrl);

        /// <summary>
        /// Create a simple HTTP DELETE request given the URL
        /// </summary>
        /// <param name="queryUrl">Url the request should be sent to</param>
        /// <returns> HttpRequest initialised with the url specified</returns>
        HttpRequest Delete(string queryUrl);

        /// <summary>
        /// Create a simple HTTP PATCH request given the URL
        /// </summary>
        /// <param name="queryUrl">Url the request should be sent to</param>
        /// <returns> HttpRequest initialised with the url specified</returns>
        HttpRequest Patch(string queryUrl);

        /// <summary>
        /// Create a simple HTTP GET request given relavent parameters
        /// </summary>
        /// <param name="queryUrl">Url the request should be sent to</param>
        /// <param name="headers">HTTP headers that should be included</param>
        /// <param name="username">Basic Auth username</param>
        /// <param name="password">Basic Auth password</param>
        /// <returns> HttpRequest initialised with the http parameters specified</returns>
        HttpRequest Get(string queryUrl, Dictionary<string, string> headers, string username = null, string password = null);

        /// <summary>
        ///  Create a simple HTTP POST request given relavent parameters
        /// </summary>
        /// <param name="queryUrl">Url the request should be sent to</param>
        /// <param name="headers">HTTP headers that should be included</param>
        /// <param name="formParameters">Form parameters to be included</param>
        /// <param name="username">Basic Auth username</param>
        /// <param name="password">Basic Auth password</param>
        /// <returns> HttpRequest initialised with the http parameters specified</returns>
        HttpRequest Post(string queryUrl, Dictionary<string, string> headers, Dictionary<string, Object> formParameters,
           string username = null, string password = null);

        /// <summary>
        /// Create a simple HTTP POST with a body request given relavent parameters
        /// </summary>
        /// <param name="queryUrl">Url the request should be sent to</param>
        /// <param name="headers">HTTP headers that should be included</param>
        /// <param name="body">The body/payload of the response</param>
        /// <param name="username">Basic Auth username</param>
        /// <param name="password">Basic Auth password</param>
        /// <returns> HttpRequest initialised with the http parameters specified</returns>
        HttpRequest PostBody(string queryUrl, Dictionary<string, string> headers, string body,
            string username = null, string password = null);

        /// <summary>
        ///  Create a simple HTTP PUT request given relavent parameters
        /// </summary>
        /// <param name="queryUrl">Url the request should be sent to</param>
        /// <param name="headers">HTTP headers that should be included</param>
        /// <param name="formParameters">Form parameters to be included</param>
        /// <param name="username">Basic Auth username</param>
        /// <param name="password">Basic Auth password</param>
        /// <returns> HttpRequest initialised with the http parameters specified</returns>
        HttpRequest Put(string queryUrl, Dictionary<string, string> headers, Dictionary<string, Object> formParameters,
            string username = null, string password = null);

        /// <summary>
        /// Create a simple HTTP PUT with a body request given relavent parameters
        /// </summary>
        /// <param name="queryUrl">Url the request should be sent to</param>
        /// <param name="headers">HTTP headers that should be included</param>
        /// <param name="body">The body/payload of the response</param>
        /// <param name="username">Basic Auth username</param>
        /// <param name="password">Basic Auth password</param>
        /// <returns> HttpRequest initialised with the http parameters specified</returns>
        HttpRequest PutBody(string queryUrl, Dictionary<string, string> headers, string body,
            string username = null, string password = null);

        /// <summary>
        ///  Create a simple HTTP PATCH request given relavent parameters
        /// </summary>
        /// <param name="queryUrl">Url the request should be sent to</param>
        /// <param name="headers">HTTP headers that should be included</param>
        /// <param name="formParameters">Form parameters to be included</param>
        /// <param name="username">Basic Auth username</param>
        /// <param name="password">Basic Auth password</param>
        /// <returns> HttpRequest initialised with the http parameters specified</returns>
        HttpRequest Patch(string queryUrl, Dictionary<string, string> headers, Dictionary<string, Object> formParameters,
            string username = null, string password = null);

        /// <summary>
        /// Create a simple HTTP Patch with a body request given relavent parameters
        /// </summary>
        /// <param name="queryUrl">Url the request should be sent to</param>
        /// <param name="headers">HTTP headers that should be included</param>
        /// <param name="body">The body/payload of the response</param>
        /// <param name="username">Basic Auth username</param>
        /// <param name="password">Basic Auth password</param>
        /// <returns> HttpRequest initialised with the http parameters specified</returns>
        HttpRequest PatchBody(string queryUrl, Dictionary<string, string> headers, string body,
            string username = null, string password = null);

        /// <summary>
        ///  Create a simple HTTP DELETE request given relavent parameters
        /// </summary>
        /// <param name="queryUrl">Url the request should be sent to</param>
        /// <param name="headers">HTTP headers that should be included</param>
        /// <param name="formParameters">Form parameters to be included</param>
        /// <param name="username">Basic Auth username</param>
        /// <param name="password">Basic Auth password</param>
        /// <returns> HttpRequest initialised with the http parameters specified</returns>
        HttpRequest Delete(string queryUrl, Dictionary<string, string> headers, Dictionary<string, Object> formParameters,
            string username = null, string password = null);

        /// <summary>
        /// Create a simple HTTP Delete with a body request given relavent parameters
        /// </summary>
        /// <param name="queryUrl">Url the request should be sent to</param>
        /// <param name="headers">HTTP headers that should be included</param>
        /// <param name="body">The body/payload of the response</param>
        /// <param name="username">Basic Auth username</param>
        /// <param name="password">Basic Auth password</param>
        /// <returns> HttpRequest initialised with the http parameters specified</returns>
        HttpRequest DeleteBody(string queryUrl, Dictionary<string, string> headers, string body,
            string username = null, string password = null);
    }
}

