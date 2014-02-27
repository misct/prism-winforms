using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Practices.Prism.Regions
{
	public class RegionManager
	{
		#region Static members (for WinForms support)

		public static readonly AssignedProperty RegionManagerProperty = AssignedProperty.RegisterAssigned(
			"RegionManager",
			typeof(IRegionManager),
			typeof(RegionManager)
		);

		public static readonly AssignedProperty RegionNameProperty = AssignedProperty.RegisterAssigned(
			"RegionName",
			typeof(string),
			typeof(RegionManager),
			new PropertyMetaData(OnSetRegionNameCallback)
		);

		private static void OnSetRegionNameCallback(System.ComponentModel.Component c, AssignedPropertyChangedEventArgs e)
		{
			System.Diagnostics.Debug.Print("OnSetRegionNameCallback: {0}.{1} = {2}", 
				c.GetType().Name, e.Property.Name, e.NewValue ?? "null");
			// CreateRegion(element);
		}

		#endregion
	}
}
