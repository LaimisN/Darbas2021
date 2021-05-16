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
    class PiguCartPage : BasePage

    {
        private const string urlPage = "https://pigu.lt/lt/cart"; // pasirasome url tam kad permetoda perduotomeme refresinima puslapio kiekvienam testui

        private IWebElement LoginIcon => driver.FindElement(By.CssSelector("#guideSite > div.site-header > div > div > div > div.header-bottom > ul > li > a"));
        private IWebElement emailFieldInput => driver.FindElement(By.CssSelector("#loginModal > div:nth-child(1) > div.col-1-of-2.login-details > form > div:nth-child(4) > input[type=email]"));
        private IWebElement userPasswordFieldInput => driver.FindElement(By.CssSelector("#passwordCont > input[type=password]"));
        private IWebElement RemoveFromCartButton => driver.FindElement(By.XPath("/html/body/div[1]/div[5]/section/div/div[2]/div[2]/div[1]/div[2]/form/div/table/tbody/tr[2]/td[6]/a"));
        private IWebElement RemovePopupclick => driver.FindElement(By.Id("modal-remove-from-cart"));
        private IWebElement CartEmptyResult => driver.FindElement(By.XPath("/html/body/div[1]/div[5]/section/div/div[2]/div[2]/div[1]/div[1]/p"));
        private IWebElement OrderTitle => driver.FindElement(By.Id("order-title")); // krepselio pavadinimas
        private IWebElement CartContinueButton => driver.FindElement(By.XPath("/html/body/div[1]/div[5]/section/div/div[2]/div[2]/div[1]/div[2]/form/div/div[3]/div[2]/div[2]/div[2]/div/button"));

        private IWebElement nameInputField => driver.FindElement(By.Id("name"));
        private IWebElement phoneInputField => driver.FindElement(By.Id("phone"));
        private IWebElement surnameInputField => driver.FindElement(By.Id("surname"));
        private IWebElement addressInputField => driver.FindElement(By.Id("address"));
        private IWebElement postCodeInputField => driver.FindElement(By.XPath("/html/body/div[1]/div[5]/section/div/div[2]/div/div/div/form/div[2]/div[5]/div/div/input"));
        private IWebElement Vilniusselect => driver.FindElement(By.CssSelector("#city_id1"));
        private IWebElement dropwownclick => driver.FindElement(By.XPath("//*[@id='city_idFilter']"));
        

        //private SelectElement cityDropDown => new SelectElement(driver.FindElement(By.Id("city_idSelect")));
        private SelectElement cityDropDown => new SelectElement(driver.FindElement(By.XPath("//*[@id='city_idFilter']")));


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
        public void RemoveFromCartOperation()
        {
            RemoveFromCartButton.Click();
            Thread.Sleep(2000);
            RemovePopupclick.Click();
        }
        public PiguCartPage EmptyCartConformation()
        {
            Assert.IsTrue(CartEmptyResult.Text.Contains("Jūsų prekių krepšelis tuščiass"), "Tekstas neatitinka arba tavo krepšelis netuščias");
            return this;
        }
        public void IfNotEmptyThanEmptyCartConformation()

        {

            //ifas neveikia nes jei atidaro puslapi kuriame yra perekes tuomet neberanda pagal ka ifa paleisti neberanda uzraso .
            bool ifas = CartEmptyResult.Text.Contains("Jūsų prekių krepšelis tuščiass");
            /*
              if (CartEmptyResult.Text.Contains("Jūsų prekių krepšelis tuščiass") || OrderTitle.Text.Contains("krepšelis"))
              {

              }
            */

            if (ifas)

            {
                Assert.IsTrue(CartEmptyResult.Text.Contains("Jūsų prekių krepšelis tuščiass"), "Tekstas neatitinka arba tavo krepšelis netuščias");
            }
            else
            {

                RemoveFromCartOperation();
                Assert.IsTrue(CartEmptyResult.Text.Contains("Jūsų prekių krepšelis tuščiass"), "Tekstas neatitinka arba tavo krepšelis netuščias");

            }
            /*
            switch (CartEmptyResult.Text.Contains("Jūsų prekių krepšelis tuščiass")== true || OrderTitle.Text.Contains("krepšelis")==true)
            {
                case Assert.IsTrue(CartEmptyResult.Text.Contains("Jūsų prekių krepšelis tuščiass")):
                    
                    break;
                case 2:

                    break;
                case 3:

                    break;
            }
            */
        }

        public void CartContinueButtonAndClick()
        {
            CartContinueButton.Click();
            nameInputField.SendKeys("kalakala");
            surnameInputField.SendKeys("BalaBala");
            phoneInputField.SendKeys("+37000054863");
            Thread.Sleep(2000);
           // dropwownclick.Click();
           // Thread.Sleep(2000);

//            Vilniusselect.Click();
           // cityDropDown.SelectByValue("1");
           // cityDropDown.SelectByText("Vilnius");
            cityDropDown.SelectByIndex(2);

            addressInputField.SendKeys("Vilniaus g");
            postCodeInputField.SendKeys("1420");
        }

    }
}
