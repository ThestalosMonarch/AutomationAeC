using System;
using OpenQA.Selenium;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Chrome;
using Automation.Service;
using Automation.Infraestructure;

namespace Automation_AeC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Checagem inicial do ambiente
            EnviromentValidation.IsInternetAvailable();
            EnviromentValidation.IsGoogleChromeInstalled();
            EnviromentValidation.FileExists();
            #endregion
            IWebDriver driver = SeleniumConfiguration.CreateAndInitializeDriver();
            AluraSiteActions.SearchContent(driver);
            AluraSiteActions.FilterContent(driver);
            DatabaseActions databaseActions = new DatabaseActions();
            databaseActions.SaveCursos(AluraSiteActions.GetContentResultInformation(driver));
        }
    }
}