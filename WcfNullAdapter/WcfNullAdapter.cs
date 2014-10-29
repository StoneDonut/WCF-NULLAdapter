/// -----------------------------------------------------------------------------------------------------------
/// Module      :  WcfNullAdapter.cs
/// Description :  The main adapter class which inherits from Adapter
/// -----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Description;

using Microsoft.ServiceModel.Channels.Common;

namespace StoneDonut.Adapters.Null
{
    public class WcfNullAdapter : Adapter
    {
        // Scheme associated with the adapter
        internal const string SCHEME = "null";
        // Namespace for the proxy that will be generated from the adapter schema
        internal const string SERVICENAMESPACE = "null://stonedonut.adapters.null";
        // Initializes the AdapterEnvironmentSettings class
        private static AdapterEnvironmentSettings environmentSettings = new AdapterEnvironmentSettings();

        private bool enableEventLog;

        /// <summary>
        /// Initializes a new instance of the WcfNullAdapter class
        /// </summary>
        public WcfNullAdapter() : base(environmentSettings)
        {
            Settings.Metadata.DefaultMetadataNamespace = SERVICENAMESPACE;
        }

        /// <summary>
        /// Initializes a new instance of the WcfNullAdapter class with a binding
        /// </summary>
        public WcfNullAdapter(WcfNullAdapter binding) : base(binding)
        {
            this.EnableEventLog = binding.EnableEventLog;
        }

        [System.Configuration.ConfigurationProperty("enableEventLog", DefaultValue = false)]
        public bool EnableEventLog
        {
            get
            {
                return this.enableEventLog;
            }
            set
            {
                this.enableEventLog = value;
            }
        }

        /// <summary>
        /// Gets the URI transport scheme that is used by the adapter
        /// </summary>
        public override string Scheme
        {
            get
            {
                return SCHEME;
            }
        }

        /// <summary>
        /// Creates a ConnectionUri instance from the provided Uri
        /// </summary>
        protected override ConnectionUri BuildConnectionUri(Uri uri)
        {
            return new WcfNullAdapterConnectionUri(uri);
        }

        /// <summary>
        /// Builds a connection factory from the ConnectionUri and ClientCredentials
        /// </summary>
        protected override IConnectionFactory BuildConnectionFactory(ConnectionUri connectionUri, ClientCredentials clientCredentials, System.ServiceModel.Channels.BindingContext context)
        {
            return new WcfNullAdapterConnectionFactory(connectionUri, clientCredentials, this);
        }

        /// <summary>
        /// Returns a clone of the adapter object
        /// </summary>
        protected override Adapter CloneAdapter()
        {
            return new WcfNullAdapter(this);
        }

        /// <summary>
        /// Indicates whether the provided TConnectionHandler is supported by the adapter or not
        /// </summary>
        protected override bool IsHandlerSupported<TConnectionHandler>()
        {
            return (
                  typeof(IOutboundHandler) == typeof(TConnectionHandler));
        }

        /// <summary>
        /// Gets the namespace that is used when generating schema and WSDL
        /// </summary>
        protected override string Namespace
        {
            get
            {
                return SERVICENAMESPACE;
            }
        }
    }
}
