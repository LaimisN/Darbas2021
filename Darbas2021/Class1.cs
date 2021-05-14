using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Darbas2021
{
    public class Class1
    {



        [Test]

        public static void PiguPageUserRegistrationTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://pigu.lt/lt/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();

            driver.FindElement(By.CssSelector("#fixedHeaderContainer > div > div > div.header-bottom > ul > li.visitor-login.has-submenu.guide-item")).Click();
            IWebElement email = driver.FindElement(By.CssSelector("#loginModal > div:nth-child(1) > div.col-1-of-2.login-details > form > div:nth-child(4) > input[type=email]"));
            email.Clear();
            string usermail = "testamailas5@gmail.com";// tam kad veiktu reikia pakeisti maila. 
            email.SendKeys(usermail);
            string userpass = "test2021";
            IWebElement userPasswordInput = driver.FindElement(By.CssSelector("#passwordCont > input[type=password]"));
            userPasswordInput.SendKeys(userpass);
            // driver.FindElement(By.XPath("//*[@id='passwordCont']/div)")).Click();
            driver.FindElement(By.CssSelector("#passwordCont > div")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//*[@id='loginModal']/div[1]/div[1]/form/div[4]/input")).Click(); // prisijungti paspaudimas
  
            // paspaudzia registracijos mygtuka
            //  driver.FindElement(By.Id("loginModal")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.CssSelector("#loginModal > div:nth-child(1) > div.col-1-of-2.login-details > form > div:nth-child(12) > a")).Click();// registracijos buuton papaudimas
            Thread.Sleep(2000);
            //pakartoja passworda
            IWebElement userPasswordInput2 = driver.FindElement(By.CssSelector("#passwordContPopupRepeat > input[type=password]"));
            userPasswordInput2.SendKeys(userpass);
            driver.FindElement(By.CssSelector("#agreeCheck > div")).Click();
            driver.FindElement(By.CssSelector("#policiesButtonApprove")).Click();
            //paspaudzia registruotis
            driver.FindElement(By.CssSelector("#loginModal > div.register-wrapper.clearfix > div.col-1-of-2.register-details > form > div.form-controls > input")).Click();
            IWebElement RegistrationFormcheckresult = driver.FindElement(By.CssSelector("#loginModal > div:nth-child(2) > div.col-1-of-2.login-details > form > div.notification.success.mb20 > div > strong"));
            Assert.AreEqual(usermail, RegistrationFormcheckresult.Text, "tekstas neatitinka");// registracijos patikrinimas

        }
        [Test]

        public static void PiguPageUserLogInTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://pigu.lt/lt/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            //   driver.FindElement(By.CssSelector("#fixedHeaderContainer > div > div > div.header-bottom > ul > li.visitor-login.has-submenu.guide-item")).Click(); // login click
            IWebElement UserLoginArea = driver.FindElement(By.CssSelector("#fixedHeaderContainer > div > div > div.header-bottom > ul > li.visitor-login.has-submenu.guide-item"));
            UserLoginArea.Click();
            IWebElement UserLogInEmail = driver.FindElement(By.CssSelector("#loginModal > div:nth-child(1) > div.col-1-of-2.login-details > form > div:nth-child(4) > input[type=email]"));
            UserLogInEmail.Clear();
            string usermail = "testamailas@gmail.com";
            UserLogInEmail.SendKeys(usermail);
            string userpass = "test2021";
            IWebElement UserLogInPass = driver.FindElement(By.CssSelector("#passwordCont > input[type=password]"));
            UserLogInPass.SendKeys(userpass);
            driver.FindElement(By.CssSelector("#passwordCont > div")).Click();
            driver.FindElement(By.XPath("//*[@id='loginModal']/div[1]/div[1]/form/div[4]/input")).Click();
            IWebElement LoggedInUserResult = driver.FindElement(By.CssSelector("#guideSite > div.site-center > section.simple-section > div > div.user-tab-content.clearfix > div.dashboard-header.clearfix.display-flex > div:nth-child(1) > div > a"));
            Assert.AreEqual(usermail, LoggedInUserResult.Text, "tekstas neatitinka");


        }

        [Test]
        public static void PiguPageUserLogInFirefoxTest()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "https://pigu.lt/lt/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            //   driver.FindElement(By.CssSelector("#fixedHeaderContainer > div > div > div.header-bottom > ul > li.visitor-login.has-submenu.guide-item")).Click(); // login click
            IWebElement UserLoginArea = driver.FindElement(By.CssSelector("#fixedHeaderContainer > div > div > div.header-bottom > ul > li.visitor-login.has-submenu.guide-item"));
            UserLoginArea.Click();
            IWebElement UserLogInEmail = driver.FindElement(By.CssSelector("#loginModal > div:nth-child(1) > div.col-1-of-2.login-details > form > div:nth-child(4) > input[type=email]"));
            UserLogInEmail.Clear();
            string usermail = "testamailas@gmail.com";
            UserLogInEmail.SendKeys(usermail);
            string userpass = "test2021";
            IWebElement UserLogInPass = driver.FindElement(By.CssSelector("#passwordCont > input[type=password]"));
            UserLogInPass.SendKeys(userpass);
            driver.FindElement(By.CssSelector("#passwordCont > div")).Click();
            driver.FindElement(By.XPath("//*[@id='loginModal']/div[1]/div[1]/form/div[4]/input")).Click(); // login enter

            IWebElement LoggedInUserResult = driver.FindElement(By.CssSelector("#guideSite > div.site-center > section.simple-section > div > div.user-tab-content.clearfix > div.dashboard-header.clearfix.display-flex > div:nth-child(1) > div > a"));
            Assert.AreEqual(usermail, LoggedInUserResult.Text, "tekstas neatitinka");

            // samsung galaxy s21 prekis idejimas i krepseli
            IWebElement ItemEnterField = driver.FindElement(By.Id("searchInput"));
            string item = " samsung galaxy s21";
            ItemEnterField.Clear();
            ItemEnterField.SendKeys(item);
            driver.FindElement(By.CssSelector("#searchRow > button:nth-child(2) > i:nth-child(1) > svg:nth-child(1)")).Click(); // searchas 
            driver.FindElement(By.CssSelector("#productBlock36608146 > div:nth-child(1) > div:nth-child(1) > div:nth-child(3) > a:nth-child(1) > img:nth-child(1)")).Click(); //produktoparinkimas
            driver.FindElement(By.CssSelector("div.warranty-card:nth-child(2) > div:nth-child(2) > label:nth-child(1) > span:nth-child(2)")).Click();

            // IWebElement warrantyDropdown = driver.FindElement(By.Id("insuranceDropdownList"));
            IWebElement warrantyDropdown = driver.FindElement(By.Id("insuranceDropdown"));
            //IWebElement warrantyDropdown = driver.FindElement(By.CssSelector("# insuranceDropdown"));

            warrantyDropdown.Click();
            driver.FindElement(By.Id("insuranceDropdown5fe196d2ed8680bd085e70ad2d03d0af")).Click();
            //driver.FindElement(By.Id("insuranceDropdown5fe196d2ed8680bd085e70ad2d03d0af"));
            /* SelectElement element = new SelectElement(warrantyDropdown);
             element.SelectByValue("5fe196d2ed8680bd085e70ad2d03d0af");
             // SelectElement element = new SelectElement(warrantyDropdown);
            */

            driver.FindElement(By.CssSelector("#stickyCartButton > div > button")).Click(); // i krepseli
            driver.FindElement(By.CssSelector("#continue")).Click();   // testi
            /*
            IWebElement showMessage = chrome.FindElement(By.CssSelector("#txtAge"));
            Assert.IsTrue(showMessage.Text.Equals("Success - Check box is checked"));*/

        }

        [Test]
        public static void Test()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://pigu.lt/lt/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            IWebElement UserLoginArea = driver.FindElement(By.CssSelector("#fixedHeaderContainer > div > div > div.header-bottom > ul > li.visitor-login.has-submenu.guide-item"));
            UserLoginArea.Click();
            IWebElement UserLogInEmail = driver.FindElement(By.CssSelector("#loginModal > div:nth-child(1) > div.col-1-of-2.login-details > form > div:nth-child(4) > input[type=email]"));
            UserLogInEmail.Clear();
            string usermail = "testamailas@gmail.com";
            UserLogInEmail.SendKeys(usermail);
            string userpass = "test2021";
            IWebElement UserLogInPass = driver.FindElement(By.CssSelector("#passwordCont > input[type=password]"));
            UserLogInPass.SendKeys(userpass);
            driver.FindElement(By.XPath("//*[@id='loginModal']/div[1]/div[1]/form/div[4]/input")).Click(); //Logino mygtuko paspaudimas
            driver.FindElement(By.CssSelector("#cartWidget > a:nth-child(1)")).Click(); // krepselio ikonos paskaudimas
            // krepselio patikrinimas ar prie telefono pridetas draudimas
            Thread.Sleep(5000);

            IWebElement InsuranceBoxCheck = driver.FindElement(By.CssSelector ("#insuranceCheckboxPzu272290896 > div"));
            InsuranceBoxCheck.Click();
            Thread.Sleep(5000);

            Assert.IsTrue( !InsuranceBoxCheck.Selected, "nepasirinktas draudimas");// kodel ki paselektintas pazymi jog folse. grazina reikksme xxx.selected falce

            //IWebElement = driver.FindElement(By.CssSelector ());
            //IWebElement = driver.FindElement(By.CssSelector ());
            //IWebElement = driver.FindElement(By.CssSelector ());

        }
        [Test]
        public static void TestFacebook()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.facebook.com/r.php?next=https%3A%2F%2Fwww.facebook.com%2Fpages%2Fcreate%2F%3Fref_type%3Dregistration_form&locale=en_US&display=page";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);/*
            driver.FindElement(By.XPath("//*[@id='u_0_j_Au']")).Click();
            driver.FindElement(By.CssSelector("#u_0_2_fW")).Click();
            driver.FindElement(By.CssSelector("#u_0_i_te")).Click();
            driver.FindElement(By.CssSelector("#u_0_p_lK")).Click();*/
            IWebElement monyhdroplist = driver.FindElement(By.CssSelector("#month"));
             SelectElement element = new SelectElement(monyhdroplist);
             element.SelectByValue("5");
            Thread.Sleep(1000);
            element.SelectByIndex(2);
            Thread.Sleep(1000);
            element.SelectByText("May");
        }

        /*
        [Test]
        public static void testchart()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://pigu.lt/lt/checkout/delivery/customer";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();

            IWebElement  phoneInputField = driver.FindElement(By.Id("phone"));
            phoneInputField.SendKeys("+365661616");

        }
    */
        }
}
