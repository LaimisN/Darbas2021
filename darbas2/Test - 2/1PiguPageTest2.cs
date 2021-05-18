
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

    class PiguPageTest2 : BaseTest2
    {
        [Order(1)]
        [Test, Category("Happy Flow 2")]

        public static void NewUserRegistration()
        {
            string UserName = "testamailas47@gmail.com";// tam kad veiktu reikia pakeisti maila.
            string password = "test2021";
            piguPage2.NavigateToDefaultPage()
            .LogInProcedure(UserName, password)
            .RegistrationProcedure(password)
            .RegistrationVerification(UserName);

        }
        [Order(2)]
        [Test, Category("Happy Flow 2")]

        public static void PiguPageUserLogInLogOutTest()
        {
            piguPage2.NavigateToDefaultPage()
            .LogInProcedure("testamailas@gmail.com", "test2021")
            .VerificationOfLogedUser("testamailas@gmail.com")
            .LogOutProcedure()
            .LogOutVerification();
        }
        [Order(3)]
        [Test, Category("Happy Flow 2")]
        public static void PiguPageUserLogOutTest()
        {
            piguPage2.NavigateToDefaultPage()
            .LogInProcedure("testamailas@gmail.com", "test2021")
            .LogOutProcedure()
            .LogOutVerification();
        }

        [Order(4)]
        [Test, Category("Happy Flow 2")]
        public static void PiguCartInput()
        {
            piguPage2.NavigateToDefaultPage()
            .LogInProcedure("testamailas@gmail.com", "test2021")
            //samsung galaxy s21 prekis idejimas i krepseli
            .InputInItemEnterField("samsung galaxy s21")

            .SearchForItemNavigationCliks()
            .ItemInCartValidation();

        }

    }
}
