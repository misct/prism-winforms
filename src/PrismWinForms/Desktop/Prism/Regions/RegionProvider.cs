using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Microsoft.Practices.Prism.Regions
{
	[ProvideProperty("RegionName", typeof(Control))]
	public class RegionProvider : Component, IExtenderProvider
	{
		public RegionProvider(IContainer container)
		{
			container.Add(this);
		}

		public bool CanExtend(object extendee)
		{
			return (extendee is Control);
		}

		protected bool DesignModeSafe
		{
			get
			{
				return
					base.DesignMode ||
					LicenseManager.UsageMode == LicenseUsageMode.Designtime;
			}
		}

		[Bindable(false)]
		[DefaultValue((string)null)]
		public string GetRegionName(Control control)
		{
			return control.GetAssignedValue(RegionManager.RegionNameProperty) as string;
		}

		public void SetRegionName(Control control, string value)
		{
			control.SetAssignedValue(RegionManager.RegionNameProperty, value);
		}

		public IRegionManager GetRegionManager(Control control)
		{
			return control.GetAssignedValue(RegionManager.RegionManagerProperty) as IRegionManager;
		}

		public void SetRegionManager(Control control, IRegionManager value)
		{
			control.SetAssignedValue(RegionManager.RegionManagerProperty, value);
		}
	}
}
