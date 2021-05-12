using Darbas2021.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Darbas2021.Test
{
    class PiguPageTest : BaseTest
    {
        //private static IWebDriver driver;
        /*
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
        */
        [Test]

        public static void NewUserRegistration()
        {
            string UserName = "testamailas21@gmail.com";// tam kad veiktu reikia pakeisti maila.
            string password = "test2021";
            PiguPage page = new PiguPage(driver);
            page.NavigateToDefaultPage();
            page.LogInProcedure(UserName, password);
            page.RegistrationProcedure(password);
            page.RegistrationVerification(UserName);

        }
        [Test]
        public static void PiguPageUserLogInTest()
        {
            PiguPage page = new PiguPage(driver);
            page.NavigateToDefaultPage();
            page.LogInProcedure("testamailas@gmail.com", "test2021");
            page.VerificationOfLogedUser("testamailas@gmail.com");
        }
        [Test]
        public static void PiguCartInput()
        {
            PiguPage page = new PiguPage(driver);
            page.NavigateToDefaultPage();
            page.LogInProcedure("testamailas@gmail.com", "test2021");
             //samsung galaxy s21 prekis idejimas i krepseli
            page.InputInItemEnterField("samsung galaxy s21");
            
            page.SearchForItemNavigationCliks();
            page.ItemInCartValidation();

        }
        /*
        [Test]
        public static void GoToCart()
        {
            PiguPage page = new PiguPage(driver);
            page.NavigateToDefaultPage();
            page.LogInProcedure("testamailas@gmail.com", "test2021");
            // samsung galaxy s21 prekis idejimas i krepseli
            //page.ItemInCartValidation();

        }*/
    }
}
