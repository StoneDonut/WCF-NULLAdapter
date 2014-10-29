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

