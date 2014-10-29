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

