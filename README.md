WCF-NULLAdapter
===============

# Description

A /dev/null WCF LOB adapter binding for use with the BizTalk 2013 WCF-Custom adapter.

# Purpose

This binding is useful for situations where a system is sending a stream of messages to BizTalk and some of these messages will not have a subscriber. Instead of getting spurious routing errors this adapter can be used to subscribe to these messages and terminate them.
This project has the dual goals of being a learning experience for building a WCF LOB adapter and to create a NULL adapter with an explicit open source license.

# Limitations

This only functions as binding for the WCF-Custom adapter. I have been unable to find any documentation on registering an adapter built with the WCF LOB SDK as a physical adapter. Apparently Microsoft does not want developers to do this.
This adapter only supports outbound synchronous (one-way) communication. I cannot think of any scenarios where it would make sense to support inbound or asynchronous communication.

# Installation

## Prerequisites

For BizTalk 2013 you will need Visual Studion 2012 with the BizTalk developer tools installed to build the solution.

## Build and Install the Adapter

1. Open the solution in Visual Studio 2012 and build the assembly.
2. Open a Visual Studio commmand prompt and navigate to the folder with the adapter assembly.
3. Run `gacutil /i StoneDonut.Adapters.Null.dll` to place the compiled assembly into the GAC.
4. Run `installutil StoneDonut.Adapters.Null.dll` to create the custom event log source.

## Configure the Adapter

1. Add an entry to the bindingElementExtensions section of the machine.config file under C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config:
```xml
<bindingElementExtensions>
  ...
  <add name="nullAdapter" type="StoneDonut.Adapters.Null.WcfNullAdapterBindingElementExtensionElement, StoneDonut.Adapters.Null, Version=1.0.0.0, Culture=neutral, PublicKeyToken=7b5655597b4dca60" />
 </bindingElementExtensions>
```
2. Add an entry to the bindingExtensions section of the machine.config file under C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config:
```xml
<bindingExtensions>
  ...
  <add name="nullBinding" type="StoneDonut.Adapters.Null.WcfNullAdapterBindingCollectionElement, StoneDonut.Adapters.Null, Version=1.0.0.0, Culture=neutral, PublicKeyToken=7b5655597b4dca60" />
</bindingExtensions>
```
3. Repeat steps 1. and 2. for the machine.config file under C:\Windows\Microsoft.NET\Framework64\v4.0.30319\Config.

## Configure a Send Port

1. Open the BizTalk administration console.
2. Create a new static, one-way send port.
3. Choose the WCF-Custom adapter and click on the **Configure** button.
4. Under the **Binding** tab select **nullBinding** from the drop-down list.
5. (Optional) Enable the event log support by setting the **enableEventLog** property to **True**.

# Acknowledgements

Hat tip to Tomas Restrepo for his [nulladapter](https://github.com/tomasr/nulladapter) project for providing the inspiration to try this using the WCF LOB SDK.
