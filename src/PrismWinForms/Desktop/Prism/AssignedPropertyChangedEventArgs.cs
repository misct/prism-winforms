using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Practices.Prism
{
	public class AssignedPropertyChangedEventArgs : EventArgs
	{
		public AssignedPropertyChangedEventArgs(AssignedProperty property, object oldValue, object newValue)
		{
			_property = property;
			_oldValue = oldValue;
			_newValue = newValue;
		}

		readonly AssignedProperty _property;
		public AssignedProperty Property
		{
			get { return _property; }
		}

		readonly object _newValue;
		public object NewValue
		{
			get { return _newValue; }
		}

		readonly object _oldValue;
		public object OldValue
		{
			get { return _oldValue; }
		}

	}
}
