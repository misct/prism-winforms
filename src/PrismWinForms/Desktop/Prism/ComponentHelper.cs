using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Microsoft.Practices.Prism
{
	public static class ComponentHelper
	{
		#region Property Data Classes

		class AttachedProperty
		{
			public Func<Component, object> Getter;
			public Action<Component, object> Setter;
			public object Value;
			public bool AutoDispose;

			public object GetValue(Component component)
			{
				var getter = this.Getter;
				if (getter != null)
					return getter(component);
				return this.Value;
			}
		}

		class AttachedPropertyMap : Dictionary<string, AttachedProperty> { }

		#endregion

		static Dictionary<Component, AttachedPropertyMap> _propertyMaps =
			new Dictionary<Component, AttachedPropertyMap>();

		public static void AttachProperty(this Component component, string name, Func<Component, object> getter,
			Action<Component, object> setter = null,
			bool autoDispose = false)
		{
			AttachedPropertyMap props;
			if (!_propertyMaps.TryGetValue(component, out props))
			{
				props = new AttachedPropertyMap();
				props.Add(name, new AttachedProperty
				{
					Getter = getter,
					Setter = setter ?? ReadOnlySetter,
					AutoDispose = autoDispose
				});
				AttachPropertyMap(component, props);
				return;
			}
			if (props.ContainsKey(name))
				throw new InvalidOperationException(String.Format("Property {0} already attached.", name));
			props.Add(name, new AttachedProperty
			{
				Getter = getter,
				Setter = setter ?? ReadOnlySetter,
				AutoDispose = autoDispose
			});
		}

		static void AttachPropertyMap(Component component, AttachedPropertyMap props)
		{
			if (component == null)
				throw new ArgumentNullException("component");

			_propertyMaps.Add(component, props);

			component.Disposed += component_Disposed;
		}

		static void component_Disposed(object sender, EventArgs e)
		{
			var component = sender as Component;
			if (component == null)
				return;

			component.Disposed -= component_Disposed;

			AttachedPropertyMap props;
			if (!_propertyMaps.TryGetValue(component, out props))
				return;

			_propertyMaps.Remove(component);
			foreach (var kv in props)
			{
				var prop = kv.Value;
				if (!prop.AutoDispose)
					continue;

				IDisposable disp = null;
				var value = prop.GetValue(component);
				if (value == null)
					continue;

				disp = value as IDisposable;
				if (disp != null)
					disp.Dispose();
			}
		}

		public static object GetAttachedValue(this Component component, string name)
		{
			AttachedPropertyMap props;
			if (_propertyMaps.TryGetValue(component, out props))
			{
				AttachedProperty prop;
				if (props.TryGetValue(name, out prop))
				{
					var getter = prop.Getter;
					if (getter != null)
						return getter(component);

					return prop.Value;
				}
			}
			return null;
		}

		static void ReadOnlySetter(Component component, object value)
		{
			throw new InvalidOperationException("The property is read-only.");
		}

		public static void SetAttachedValue(this Component component, string name, object value,
			Nullable<bool> autoDispose = null)
		{
			AttachedPropertyMap props;
			if (!_propertyMaps.TryGetValue(component, out props))
			{
				props = new AttachedPropertyMap();
				props.Add(name, new AttachedProperty { Value = value, AutoDispose = autoDispose.GetValueOrDefault() });
				AttachPropertyMap(component, props);
				return;
			}
			AttachedProperty prop;
			if (!props.TryGetValue(name, out prop))
			{
				props.Add(name, new AttachedProperty { Value = value, AutoDispose = autoDispose.GetValueOrDefault() });
				return;
			}
			if (prop.AutoDispose && value == null)
			{
				var dispValue = prop.GetValue(component) as IDisposable;
				if (dispValue != null)
					dispValue.Dispose();
			}
			var setter = prop.Setter;
			if (setter != null)
				setter(component, value);
			else
			{
				prop.Value = value;
				if (autoDispose != null)
					prop.AutoDispose = autoDispose.Value;
			}
		}
	}
}
