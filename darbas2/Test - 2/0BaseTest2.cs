using Darbas2021.Driver;
using Darbas2021.Page;
using Darbas2021.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;


namespace Darbas2021.Test
{
    public class BaseTest2
    {

        protected static IWebDriver driver;
        public static _3PiguWishListPage2 _3piguWishListPage2;
        public static PiguPage2 piguPage2;
        public static PiguCartPage2 piguCartPage2;

        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetFirefoxDriver();
            piguPage2 = new PiguPage2(driver);
            piguCartPage2 = new PiguCartPage2(driver);
            _3piguWishListPage2 = new _3PiguWishListPage2(driver);
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
