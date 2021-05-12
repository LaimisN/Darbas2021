using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darbas2021.Page
{
    class PiguPage
    {
        private static IWebDriver driver;
        private IWebElement LoginIcon => driver.FindElement(By.CssSelector("#fixedHeaderContainer > div > div > div.header-bottom > ul > li.visitor-login.has-submenu.guide-item"));
        private IWebElement emailFieldInput => driver.FindElement(By.CssSelector("#loginModal > div:nth-child(1) > div.col-1-of-2.login-details > form > div:nth-child(4) > input[type=email]"));
        private IWebElement userPasswordFieldInput => driver.FindElement(By.CssSelector("#passwordCont > input[type=password]"));
        private IWebElement logInButton => driver.FindElement(By.XPath("//*[@id='loginModal']/div[1]/div[1]/form/div[4]/input"));
        private IWebElement registrationButton => driver.FindElement(By.CssSelector("#loginModal > div:nth-child(1) > div.col-1-of-2.login-details > form > div:nth-child(12) > a"));
        private IWebElement registrationButton2 => driver.FindElement(By.CssSelector("#loginModal > div.register-wrapper.clearfix > div.col-1-of-2.register-details > form > div.form-controls > input"));
        private IWebElement userPasswordFielfInput2 => driver.FindElement(By.CssSelector("#passwordContPopupRepeat > input[type=password]"));
        private IWebElement RegistrationFormcheckresult => driver.FindElement(By.CssSelector("#loginModal > div:nth-child(2) > div.col-1-of-2.login-details > form > div.notification.success.mb20 > div > strong"));
        private IWebElement LoggedInUserResult => driver.FindElement(By.CssSelector("#guideSite > div.site-center > section.simple-section > div > div.user-tab-content.clearfix > div.dashboard-header.clearfix.display-flex > div:nth-child(1) > div > a"));
        public PiguPage(IWebDriver webdriver)
        {
            driver = webdriver;

        }
        public void LogInProcedure(string email, string password)
        {
            //login procedura:
            LoginIcon.Click();
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
            //paspaudzia registruotis
            registrationButton2.Click();
        }
        public void RegistrationVerification(string email)
        {
            Assert.AreEqual(email, RegistrationFormcheckresult.Text, "tekstas neatitinka");// registracijos patikrinimas
        }

        public void VerificationOfLogedUser(string email)
        {
            Assert.AreEqual(email, LoggedInUserResult.Text, "tekstas neatitinka");
        }
    }
}
