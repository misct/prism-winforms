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
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition.Hosting;

namespace Microsoft.Practices.Prism.MefExtensions.Regions
{
    /// <summary>
    /// Exports the LocatorNavigationTargetHandler using the Managed Extensibility Framework (MEF).
    /// </summary>
    /// <remarks>
    /// This allows the MefBootstrapper to provide this class as a default implementation.
    /// If another implementation is found, this export will not be used.
    /// </remarks>
    [Export(typeof(IRegionNavigationContentLoader))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class MefRegionNavigationContentLoader : RegionNavigationContentLoader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MefRegionNavigationContentLoader"/> class.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IServiceLocator"/> used to create the instance of the view from its <see cref="Type"/>.</param>
        [ImportingConstructor]
        public MefRegionNavigationContentLoader(IServiceLocator serviceLocator)
            : base(serviceLocator)
        {
        }

        /// <summary>
        /// Returns the set of candidates that may satisfiy this navigation request.
        /// </summary>
        /// <param name="region">The region containing items that may satisfy the navigation request.</param>
        /// <param name="candidateNavigationContract">The candidate navigation target.</param>
        /// <returns>An enumerable of candidate objects from the <see cref="IRegion"/></returns>
        protected override IEnumerable<object> GetCandidatesFromRegion(IRegion region, string candidateNavigationContract)
        {
            if (candidateNavigationContract == null || candidateNavigationContract.Equals(string.Empty))
                throw new ArgumentNullException("candidateNavigationContract");

            IEnumerable<object> contractCandidates = base.GetCandidatesFromRegion(region, candidateNavigationContract);

            if (!contractCandidates.Any())
            {
                contractCandidates = region.Views.Where(v => candidateNavigationContract.Equals( v.GetType().GetCustomAttributes(false).OfType<ExportAttribute>().FirstOrDefault().ContractName, StringComparison.Ordinal));
            }

            return contractCandidates;
        }
    }
}
