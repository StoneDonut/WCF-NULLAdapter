/// -----------------------------------------------------------------------------------------------------------
/// Module      :  WcfNullAdapterBindingCollectionElement.cs
/// Description :  Binding Collection Element class which implements the StandardBindingCollectionElement
/// -----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Configuration;

using Microsoft.ServiceModel.Channels.Common;

namespace StoneDonut.Adapters.Null
{
    /// <summary>
    /// Initializes a new instance of the WcfNullAdapterBindingCollectionElement class
    /// </summary>
    public class WcfNullAdapterBindingCollectionElement : StandardBindingCollectionElement<WcfNullAdapterBinding, WcfNullAdapterBindingElement>
    {
    }
}

