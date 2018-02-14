using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading.Tasks;
using System;

namespace ChromeDrivers
{
    class Program
    {
        public static object DeviceId { get; private set; }
        public static string RpcPath { get; private set; }

        static void Main(string[] args)
        {
            RpcPath = "https://mm16.r11.fuel.ddns.ea.com/g/tools/";
            MultiChrome(new string[] { "user-reset", "cheatsTEST" });
        }

        public static void MultiChrome(string[] cheats)
        {
            using (ChromeDriver driver = new ChromeDriver(@"D:\gastanica_RO-3050829_5456\EAOS\QECS\TOOLS\GatorScripts\MaddenMobile\SeleniumDriver"))
            {
                //driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl(RpcPath);
                driver.FindElement(By.Name("username")).SendKeys("automationcqa@ea.com");
                driver.FindElement(By.Name("password")).SendKeys("Farmmach1ne");
                driver.FindElementByXPath(("//button[contains(.,'Login')]")).Click();
                Thread.Sleep(2000);
                driver.Navigate().GoToUrl("https://mm16.r11.fuel.ddns.ea.com/g/tools/users");
                driver.FindElement(By.Id("query")).SendKeys("asdfgh");
                driver.FindElement(By.Id("submit-search")).Click();
                ///html/body/div[4]/div[4]/div[1]/div/div/div/small[1]
                var rpcDevelopment = String.Format("{0}/development/rpc", RpcPath);
                driver.Navigate().GoToUrl("https://mm16.r11.fuel.ddns.ea.com/g/tools/development/rpc");
                foreach (var item in cheats)
                {
                    Thread.Sleep(2000);
                    driver.FindElementByXPath((".//*[@id='rpc-user']")).SendKeys("ssssss");
                    driver.FindElementByXPath(".//*[@id='rpc-method']").SendKeys(item);
                    driver.FindElementByXPath(("//*[@id='rpc-form']/div[1]/div[3]/button")).Click();
                    Thread.Sleep(2000);
                    driver.FindElementByXPath(".//*[@id='rpc-method']").Clear();
                }
            }
        }
    }
}
