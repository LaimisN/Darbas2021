using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
        private IWebElement CartContinueButton => driver.FindElement(By.XPath("/html/body/div[1]/div[5]/section/div/div[2]/div[2]/div[1]/div[2]/form/div/div[3]/div[2]/div[2]/div[2]/div/button"));
        private IWebElement NewPersonClick => driver.FindElement(By.Id("receiver_new_remote_self"));
        private IWebElement nameInputField => driver.FindElement(By.Id("receiver_name"));
        private IWebElement surnameInputField => driver.FindElement(By.Id("receiver_surname"));
        private IWebElement KaunasSelect => driver.FindElement(By.CssSelector("#remote_self_office2"));
        private IWebElement Continiu2 => driver.FindElement(By.CssSelector("button.btn:nth-child(2)"));
        private IWebElement Continiu3 => driver.FindElement(By.CssSelector("#tab-content-Cash > div:nth-child(4) > div:nth-child(1) > button:nth-child(1)"));
        private IWebElement NewAReceiverPersonResult => driver.FindElement(By.XPath("/html/body/div[1]/div[5]/section/div/div[2]/div[2]/div[2]/div/div[2]/p[1]/strong"));
        private IWebElement CashTabRadioClick => driver.FindElement(By.Id("CashTabRadio"));
        private IWebElement InsuranceCheckBox => driver.FindElement(By.XPath ("//*[starts-with(@id,'insuranceCheckbox')]/div")); // dinaminis Xpathas
        //private IWebElement InsuranceCheckBox => driver.FindElement(By.XPath("/html/body/div[1]/div[5]/section/div/div[2]/div[2]/div[1]/div[2]/form/div/table/tbody/tr[3]/td[2]/div[1]/div/div[1]/label/div"));
        private IWebElement LogOutButton => driver.FindElement(By.CssSelector("#guideSite > div.site-header > div > div > div > div.header-bottom > ul > li > div > ul > li > a"));
        private IWebElement cityDropDown => driver.FindElement(By.Id("remote_self_officeFilter"));

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
            LoginIcon.Click();
            GetWait().Until(ExpectedConditions.ElementExists(By.CssSelector("#loginModal > div:nth-child(1) > div.col-1-of-2.login-details > form > div:nth-child(4) > input[type=email]")));
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
            RemovePopupclick.Click();
        }
        public PiguCartPage EmptyCartConformation()
        {
            Assert.IsTrue(CartEmptyResult.Text.Contains("Jūsų prekių krepšelis tuščias"), "Tekstas neatitinka arba tavo krepšelis netuščias");
            return this;
        }
        public void IfNotEmptyThanEmptyCartConformation()
        {
            bool ifas = false;
            try
            {
                ifas = CartEmptyResult.Text.Contains("Jūsų prekių krepšelis tuščias");
                ifas = true;
            }
            catch (Exception)
            {
                ifas = false;
            }

            if (ifas)
            {
                EmptyCartConformation();
            }
            else
            {
                RemoveFromCartOperation();
                EmptyCartConformation();
            }
        }
        public void CartContinueNewPersonTakeOrder(string Name, string surname)
        {
            //InsuranceCheckBox.Click(); //*[@id="insuranceCheckboxPzu273878986"]/div  div[id*='insuranceCheckbox']            
            if (!InsuranceCheckBox.Selected)
            {
                InsuranceCheckBox.Click();
            }

            GetWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[5]/section/div/div[2]/div[2]/div[1]/div[2]/form/div/div[3]/div[2]/div[2]/div[2]/div/button")));
            Thread.Sleep(2000);
            CartContinueButton.Click();
            cityDropDown.SendKeys("Kaune"); ///pasirenkamas kaunas irasant i inputline KAUNE
            KaunasSelect.Click();
            if (!NewPersonClick.Selected)// jeigu nepaselektintas kitas asmuo paselektinti
            {
                NewPersonClick.Click();
            }
            nameInputField.SendKeys(Name);
            surnameInputField.SendKeys(surname);
            Continiu2.Click();
            CashTabRadioClick.Click();
            Continiu3.Click();
        }
        public void LogOutProcedure()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(LoginIcon);
            action.Build().Perform();
            GetWait().Until(ExpectedConditions.ElementExists(By.CssSelector("#guideSite > div.site-header > div > div > div > div.header-bottom > ul > li > div > ul > li > a")));
            LogOutButton.Click();
        }

        public void NewReceivercheckUp(string Name, string surname)
        {
            Assert.IsTrue(NewAReceiverPersonResult.Text.Contains($"{Name } {surname }"));
        }
    }
}
