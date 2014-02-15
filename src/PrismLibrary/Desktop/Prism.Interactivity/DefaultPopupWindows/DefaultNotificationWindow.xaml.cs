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
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using System.Windows;

namespace Microsoft.Practices.Prism.Interactivity.DefaultPopupWindows
{
    /// <summary>
    /// Interaction logic for NotificationChildWindow.xaml
    /// </summary>
    public partial class DefaultNotificationWindow : Window
    {
        /// <summary>
        /// Creates a new instance of <see cref="DefaultNotificationWindow"/>
        /// </summary>
        public DefaultNotificationWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets or gets the <see cref="INotification"/> shown by this window./>
        /// </summary>
        public INotification Notification 
        {
            get
            {
                return this.DataContext as INotification;
            }
            set
            {
                this.DataContext = value;
            }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
