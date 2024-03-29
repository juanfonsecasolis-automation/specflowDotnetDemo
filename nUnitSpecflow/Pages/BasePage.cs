﻿using nUnitSpecflow.Hooks;

namespace nUnitSpecflow.Pages
{
    internal abstract class BasePage
    {
        protected MyDriverManager MyDriverManager;

        public BasePage(MyDriverManager myDriverManager)
        {
            MyDriverManager = myDriverManager;
        }

        public abstract void VerifyPageLoadedCorrectly();
    }
}
