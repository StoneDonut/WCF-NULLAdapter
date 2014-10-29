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