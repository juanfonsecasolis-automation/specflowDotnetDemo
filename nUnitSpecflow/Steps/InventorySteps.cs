using NUnit.Framework.Internal;
using NUnit.Framework;
using nUnitSpecflow.Hooks;
using nUnitSpecflow.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace nUnitSpecflow.Steps
{
    [Binding]
    internal class InventorySteps : BaseSteps
    {
        public InventorySteps(MyDriverManager myDriverManager) : base(myDriverManager) { }

        [Then(@"only six items are rendered")]
        public void ThenOnlySixItemsAreRendered()
        {
            Assert.Equals(6, ((InventoryPage)CurrentPage).GetInventoryItems().Count);
        }

    }
}
