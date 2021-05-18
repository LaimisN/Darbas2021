using Darbas2021.Page;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darbas2021.Test
{
    class _3PiguWishListTeste2 : BaseTest2
    {
        public static void LogInToPage()
        {
            _3piguWishListPage2.NavigateToDefaultPage()
            .LogInProcedure("testamailas@gmail.com", "test2021");
        }

        [Test, Category("Regression Testing 2")]

        public static void PiguWiskListAddandConfirmation()
        {
            LogInToPage();
            _3piguWishListPage2.AddItemToWishList()
            .WishListItemConformation();
        }
    }
}
