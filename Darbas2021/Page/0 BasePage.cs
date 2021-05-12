using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darbas2021.Page
{
    public class BasePage
    {
        protected static IWebDriver driver;

        public BasePage(IWebDriver webdriver)
        {
            driver = webdriver;
        }

        public void CloseBrowser()
        {
            driver.Close();
        }

        public WebDriverWait GetWait(int seconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait;
        }


    }
}
