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
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace Microsoft.Practices.Prism.Mvvm
{
    /// <summary>
    /// The ViewModelLocationProvider class locates the view model for the view that has the AutoWireViewModelChanged attached property set to true.
    /// The view model will be located and injected into the view's DataContext. To locate the view, two strategies are used: First the ViewModelLocationProvider
    /// will look to see if there is a view model factory registered for that view, if not it will try to infer the view model using a convention based approach.
    /// This class also provide methods for registering the view model factories,
    /// and also to override the default view model factory and the default view type to view model type resolver.
    /// </summary>
    
    // Documentation on using the MVVM pattern is at http://go.microsoft.com/fwlink/?LinkID=288814&clcid=0x409

    public static class ViewModelLocationProvider
    {
        /// <summary>
        /// A dictionary that contains all the registered factories for the views.
        /// </summary>
        static Dictionary<string, Func<object>> factories = new Dictionary<string, Func<object>>();
        /// <summary>
        /// The default view model factory.
        /// </summary>
        private static Func<Type, object> defaultViewModelFactory = type => Activator.CreateInstance(type);
        
        /// <summary>
        /// Default view type to view model type resolver, assumes the view model is in same assembly as the view type, but in the "ViewModels" namespace.
        /// </summary>
        private static Func<Type, Type> defaultViewTypeToViewModelTypeResolver = 
            viewType =>
            {
                var viewName = viewType.FullName;
                viewName = viewName.Replace(".Views.", ".ViewModels.");
                var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
                var viewModelName = String.Format(CultureInfo.InvariantCulture, "{0}ViewModel, {1}", viewName, viewAssemblyName);
                return Type.GetType(viewModelName);
            };

        /// <summary>
        /// Sets the default view model factory.
        /// </summary>
        /// <param name="viewModelFactory">The view model factory.</param>
        public static void SetDefaultViewModelFactory(Func<Type, object> viewModelFactory)
        {
            defaultViewModelFactory = viewModelFactory;
        }

        /// <summary>
        /// Sets the default view type to view model type resolver.
        /// </summary>
        /// <param name="viewTypeToViewModelTypeResolver">The view type to view model type resolver.</param>
        public static void SetDefaultViewTypeToViewModelTypeResolver(Func<Type, Type> viewTypeToViewModelTypeResolver)
        {
            defaultViewTypeToViewModelTypeResolver = viewTypeToViewModelTypeResolver;
        }


        /// <summary>
        /// Automatically looks up the viewmodel that corresponds to the current view, using two strategies:
        /// It first looks to see if there is a mapping registered for that view, if not it will fallback to the convention based approach.
        /// </summary>
        /// <param name="view">The dependency object, typically a view.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        public static void AutoWireViewModelChanged(IView view)
        {
            // Try mappings first
            object viewModel = GetViewModelForView(view);
            // Fallback to convention based
            if (viewModel == null)
            {
                var viewModelType = defaultViewTypeToViewModelTypeResolver(view.GetType());
                if (viewModelType == null) return;

                // Really need Container or Factories here to deal with injecting dependencies on construction
                viewModel = defaultViewModelFactory(viewModelType);
            }
            
            view.DataContext = viewModel;
        }

        /// <summary>
        /// Gets the view model for the specified view.
        /// </summary>
        /// <param name="view">The view that the view model wants.</param>
        /// <returns>The vie wmodel that corresponds to the view passed as a parameter.</returns>
        private static object GetViewModelForView(IView view)
        {
            // Mapping of view models base on view type (or instance) goes here
            if (factories.ContainsKey(view.GetType().ToString()))
                return factories[view.GetType().ToString()]();
            return null;
        }

        /// <summary>
        /// Registers the view model factory for the specified view type name.
        /// </summary>
        /// <param name="viewTypeName">The name of the view type.</param>
        /// <param name="factory">The viewmodel factory.</param>
        public static void Register(string viewTypeName, Func<object> factory)
        {
            factories[viewTypeName] = factory;
        }
    }
}
