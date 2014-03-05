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
using System;

namespace Microsoft.Practices.Prism.Interactivity.InteractionRequest
{
    /// <summary>
    /// Interface used by the <see cref="PopupWindowAction"/>.
    /// If the DataContext object of a view that is shown with this action implements this interface
    /// it will be populated with the <see cref="INotification"/> data of the interaction request 
    /// as well as an <see cref="Action"/> to finish the request upon invocation.
    /// </summary>
    public interface IInteractionRequestAware
    {
        /// <summary>
        /// The <see cref="INotification"/> passed when the interaction request was raised.
        /// </summary>
        INotification Notification { get; set; }

        /// <summary>
        /// An <see cref="Action"/> that can be invoked to finish the interaction.
        /// </summary>
        Action FinishInteraction { get; set; }
    }
}
