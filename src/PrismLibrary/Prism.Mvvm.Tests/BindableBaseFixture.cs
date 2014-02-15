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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Prism.Mvvm.Tests.Mocks.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Practices.Prism.Mvvm.Tests
{
    [TestClass]
    public class BindableBaseFixture
    {
        [TestMethod]
        public void SetPropertyMethodShouldSetTheNewValue()
        {
            int value = 10;
            MockViewModel mockViewModel = new MockViewModel();

            Assert.AreEqual(mockViewModel.MockProperty, 0);

            mockViewModel.MockProperty = value;
            Assert.AreEqual(mockViewModel.MockProperty, value);
        }

        [TestMethod]
        public void SetPropertyMethodShouldRaisePropertyRaised()
        {
            bool invoked = false;
            MockViewModel mockViewModel = new MockViewModel();

            mockViewModel.PropertyChanged += (o, e) => { if (e.PropertyName.Equals("MockProperty")) invoked = true; };
            mockViewModel.MockProperty = 10;

            Assert.IsTrue(invoked);
        }

        [TestMethod]
        public void OnPropertyChangedShouldExtractPropertyNameCorrectly()
        {
            bool invoked = false;
            MockViewModel mockViewModel = new MockViewModel();

            mockViewModel.PropertyChanged += (o, e) => { if (e.PropertyName.Equals("MockProperty")) invoked = true; };
            mockViewModel.InvokeOnPropertyChanged();

            Assert.IsTrue(invoked);
        }
    }
}
