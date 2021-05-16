﻿using NUnit.Framework;
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
    class _3PiguWishListPage : BasePage
    {
        private const string urlPage = "https://pigu.lt/lt/"; // pasirasome url tam kad permetoda perduotomeme refresinima puslapio kiekvienam testui


        private IWebElement LoginIcon => driver.FindElement(By.CssSelector("#fixedHeaderContainer > div > div > div.header-bottom > ul > li.visitor-login.has-submenu.guide-item"));
        private IWebElement emailFieldInput => driver.FindElement(By.CssSelector("#loginModal > div:nth-child(1) > div.col-1-of-2.login-details > form > div:nth-child(4) > input[type=email]"));
        private IWebElement userPasswordFieldInput => driver.FindElement(By.CssSelector("#passwordCont > input[type=password]"));
        private IWebElement meniubutton => driver.FindElement(By.CssSelector("#loaded-main-menu > li:nth-child(1) > a:nth-child(1)"));//meniu click
        private IWebElement KompiuterineTechnikaButton => driver.FindElement(By.Id("#department-48"));//kompiuterine technika click????

        private SelectElement DropDown => new SelectElement(driver.FindElement(By.ClassName("menu.submenu")));//meniu left dropdown????
        private IWebElement SmartWatchButton => driver.FindElement(By.CssSelector(".category-listing > div:nth-child(1) > div:nth-child(1) > div:nth-child(14) > a:nth-child(2)"));
        private IWebElement SamsungButton => driver.FindElement(By.CssSelector("#filter-13730 > ul:nth-child(2) > li:nth-child(4) > a:nth-child(1)"));
        public IReadOnlyCollection<IWebElement> RekomenduojameCheckBoxas => driver.FindElements(By.ClassName("menu.filters-block-list.flex-column"));
      //  public IReadOnlyCollection<IWebElement> RekomenduojameCheckBoxas => driver.FindElements(By.Id("filter44551"));
        //private IReadOnlyCollection<IWebElement> RekomenduojameCheckBoxas => driver.FindElements(By.CssSelector("#filter44551 > ul"));
        private IWebElement check1 => driver.FindElement(By.CssSelector("#filter44551 > ul > li:nth-child(1) > a"));
        private IWebElement check2 => driver.FindElement(By.CssSelector("#filter44551 > ul > li:nth-child(2) > a"));
        private IWebElement ItemSellectButton => driver.FindElement(By.CssSelector("#productBlock32246752 > div:nth-child(1) > div:nth-child(1) > div:nth-child(3) > a:nth-child(1) > img:nth-child(1)"));
        private IWebElement AddToWishListButton => driver.FindElement(By.CssSelector(".add-to-wish-list"));
        private IWebElement RemuveToWishListButton => driver.FindElement(By.CssSelector(".remove-from-wish-list"));
        private IWebElement ReviewListButton => driver.FindElement(By.CssSelector("#review_list"));
        private IWebElement RemoveContinue => driver.FindElement(By.CssSelector("#continue"));
        private IWebElement PopUpCancel => driver.FindElement(By.CssSelector(".piguclub-popup__reject-link"));
        private IWebElement WishlistItemCountResult => driver.FindElement(By.CssSelector("#menuCount2442046"));






        public _3PiguWishListPage(IWebDriver webdriver) : base(webdriver)
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
            GetWait().Until(ExpectedConditions.ElementExists(By.CssSelector("#loginModal > div:nth-child(1) > div.col-1-of-2.login-details > form > div:nth-child(4) > input[type=email]")));
            //            WebDriverWait wait = new WebDriverWait(driver(), 10);
            // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //IWebElement element = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("#loginModal > div:nth-child(1) > div.col-1-of-2.login-details > form > div:nth-child(4) > input[type=email]")));
            //IWebElement element = wait.Until(ExpectedConditions.InvisibilityOfElementLocated("emailFieldInput");

            emailFieldInput.Clear();
            emailFieldInput.SendKeys(email);
            userPasswordFieldInput.SendKeys(password);
            driver.FindElement(By.CssSelector("#passwordCont > div")).Click();// passwordo perziura
            driver.FindElement(By.XPath("//*[@id='loginModal']/div[1]/div[1]/form/div[4]/input")).Click(); // prisijungti paspaudimas

        }

        public void AddItemToWishList()
        {
            meniubutton.Click();
            //DropDown.SelectByText() ;
           // KompiuterineTechnikaButton.Click();
            SmartWatchButton.Click();
            SamsungButton.Click();
          //  Thread.Sleep(2000);

            check1.Click();
            check2.Click();
            foreach (IWebElement singleCheckbox in RekomenduojameCheckBoxas) //suforeachu pazymime visus boxus
            {
               // if (!singleCheckbox.Selected)
                    singleCheckbox.Click();
            }
            //Thread.Sleep(2000);
            ItemSellectButton.Click();
            try
            {
            AddToWishListButton.Click();
            }
            catch (Exception)
            {
                RemuveToWishListButton.Click();
                RemoveContinue.Click();
                Thread.Sleep(2000);
                AddToWishListButton.Click();
                Thread.Sleep(2000);
               // ReviewListButton.Click();
            }
            ReviewListButton.Click();
            //PopUpCancel.Click();
        }

        public void WishListItemConformation()
        {
            Assert.IsTrue(WishlistItemCountResult.Text.Contains("1"));
        }
    }

}