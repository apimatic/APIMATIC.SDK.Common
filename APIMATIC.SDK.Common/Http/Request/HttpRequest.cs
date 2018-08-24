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
using System.Net.Http;

namespace APIMATIC.SDK.Http.Request
{
    public class HttpRequest
    {
        /// <summary>
        /// The HTTP verb to use for this request
        /// </summary>
        public HttpMethod HttpMethod { get; set; }

        /// <summary>
        /// The query url for the http request
        /// </summary>
        public string QueryUrl { get; set; }

        /// <summary>
        /// Headers collection for the current http request
        /// </summary>
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Form parameters for the current http request
        /// </summary>
        public List<KeyValuePair<string, object>> FormParameters { get; set; }

        /// <summary>
        /// Optional raw string to send as request body
        /// </summary>
        public object Body { get; set; }

        /// <summary>
        /// Optional username for Basic Auth
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Optional password for Basic Auth
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Constructor to initialize the http request obejct
        /// </summary>
        /// <param name="method">Http verb to use for the http request</param>
        /// <param name="queryUrl">The query url for the http request</param>
        public HttpRequest(HttpMethod method, string queryUrl)
        {
            this.HttpMethod = method;
            this.QueryUrl = queryUrl;
        }

        /// <summary>
        /// Constructor to initialize the http request with headers and optional Basic auth params
        /// </summary>
        /// <param name="method">Http verb to use for the http request</param>
        /// <param name="queryUrl">The query url for the http request</param>
        /// <param name="headers">Headers to send with the request</param>
        /// <param name="username">Basic auth username</param>
        /// <param name="password">Basic auth password</param>
        public HttpRequest(HttpMethod method, string queryUrl, Dictionary<string, string> headers, string username, string password)
            : this(method, queryUrl)
        {
            this.Headers = headers;
            this.Username = username;
            this.Password = password;
        }

        /// <summary>
        /// Constructor to initialize the http request with headers, body and optional Basic auth params
        /// </summary>
        /// <param name="method">Http verb to use for the http request</param>
        /// <param name="queryUrl">The query url for the http request</param>
        /// <param name="headers">Headers to send with the request</param>
        /// <param name="body">The string to use as raw body of the http request</param>
        /// <param name="username">Basic auth username</param>
        /// <param name="password">Basic auth password</param>
        public HttpRequest(HttpMethod method, string queryUrl, Dictionary<string, string> headers, object body, string username, string password)
            : this(method, queryUrl, headers, username, password)
        {
            this.Body = body;
        }

        /// <summary>
        /// Constructor to initialize the http request with headers, form parameters and optional Basic auth params
        /// </summary>
        /// <param name="method">Http verb to use for the http request</param>
        /// <param name="queryUrl">The query url for the http request</param>
        /// <param name="headers">Headers to send with the request</param>
        /// <param name="formParameters">Form parameters collection for the request</param>
        /// <param name="username">Basic auth username</param>
        /// <param name="password">Basic auth password</param>
        public HttpRequest(HttpMethod method, string queryUrl, Dictionary<string, string> headers, List<KeyValuePair<string, Object>> formParameters, string username, string password)
            : this(method, queryUrl, headers, username, password)
        {
            this.FormParameters = formParameters;
        }
    }
}
