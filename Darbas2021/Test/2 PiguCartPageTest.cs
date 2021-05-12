using Darbas2021.Page;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darbas2021.Test
{
    class PiguCartPageTest : BaseTest 
    {
        [Test]
        public static void PiguPageUserLogInTest()
        {
            PiguCartPage page = new PiguCartPage(driver);
            page.NavigateToDefaultPage();
            page.LogInProcedure("testamailas@gmail.com", "test2021");


           // page.VerificationOfLogedUser("testamailas@gmail.com");
        }
    }
}
