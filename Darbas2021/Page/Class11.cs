using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darbas2021.Page
{
    class Class11:BasePage 
    {/*
        private const string urlPage = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
        private const string successMessage = "Success - Check box is checked";
        private IReadOnlyCollection<IWebElement> multipleCheckBoxes => driver.FindElements(By.ClassName("cb1-element"));
       // private IReadOnlyCollection<IWebElement> multipleCheckBoxes => driver.FindElements(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > div:nth-child(3)"));
        private IWebElement checkAllButton => driver.FindElement(By.Id("check1"));
       */ 
        private const string urlPage = "https://pigu.lt/lt/mobilieji-telefonai-foto-ir-video/ismanieji-laikrodziai-ir-ismaniosios-apyrankes/ismanieji-laikrodziai-smartwatch/f/samsung";
        //private IReadOnlyCollection<IWebElement> multipleCheckBoxes => driver.FindElements(By.ClassName("icheckbox.icheck-itemcb1-element"));
        //private IReadOnlyCollection<IWebElement> multipleCheckBoxes => driver.FindElements(By.ClassName("order-up"));
        //private IReadOnlyCollection<IWebElement> multipleCheckBoxes => driver.FindElements(By.ClassName("menu.filters-block-list.flex-column"));
        private IReadOnlyCollection<IWebElement> multipleCheckBoxes => driver.FindElements(By.CssSelector("#filter44551 > ul"));
        private IWebElement check1 => driver.FindElement(By.CssSelector("#filter44551 > ul > li:nth-child(1) > a"));
        private IWebElement check2 => driver.FindElement(By.CssSelector("#filter44551 > ul > li:nth-child(2) > a"));



        public Class11(IWebDriver webdriver) : base(webdriver)
        {
        }
        public void NavigateToDefaultPage()
        {
            if (driver.Url != urlPage)
            {
                driver.Url = urlPage;
            }
            
        }


        public void CheckAllMultipleCheckBoxes()
        {
            
            foreach (IWebElement singleCheckbox in multipleCheckBoxes)
            {
                //singleCheckbox.Click();
                
                if (!singleCheckbox.Selected)
                    singleCheckbox.Click();
            }
           
        }

        public void singlecheckclick()
        {
            check1.Click();
        }
    }
}
