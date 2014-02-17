using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Microsoft.Practices.Prism.Mvvm
{
	[ProvideProperty("AutoWireViewModel", typeof(Control))]
	public class ViewModelLocator : Component, IExtenderProvider
	{
		HashSet<Control> _designerAutoWireViewModelValue;

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
		[DefaultValue(false)]
		public bool GetAutoWireViewModel(Control control)
		{
			if (DesignModeSafe)
			{
				if (_designerAutoWireViewModelValue != null)
					return _designerAutoWireViewModelValue.Contains(control);
				else
					return false;
			}
			return false;
		}

		public void SetAutoWireViewModel(Control control, bool value)
		{
			if (DesignModeSafe)
			{
				if (_designerAutoWireViewModelValue == null)
					_designerAutoWireViewModelValue = new HashSet<Control>();
				if (value == true)
					_designerAutoWireViewModelValue.Add(control);
				else
					_designerAutoWireViewModelValue.Remove(control);
				return;
			}
			
			if (value != true)
				return;

			var view = control as IView;
			if (view != null)
				ViewModelLocationProvider.AutoWireViewModelChanged(view);
		}
	}
}
