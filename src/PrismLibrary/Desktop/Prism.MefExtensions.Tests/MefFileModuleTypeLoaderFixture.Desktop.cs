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
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace Microsoft.Practices.Prism.MefExtensions.Tests
{
    [TestClass]
    public class MefFileModuleTypeLoaderFixture
    {
        [TestMethod]
        public void CanLoadModulesWithUrlThatHaveFilePrefix()
        {
            MefFileModuleTypeLoader loader = new MefFileModuleTypeLoader();
            ModuleInfo info = this.CreateModuleInfo();

            bool canLoad = loader.CanLoadModuleType(info);

            Assert.IsTrue(canLoad);
        }

        [TestMethod]
        public void CannotLoadModulesWithUrlThatDontHaveFilePrefix()
        {
            MefFileModuleTypeLoader loader = new MefFileModuleTypeLoader();
            ModuleInfo info = this.CreateModuleInfo();
            info.Ref = "MefModulesForTesting.dll";

            bool canLoad = loader.CanLoadModuleType(info);

            Assert.IsFalse(canLoad);
        }

        [TestMethod]
        public void LoadModuleTypeShouldRaiseTheCorrespondingEvents()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            var newCatalog = DefaultPrismServiceRegistrar.RegisterRequiredPrismServicesIfMissing(catalog);

            CompositionContainer container = new CompositionContainer(newCatalog);
            container.ComposeExportedValue<AggregateCatalog>(catalog);

            MefFileModuleTypeLoader loader = container.GetExportedValue<MefFileModuleTypeLoader>();
            ModuleInfo info = this.CreateModuleInfo();

            // Flags
            bool progressChangedRaised = false;
            bool completedRaised = false;

            // We subscribe to the events
            loader.ModuleDownloadProgressChanged += (o, e) => { progressChangedRaised = true; };
            loader.LoadModuleCompleted += (o, e) => { completedRaised = true; };

            loader.LoadModuleType(info);

            Assert.IsTrue(progressChangedRaised);
            Assert.IsTrue(completedRaised);
        }

        public ModuleInfo CreateModuleInfo()
        {
            ModuleInfo info = new ModuleInfo();
            info.ModuleName = "MefModuleOne";
            info.Ref = "file:///MefModulesForTesting.dll";

            return info;
        }
    }
}
