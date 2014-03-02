//===================================================================================
// Microsoft patterns & practices
// Composite Application Guidance for Windows Presentation Foundation
//===================================================================================
// Copyright (c) Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//===================================================================================
using System;

namespace Microsoft.Practices.Prism.Regions
{
	/// <summary>
	/// Defines a class that wraps an item and adds metadata for it.
	/// </summary>
	public class ItemMetadata
	{
		/// <summary>
		/// Initializes a new instance of <see cref="ItemMetadata"/>.
		/// </summary>
		/// <param name="item">The item to wrap.</param>
		public ItemMetadata(object item)
		{
			// check for null
			this.Item = item;
		}

		/// <summary>
		/// Gets the wrapped item.
		/// </summary>
		/// <value>The wrapped item.</value>
		public object Item { get; private set; }

		/// <summary>
		/// Gets or sets a name for the wrapped item.
		/// </summary>
		/// <value>The name of the wrapped item.</value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the wrapped item is considered active.
		/// </summary>
		/// <value><see langword="true" /> if the item should be considered active; otherwise <see langword="false" />.</value>
		public bool IsActive { get; set; }

		/// <summary>
		/// Occurs when metadata on the item changes.
		/// </summary>
		public event EventHandler MetadataChanged;

		/// <summary>
		/// Explicitly invokes <see cref="MetadataChanged"/> to notify listeners.
		/// </summary>
		public void InvokeMetadataChanged()
		{
			EventHandler metadataChangedHandler = MetadataChanged;
			if (metadataChangedHandler != null) metadataChangedHandler(this, EventArgs.Empty);
		}
	}
}