using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Microsoft.Practices.Prism
{
	public sealed class AssignedProperty
	{
		private AssignedProperty(
			string name,
			Type propertyType,
			Type ownerType,
			PropertyMetaData typeMetadata)
		{
			_name = name;
			_propertyType = propertyType;
			_ownerType = ownerType;
			_typeMetadata = typeMetadata;

			_hashCode = (_name.GetHashCode() ^ _ownerType.GetHashCode());
		}

		private readonly string _name;
		public string Name { get { return _name; } }

		private readonly Type _ownerType;
		public Type OwnerType { get { return _ownerType; } }

		private readonly Type _propertyType;
		public Type PropertyType { get { return _propertyType; } }

		private readonly PropertyMetaData _typeMetadata;
		public PropertyMetaData PropertyMetadata { get { return _typeMetadata; } }

		#region Equality

		private readonly int _hashCode;

		public override int GetHashCode()
		{
			return _hashCode;
		}

		public override bool Equals(object obj)
		{
			return obj != null && obj is AssignedProperty && this.Equals((AssignedProperty)obj);
		}

		public bool Equals(AssignedProperty property)
		{
			return _name.Equals(property._name) && _ownerType == property._ownerType;
		}

		#endregion

		#region Registration

		private static HashSet<AssignedProperty> _registered = new HashSet<AssignedProperty>();
		private static object _guardRegistered = new object();

		public static AssignedProperty RegisterAssigned(string name, 
			Type propertyType, Type ownerType,
			PropertyMetaData typeMetadata = null)
		{
			var item = new AssignedProperty(name, propertyType, ownerType, typeMetadata);
			lock(_guardRegistered)
			{
				if (_registered.Contains(item))
					throw new ArgumentException(String.Format(
						"AssignedProperty already registered: {0} owned by {1}.", 
						name, ownerType.Name));
				else
					_registered.Add(item);
			}
			return item;
		}

		#endregion
	}
}
