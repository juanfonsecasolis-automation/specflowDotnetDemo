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
    internal class LoginPage : BasePage
    {
        TextFieldComponent _usernameTextField;
        TextFieldComponent _passwordTextField;
        ButtonComponent _loginButton;
        
        public LoginPage(MyDriverManager myDriverManager) : base(myDriverManager) 
        {
            _usernameTextField = new TextFieldComponent(By.XPath("//*[@data-test='username']"), myDriverManager);
            _passwordTextField = new TextFieldComponent(By.XPath("//*[@data-test='password']"), myDriverManager);
            _loginButton = new ButtonComponent(By.XPath("//*[@data-test='login-button']"), myDriverManager);
            VerifyPageLoadedCorrectly();
        }

        public override void VerifyPageLoadedCorrectly()
        {
            Assert.True(_usernameTextField.IsDisplayed);
        }

        internal InventoryPage LoginAndGetInventoryPage(string username, string password)
        {
            _usernameTextField.Type(username);
            _passwordTextField.Type(password);
            _loginButton.Click();
            return new InventoryPage(MyDriverManager); // TODO: handle bad login
        }
    }
}
