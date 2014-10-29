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
