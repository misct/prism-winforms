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
		Dictionary<Control, string> _regionNames = new Dictionary<Control,string>();

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
			string value;
			_regionNames.TryGetValue(control, out value);
			return value;
		}

		public void SetRegionName(Control control, string value)
		{
			if (value == null)
				_regionNames.Remove(control);
			else
				_regionNames[control] = value;
		}
	}
}
