/// -----------------------------------------------------------------------------------------------------------
/// Module      :  WcfNullAdapterBinding.cs
/// Description :  This is the class used while creating a binding for an adapter
/// -----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;

using Microsoft.ServiceModel.Channels.Common;

namespace StoneDonut.Adapters.Null
{
    public class WcfNullAdapterBinding : AdapterBinding
    {
        // Scheme in Binding does not have to be the same as Adapter Scheme. 
        // Over write this value as appropriate.
        private const string BindingScheme = "null";

        /// <summary>
        /// Initializes a new instance of the AdapterBinding class
        /// </summary>
        public WcfNullAdapterBinding() { }

        /// <summary>
        /// Initializes a new instance of the AdapterBinding class with a configuration name
        /// </summary>
        public WcfNullAdapterBinding(string configName)
        {
            ApplyConfiguration(configName);
        }

        /// <summary>
        /// Applies the current configuration to the WcfNullAdapterBindingCollectionElement
        /// </summary>
        private void ApplyConfiguration(string configurationName)
        {
            /*
            //
            // TODO : replace the <The config name of your adapter> below with the configuration name of your adapter
            //
            BindingsSection bindingsSection = (BindingsSection)System.Configuration.ConfigurationManager.GetSection("system.serviceModel/bindings");
            WcfNullAdapterBindingCollectionElement bindingCollectionElement = (WcfNullAdapterBindingCollectionElement)bindingsSection["<The config name of your adapter>"];
            WcfNullAdapterBindingElement element = bindingCollectionElement.Bindings[configurationName];
            if (element != null)
            {
                element.ApplyConfiguration(this);
            }
            */
            throw new NotImplementedException("The method or operation is not implemented.");
        }

        private WcfNullAdapter binding;

        private bool enableEventLog;

        /// <summary>
        /// Gets the URI transport scheme that is used by the channel and listener factories that are built by the bindings.
        /// </summary>
        public override string Scheme
        {
            get
            {
                return BindingScheme;
            }
        }

        /// <summary>
        /// Returns a value indicating whether this binding supports metadata browsing.
        /// </summary>
        public override bool SupportsMetadataBrowse
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Returns a value indicating whether this binding supports metadata retrieval.
        /// </summary>
        public override bool SupportsMetadataGet
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Returns a value indicating whether this binding supports metadata searching.
        /// </summary>
        public override bool SupportsMetadataSearch
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the custom type of the ConnectionUri.
        /// </summary>
        public override Type ConnectionUriType
        {
            get
            {
                return typeof(WcfNullAdapterConnectionUri);
            }
        }

        [System.Configuration.ConfigurationProperty("enableEventLog", DefaultValue = false)]
        public bool EnableEventLog
        {
            get
            {
                return this.enableEventLog;
            }
            set
            {
                this.enableEventLog = value;
            }
        }

        private WcfNullAdapter BindingElement
        {
            get
            {
                if (binding == null)
                    binding = new WcfNullAdapter();
                binding.EnableEventLog = this.EnableEventLog;
                return binding;
            }
        }

        /// <summary>
        /// Creates a clone of the existing BindingElement and returns it
        /// </summary>
        public override BindingElementCollection CreateBindingElements()
        {
            BindingElementCollection bindingElements = new BindingElementCollection();
            //Only create once
            bindingElements.Add(this.BindingElement);
            //Return the clone
            return bindingElements.Clone();
        }
    }
}
