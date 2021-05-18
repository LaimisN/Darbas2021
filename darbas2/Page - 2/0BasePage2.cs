using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darbas2021.Page
{
    public class BasePage2
    {
        protected static IWebDriver driver;

        public BasePage2(IWebDriver webdriver)
        {
            driver = webdriver;
        }

        public void CloseBrowser()
        {
            driver.Close();
        }

        public WebDriverWait GetWait(int seconds = 10)
        {
           
           return new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
        }


    }
}
