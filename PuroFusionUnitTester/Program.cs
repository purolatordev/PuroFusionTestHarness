using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ConsoleApp1
{
    class Program
    {
        static IWebDriver driver;
        static void Main(string[] args)
        {
            //Guru99Demo g = new Guru99Demo();
            //g.startBrowser();
            //g.test();
            //FirstExample();
            driver = new ChromeDriver(@"C:\Software\Selenium");
            PuroFusion2();
            driver.Quit();
            Environment.Exit(0);
            return;
        }
        static void PuroFusion2()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                driver.Navigate().GoToUrl("http://localhost/PuroFusion/");
                Console.WriteLine("Go to PuroFusion");

                string originalWindow = driver.CurrentWindowHandle;

                //Check we don't have other windows open already
                Assert.AreEqual(driver.WindowHandles.Count, 1);

                var q = driver.FindElement(By.TagName("input"));
                var inputUserName = driver.FindElement(By.Id("ctl00_MainContentLogin_txtUser"));
                var UserName = inputUserName.GetAttribute("value");
                Console.WriteLine("txtUser: " + UserName.ToString());

                driver.FindElement(By.Id("ctl00_MainContentLogin_txtPasswrd")).SendKeys("your value");
                driver.FindElement(By.Id("ctl00_MainContentLogin_btnSubmit_input")).Click();
                Console.WriteLine("Login press");

                string strLogInType = driver.FindElement(By.Id("LoginStatus1_lblRole")).Text;
                Console.WriteLine("Login Account Type: " + strLogInType);
                driver.FindElement(By.Id("ctl00_MainContent_rgRequests_ctl00_ctl04_btnEdit")).Click();
                var yourParentElement = driver.FindElement(By.Id("ctl00_MainContent_RadTabStrip1"));
                IReadOnlyCollection<IWebElement> children = yourParentElement.FindElements(By.XPath(".//*"));
                var p = children.Where(f => f.TagName == "li").Select(f => f.Text).ToList();
                IList<string> tabsCompare = new List<string>() { "Customer Info", "Contact Info", "Current Solution", "Shipping Services", "Profile", "Non-Courier EDI", "Add'l Notes", "File Uploads" };
                bool isEqual = Enumerable.SequenceEqual(p, tabsCompare);
                Console.WriteLine("Solution Type Shipping Services tabs correct: " + isEqual.ToString());
                //IList<string> tabs = new List<string>();
                //foreach (IWebElement e in children)
                //{
                //    if (e.TagName.Contains("li"))
                //    {
                //        tabs.Add(e.Text);
                //    }
                //}

                var ParentSolutionType = driver.FindElement(By.Id("ctl00_MainContent_rddlSolutionType"));
                IWebElement Item2 = ParentSolutionType.FindElement(By.ClassName("rddlInner"));
                Console.WriteLine("rddlInner - Item2");
                IReadOnlyCollection<IWebElement> AllLis = ParentSolutionType.FindElements(By.ClassName("rddlItem"));
                Console.WriteLine("AllLis...");
                Item2.Click();
                Console.WriteLine("rItem2.Click()");

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                AllLis.ElementAt(1).Click();
                Console.WriteLine("AllLis.ElementAt(1).Click()");

                IList<string> tabsEDI = new List<string>() { "Customer Info", "Contact Info", "Current Solution", "EDI Services", "Profile", "Non-Courier EDI", "Add'l Notes", "File Uploads" };
                yourParentElement = driver.FindElement(By.Id("ctl00_MainContent_RadTabStrip1"));
                children = yourParentElement.FindElements(By.XPath(".//*"));
                p = children.Where(f => f.TagName == "li").Select(f => f.Text).ToList();
                isEqual = Enumerable.SequenceEqual(p, tabsEDI);
                Console.WriteLine("Solution Type EDI tabs correct: " + isEqual.ToString());

                Console.WriteLine("Click... EDI Services Tab");
                IReadOnlyCollection<IWebElement> AllTheTabs = children.Where(f => f.TagName == "li").ToList();
                AllTheTabs.ElementAt(3).Click();
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            int er = 0;

            er++;
        }
        static void PuroFusion1()
        {
            using (IWebDriver driver = new ChromeDriver(@"C:\Software\Selenium"))
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                driver.Navigate().GoToUrl("http://localhost/PuroFusion/");
                string originalWindow = driver.CurrentWindowHandle;

                //Check we don't have other windows open already
                Assert.AreEqual(driver.WindowHandles.Count, 1);

                //Click the link which opens in a new window
                //var q = driver.FindElement(By.TagName("ctl00_MainContentLogin_txtPasswrd"));
                var q = driver.FindElement(By.TagName("input"));
                var inputUserName = driver.FindElement(By.Id("ctl00_MainContentLogin_txtUser"));
                var UserName = inputUserName.GetAttribute("value");
                driver.FindElement(By.Id("ctl00_MainContentLogin_txtPasswrd")).SendKeys("your value");
                driver.FindElement(By.Id("ctl00_MainContentLogin_btnSubmit_input")).Click();
                driver.FindElement(By.Id("ctl00_MainContent_rgRequests_ctl00_ctl04_btnEdit")).Click();
                int er = 0;

                er++;
                //driver.Quit(); 
                //driver.FindElement(By.Name("q")).SendKeys("cheese" + Keys.Enter);
                //wait.Until(webDriver => webDriver.FindElement(By.CssSelector("h3")).Displayed);
                //IWebElement firstResult = driver.FindElement(By.CssSelector("h3"));
                //Console.WriteLine(firstResult.GetAttribute("textContent"));
            }
        }
        static void FirstExample()
        {
            using (IWebDriver driver = new ChromeDriver(@"C:\Software\Selenium"))
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                driver.Navigate().GoToUrl("https://www.google.com/ncr");
                driver.FindElement(By.Name("q")).SendKeys("cheese" + Keys.Enter);
                wait.Until(webDriver => webDriver.FindElement(By.CssSelector("h3")).Displayed);
                IWebElement firstResult = driver.FindElement(By.CssSelector("h3"));
                Console.WriteLine(firstResult.GetAttribute("textContent"));
            }
        }
    }
}
