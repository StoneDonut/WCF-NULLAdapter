/// -----------------------------------------------------------------------------------------------------------
/// Module      :  WcfNullAdapterConnection.cs
/// Description :  Defines the connection to the target system.
/// -----------------------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

using Microsoft.ServiceModel.Channels.Common;

namespace StoneDonut.Adapters.Null
{
    public class WcfNullAdapterConnection : IConnection
    {
        private WcfNullAdapterConnectionFactory connectionFactory;
        private string connectionId;

        /// <summary>
        /// Initializes a new instance of the WcfNullAdapterConnection class with the WcfNullAdapterConnectionFactory
        /// </summary>
        public WcfNullAdapterConnection(WcfNullAdapterConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
            this.connectionId = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Gets the ConnectionFactory
        /// </summary>
        public WcfNullAdapterConnectionFactory ConnectionFactory
        {
            get
            {
                return this.connectionFactory;
            }
        }

        /// <summary>
        /// Closes the connection to the target system
        /// </summary>
        public void Close(TimeSpan timeout)
        {
            WcfNullAdapterUtilities.Trace.Trace(System.Diagnostics.TraceEventType.Information, "WcfNullAdapterConnection::Close", "Connection successfully closed!");
        }

        /// <summary>
        /// Returns a value indicating whether the connection is still valid
        /// </summary>
        public bool IsValid(TimeSpan timeout)
        {
            return true;

        }

        /// <summary>
        /// Opens the connection to the target system.
        /// </summary>
        public void Open(TimeSpan timeout)
        {
            WcfNullAdapterUtilities.Trace.Trace(System.Diagnostics.TraceEventType.Information, "WcfNullAdapterConnection::Open", "Connection successfully established!");

        }

        /// <summary>
        /// Clears the context of the Connection. This method is called when the connection is set back to the connection pool
        /// </summary>
        public void ClearContext()
        {
            
        }

        /// <summary>
        /// Builds a new instance of the specified IConnectionHandler type
        /// </summary>
        public TConnectionHandler BuildHandler<TConnectionHandler>(MetadataLookup metadataLookup)
             where TConnectionHandler : class, IConnectionHandler
        {

            if (typeof(IOutboundHandler).IsAssignableFrom(typeof(TConnectionHandler)))
            {
                return new WcfNullAdapterOutboundHandler(this, metadataLookup) as TConnectionHandler;
            }

            return default(TConnectionHandler);
        }

        /// <summary>
        /// Aborts the connection to the target system
        /// </summary>
        public void Abort()
        {
            
        }


        /// <summary>
        /// Gets the Id of the Connection
        /// </summary>
        public String ConnectionId
        {
            get
            {
                return connectionId;
            }
        }
    }
}
