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
    class CheckboxPageTest
    {

        private static IWebDriver driver;

        [OneTimeSetUp]
        public static void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            driver.Close();
        }
        [Test]

        public static void ClickOnCheckBox()
        {
            CheckboxPage page = new CheckboxPage(driver);
            page.OneCheckBoxClick();
            page.VerifyIfOneCheckBoxClickedResult();         
        }
        [Test]
        public static void MultipleCheckboxTest()
        {
            CheckboxPage page = new CheckboxPage(driver);
            page.OneCheckBoxClickUnclick();
            page.All4CheckBoxClik();
            page.VerifyIfUncheckAllButton();
        }
        [Test]
        public static void MultipleCheckboxUncheckAllTest()
        {
            CheckboxPage page = new CheckboxPage(driver);
            //page.CheckAllAndUncheckAllButtonClick();
            Thread.Sleep(2000);
            page.VerificationOfUncheckAllButton();
           // Thread.Sleep(2000);
            // page.CheckAllAndUncheckAllButtonClick();
            // page.CheckAllAndUncheckAllButtonClick();
            //   page.Onecheckboxclic();  //testo patikrinimas. vienas is checkbox pazymejimas. ir testas neigiamas
            //Thread.Sleep(2000);

            page.VerifyAllCheckBox();
        }

    }
}
