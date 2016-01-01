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

using APIMATIC.SDK.Http.Request;
using APIMATIC.SDK.Http.Response;

namespace APIMATIC.SDK.Http.Client
{
    /// <summary>
    /// Represents the contextual information of HTTP request and response
    /// </summary>
    public class HttpContext
    {
        /// <summary>
        /// The http request in the current context
        /// </summary>
        public HttpRequest Request { get; set; }

        /// <summary>
        /// The http response in the current context
        /// </summary>
        public HttpResponse Response { get; set; }

        /// <summary>
        /// Constructor to initialize the context with http request and response information
        /// </summary>
        /// <param name="request">The http request in the current context</param>
        /// <param name="response">The http response in the current context</param>
		public HttpContext(HttpRequest request, HttpResponse response)
        {
            Request = request;
            Response = response;
        }
    }
}
