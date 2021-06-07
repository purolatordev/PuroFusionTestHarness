using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Guru99Demo
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            //driver = new ChromeDriver("D:\\3rdparty\\chrome");@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"
            driver = new ChromeDriver(@"C:\Software\Selenium");
            
        }

        [Test]
        public void test()
        {
            driver.Url = "https://www.google.com";
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
