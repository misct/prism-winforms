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
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using System.Windows.Input;

namespace Microsoft.Practices.Prism.Interactivity.Tests
{
    [TestClass]
    public class CommandBehaviorBaseFixture
    {
        [TestMethod]
        public void ExecuteUsesCommandParameterWhenSet()
        {
            var targetUIElement = new UIElement();
            var target = new TestableCommandBehaviorBase(targetUIElement);
            target.CommandParameter = "123";
            TestCommand testCommand = new TestCommand();
            target.Command = testCommand;

            target.ExecuteCommand("testparam");

            Assert.AreEqual("123", testCommand.ExecuteCalledWithParameter);
        }

        [TestMethod]
        public void ExecuteUsesParameterWhenCommandParameterNotSet()
        {
            var targetUIElement = new UIElement();
            var target = new TestableCommandBehaviorBase(targetUIElement);
            TestCommand testCommand = new TestCommand();
            target.Command = testCommand;

            target.ExecuteCommand("testparam");

            Assert.AreEqual("testparam", testCommand.ExecuteCalledWithParameter);
        }
    }

    class TestableCommandBehaviorBase : CommandBehaviorBase<UIElement>
    {
        public TestableCommandBehaviorBase(UIElement targetObject)
            : base(targetObject)
        {}

        public new void ExecuteCommand(object parameter)
        {
            base.ExecuteCommand(parameter);
        }
    }

    class TestCommand : ICommand
    {
        public object CanExecuteCalledWithParameter { get; set; }
        public bool CanExecute(object parameter)
        {
            CanExecuteCalledWithParameter = parameter;
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public object ExecuteCalledWithParameter { get; set; }
        public void Execute(object parameter)
        {
            ExecuteCalledWithParameter = parameter;
        }
    }

}
