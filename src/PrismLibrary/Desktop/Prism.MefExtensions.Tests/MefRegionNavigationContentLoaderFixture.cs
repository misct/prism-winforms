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
using Microsoft.Practices.Prism.MefExtensions.Regions;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Practices.Prism.MefExtensions.Tests
{
    [TestClass]
    public class MefRegionNavigationContentLoaderFixture
    {
        [TestMethod]
        public void ShouldFindCandidateViewInRegion()
        {
            this.ConfigureMockServiceLocator();

            // We cannot access the MefRegionNavigationContentLoader directly so we need to call its
            // GetCandidatesFromRegion method through a navigation request.
            IRegion testRegion = new Region();

            MockView1 view = new MockView1();
            testRegion.Add(view);
            testRegion.Deactivate(view);

            testRegion.RequestNavigate("MockView1");

            Assert.IsTrue(testRegion.Views.Contains(view));
            Assert.IsTrue(testRegion.Views.Count() == 1);
            Assert.IsTrue(testRegion.ActiveViews.Count() == 1);
            Assert.IsTrue(testRegion.ActiveViews.Contains(view));
        }

        [TestMethod]
        public void ShouldFindCandidateViewWithFriendlyNameInRegion()
        {
            this.ConfigureMockServiceLocator();

            // We cannot access the MefRegionNavigationContentLoader directly so we need to call its
            // GetCandidatesFromRegion method through a navigation request.
            IRegion testRegion = new Region();

            MockView2 view = new MockView2();
            testRegion.Add(view);
            testRegion.Deactivate(view);

            testRegion.RequestNavigate("SomeView");

            Assert.IsTrue(testRegion.Views.Contains(view));
            Assert.IsTrue(testRegion.Views.Count() == 1);
            Assert.IsTrue(testRegion.ActiveViews.Count() == 1);
            Assert.IsTrue(testRegion.ActiveViews.Contains(view));
        }

        public void ConfigureMockServiceLocator()
        {
            MockServiceLocator serviceLocator = new MockServiceLocator();
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }
    }

    [Export]
    public class MockView1
    {
    }

    [Export("SomeView")]
    public class MockView2
    {
    }

    public class MockServiceLocator : ServiceLocatorImplBase
    {
        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            throw new NotImplementedException();
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            if (serviceType == typeof(IRegionNavigationService))
            {
                MefRegionNavigationContentLoader loader = new MefRegionNavigationContentLoader(this);
                return new MefRegionNavigationService(this, loader, new MefRegionNavigationJournal());
            }

            return null;
        }
    }
}
