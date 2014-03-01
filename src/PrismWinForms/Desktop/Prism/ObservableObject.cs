using System.Collections.Generic;
//===================================================================================
// Microsoft patterns & practices
// Composite Application Guidance for Windows Presentation Foundation
//===================================================================================
// Copyright (c) Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//===================================================================================
using System.ComponentModel;
using System.Windows;
using Microsoft.Practices.Prism.ViewModel;

namespace Microsoft.Practices.Prism
{
    /// <summary>
    /// Class that wraps an object, so that other classes can notify for Change events. Typically, this class is set as 
    /// a Dependency Property on DependencyObjects, and allows other classes to observe any changes in the Value. 
    /// </summary>
    /// <remarks>
    /// This class is required, because in Silverlight, it's not possible to receive Change notifications for Dependency properties that you do not own. 
    /// </remarks>
    /// <typeparam name="T">The type of the property that's wrapped in the Observable object</typeparam>
	public sealed class ObservableObject<T> : NotificationObject
    {
		readonly EqualityComparer<T> _comparer = EqualityComparer<T>.Default;

		T _Value;
		public T Value
		{
			get { return _Value; }
			set
			{
				if (_comparer.Equals(_Value, value))
					return;
				_Value = value;
				base.RaisePropertyChanged("Value");
			}
		}
    }
}