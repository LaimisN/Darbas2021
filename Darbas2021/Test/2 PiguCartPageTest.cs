using Darbas2021.Page;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Darbas2021.Test
{
    class PiguCartPageTest : BaseTest 
    {

        public static void LogInToPage()
        {
            PiguCartPage page = new PiguCartPage(driver);
            page.NavigateToDefaultPage();
            page.LogInProcedure("testamailas@gmail.com", "test2021");
        }

        [Test]
        public static void PiguPagecartItemRemoval()
        {
            // PiguCartPage page = new PiguCartPage(driver);
            // page.NavigateToDefaultPage();
            // page.LogInProcedure("testamailas@gmail.com", "test2021");
            LogInToPage();
            PiguCartPage page = new PiguCartPage(driver);
            page.IfNotEmptyThanEmptyCartConformation();
           // page.RemoveFromCartOperation();
           // page.EmptyCartConformation();


            // page.VerificationOfLogedUser("testamailas@gmail.com");
        }
        [Test]
        public static void CheckoutDeliveryForm()
        {
            LogInToPage();
            PiguCartPage page = new PiguCartPage(driver);
            page.CartContinueButtonAndClick();
           // page.CartContinueButtonAndClick();
        }


    }
}
