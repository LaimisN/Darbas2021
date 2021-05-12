using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darbas2021.Page
{
    class PiguCartPage : BasePage

    {
        private const string urlPage = "https://pigu.lt/lt/cart"; // pasirasome url tam kad permetoda perduotomeme refresinima puslapio kiekvienam testui

        private IWebElement LoginIcon => driver.FindElement(By.CssSelector("#guideSite > div.site-header > div > div > div > div.header-bottom > ul > li > a"));
        private IWebElement emailFieldInput => driver.FindElement(By.CssSelector("#loginModal > div:nth-child(1) > div.col-1-of-2.login-details > form > div:nth-child(4) > input[type=email]"));
        private IWebElement userPasswordFieldInput => driver.FindElement(By.CssSelector("#passwordCont > input[type=password]"));
        private IWebElement RemoveFromCartButton => driver.FindElement(By.CssSelector("td.tar:nth-child(6)"));




        public PiguCartPage(IWebDriver webdriver) : base(webdriver) //konstruktoriumi perduodame driver is base klases
        {                 
        }

        public void NavigateToDefaultPage() // Metodas refresina puslapi pries kiekviena testa
        {
            if (driver.Url != urlPage)
            {
                driver.Url = urlPage;
            }
        }

        public void LogInProcedure(string email, string password)
        {
            //login procedura:
            LoginIcon.Click();
            emailFieldInput.Clear();
            emailFieldInput.SendKeys(email);
            userPasswordFieldInput.Clear();
            userPasswordFieldInput.SendKeys(password);
            driver.FindElement(By.CssSelector("#passwordCont > div")).Click();// passwordo perziura
            driver.FindElement(By.XPath("//*[@id='loginModal']/div[1]/div[1]/form/div[4]/input")).Click(); // prisijungti paspaudimas

        }

    }
}
