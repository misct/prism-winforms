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
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.UnityExtensions.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Practices.Prism.UnityExtensions.Tests
{
    [TestClass]
    public class UnityRegionNavigationContentLoaderFixture
    {
        [TestMethod]
        public void ShouldFindCandidateViewInRegion()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<object, MockView>("MockView");

            this.ConfigureMockServiceLocator(container);

            // We cannot access the UnityRegionNavigationContentLoader directly so we need to call its
            // GetCandidatesFromRegion method through a navigation request.
            IRegion testRegion = new Region();

            MockView view = new MockView();
            testRegion.Add(view);
            testRegion.Deactivate(view);

            testRegion.RequestNavigate("MockView");

            Assert.IsTrue(testRegion.Views.Contains(view));
            Assert.IsTrue(testRegion.Views.Count() == 1);
            Assert.IsTrue(testRegion.ActiveViews.Count() == 1);
            Assert.IsTrue(testRegion.ActiveViews.Contains(view));
        }

        [TestMethod]
        public void ShouldFindCandidateViewWithFriendlyNameInRegion()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<object, MockView>("SomeView");

            this.ConfigureMockServiceLocator(container);

            // We cannot access the UnityRegionNavigationContentLoader directly so we need to call its
            // GetCandidatesFromRegion method through a navigation request.
            IRegion testRegion = new Region();

            MockView view = new MockView();
            testRegion.Add(view);
            testRegion.Deactivate(view);

            testRegion.RequestNavigate("SomeView");

            Assert.IsTrue(testRegion.Views.Contains(view));
            Assert.IsTrue(testRegion.Views.Count() == 1);
            Assert.IsTrue(testRegion.ActiveViews.Count() == 1);
            Assert.IsTrue(testRegion.ActiveViews.Contains(view));
        }

        public void ConfigureMockServiceLocator(IUnityContainer container)
        {
            MockServiceLocator serviceLocator = new MockServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }
    }

    public class MockView
    {
    }

    public class MockServiceLocator : ServiceLocatorImplBase
    {
        IUnityContainer container;

        public MockServiceLocator(IUnityContainer container)
        {
            this.container = container;
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            throw new NotImplementedException();
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            if (serviceType == typeof(IRegionNavigationService))
            {
                UnityRegionNavigationContentLoader loader = new UnityRegionNavigationContentLoader(this, this.container);
                return new RegionNavigationService(this, loader, new RegionNavigationJournal());
            }

            return null;
        }
    }
}
