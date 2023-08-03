﻿using nUnitSpecflow.Hooks;
using nUnitSpecflow.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace nUnitSpecflow.Steps
{
    enum ContextKeys
    {
        CurrentPage,
        MyWebDriver
    }

    [Binding]
    internal abstract class BaseSteps
    {
        protected MyDriverManager MyDriverManager;
        private ScenarioContext _scenarioContext;
        public const string UiTestLabel = "uiTest";

        protected BasePage CurrentPage 
        {
            get => Get<BasePage>(ContextKeys.CurrentPage);
            set => Set(value, ContextKeys.CurrentPage);
        }

        public BaseSteps(FeatureContext featureContext, ScenarioContext scenarioContext) {
            if (featureContext.FeatureInfo.Tags.Contains(UiTestLabel)) 
            {
                MyDriverManager = featureContext.Get<MyDriverManager>(ContextKeys.MyWebDriver.ToString());
            }
            _scenarioContext = scenarioContext;
        }

        protected T Get<T>(ContextKeys contextKeys) 
        {
            return _scenarioContext.Get<T>(contextKeys.ToString());
        }

        protected void Set<T>(T value, ContextKeys contextKeys)
        {
            _scenarioContext.Set(value, contextKeys.ToString());
        }
    }
}
