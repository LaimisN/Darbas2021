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
    class PiguCartPageTest2 : BaseTest2
    {
        public static void LogInToPage()
        {
            piguCartPage2.NavigateToDefaultPage()
            .LogInProcedure("testamailas@gmail.com", "test2021");
        }
        [Order(2)]
        [Test, Category("Regression Testing 2")]
        public static void PiguPagecartItemRemoval()
        {    
            LogInToPage();
            piguCartPage2.IfNotEmptyThanEmptyCartConformation(); 
        }
        [Order(1)]
        [Test, Category("Regression Testing 2")]
        public static void CheckoutDeliveryFormReceiverNewPersonComparison()
        {
            string name = "Tuktukas";
            string surname = "Plaktukas";

            LogInToPage();
            piguCartPage2.CartContinueNewPersonTakeOrder(name, surname)
            .NewReceivercheckUp(name, surname)
            .LogOutProcedure();
        }
    }
}
