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
/// Module      :  WcfNullAdapterHandlerBase.cs
/// Description :  This is the base class for handlers used to store common properties/helper functions
/// -----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.ServiceModel.Channels.Common;

namespace StoneDonut.Adapters.Null
{
    public abstract class WcfNullAdapterHandlerBase
    {
        private WcfNullAdapterConnection connection;
        private MetadataLookup metadataLookup;

        protected WcfNullAdapterHandlerBase(WcfNullAdapterConnection connection
            , MetadataLookup metadataLookup)
        {
            this.connection = connection;
            this.metadataLookup = metadataLookup;
        }

        public WcfNullAdapterConnection Connection
        {
            get
            {
                return this.connection;
            }
        }

        public MetadataLookup MetadataLookup
        {
            get
            {
                return this.metadataLookup;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            
        }
    }
}

