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
/// Module      :  WcfNullAdapterTrace.cs
/// Description :  Implements adapter tracing
/// -----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Microsoft.ServiceModel.Channels.Common;

namespace StoneDonut.Adapters.Null
{
    // Use WcfNullAdapterUtilities.Trace in the code to trace the adapter
    public class WcfNullAdapterUtilities
    {
        //
        // Initializes a new instane of  Microsoft.ServiceModel.Channels.Common.AdapterTrace using the specified name for the source
        //
        static AdapterTrace trace = new AdapterTrace("WcfNullAdapter");
        public static readonly string InterchangeIdKey = "http://schemas.microsoft.com/BizTalk/2003/system-properties#InterchangeID";
        public static readonly string MessageIdKey = "http://schemas.microsoft.com/BizTalk/2003/system-properties#BizTalkMessageID";
        public static readonly string ServiceInstanceIdKey = "http://schemas.microsoft.com/BizTalk/2003/system-properties#TransmitInstanceID";

        /// <summary>
        /// Gets the AdapterTrace
        /// </summary>
        public static AdapterTrace Trace
        {
            get
            {
                return trace;
            }
        }

        public static void LogEvent(string message)
        {
            EventLog.WriteEntry(EventLogSourceInstaller.NullEventLogSource.SOURCE_NAME, message);
        }
    }
}

