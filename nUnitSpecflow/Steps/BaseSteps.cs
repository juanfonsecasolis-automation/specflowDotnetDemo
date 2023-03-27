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
    internal abstract class BaseSteps
    {
        protected MyDriverManager MyDriverManager;
        protected BasePage CurrentPage;

        public BaseSteps(MyDriverManager myDriverManager) {
            MyDriverManager = myDriverManager;
        }
    }
}
