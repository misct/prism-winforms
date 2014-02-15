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
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Prism.Mvvm.Tests
{
    [VisualStudio.TestTools.UnitTesting.TestClass]
    public class PropertySupportFixture
    {
        [TestMethod]
        public virtual void WhenExtractingNameFromAValidPropertyExpression_ThenPropertyNameReturned()
        {
            var propertyName = PropertySupport.ExtractPropertyName(() => this.InstanceProperty);
            Assert.AreEqual("InstanceProperty", propertyName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenExpressionRepresentsAStaticProperty_ThenExceptionThrown()
        {
            PropertySupport.ExtractPropertyName(() => StaticProperty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenExpressionIsNull_ThenAnExceptionIsThrown()
        {
            PropertySupport.ExtractPropertyName<int>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenExpressionRepresentsANonMemberAccessExpression_ThenAnExceptionIsThrown()
        {
            PropertySupport.ExtractPropertyName(() => this.GetHashCode());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenExpressionRepresentsANonPropertyMemberAccessExpression_ThenAnExceptionIsThrown()
        {
            PropertySupport.ExtractPropertyName(() => this.InstanceField);
        }

        public static int StaticProperty { get; set; }
        public int InstanceProperty { get; set; }
        public int InstanceField;
        public static int SetOnlyStaticProperty { set { } }
    }
}
