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
