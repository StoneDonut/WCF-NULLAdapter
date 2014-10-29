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
/// Module      :  WcfNullAdapterBindingElementExtensionElement.cs
/// Description :  This class is provided to surface Adapter as a binding element, so that it 
///                can be used within a user-defined WCF "Custom Binding".
///                In configuration file, it is defined under
///                <system.serviceModel>
///                  <extensions>
///                     <bindingElementExtensions>
///                         <add name="{name}" type="{this}, {assembly}"/>
///                     </bindingElementExtensions>
///                  </extensions>
///                </system.serviceModel>
/// -----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Channels;
using System.Configuration;
using System.Globalization;

using Microsoft.ServiceModel.Channels.Common;

namespace StoneDonut.Adapters.Null
{
    using System;
    using System.Configuration;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Configuration;

    public class WcfNullAdapterBindingElementExtensionElement : BindingElementExtensionElement
    {

        /// <summary>
        /// Default constructor
        /// </summary>
        public WcfNullAdapterBindingElementExtensionElement()
        {
        }

        [System.Configuration.ConfigurationProperty("enableEventLog", DefaultValue = false)]
        public bool EnableEventLog
        {
            get
            {
                return ((bool)(base["EnableEventLog"]));
            }
            set
            {
                base["EnableEventLog"] = value;
            }
        }
        
        /// <summary>
        /// Return the type of the adapter (binding element)
        /// </summary>
        public override Type BindingElementType
        {
            get
            {
                return typeof(WcfNullAdapter);
            }
        }
        /// <summary>
        /// Returns a collection of the configuration properties
        /// </summary>
        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                ConfigurationPropertyCollection configProperties = base.Properties;
                configProperties.Add(new ConfigurationProperty("EnableEventLog", typeof(System.Boolean), false, null, null, ConfigurationPropertyOptions.None));
                return configProperties;
            }
        }

        /// <summary>
        /// Instantiate the adapter.
        /// </summary>
        /// <returns></returns>
        protected override BindingElement CreateBindingElement()
        {
            WcfNullAdapter adapter = new WcfNullAdapter();
            this.ApplyConfiguration(adapter);
            return adapter;
        }

        /// <summary>
        /// Apply the configuration properties to the adapter.
        /// </summary>
        /// <param name="bindingElement"></param>
        public override void ApplyConfiguration(BindingElement bindingElement)
        {
            base.ApplyConfiguration(bindingElement);
            WcfNullAdapter adapterBinding = ((WcfNullAdapter)(bindingElement));
            adapterBinding.EnableEventLog = (System.Boolean)this["EnableEventLog"];
        }

        /// <summary>
        /// Initialize the binding properties from the adapter.
        /// </summary>
        /// <param name="bindingElement"></param>
        protected override void InitializeFrom(BindingElement bindingElement)
        {
            base.InitializeFrom(bindingElement);
            WcfNullAdapter adapterBinding = ((WcfNullAdapter)(bindingElement));
            this["EnableEventLog"] = adapterBinding.EnableEventLog;
        }

        /// <summary>
        /// Copy the properties to the custom binding
        /// </summary>
        /// <param name="from"></param>
        public override void CopyFrom(ServiceModelExtensionElement from)
        {
            base.CopyFrom(from);
            WcfNullAdapterBindingElementExtensionElement adapterBinding = ((WcfNullAdapterBindingElementExtensionElement)(from));
            this["EnableEventLog"] = adapterBinding.EnableEventLog;
        }
    }
}

