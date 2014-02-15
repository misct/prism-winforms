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
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Prism.PubSubEvents.Tests
{
    [TestClass]
    public class DispatcherEventSubscriptionFixture
    {
        [TestMethod]
        public void ShouldCallInvokeOnDispatcher()
        {
            DispatcherEventSubscription<object> eventSubscription = null;

            IDelegateReference actionDelegateReference = new MockDelegateReference()
            {
                Target = (Action<object>)(arg =>
                {
                    return;
                })
            };

            IDelegateReference filterDelegateReference = new MockDelegateReference
            {
                Target = (Predicate<object>)(arg => true)
            };
            var mockSyncContext = new MockSynchronizationContext();

            eventSubscription = new DispatcherEventSubscription<object>(actionDelegateReference, filterDelegateReference, mockSyncContext);

            eventSubscription.GetExecutionStrategy().Invoke(new object[0]);

            Assert.IsTrue(mockSyncContext.InvokeCalled);
        }

        [TestMethod]
        public void ShouldPassParametersCorrectly()
        {
            IDelegateReference actionDelegateReference = new MockDelegateReference()
            {
                Target =
                    (Action<object>)(arg1 =>
                    {
                        return;
                    })
            };
            IDelegateReference filterDelegateReference = new MockDelegateReference
            {
                Target = (Predicate<object>)(arg => true)
            };

            var mockSyncContext = new MockSynchronizationContext();

            DispatcherEventSubscription<object> eventSubscription = new DispatcherEventSubscription<object>(actionDelegateReference, filterDelegateReference, mockSyncContext);

            var executionStrategy = eventSubscription.GetExecutionStrategy();
            Assert.IsNotNull(executionStrategy);

            object argument1 = new object();

            executionStrategy.Invoke(new[] { argument1 });

            Assert.AreSame(argument1, mockSyncContext.InvokeArg);
        }
    }

    internal class MockSynchronizationContext : SynchronizationContext
    {
        public bool InvokeCalled;
        public object InvokeArg;

        public override void Post(SendOrPostCallback d, object state)
        {
            InvokeCalled = true;
            InvokeArg = state;
        }
    }
}
