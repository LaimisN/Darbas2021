using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Darbas2021
{
    class NDCheckbox
    {
        public IWebDriver chrome = new ChromeDriver();

        [Test]

        public void OneCheckBoxClick()
        {
            chrome = new ChromeDriver();
            chrome.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
            //  Thread.Sleep(2000);
            IWebElement OneCheckBoxClick = chrome.FindElement(By.Id("isAgeSelected"));
            OneCheckBoxClick.Click();
            IWebElement OneCheckBoxClickResult = chrome.FindElement(By.Id("txtAge"));
            Assert.IsTrue(OneCheckBoxClickResult.Text.Contains("Success - Check box is checked"));
            chrome.Close();

        }
        [Test]

        public void MultipleCheckbox()
        {
            chrome = new FirefoxDriver();
            chrome.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
            IWebElement OneCheckBoxClick = chrome.FindElement(By.Id("isAgeSelected"));
            if (OneCheckBoxClick.Selected)
            {
                OneCheckBoxClick.Click();
            }
            chrome.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > div:nth-child(3) > label > input")).Click();//click 1
            Thread.Sleep(1500);
            chrome.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > div:nth-child(4) > label > input")).Click();//click 2
            Thread.Sleep(1500);
            chrome.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > div:nth-child(5) > label > input")).Click();//click 3
            Thread.Sleep(0200);
            chrome.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > div:nth-child(6) > label > input")).Click();//click 4
            IWebElement   UncheckAllButton = chrome.FindElement(By.Id("check1")); //Check all button 
            // UncheckAllButton.GetAttribute("true");

         // IWebElement UncheckAllButton = chrome.FindElement(By("check1"));  isChkd //Check all button 
            /* //string result = UncheckAllButton.GetCssValue("Uncheck All");
          if (UncheckAllButton.GetCssValue("true") != true)
          {

              IWebElement oneoption =chrome.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > div:nth-child(3) > label > input"));
              oneoption.Click();
          }*/
            //Assert.AreEqual(result, "Uncheck All", "tek");
           // Assert.IsTrue(UncheckAllButton.Selected.ToString("True"));
            Assert.AreEqual("Uncheck All", UncheckAllButton.GetAttribute("value"), "tekstas neatitinka");
            chrome.Close();
        }
    }
}
