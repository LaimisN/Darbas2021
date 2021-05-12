using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darbas2021.Driver
{
    public class CustomDriver
    {
        public static IWebDriver GetChromeDriver()
        {
            return GetDriver(Browsers.Chrome);
        }

        public static IWebDriver GetFirefoxDriver()
        {
            return GetDriver(Browsers.Firefox);
        }

        private static IWebDriver GetDriver(Browsers browserName)
        {
            IWebDriver webdriver = null;
            switch (browserName)
            {
                case Browsers.Chrome:
                    webdriver = new ChromeDriver();
                    break;
                case Browsers.Firefox:
                    webdriver = new FirefoxDriver();
                    break;
                case Browsers.Opera:
                    OperaDriverService service = OperaDriverService.CreateDefaultService("C:\\Users\\Bullet\\AppData\\Local\\Programs\\Opera", "operadriver.exe");
                    var operaOptions = new OperaOptions
                    {
                        BinaryLocation = "C:\\Users\\Bullet\\AppData\\Local\\Programs\\Opera\\76.0.4017.107\\opera.exe",
                        LeaveBrowserRunning = false
                    };
                    webdriver = new OperaDriver(service, operaOptions);
                    break;
                default:
                    webdriver = new ChromeDriver();

                    break;
            }

            webdriver.Manage().Window.Maximize();
            webdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return webdriver;
        }

    }
}
