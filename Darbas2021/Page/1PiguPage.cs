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
    public class PiguPage : BasePage
    {
        private const string urlPage = "https://pigu.lt/lt/"; // pasirasome url tam kad permetoda perduotomeme refresinima puslapio kiekvienam testui

        private IWebElement LoginIcon => driver.FindElement(By.CssSelector("#fixedHeaderContainer > div > div > div.header-bottom > ul > li.visitor-login.has-submenu.guide-item"));
        private IWebElement emailFieldInput => driver.FindElement(By.CssSelector("#loginModal > div:nth-child(1) > div.col-1-of-2.login-details > form > div:nth-child(4) > input[type=email]"));
        private IWebElement userPasswordFieldInput => driver.FindElement(By.CssSelector("#passwordCont > input[type=password]"));
        private IWebElement registrationButton => driver.FindElement(By.CssSelector("#loginModal > div:nth-child(1) > div.col-1-of-2.login-details > form > div:nth-child(12) > a"));
        private IWebElement registrationButton2 => driver.FindElement(By.CssSelector("#loginModal > div.register-wrapper.clearfix > div.col-1-of-2.register-details > form > div.form-controls > input"));
        private IWebElement userPasswordFielfInput2 => driver.FindElement(By.CssSelector("#passwordContPopupRepeat > input[type=password]"));
        private IWebElement RegistrationFormcheckresult => driver.FindElement(By.CssSelector("#loginModal > div:nth-child(2) > div.col-1-of-2.login-details > form > div.notification.success.mb20 > div > strong"));
        private IWebElement LoggedInUserResult => driver.FindElement(By.CssSelector("#guideSite > div.site-center > section.simple-section > div > div.user-tab-content.clearfix > div.dashboard-header.clearfix.display-flex > div:nth-child(1) > div > a"));
        private IWebElement ItemEnterField => driver.FindElement(By.Id("searchInput"));
        private IWebElement warrantyDropdown => driver.FindElement(By.Id("insuranceDropdown"));
        private SelectElement warrantyDropdownList => new SelectElement(driver.FindElement(By.Id("insuranceDropdown")));
        private IWebElement PiguCart => driver.FindElement(By.CssSelector("#cartWidget > a:nth-child(1) > div:nth-child(2) > div:nth-child(1) > span:nth-child(1)"));
        private IWebElement PiguCartItemWarantyPriceResult => driver.FindElement(By.XPath("/html/body/div[1]/div[5]/section/div/div[2]/div[2]/div[1]/div[2]/form/div/table/tbody/tr[3]/td[2]/div[1]/div/div[6]")); // keiciant preke reikia pakeisti
        private IWebElement LogOutButton => driver.FindElement(By.CssSelector(".drop-down--dark > li:nth-child(7) > a:nth-child(1)"));
        private IWebElement LogOutConfirmation => driver.FindElement(By.CssSelector("#loginModal > div:nth-child(1) > div.col-1-of-2.login-details > form > h1"));

        public PiguPage(IWebDriver webdriver) : base(webdriver)//konstruktoriumi perduodame driver is base klases
        {
            //driver = webdriver;

        }
        public void NavigateToDefaultPage() // Metodas refresina puslapi pries kiekviena testa
        {
            if (driver.Url != urlPage)
            {
                driver.Url = urlPage;
            }
        }

        [Obsolete]
        public void LogInProcedure(string email, string password)
        {
            LoginIcon.Click();
            GetWait().Until(ExpectedConditions.ElementExists(By.CssSelector("#loginModal > div:nth-child(1) > div.col-1-of-2.login-details > form > div:nth-child(4) > input[type=email]")));
            //WebDriverWait wait = new WebDriverWait(driver(), 10);
            // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //IWebElement element = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("#loginModal > div:nth-child(1) > div.col-1-of-2.login-details > form > div:nth-child(4) > input[type=email]")));
            //IWebElement element = wait.Until(ExpectedConditions.InvisibilityOfElementLocated("emailFieldInput");

            emailFieldInput.Clear();
            emailFieldInput.SendKeys(email);
            userPasswordFieldInput.SendKeys(password);
            driver.FindElement(By.CssSelector("#passwordCont > div")).Click();// passwordo perziura
            driver.FindElement(By.XPath("//*[@id='loginModal']/div[1]/div[1]/form/div[4]/input")).Click(); // prisijungti paspaudimas

        }
        public void RegistrationProcedure(string password)
        {
            registrationButton.Click();// registracijos buuton papaudimas
            userPasswordFielfInput2.SendKeys(password);//pakartoja passworda
            driver.FindElement(By.CssSelector("#agreeCheck > div")).Click(); // paklikina Check boxa
            driver.FindElement(By.CssSelector("#policiesButtonApprove")).Click(); // paklikina Check boxa
            registrationButton2.Click();//paspaudzia registruotis
        }
        public void RegistrationVerification(string email)
        {
            Assert.AreEqual(email, RegistrationFormcheckresult.Text, "tekstas neatitinka");// registracijos patikrinimas
        }

        public void VerificationOfLogedUser(string email)
        {
            Assert.AreEqual(email, LoggedInUserResult.Text, "tekstas neatitinka");
        }

        public void InputInItemEnterField(string item)
        {
            ItemEnterField.Clear();
            ItemEnterField.SendKeys(item);
            driver.FindElement(By.CssSelector("#searchRow > button:nth-child(2) > i:nth-child(1) > svg:nth-child(1)")).Click(); // searchas.click
        }
        public void SearchForItemNavigationCliks()
        {
            driver.FindElement(By.CssSelector("#productBlock36607961 > div:nth-child(1) > div:nth-child(1) > div:nth-child(3) > a:nth-child(1) > img:nth-child(1)")).Click(); //produktoparinkimas.clickinimas
            driver.FindElement(By.CssSelector("div.warranty-card:nth-child(2) > div:nth-child(2) > label:nth-child(1) > span:nth-child(2)")).Click(); // kitame lange paklikinimas i krepseli
            Thread.Sleep(1000);
            warrantyDropdown.Click();
            driver.FindElement(By.Id("insuranceDropdown5fe196d2ed8680bd085e70ad2d03d0af")).Click(); // parenkama 1 metu garantija per dropdowna
            Thread.Sleep(1000);

            Actions action = new Actions(driver);
            action.SendKeys(Keys.PageDown);
            action.SendKeys(Keys.PageDown);
            action.SendKeys(Keys.PageDown);
            action.SendKeys(Keys.PageDown);
            action.Build().Perform();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("#stickyCartButton > div > button")).Click(); // i krepseli.clik
            driver.FindElement(By.CssSelector("#continue")).Click();   // testi apsipoirkima.click
        }
        public void LogOutProcedure()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(LoginIcon);
            action.Build().Perform();
            GetWait().Until(ExpectedConditions.ElementExists(By.CssSelector(".drop-down--dark > li:nth-child(7) > a:nth-child(1)")));
            LogOutButton.Click();
        }
        public void LogOutVerification()
        {
            Assert.IsTrue(LogOutConfirmation.Text.Contains("Prisijungti"));

        }
        public void SelectrForomWarrantyDropdownList()
        {
            warrantyDropdownList.SelectByValue("5fe196d2ed8680bd085e70ad2d03d0af");
        }
        public void ItemInCartValidation()
        {
            PiguCart.Click();
            Assert.AreEqual("€ 129,00", PiguCartItemWarantyPriceResult.Text, "kaina neatitinka");
        }
    }
}
