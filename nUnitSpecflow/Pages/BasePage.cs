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
        protected MyDriverManager _myDriverManager;

        public BasePage(MyDriverManager myDriverManager)
        {
            _myDriverManager = myDriverManager;
        }

        public abstract void VerifyPageLoadedCorrectly();
    }
}
