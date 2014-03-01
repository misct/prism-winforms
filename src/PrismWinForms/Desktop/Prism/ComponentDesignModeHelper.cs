using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Microsoft.Practices.Prism
{
	public static class ComponentDesignModeHelper
	{
		public static bool IsInDesignMode(Component c)
		{
			return
				LicenseManager.UsageMode == LicenseUsageMode.Designtime;
		}

		public static bool IsInDesignMode(bool componentDesignMode)
		{
			return
				componentDesignMode ||
				LicenseManager.UsageMode == LicenseUsageMode.Designtime;
		}
	}
}
