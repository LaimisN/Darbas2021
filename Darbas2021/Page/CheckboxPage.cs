using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Darbas2021.Page
{
    class CheckboxPage
    {
        private static IWebDriver driver;
        private IWebElement CheckBoxClick => driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement OneCheckBoxClickResult => driver.FindElement(By.Id("txtAge"));
        private IWebElement checkboxselectedoption1 => driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > div:nth-child(3) > label > input"));
        private IWebElement checkboxselectedoption2 => driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > div:nth-child(4) > label > input"));
        private IWebElement checkboxselectedoption3 => driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > div:nth-child(5) > label > input"));
        private IWebElement checkboxselectedoption4 => driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > div:nth-child(6) > label > input"));

        private IWebElement UncheckAllButton => driver.FindElement(By.Id("check1")); //Check all button 

        public CheckboxPage(IWebDriver webdriver)
        {
            driver = webdriver;

        }

        public void OneCheckBoxClick()
        {
            CheckBoxClick.Click();

        }

        public void VerifyIfOneCheckBoxClickedResult()
        {
            Assert.IsTrue(OneCheckBoxClickResult.Text.Contains("Success - Check box is checked"));
            //Assert.AreEqual(expectedResult, OneCheckBoxClickResult.Text, "Result is not correct!");
        }
        public void OneCheckBoxClickUnclick()
        {
            if (CheckBoxClick.Selected)
            {
                CheckBoxClick.Click();
            }
        }
        public void All4CheckBoxClik()
        {
            driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > div:nth-child(3) > label > input")).Click();//click 1
            Thread.Sleep(3000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.TextToBePresentInElementValue(UncheckAllButton, "Unchek all")); // veikia greiciau tol kol sulaukia
            driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > div:nth-child(4) > label > input")).Click();//click 2
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > div:nth-child(5) > label > input")).Click();//click 3
            Thread.Sleep(0200);
            driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > div:nth-child(6) > label > input")).Click();//click 4
        }
        public void VerifyIfUncheckAllButton()
        {
            Assert.AreEqual("Uncheck All", UncheckAllButton.GetAttribute("value"), "tekstas neatitinka");
        }
        public void CheckAllAndUncheckAllButtonClick()
        {
            UncheckAllButton.Click();
        }
        public void Onecheckboxclic()
        {
            checkboxselectedoption2.Click();
        }

        public void VerifyAllCheckBox()
        {
            bool result = true;
            if (!checkboxselectedoption1.Selected && !checkboxselectedoption2.Selected && !checkboxselectedoption3.Selected && !checkboxselectedoption4.Selected)
            {
                result = false;
            }
            Assert.IsFalse(result);
        }
        public void VerificationOfUncheckAllButton()
        {

            if (UncheckAllButton.GetAttribute("value").Equals("Uncheck All"))
            {
                UncheckAllButton.Click();
            }
            /*
            if (UncheckAllButton.GetAttribute("value") == "true")
            {
                UncheckAllButton.Click();
            }
            else
            {
                VerifyAllCheckBox();
            }
            */
  
        }
  
    }



}
