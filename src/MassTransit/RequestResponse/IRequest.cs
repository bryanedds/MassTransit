﻿// Copyright 2007-2011 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit.RequestResponse
{
    using System;

    public interface IRequest :
        IAsyncResult
    {
        /// <summary>
        /// Identifies the request for matching up request/response messages
        /// </summary>
        string RequestId { get; }

        /// <summary>
        /// Wait for the request to complete. If the timeout expires, the request
        /// completes and the timeout callback is called.
        /// </summary>
        /// <returns>True if the request completed before the timeout expired</returns>
        bool Wait();

        /// <summary>
        /// Wait for the request to complete. If the timeout expires, the request
        /// completes and the timeout callback is called.
        /// </summary>
        /// <param name="timeout">The timeout for the request</param>
        /// <returns>True if the request completed before the timeout expired</returns>
        bool Wait(TimeSpan timeout);

        /// <summary>
        /// Begins the request as an asynchronous operation
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        IAsyncResult BeginAsync(AsyncCallback callback, object state);
    }

    public interface IRequest<T> :
        IRequest
        where T : class
    {
    }
}