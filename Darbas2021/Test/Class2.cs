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
    class Class2:BaseTest 
    {

        [Order(2)]
        [Test]
        public static void MultipleCheckBoxTest()
        {
            Class11 page = new Class11(driver);

            page.NavigateToDefaultPage();
           page.singlecheckclick();
            Thread.Sleep(3000);
            page.CheckAllMultipleCheckBoxes();
            Thread.Sleep(2000);
            /*
            basicCheckboxDemoPage.NavigateToDefaultPage()
                .CheckAllMultipleCheckBoxes()
                .AssertButtonName("Uncheck All");*/
        }

    }
}
