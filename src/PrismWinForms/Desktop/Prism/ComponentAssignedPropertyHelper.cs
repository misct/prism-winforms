using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Microsoft.Practices.Prism
{
	public static class ComponentAssignedPropertyHelper
	{
		#region ValueInfo

		struct ValueInfo
		{
			public ValueInfo(object value, bool autoDispose)
			{
				_value = value;
				_autoDispose = autoDispose;
			}
			public ValueInfo(object value) : this(value, false) { }
			public ValueInfo(bool autoDispose) : this(null, autoDispose) { }

			readonly object _value;
			public object Value { get { return _value; } }

			readonly bool _autoDispose;
			public bool AutoDispose { get { return _autoDispose; } }
		}

		#endregion

		#region ValueMap

		class ValueMap : Dictionary<AssignedProperty, ValueInfo> { }

		#endregion

		/// <summary>
		/// Holds one ValueMap per Component.
		/// </summary>
		static Dictionary<Component, ValueMap> _valueMaps =
			new Dictionary<Component, ValueMap>();

		static ValueMap AddComponentValueMap(Component component)
		{
			var map = new ValueMap();
			_valueMaps.Add(component, map);
			component.Disposed += component_Disposed;
			return map;
		}

		/// <summary>
		/// Assigns the given <see cref="AssignedProperty"/> to the given
		/// component, setting the default value when it is non-null.
		/// </summary>
		/// <param name="component"></param>
		/// <param name="property"></param>
		/// <param name="autoDispose"></param>
		public static void AssignProperty(this Component component, AssignedProperty property)
		{
			if (property == null)
				throw new ArgumentNullException("property");
			var pmd = property.PropertyMetadata;
			if (pmd == null || pmd.DefaultValue == null)
				return;
			SetAssignedValue(component, property, pmd.DefaultValue, false);
		}

		static void component_Disposed(object sender, EventArgs e)
		{
			var component = sender as Component;
			if (component == null)
				return;

			component.Disposed -= component_Disposed;

			ValueMap map;
			if (!_valueMaps.TryGetValue(component, out map))
				return;
			_valueMaps.Remove(component);
			foreach (var kv in map)
			{
				var vi = kv.Value;
				if (!vi.AutoDispose)
					continue;
				var prop = kv.Key;
				DisposeValue(vi.Value);
			}
		}

		static void DisposeValue(object value)
		{
			if (value == null)
				return;
			var disp = value as IDisposable;
			if (disp != null)
				disp.Dispose();
		}

		public static object GetAssignedValue(this Component component, AssignedProperty prop)
		{
			ValueMap map;
			if (_valueMaps.TryGetValue(component, out map))
			{
				ValueInfo vi;
				if (map.TryGetValue(prop, out vi))
					return vi.Value;
			}
			return null;
		}

		static void OnAssignedPropertyChanged(Component component, AssignedProperty prop, object oldValue, object newValue)
		{
			var pmd = prop.PropertyMetadata;
			if (pmd == null)
				return;

			var callback = pmd.PropertyChangedCallback;
			if (callback == null)
				return;

			var e = new AssignedPropertyChangedEventArgs(prop, oldValue, newValue);
			callback(component, e);
		}

		public static void SetAssignedValue(
			this Component component,
			AssignedProperty property, 
			object value,
			bool autoDispose = false)
		{
			if (component == null)
				throw new ArgumentNullException("component");
			if (property == null)
				throw new ArgumentNullException("property");

			ValueMap map;
			if (!_valueMaps.TryGetValue(component, out map))
			{
				map = AddComponentValueMap(component);
				map.Add(property, new ValueInfo(value, autoDispose));
				OnAssignedPropertyChanged(component, property, null, value);
				return;
			}
			ValueInfo vi;
			if (!map.TryGetValue(property, out vi))
			{
				map.Add(property, new ValueInfo(value, autoDispose));
				OnAssignedPropertyChanged(component, property, null, value);
				return;
			}
			// AutoDispose the old value.
			if (vi.AutoDispose)
				DisposeValue(vi.Value);
			
			var viNew = new ValueInfo(value, autoDispose);
			map[property] = viNew;
			OnAssignedPropertyChanged(component, property, vi.Value, value);
		}
	}
}
