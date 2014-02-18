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

namespace Microsoft.Practices.Prism.Regions
{
    /// <summary>
    /// This class contains extension methods for the Region and RegionManager instances, that allows you to pass object parameters in navigation.
    /// </summary>
    public static class NavigationWithParametersExtensions
    {
        /// <summary>
        /// This method allows an IRegion to navigate to the specified target URI, passing a callback and an instance of NavigationParameters, which holds a collection of object parameters.
        /// </summary>
        /// <param name="region">The IRegion instance that is extended by this method</param>
        /// <param name="target">A Uri that represents the target where the region will navigate.</param>
        /// <param name="navigationCallback">The navigation callback that will be executed after the navigation is completed.</param>
        /// <param name="navigationParameters">An instance of NavigationParameters, which holds a collection of object parameters.</param>
        public static void RequestNavigate(this IRegion region, Uri target, Action<NavigationResult> navigationCallback, NavigationParameters navigationParameters)
        {
            if (region == null)
            {
                return;
            }

            region.NavigationParameters = navigationParameters;
            region.RequestNavigate(target, navigationCallback);
        }

        /// <summary>
        /// This method allows an IRegion to navigate to the specified target string, passing a callback and an instance of NavigationParameters, which holds a collection of object parameters.
        /// </summary>
        /// <param name="region">The IRegion instance that is extended by this method</param>
        /// <param name="target">A string that represents the target where the region will navigate.</param>
        /// <param name="navigationCallback">The navigation callback that will be executed after the navigation is completed.</param>
        /// <param name="navigationParameters">An instance of NavigationParameters, which holds a collection of object parameters.</param>
        public static void RequestNavigate(this IRegion region, string target, Action<NavigationResult> navigationCallback, NavigationParameters navigationParameters)
        {
            RequestNavigate(region, new Uri(target, UriKind.RelativeOrAbsolute), navigationCallback, navigationParameters);
        }

        /// <summary>
        /// This method allows an IRegion to navigate to the specified target URI, passing an instance of NavigationParameters, which holds a collection of object parameters..
        /// </summary>
        /// <param name="region">The IRegion instance that is extended by this method</param>
        /// <param name="target">A Uri that represents the target where the region will navigate.</param>
        /// <param name="navigationParameters">An instance of NavigationParameters, which holds a collection of object parameters.</param>
        public static void RequestNavigate(this IRegion region, Uri target, NavigationParameters navigationParameters)
        {
            RequestNavigate(region, target, nr => { }, navigationParameters);
        }
        
        /// <summary>
        /// This method allows an IRegion to navigate to the specified target string, passing an instance of NavigationParameters, which holds a collection of object parameters
        /// </summary>
        /// <param name="region">The IRegion instance that is extended by this method.</param>
        /// <param name="target">A string that represents the target where the region will navigate.</param>
        /// <param name="navigationParameters">An instance of NavigationParameters, which holds a collection of object parameters.</param>
        public static void RequestNavigate(this IRegion region, string target, NavigationParameters navigationParameters)
        {
            RequestNavigate(region, new Uri(target, UriKind.RelativeOrAbsolute), nr => { }, navigationParameters);
        }

        /// <summary>
        /// This method allows an IRegionManager to locate a specified region and navigate in it to the specified target Uri, passing a navigation callback and an instance of NavigationParameters, which holds a collection of object parameters.
        /// </summary>
        /// <param name="regionManager">The IRegionManager instance that is extended by this method.</param>
        /// <param name="regionName">The name of the region where the navigation will occur.</param>
        /// <param name="target">A Uri that represents the target where the region will navigate.</param>
        /// <param name="navigationCallback">The navigation callback that will be executed after the navigation is completed.</param>
        /// <param name="navigationParameters">An instance of NavigationParameters, which holds a collection of object parameters.</param>
        public static void RequestNavigate(this IRegionManager regionManager, string regionName, Uri target, Action<NavigationResult> navigationCallback, NavigationParameters navigationParameters)
        {
            if (regionManager == null)
            {
                return;
            }

            if (regionManager.Regions.ContainsRegionWithName(regionName))
            {
                regionManager.Regions[regionName].RequestNavigate(target, navigationCallback, navigationParameters);
            }
        }

        /// <summary>
        /// This method allows an IRegionManager to locate a specified region and navigate in it to the specified target string, passing a navigation callback and an instance of NavigationParameters, which holds a collection of object parameters.
        /// </summary>
        /// <param name="regionManager">The IRegionManager instance that is extended by this method.</param>
        /// <param name="regionName">The name of the region where the navigation will occur.</param>
        /// <param name="target">A string that represents the target where the region will navigate.</param>
        /// <param name="navigationCallback">The navigation callback that will be executed after the navigation is completed.</param>
        /// <param name="navigationParameters">An instance of NavigationParameters, which holds a collection of object parameters.</param>
        public static void RequestNavigate(this IRegionManager regionManager, string regionName, string target, Action<NavigationResult> navigationCallback, NavigationParameters navigationParameters)
        {
            RequestNavigate(regionManager, regionName, new Uri(target, UriKind.RelativeOrAbsolute), navigationCallback, navigationParameters);
        }

        /// <summary>
        /// This method allows an IRegionManager to locate a specified region and navigate in it to the specified target Uri, passing an instance of NavigationParameters, which holds a collection of object parameters.
        /// </summary>
        /// <param name="regionManager">The IRegionManager instance that is extended by this method.</param>
        /// <param name="regionName">The name of the region where the navigation will occur.</param>
        /// <param name="target">A Uri that represents the target where the region will navigate.</param>
        /// <param name="navigationParameters">An instance of NavigationParameters, which holds a collection of object parameters.</param>
        public static void RequestNavigate(this IRegionManager regionManager, string regionName, Uri target, NavigationParameters navigationParameters)
        {
            RequestNavigate(regionManager, regionName, target, nr => { }, navigationParameters);
        }

        /// <summary>
        /// This method allows an IRegionManager to locate a specified region and navigate in it to the specified target string, passing an instance of NavigationParameters, which holds a collection of object parameters.
        /// </summary>
        /// <param name="regionManager">The IRegionManager instance that is extended by this method.</param>
        /// <param name="regionName">The name of the region where the navigation will occur.</param>
        /// <param name="target">A string that represents the target where the region will navigate.</param>
        /// <param name="navigationParameters">An instance of NavigationParameters, which holds a collection of object parameters.</param>
        public static void RequestNavigate(this IRegionManager regionManager, string regionName, string target, NavigationParameters navigationParameters)
        {
            RequestNavigate(regionManager, regionName, new Uri(target, UriKind.RelativeOrAbsolute), nr => { }, navigationParameters);
        }
    }
}
