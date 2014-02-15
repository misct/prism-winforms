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

namespace Microsoft.Practices.Prism.Regions
{
    /// <summary>
    /// Encapsulates information about a navigation request.
    /// </summary>
    public class NavigationContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationContext"/> class for a region name and a 
        /// <see cref="Uri"/>.
        /// </summary>
        /// <param name="navigationService">The navigation service.</param>
        /// <param name="uri">The Uri.</param>
        public NavigationContext(IRegionNavigationService navigationService, Uri uri)
        {
            this.NavigationService = navigationService;

            this.Uri = uri;
            this.Parameters = uri != null ? UriParsingHelper.ParseQuery(uri) : null;
            this.GetNavigationParameters();
        }

        /// <summary>
        /// Gets the region navigation service.
        /// </summary>
        /// <value>The navigation service.</value>
        public IRegionNavigationService NavigationService { get; private set; }

        /// <summary>
        /// Gets the navigation URI.
        /// </summary>
        /// <value>The navigation URI.</value>
        public Uri Uri { get; private set; }

        /// <summary>
        /// Gets the <see cref="NavigationParameters"/> extracted from the URI and the object parameters passed in navigation.
        /// </summary>
        /// <value>The URI query.</value>
        public NavigationParameters Parameters { get; private set; }

        private void GetNavigationParameters()
        {
            if (this.Parameters == null || this.NavigationService == null || this.NavigationService.Region == null)
            {
                this.Parameters = new NavigationParameters();
                return;
            }
            var navigationParameters = this.NavigationService.Region.NavigationParameters;

            if (navigationParameters != null)
            { 
                foreach (KeyValuePair<string, object> navigationParameter in navigationParameters)
                {
                    this.Parameters.Add(navigationParameter.Key, navigationParameter.Value);
                }
            }
        }
    }
}
