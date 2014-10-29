/// -----------------------------------------------------------------------------------------------------------
/// Module      :  WcfNullAdapterConnectionUri.cs
/// Description :  This is the class for representing an adapter connection uri
/// -----------------------------------------------------------------------------------------------------------

using System;

using Microsoft.ServiceModel.Channels.Common;

namespace StoneDonut.Adapters.Null
{
    /// <summary>
    /// This is the class for building the WcfNullAdapterConnectionUri
    /// </summary>
    public class WcfNullAdapterConnectionUri : ConnectionUri
    {
        private string portName = null;

        /// <summary>
        /// Initializes a new instance of the ConnectionUri class
        /// </summary>
        public WcfNullAdapterConnectionUri()
        {
            Uri = new Uri("null://portname");
        }

        /// <summary>
        /// Initializes a new instance of the ConnectionUri class with a Uri object
        /// </summary>
        public WcfNullAdapterConnectionUri(Uri uri) : base()
        {
            Uri = uri;
        }

        [System.ComponentModel.Category("Connection")]
        [System.ComponentModel.Description("A unique name for this port.")]
        public string PortName
        {
            get
            {
                return this.portName;
            }
            set
            {
                this.portName = value;
            }
        }

        /// <summary>
        /// Getter and Setter for the Uri
        /// </summary>
        public override Uri Uri
        {
            get
            {
                if (string.IsNullOrEmpty(this.portName)) throw new InvalidUriException("Invalid port name.");

                return new Uri(string.Format("{0}://{1}", WcfNullAdapter.SCHEME, PortName));
            }

            set
            {
                this.portName = value.Host;
            }
        }
    }
}