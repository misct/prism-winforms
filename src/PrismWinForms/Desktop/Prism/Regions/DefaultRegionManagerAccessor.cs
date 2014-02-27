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
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Microsoft.Practices.Prism.Regions
{
    internal class DefaultRegionManagerAccessor : IRegionManagerAccessor
    {


        /// <summary>
        /// Notification used by attached behaviors to update the region managers appropriatelly if needed to.
        /// </summary>
        /// <remarks>This event uses weak references to the event handler to prevent this static event of keeping the
        /// target element longer than expected. For security reasons, to use weak delegates in Silverlight you must provide
        /// a delegate that is available in the public API of the class (no private or anonymous delegates allowed).</remarks>
        public event EventHandler UpdatingRegions
        {
            add { } //add { RegionManager.UpdatingRegions += value; }
            remove { } //remove { RegionManager.UpdatingRegions -= value; }
        }

        /// <summary>
        /// Gets the value for the RegionName attached property.
        /// </summary>
        /// <param name="element">The object to adapt. This is typically a container (i.e a control).</param>
        /// <returns>The name of the region that should be created when 
        /// the RegionManager is also set in this element.</returns>
        public string GetRegionName(object element)
        {
			if (element == null) throw new ArgumentNullException("element");
			var component = element as Component;
			if (component == null) throw new ArgumentException("Expected element of type System.ComponentModel.Component.", "element");

			return component.GetAssignedValue(RegionManager.RegionNameProperty) as string;
        }

        /// <summary>
        /// Gets the value of the RegionName attached property.
        /// </summary>
        /// <param name="element">The target element.</param>
        /// <returns>The <see cref="IRegionManager"/> attached to the <paramref name="element"/> element.</returns>
		public IRegionManager GetRegionManager(object element)
        {
            if (element == null) throw new ArgumentNullException("element");
			var component = element as Component;
			if (component == null) throw new ArgumentException("Expected element of type System.ComponentModel.Component.", "element");

			return component.GetAssignedValue(RegionManager.RegionManagerProperty) as IRegionManager;
        }
    }
}