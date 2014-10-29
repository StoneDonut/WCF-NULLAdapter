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
/// Module      :  WcfNullAdapterOutboundHandler.cs
/// Description :  This class is used for sending data to the target system
/// -----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Channels;

using Microsoft.ServiceModel.Channels.Common;

namespace StoneDonut.Adapters.Null
{
    public class WcfNullAdapterOutboundHandler : WcfNullAdapterHandlerBase, IOutboundHandler
    {
        /// <summary>
        /// Initializes a new instance of the WcfNullAdapterOutboundHandler class
        /// </summary>
        public WcfNullAdapterOutboundHandler(WcfNullAdapterConnection connection, MetadataLookup metadataLookup) : base(connection, metadataLookup)
        {
        }

        /// <summary>
        /// Executes the request message on the target system and returns a response message.
        /// If there isn’t a response, this method should return null
        /// </summary>
        public Message Execute(Message message, TimeSpan timeout)
        {
            bool enableEventLog = this.Connection.ConnectionFactory.Adapter.EnableEventLog;

            WcfNullAdapterUtilities.Trace.Trace(System.Diagnostics.TraceEventType.Verbose, "http://Microsoft.Adapters.Samples.Sql/TraceCode/InputWcfMessage", "Input WCF Message", this, new MessageTraceRecord(message));

            if (enableEventLog)
            {
                string interchangeId = string.Format("{0}", message.Properties[WcfNullAdapterUtilities.InterchangeIdKey]);
                string messageId = string.Format("{0}", message.Properties[WcfNullAdapterUtilities.MessageIdKey]);
                string serviceInstanceId = string.Format("{0}", message.Properties[WcfNullAdapterUtilities.ServiceInstanceIdKey]);

                WcfNullAdapterUtilities.LogEvent(string.Format("The message with:\r\n\r\nInterchange ID: '{0}'\r\nMessage ID: '{1}'\r\nService Instance ID: '{2}'\r\n\r\n has been sent to /dev/null.", interchangeId, messageId, serviceInstanceId));
            }

            return null;
        }
    }
}
