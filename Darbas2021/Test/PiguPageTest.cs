using Darbas2021.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darbas2021.Test
{
    class PiguPageTest
    {
        private static IWebDriver driver;

        [OneTimeSetUp]
        public static void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "https://pigu.lt/lt/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Window.Maximize();

        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            driver.Close();
        }
        [Test]

        public static void NewUserRegistration()
        {

            PiguPage page = new PiguPage(driver);
            page.LogInProcedure("testamailas12@gmail.com", "test2021");// tam kad veiktu reikia pakeisti maila.
            page.RegistrationProcedure("test2021");
            page.RegistrationVerification("testamailas12@gmail.com");

        }
        [Test]
        public static void PiguPageUserLogInTest()
        {
            PiguPage page = new PiguPage(driver);
            page.LogInProcedure("testamailas@gmail.com", "test2021");
            page.VerificationOfLogedUser("testamailas@gmail.com");
        }
    }
}
