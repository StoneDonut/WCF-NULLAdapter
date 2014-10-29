/// -----------------------------------------------------------------------------------------------------------
/// Module      :  WcfNullAdapterBindingElement.cs
/// Description :  Provides a base class for the configuration elements.
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
    public class WcfNullAdapterBindingElement : StandardBindingElement
    {
        private ConfigurationPropertyCollection properties;

        /// <summary>
        /// Initializes a new instance of the WcfNullAdapterBindingElement class
        /// </summary>
        public WcfNullAdapterBindingElement() : base(null)
        {
        }


        /// <summary>
        /// Initializes a new instance of the WcfNullAdapterBindingElement class with a configuration name
        /// </summary>
        public WcfNullAdapterBindingElement(string configurationName) : base(configurationName)
        {
        }

        [System.ComponentModel.Category("Debug")]
        [System.ComponentModel.Description("Write a message to the event log every time a message is sent to /dev/null.")]
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
        /// Gets the type of the BindingElement
        /// </summary>
        protected override Type BindingElementType
        {
            get
            {
                return typeof(WcfNullAdapterBinding);
            }
        }

        /// <summary>
        /// Initializes the binding with the configuration properties
        /// </summary>
        protected override void InitializeFrom(Binding binding)
        {
            base.InitializeFrom(binding);
            WcfNullAdapterBinding adapterBinding = (WcfNullAdapterBinding)binding;
            this["EnableEventLog"] = adapterBinding.EnableEventLog;
        }

        /// <summary>
        /// Applies the configuration
        /// </summary>
        protected override void OnApplyConfiguration(Binding binding)
        {
            if (binding == null)
                throw new ArgumentNullException("binding");

            WcfNullAdapterBinding adapterBinding = (WcfNullAdapterBinding)binding;
            adapterBinding.EnableEventLog = (System.Boolean)this["EnableEventLog"];
        }

        /// <summary>
        /// Returns a collection of the configuration properties
        /// </summary>
        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                if (this.properties == null)
                {
                    ConfigurationPropertyCollection configProperties = base.Properties;
                    configProperties.Add(new ConfigurationProperty("EnableEventLog", typeof(System.Boolean), false, null, null, ConfigurationPropertyOptions.None));
                    this.properties = configProperties;
                }
                return this.properties;
            }
        }
    }
}
