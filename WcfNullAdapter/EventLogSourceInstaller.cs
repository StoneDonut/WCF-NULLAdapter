using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;
using System.Diagnostics;

namespace StoneDonut.Adapters.Null
{
    [RunInstaller(true)]
    public partial class EventLogSourceInstaller : Installer
    {
        public EventLogSourceInstaller()
        {
        }

        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            NullEventLogSource.Create();
        }

        public override void Rollback(System.Collections.IDictionary savedState)
        {
            base.Rollback(savedState);
            NullEventLogSource.Delete();
        }

        public class NullEventLogSource
        {
            public const string SOURCE_NAME = "WCF-NULL Adapter";
            private const string LOG_NAME = "Application";

            public static void Create()
            {
                if (!EventLog.SourceExists(SOURCE_NAME))
                {
                    EventLog.CreateEventSource(SOURCE_NAME, LOG_NAME);
                }
            }

            public static void Delete()
            {
                if (EventLog.SourceExists(SOURCE_NAME))
                {
                    EventLog.DeleteEventSource(SOURCE_NAME);
                }
            }
        }
    }
}
