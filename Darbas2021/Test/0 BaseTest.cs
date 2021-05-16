using Darbas2021.Driver;
using Darbas2021.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darbas2021.Test
{
    class BaseTest
    {
        protected static IWebDriver driver;
       // public static BasicCheckboxDemoPage basicCheckboxDemoPage;
        //public static SelectDropDownListPage selectDropDownPage;

        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetChromeDriver();
           // basicCheckboxDemoPage = new BasicCheckboxDemoPage(driver);
          //  selectDropDownPage = new SelectDropDownListPage(driver);
        }

        [TearDown]
        public static void TearDownAttribute()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenshot.TakeScreenshot(driver);
            }
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            driver.Quit();
        }
    }
}
