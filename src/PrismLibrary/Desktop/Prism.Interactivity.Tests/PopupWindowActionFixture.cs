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
using Microsoft.Practices.Prism.Interactivity.DefaultPopupWindows;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.Interactivity.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Microsoft.Practices.Prism.Interactivity.Tests
{
    [TestClass]
    public class PopupWindowActionFixture
    {
        [TestMethod]
        public void WhenWindowContentIsNotSet_ShouldUseDefaultWindowForNotifications()
        {
            TestablePopupWindowAction popupWindowAction = new TestablePopupWindowAction();
            popupWindowAction.IsModal = true;
            popupWindowAction.CenterOverAssociatedObject = true;

            INotification notification = new Notification();
            notification.Title = "Title";
            notification.Content = "Content";

            Assert.AreEqual(popupWindowAction.IsModal, true);
            Assert.AreEqual(popupWindowAction.CenterOverAssociatedObject, true);

            Window window = popupWindowAction.GetWindow(notification);
            Assert.IsInstanceOfType(window, typeof(DefaultNotificationWindow));

            DefaultNotificationWindow defaultWindow = window as DefaultNotificationWindow;
            Assert.ReferenceEquals(defaultWindow.Notification, notification);
        }

        [TestMethod]
        public void WhenWindowContentIsNotSet_ShouldUseDefaultWindowForConfirmations()
        {
            TestablePopupWindowAction popupWindowAction = new TestablePopupWindowAction();
            popupWindowAction.IsModal = true;
            popupWindowAction.CenterOverAssociatedObject = true;

            INotification notification = new Confirmation();
            notification.Title = "Title";
            notification.Content = "Content";

            Assert.AreEqual(popupWindowAction.IsModal, true);
            Assert.AreEqual(popupWindowAction.CenterOverAssociatedObject, true);

            Window window = popupWindowAction.GetWindow(notification);
            Assert.IsInstanceOfType(window, typeof(DefaultConfirmationWindow));

            DefaultConfirmationWindow defaultWindow = window as DefaultConfirmationWindow;
            Assert.ReferenceEquals(defaultWindow.Confirmation, notification);
        }

        [TestMethod]
        public void WhenWindowContentIsSet_ShouldWrapContentInCommonWindow()
        {
            MockFrameworkElement element = new MockFrameworkElement();
            TestablePopupWindowAction popupWindowAction = new TestablePopupWindowAction();
            popupWindowAction.WindowContent = element;

            INotification notification = new Notification();
            notification.Title = "Title";
            notification.Content = "Content";

            Window window = popupWindowAction.GetWindow(notification);
            Assert.IsNotInstanceOfType(window, typeof(DefaultNotificationWindow));
            Assert.IsNotInstanceOfType(window, typeof(DefaultConfirmationWindow));
            Assert.IsInstanceOfType(window, typeof(Window));
        }

        [TestMethod]
        public void WhenWindowContentImplementsIInteractionRequestAware_ShouldSetUpProperties()
        {
            MockInteractionRequestAwareElement element = new MockInteractionRequestAwareElement();
            TestablePopupWindowAction popupWindowAction = new TestablePopupWindowAction();
            popupWindowAction.WindowContent = element;

            INotification notification = new Notification();
            notification.Title = "Title";
            notification.Content = "Content";

            Window window = popupWindowAction.GetWindow(notification);
            Assert.IsNotNull(element.Notification);
            Assert.ReferenceEquals(element.Notification, notification);
            Assert.IsNotNull(element.FinishInteraction);
        }

        [TestMethod]
        public void WhenDataContextOfWindowContentImplementsIInteractionRequestAware_ShouldSetUpProperties()
        {
            MockInteractionRequestAwareElement dataContext = new MockInteractionRequestAwareElement();
            MockFrameworkElement element = new MockFrameworkElement();
            TestablePopupWindowAction popupWindowAction = new TestablePopupWindowAction();
            element.DataContext = dataContext;
            popupWindowAction.WindowContent = element;

            INotification notification = new Notification();
            notification.Title = "Title";
            notification.Content = "Content";

            Window window = popupWindowAction.GetWindow(notification);
            Assert.IsNotNull(dataContext.Notification);
            Assert.ReferenceEquals(dataContext.Notification, notification);
            Assert.IsNotNull(dataContext.FinishInteraction);
        }
    }

    public class TestablePopupWindowAction : PopupWindowAction
    {
        public new Window GetWindow(INotification notification)
        {
            return base.GetWindow(notification);
        }
    }
}
