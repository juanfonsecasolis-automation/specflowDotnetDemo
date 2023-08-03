using NUnit.Framework;
using nUnitSpecflow.Hooks;
using nUnitSpecflow.Pages.Components;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nUnitSpecflow.Pages
{
    internal abstract class WithUpperMenuPage : BasePage
    {
        MenuComponent _hamburgerMenu;

        public WithUpperMenuPage(MyDriverManager myDriverManager)
            : base(myDriverManager)
        {
            _hamburgerMenu = new MenuComponent(By.Id("react-burger-menu-btn"), MyDriverManager);
        }

        internal void LogOut()
        {
            _hamburgerMenu.ClickElementByText("Logout");
        }
    }
}
