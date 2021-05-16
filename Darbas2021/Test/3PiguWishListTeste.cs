using Darbas2021.Page;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darbas2021.Test
{
    class _3PiguWishListTeste : BaseTest
    {
        public static void LogInToPage()
        {
            _3PiguWishListPage page = new _3PiguWishListPage(driver);
            page.NavigateToDefaultPage();
            page.LogInProcedure("testamailas@gmail.com", "test2021");
        }

        [Test]
        public static void PiguWiskListAddandConfirmation()
        {
            LogInToPage();
            _3PiguWishListPage page = new _3PiguWishListPage(driver);
            page.AddItemToWishList();
            page.WishListItemConformation();
        }
    }
}
