using Darbas2021.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Darbas2021.Test
{
    class PiguPageTest : BaseTest
    {
        [Order(1)]
        [Test]
       
        public static void NewUserRegistration()
        {
            string UserName = "testamailas37@gmail.com";// tam kad veiktu reikia pakeisti maila.
            string password = "test2021";
            PiguPage page = new PiguPage(driver);
            page.NavigateToDefaultPage();
            page.LogInProcedure(UserName, password);
            page.RegistrationProcedure(password);
            page.RegistrationVerification(UserName);
            
        }
        [Order(2)]
        [Test]
        public static void PiguPageUserLogInLogOutTest()
        {
            PiguPage page = new PiguPage(driver);
            page.NavigateToDefaultPage();
            page.LogInProcedure("testamailas@gmail.com", "test2021");
            page.VerificationOfLogedUser("testamailas@gmail.com");
            page.LogOutProcedure();
            page.LogOutVerification();
        }
        [Order(3)]
        [Test]
        public static void PiguPageUserLogOutTest()
        {
            PiguPage page = new PiguPage(driver);
            page.NavigateToDefaultPage();
            page.LogInProcedure("testamailas@gmail.com", "test2021");

            page.LogOutProcedure();
            page.LogOutVerification();
        }

        [Order(4)]
        [Test]
        public static void PiguCartInput()
        {
            PiguPage page = new PiguPage(driver);
            page.NavigateToDefaultPage();
            page.LogInProcedure("testamailas@gmail.com", "test2021");
             //samsung galaxy s21 prekis idejimas i krepseli
            page.InputInItemEnterField("samsung galaxy s21");
            
            page.SearchForItemNavigationCliks();
            page.ItemInCartValidation();

        }
        
    }
}
