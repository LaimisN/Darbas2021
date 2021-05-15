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
            LogInToPage();
            PiguCartPage page = new PiguCartPage(driver);
            page.IfNotEmptyThanEmptyCartConformation(); 
        }
        [Test]
        public static void CheckoutDeliveryFormReceiverNewPersonComparison()
        {
            string name = "Tuktukas";
            string surname = "Plaktukas";

            LogInToPage();
            PiguCartPage page = new PiguCartPage(driver);
            page.CartContinueNewPersonTakeOrder(name, surname);
            page.NewReceivercheckUp(name, surname);
        }

        //Thread.Sleep(2000);

    }
}
