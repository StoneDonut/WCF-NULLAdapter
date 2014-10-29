// Copyright 2014 StoneDonut, LLC.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

/// -----------------------------------------------------------------------------------------------------------
/// Module      :  WcfNullAdapterConnectionFactory.cs
/// Description :  Defines the connection factory for the target system.
/// -----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.IdentityModel.Selectors;
using System.ServiceModel.Description;

using Microsoft.ServiceModel.Channels.Common;

namespace StoneDonut.Adapters.Null
{
    public class WcfNullAdapterConnectionFactory : IConnectionFactory
    {
        // Stores the client credentials
        private ClientCredentials clientCredentials;
        // Stores the adapter class
        private WcfNullAdapter adapter;
        private WcfNullAdapterConnectionUri connectionUri;

        /// <summary>
        /// Initializes a new instance of the WcfNullAdapterConnectionFactory class
        /// </summary>
        public WcfNullAdapterConnectionFactory(ConnectionUri connectionUri, ClientCredentials clientCredentials, WcfNullAdapter adapter)
        {
            this.clientCredentials = clientCredentials;
            this.adapter = adapter;
            this.connectionUri = connectionUri as WcfNullAdapterConnectionUri;
        }

        /// <summary>
        /// Gets the adapter
        /// </summary>
        public WcfNullAdapter Adapter
        {
            get
            {
                return this.adapter;
            }
        }

        /// <summary>
        /// Returns the client credentials
        /// </summary>
        public ClientCredentials ClientCredentials
        {
            get
            {
                return this.clientCredentials;
            }
        }

        /// <summary>
        /// Returns the Connection Uri for this adapter
        /// </summary>
        public WcfNullAdapterConnectionUri ConnectionUri
        {
            get
            {
                return this.connectionUri;
            }
        }

        /// <summary>
        /// Creates the connection to the target system
        /// </summary>
        public IConnection CreateConnection()
        {
            return new WcfNullAdapterConnection(this);
        }
    }
}
