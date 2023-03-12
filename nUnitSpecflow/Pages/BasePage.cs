using nUnitSpecflow.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nUnitSpecflow.Pages
{
    internal abstract class BasePage
    {
        protected MyDriverManager DriverManager;

        public BasePage(MyDriverManager myDriverManager)
        {
            DriverManager = myDriverManager;
            VerifyPageLoadedCorrectly();
        }

        public abstract void VerifyPageLoadedCorrectly();
    }
}
