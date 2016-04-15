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
    /// Delegate to handle the event on before http request. This event is raised before any
    /// network call is made, and can be used for logging, request modification, appending
    /// additional headers etc.
    /// </summary>
    /// <param name="source">The source HttpClient that is going to make the network call</param>
    /// <param name="request">The underlying HttpRequest being sent over the network</param>
    public delegate void OnBeforeHttpRequestEventHandler(IHttpClient source, HttpRequest request);

    /// <summary>
    /// Delegate to handle the event on after http response. This event is raised after any
    /// network response is recieved, and can be used for logging, response modification, extracting
    /// additional information etc.
    /// </summary>
    /// <param name="source">The source HttpClient that recieved the response from the network call</param>
    /// <param name="request">The underlying HttpResponse recieved from the network</param>
    public delegate void OnAfterHttpResponseEventHandler(IHttpClient source, HttpResponse response);
}
