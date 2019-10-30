// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Primitives
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents the Azure Active Directory token provider for Azure Managed Identity integration.
    /// </summary>
    public class ManagedIdentityTokenProvider : TokenProvider
    {

        /// <summary>
        /// Gets a <see cref="SecurityToken"/> for the given audience and duration.
        /// </summary>
        /// <param name="appliesTo">The URI which the access token applies to</param>
        /// <param name="timeout">The time span that specifies the timeout value for the message that gets the security token</param>
        /// <returns><see cref="SecurityToken"/></returns>
        public override Task<SecurityToken> GetTokenAsync(string appliesTo, TimeSpan timeout)
        {
            throw new NotImplementedException($"TODO: I removed this.");
        }
    }
}
