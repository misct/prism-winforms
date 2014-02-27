using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Microsoft.Practices.Prism
{
	public delegate void PropertyChangedCallback(Component c, AssignedPropertyChangedEventArgs e);

	public sealed class PropertyMetaData
	{
		public PropertyMetaData() :
			this(null, null) { }

		public PropertyMetaData(object defaultValue) :
			this(defaultValue, null) { }

		public PropertyMetaData(PropertyChangedCallback propertyChangedCallback) :
			this(null, propertyChangedCallback) { }

		public PropertyMetaData(object defaultValue, PropertyChangedCallback propertyChangedCallback)
		{
			_defaultValue = defaultValue;
			_propertyChangedCallback = propertyChangedCallback;
		}

		readonly object _defaultValue;
		public object DefaultValue { get { return _defaultValue; } }

		readonly PropertyChangedCallback _propertyChangedCallback;
		public PropertyChangedCallback PropertyChangedCallback { get { return _propertyChangedCallback; } }
	}
}
