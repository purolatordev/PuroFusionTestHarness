using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PuroFusionLib;

namespace ConsoleApp1
{
    class Program
    {
        static IWebDriver driver;
        const int SOLUTION_TYPE_SHIPPING = 1;
        const int SOLUTION_TYPE_EDI = 2;
        const int SOLUTION_TYPE_BOTH = 3;
        static IList<string> Tests = new List<string>() { "Sales Shipping Test 1", "Sales Shipping Test 2", "Sales Shipping Test 3", "Sales Shipping Test 4", "Sales Shipping Test 5" };
        public enum TheTests:int  {SalesShippingTest1=0, SalesShippingTest2, SalesShippingTest3, SalesShippingTest4, SalesShippingTest5 };

        static void Main(string[] args)
        {
            IList<WhatToTest> ToTest = new List<WhatToTest>() { 
                new WhatToTest() {Name = Tests[(int)TheTests.SalesShippingTest1], Enabled = true, Step = 1.0},
                new WhatToTest() {Name = Tests[(int)TheTests.SalesShippingTest2], Enabled = true, Step = 2.0},
                new WhatToTest() {Name = Tests[(int)TheTests.SalesShippingTest3], Enabled = true, Step = 3.0},
                new WhatToTest() {Name = Tests[(int)TheTests.SalesShippingTest4], Enabled = true, Step = 4.0},
                new WhatToTest() {Name = Tests[(int)TheTests.SalesShippingTest5], Enabled = true, Step = 5.0}
            };
            DiscoveryReqUpdates insert = new DiscoveryReqUpdates()
            {
                CustomerName = "Customer A",
                Address1 = "Cust A Address B",
                Zip = "11554",
                City = "Park Slope",
                State = "NY",
                Revenue = 123.81,
                FirstName = "Scott",
                LastName = "Cardinale",
                idSolutionType = SOLUTION_TYPE_SHIPPING,
                idRequestType = 1,
                dt1 = DateTime.Now,
            };
            //string sql = GetStringToInsertIntoDb2(insert);
            //PuroTouchServiceClass o = new PuroTouchServiceClass(PuroTouchServiceClass.ConnString.PatientLocal3);
            //o.InsertTestDiscoveryRequestRecord(sql);

            driver = new ChromeDriver(@"C:\Software\Selenium");

            bool bLoggedIn = false;
            TheTests CurrentTest = TheTests.SalesShippingTest1;

            #region Sales Shipping Test 1
            if (ToTest[(int)CurrentTest].Enabled)
            {
                //Console.WriteLine("Press Space Bar to start " + ToTest[(int)CurrentTest].Name);
                //Console.ReadKey();
                if (SalesShippingTest1(insert, ToTest[(int)CurrentTest].Step))
                {
                    Console.WriteLine(ToTest[(int)CurrentTest].Name + " Passedl!");
                    bLoggedIn = true;
                }
                else
                {
                    Console.WriteLine(ToTest[(int)CurrentTest].Name + " Failed!");
                }
                //Console.WriteLine(ToTest[(int)CurrentTest].Name + " finished press Space Bar to continue.");
                //Console.ReadKey();
            }
            #endregion

            CurrentTest = CurrentTest.Next();

            #region Sales Shipping Test 2
            if (ToTest[(int)CurrentTest].Enabled)
            {
                //Console.WriteLine("Press Space Bar to start " + ToTest[(int)CurrentTest].Name);
                //Console.ReadKey();
                if ( SalesShippingTest2(insert, bLoggedIn, ToTest[(int)CurrentTest].Step) )
                {
                    Console.WriteLine(ToTest[(int)CurrentTest].Name + " was successful!");
                }
                else
                {
                    Console.WriteLine(ToTest[(int)CurrentTest].Name + " failed!");
                }
                bLoggedIn = true;
                //Console.WriteLine(ToTest[(int)CurrentTest].Name + " finished press Space Bar to continue.");
                //Console.ReadKey();
            }
            #endregion

            CurrentTest = CurrentTest.Next();

            #region Sales Shipping Test 3
            if (ToTest[(int)CurrentTest].Enabled)
            {
                //Console.WriteLine("Press Space Bar to start " + ToTest[(int)CurrentTest].Name);
                //Console.ReadKey();
                if (SalesShippingTest3(insert, bLoggedIn, ToTest[(int)CurrentTest].Step))
                {
                    Console.WriteLine(ToTest[(int)CurrentTest].Name + " was successful!");
                }
                else
                {
                    Console.WriteLine(ToTest[(int)CurrentTest].Name + " failed!");
                }
                bLoggedIn = true;
                //Console.WriteLine(ToTest[(int)CurrentTest].Name + " finished press Space Bar to continue.");
                //Console.ReadKey();
            }
            #endregion

            CurrentTest = CurrentTest.Next();

            #region Sales Shipping Test 4
            if (ToTest[(int)CurrentTest].Enabled)
            {
                //Console.WriteLine("Press Space Bar to start " + ToTest[(int)CurrentTest].Name);
                //Console.ReadKey();
                if (SalesShippingTest4(insert, bLoggedIn, ToTest[(int)CurrentTest].Step))
                {
                    Console.WriteLine(ToTest[(int)CurrentTest].Name + " was successful!");
                }
                else
                {
                    Console.WriteLine(ToTest[(int)CurrentTest].Name + " failed!");
                }
                bLoggedIn = true;
                //Console.WriteLine(ToTest[(int)CurrentTest].Name + " finished press Space Bar to continue.");
                //Console.ReadKey();
            }
            #endregion

            CurrentTest = CurrentTest.Next();

            #region Sales Shipping Test 5
            if (ToTest[(int)CurrentTest].Enabled)
            {
                //Console.WriteLine("Press Space Bar to start " + ToTest[(int)CurrentTest].Name);
                //Console.ReadKey();
                if (SalesShippingTest5(insert, bLoggedIn, ToTest[(int)CurrentTest].Step))
                {
                    Console.WriteLine(ToTest[(int)CurrentTest].Name + " was successful!");
                }
                else
                {
                    Console.WriteLine(ToTest[(int)CurrentTest].Name + " failed!");
                }
                bLoggedIn = true;
                //Console.WriteLine(ToTest[(int)CurrentTest].Name + " finished press Space Bar to continue.");
                //Console.ReadKey();
            }
            #endregion
            driver.Quit();
            Environment.Exit(0);
            return;
        }
        static bool SalesShippingTest5(DiscoveryReqUpdates insert, bool bLoggedIn, double Step)
        {
            bool bRetVal = false;
            string strCurrentStep = String.Format("Step {0:0.0#}", Step);
            try
            {
                if (!bLoggedIn)
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                    driver.Navigate().GoToUrl("http://localhost/PuroFusion/");

                    //Check we don't have other windows open already
                    Assert.AreEqual(driver.WindowHandles.Count, 1);

                    var q = driver.FindElement(By.TagName("input"));
                    var inputUserName = driver.FindElement(By.Id("ctl00_MainContentLogin_txtUser"));
                    var UserName = inputUserName.GetAttribute("value");

                    driver.FindElement(By.Id("ctl00_MainContentLogin_txtPasswrd")).SendKeys("your value");
                    driver.FindElement(By.Id("ctl00_MainContentLogin_btnSubmit_input")).Click();

                    string strLogInType = driver.FindElement(By.Id("LoginStatus1_lblRole")).Text;
                }
                driver.FindElement(By.Id("ctl00_MainContent_btnNewRequest_input")).Click();

                // Check tab strip for the tabs that are available
                string strRadTabID = "ctl00_MainContent_RadTabStrip1";
                IList<Tabs> tab2 = new List<Tabs>() {
                    new Tabs() { Name = "Customer Info", Enabled = true, Selected = true },
                    new Tabs() { Name = "Contact Info" },
                    new Tabs() { Name = "Current Solution" },
                    new Tabs() { Name = "Shipping Services" }
                };
                if (GetRadTabStrip(strRadTabID, tab2))
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }
                SelectDropdown("ctl00_MainContent_rddlDistrict");
                Thread.Sleep(5000);
                SelectDropdown("ctl00_MainContent_rddlBranch");
                Thread.Sleep(4000);
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                SelectDropdown("ctl00_MainContent_rddlRequestType");
                Thread.Sleep(4000);

                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerName")).SendKeys(insert.CustomerName);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerAddress")).SendKeys(insert.Address1);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerZip")).SendKeys(insert.Zip);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerCity")).SendKeys(insert.City);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerState")).SendKeys(insert.State);
                driver.FindElement(By.Id("ctl00_MainContent_txtRevenue")).SendKeys(insert.Revenue.ToString());
                driver.FindElement(By.Id("ctl00_MainContent_txtCommodity")).SendKeys("Shoes");

                // Click the Next Button Step 5.1
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab1")).Click();

                IList<Tabs> tab = new List<Tabs>() {
                    new Tabs() { Name = "Customer Info", Enabled = true },
                    new Tabs() { Name = "Contact Info" , Enabled = true, Selected = true},
                    new Tabs() { Name = "Current Solution" },
                    new Tabs() { Name = "Shipping Services" }
                };
                if (GetRadTabStrip(strRadTabID, tab))
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                    bRetVal = true;
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }
                driver.FindElement(By.Id("ctl00_MainContent_contactGrid_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();
                SelectDropdown("ctl00_MainContent_contactGrid_ctl00_ctl02_ctl03_radListContactType");
                Thread.Sleep(5000);

                driver.FindElement(By.Id("ctl00_MainContent_contactGrid_ctl00_ctl02_ctl03_txtBxContactName2")).SendKeys("Contact Test Name");
                driver.FindElement(By.Id("ctl00_MainContent_contactGrid_ctl00_ctl02_ctl03_txtBxContactTitle2")).SendKeys("Test Title");
                driver.FindElement(By.Id("ctl00_MainContent_contactGrid_ctl00_ctl02_ctl03_txtBxContactEmail2")).SendKeys("test.person@test.com");
                driver.FindElement(By.Id("ctl00_MainContent_contactGrid_ctl00_ctl02_ctl03_txtBxContactPhone2")).SendKeys("516 725-8956");

                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                Thread.Sleep(5000);
                driver.FindElement(By.Id("ctl00_MainContent_contactGrid_ctl00_ctl02_ctl03_btnUpdate_input")).Click();
                Thread.Sleep(5000);

                //Step 5.2
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                if (driver.FindElement(By.Id("ctl00_MainContent_btnNextTab2")).Displayed)
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                    bRetVal = true;
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab2")).Click();
                Thread.Sleep(5000);

                // Step 5.3
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                IList<Tabs> tab3 = new List<Tabs>() {
                    new Tabs() { Name = "Customer Info", Enabled = true },
                    new Tabs() { Name = "Contact Info" , Enabled = true},
                    new Tabs() { Name = "Current Solution", Enabled = true, Selected = true },
                    new Tabs() { Name = "Shipping Services" }
                };
                if (GetRadTabStrip(strRadTabID, tab3))
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                    bRetVal = true;
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }
                driver.FindElement(By.Id("MainContent_txtareaCurrentSolution")).SendKeys("This is a test message for the Current Soltion.");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab3")).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                IList<Tabs> tab4 = new List<Tabs>() {
                    new Tabs() { Name = "Customer Info", Enabled = true },
                    new Tabs() { Name = "Contact Info" , Enabled = true},
                    new Tabs() { Name = "Current Solution", Enabled = true},
                    new Tabs() { Name = "Shipping Services",Enabled = true, Selected = true }
                };
                // Step 5.4
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                if (GetRadTabStrip(strRadTabID, tab4))
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                    bRetVal = true;
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }

                driver.FindElement(By.Id("ctl00_MainContent_btnSubmit_input")).Click();
                Thread.Sleep(2000);

                // Step 1.5
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                if (driver.FindElement(By.Id("MainContent_CustomValidatorNew")).Displayed)
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                    bRetVal = true;
                    driver.FindElement(By.Id("ctl00_MainContent_btnExit1_input")).Click();
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return bRetVal;
        }

        static bool SalesShippingTest4(DiscoveryReqUpdates insert, bool bLoggedIn, double Step)
        {
            bool bRetVal = false;
            string strCurrentStep = String.Format("Step {0:0.0#}", Step);
            try
            {
                if (!bLoggedIn)
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                    driver.Navigate().GoToUrl("http://localhost/PuroFusion/");

                    //Check we don't have other windows open already
                    Assert.AreEqual(driver.WindowHandles.Count, 1);

                    var q = driver.FindElement(By.TagName("input"));
                    var inputUserName = driver.FindElement(By.Id("ctl00_MainContentLogin_txtUser"));
                    var UserName = inputUserName.GetAttribute("value");

                    driver.FindElement(By.Id("ctl00_MainContentLogin_txtPasswrd")).SendKeys("your value");
                    driver.FindElement(By.Id("ctl00_MainContentLogin_btnSubmit_input")).Click();

                    string strLogInType = driver.FindElement(By.Id("LoginStatus1_lblRole")).Text;
                }
                driver.FindElement(By.Id("ctl00_MainContent_btnNewRequest_input")).Click();

                // Check tab strip for the tabs that are available
                string strRadTabID = "ctl00_MainContent_RadTabStrip1";
                IList<Tabs> tab2 = new List<Tabs>() {
                    new Tabs() { Name = "Customer Info", Enabled = true, Selected = true },
                    new Tabs() { Name = "Contact Info" },
                    new Tabs() { Name = "Current Solution" },
                    new Tabs() { Name = "Shipping Services" }
                };
                if (GetRadTabStrip(strRadTabID, tab2))
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }
                SelectDropdown("ctl00_MainContent_rddlDistrict");
                Thread.Sleep(5000);
                SelectDropdown("ctl00_MainContent_rddlBranch");
                Thread.Sleep(4000);
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                SelectDropdown("ctl00_MainContent_rddlRequestType");
                Thread.Sleep(4000);

                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerName")).SendKeys(insert.CustomerName);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerAddress")).SendKeys(insert.Address1);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerZip")).SendKeys(insert.Zip);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerCity")).SendKeys(insert.City);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerState")).SendKeys(insert.State);
                driver.FindElement(By.Id("ctl00_MainContent_txtRevenue")).SendKeys(insert.Revenue.ToString());
                driver.FindElement(By.Id("ctl00_MainContent_txtCommodity")).SendKeys("Shoes");

                // Click the Next Button Step 1.1
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab1")).Click();

                IList<Tabs> tab = new List<Tabs>() {
                    new Tabs() { Name = "Customer Info", Enabled = true },
                    new Tabs() { Name = "Contact Info" , Enabled = true, Selected = true},
                    new Tabs() { Name = "Current Solution" },
                    new Tabs() { Name = "Shipping Services" }
                };
                if (GetRadTabStrip(strRadTabID, tab))
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                    bRetVal = true;
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }
                driver.FindElement(By.Id("ctl00_MainContent_contactGrid_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();
                SelectDropdown("ctl00_MainContent_contactGrid_ctl00_ctl02_ctl03_radListContactType");
                Thread.Sleep(5000);

                driver.FindElement(By.Id("ctl00_MainContent_contactGrid_ctl00_ctl02_ctl03_txtBxContactName2")).SendKeys("Contact Test Name");
                driver.FindElement(By.Id("ctl00_MainContent_contactGrid_ctl00_ctl02_ctl03_txtBxContactTitle2")).SendKeys("Test Title");
                driver.FindElement(By.Id("ctl00_MainContent_contactGrid_ctl00_ctl02_ctl03_txtBxContactEmail2")).SendKeys("test.person@test.com");
                driver.FindElement(By.Id("ctl00_MainContent_contactGrid_ctl00_ctl02_ctl03_txtBxContactPhone2")).SendKeys("516 725-8956");

                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                Thread.Sleep(5000);
                driver.FindElement(By.Id("ctl00_MainContent_contactGrid_ctl00_ctl02_ctl03_btnUpdate_input")).Click();
                Thread.Sleep(5000);

                //Step 4.2
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                if (driver.FindElement(By.Id("ctl00_MainContent_btnNextTab2")).Displayed)
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                    bRetVal = true;
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab2")).Click();
                Thread.Sleep(5000);

                // Step 4.3
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                IList<Tabs> tab3 = new List<Tabs>() {
                    new Tabs() { Name = "Customer Info", Enabled = true },
                    new Tabs() { Name = "Contact Info" , Enabled = true},
                    new Tabs() { Name = "Current Solution", Enabled = true, Selected = true },
                    new Tabs() { Name = "Shipping Services" }
                };
                if (GetRadTabStrip(strRadTabID, tab3))
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                    bRetVal = true;
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }

                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab3")).Click();
                // Step 4.4
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                Console.WriteLine(strCurrentStep + " Passed");

                Thread.Sleep(2000);
                bool bctl05 = driver.FindElement(By.Id("MainContent_ctl05")).Displayed;
                // Step 4.5
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                if (bctl05)
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                    bRetVal = true;
                    driver.FindElement(By.Id("ctl00_MainContent_btnExit1_input")).Click();
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return bRetVal;
        }
        static bool SalesShippingTest3(DiscoveryReqUpdates insert, bool bLoggedIn, double Step)
        {
            bool bRetVal = false;
            string strCurrentStep = String.Format("Step {0:0.0#}", Step); 
            try
            {
                if (!bLoggedIn)
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                    driver.Navigate().GoToUrl("http://localhost/PuroFusion/");

                    //Check we don't have other windows open already
                    Assert.AreEqual(driver.WindowHandles.Count, 1);

                    var q = driver.FindElement(By.TagName("input"));
                    var inputUserName = driver.FindElement(By.Id("ctl00_MainContentLogin_txtUser"));
                    var UserName = inputUserName.GetAttribute("value");

                    driver.FindElement(By.Id("ctl00_MainContentLogin_txtPasswrd")).SendKeys("your value");
                    driver.FindElement(By.Id("ctl00_MainContentLogin_btnSubmit_input")).Click();

                    string strLogInType = driver.FindElement(By.Id("LoginStatus1_lblRole")).Text;
                }
                driver.FindElement(By.Id("ctl00_MainContent_btnNewRequest_input")).Click();

                // Check tab strip for the tabs that are available
                string strRadTabID = "ctl00_MainContent_RadTabStrip1";
                IList<Tabs> tab2 = new List<Tabs>() {
                    new Tabs() { Name = "Customer Info", Enabled = true, Selected = true },
                    new Tabs() { Name = "Contact Info" },
                    new Tabs() { Name = "Current Solution" },
                    new Tabs() { Name = "Shipping Services" }
                };
                if (GetRadTabStrip(strRadTabID, tab2))
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }
                SelectDropdown("ctl00_MainContent_rddlDistrict");
                Thread.Sleep(5000);
                SelectDropdown("ctl00_MainContent_rddlBranch");
                Thread.Sleep(4000);
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                SelectDropdown("ctl00_MainContent_rddlRequestType");
                Thread.Sleep(4000);

                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerName")).SendKeys(insert.CustomerName);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerAddress")).SendKeys(insert.Address1);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerZip")).SendKeys(insert.Zip);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerCity")).SendKeys(insert.City);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerState")).SendKeys(insert.State);
                driver.FindElement(By.Id("ctl00_MainContent_txtRevenue")).SendKeys(insert.Revenue.ToString());
                driver.FindElement(By.Id("ctl00_MainContent_txtCommodity")).SendKeys("Shoes");

                // Click the Next Button Step 3.1
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab1")).Click();
                IList<Tabs> tab = new List<Tabs>() {
                    new Tabs() { Name = "Customer Info", Enabled = true },
                    new Tabs() { Name = "Contact Info" , Enabled = true, Selected = true},
                    new Tabs() { Name = "Current Solution" },
                    new Tabs() { Name = "Shipping Services" }
                };
                if (GetRadTabStrip(strRadTabID, tab))
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                    bRetVal = true;
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }
                driver.FindElement(By.Id("ctl00_MainContent_contactGrid_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();
                SelectDropdown("ctl00_MainContent_contactGrid_ctl00_ctl02_ctl03_radListContactType");
                Thread.Sleep(5000);

                driver.FindElement(By.Id("ctl00_MainContent_contactGrid_ctl00_ctl02_ctl03_txtBxContactName2")).SendKeys("Contact Test Name");
                driver.FindElement(By.Id("ctl00_MainContent_contactGrid_ctl00_ctl02_ctl03_txtBxContactTitle2")).SendKeys("Test Title");
                driver.FindElement(By.Id("ctl00_MainContent_contactGrid_ctl00_ctl02_ctl03_txtBxContactEmail2")).SendKeys("test.person@test.com");
                driver.FindElement(By.Id("ctl00_MainContent_contactGrid_ctl00_ctl02_ctl03_txtBxContactPhone2")).SendKeys("516 725-8956");

                Thread.Sleep(5000);
                driver.FindElement(By.Id("ctl00_MainContent_contactGrid_ctl00_ctl02_ctl03_btnUpdate_input")).Click();
                Thread.Sleep(5000);

                // Step 3.2
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                if (driver.FindElement(By.Id("ctl00_MainContent_btnNextTab2")).Displayed)
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                    bRetVal = true;
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }

                // Step 3.3
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                // deleted the contact
                driver.FindElement(By.Id("ctl00_MainContent_contactGrid_ctl00_ctl04_gbcDeleteLink")).Click();
                Thread.Sleep(2000);
                if (!driver.FindElement(By.Id("ctl00_MainContent_btnNextTab2")).Enabled)
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                    bRetVal = true;
                    driver.FindElement(By.Id("ctl00_MainContent_btnExit1_input")).Click();
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return bRetVal;
        }
        static bool SalesShippingTest2(DiscoveryReqUpdates insert, bool bLoggedIn, double Step)
        {
            bool bRetVal = false;
            string strCurrentStep = String.Format("Step {0:0.0#}", Step);
            try
            {
                if (!bLoggedIn)
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                    driver.Navigate().GoToUrl("http://localhost/PuroFusion/");

                    //Check we don't have other windows open already
                    Assert.AreEqual(driver.WindowHandles.Count, 1);

                    var q = driver.FindElement(By.TagName("input"));
                    var inputUserName = driver.FindElement(By.Id("ctl00_MainContentLogin_txtUser"));
                    var UserName = inputUserName.GetAttribute("value");

                    driver.FindElement(By.Id("ctl00_MainContentLogin_txtPasswrd")).SendKeys("your value");
                    driver.FindElement(By.Id("ctl00_MainContentLogin_btnSubmit_input")).Click();

                    string strLogInType = driver.FindElement(By.Id("LoginStatus1_lblRole")).Text;
                }
                driver.FindElement(By.Id("ctl00_MainContent_btnNewRequest_input")).Click();
                // Check tab strip for the tabs that are available
                string strRadTabID = "ctl00_MainContent_RadTabStrip1";
                IList<Tabs> tab2 = new List<Tabs>() {
                    new Tabs() { Name = "Customer Info", Enabled = true, Selected = true },
                    new Tabs() { Name = "Contact Info" },
                    new Tabs() { Name = "Current Solution" },
                    new Tabs() { Name = "Shipping Services" }
                };
                if (GetRadTabStrip(strRadTabID, tab2))
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }

                // Click the Next Button Step 2.1
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab1")).Click();
                string firstValue = driver.FindElement(By.Id("MainContent_ctl01")).Text;
                bool bctl01 = driver.FindElement(By.Id("MainContent_ctl01")).Displayed;
              
                string firstValue2 = driver.FindElement(By.Id("MainContent_ctl02")).Text;
                bool bctl02 = driver.FindElement(By.Id("MainContent_ctl02")).Displayed;

                string firstValue3 = driver.FindElement(By.Id("MainContent_ctl03")).Text;
                bool bctl03 = driver.FindElement(By.Id("MainContent_ctl03")).Displayed;

                //if (firstValue.Contains("Request Type is required") && firstValue2.Contains("Annualized Revenue is required") && firstValue3.Contains("Commodity is required"))
                if (bctl01 && bctl02 && bctl03)
                {
                    bRetVal = true;
                    Console.WriteLine(strCurrentStep + " Passed");
                    driver.FindElement(By.Id("ctl00_MainContent_btnExit1_input")).Click();
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return bRetVal;
        }
        static bool SalesShippingTest1(DiscoveryReqUpdates insert, double Step)
        {
            bool bRetVal = false;
            string strCurrentStep = String.Format("Step {0:0.0#}", Step);
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                driver.Navigate().GoToUrl("http://localhost/PuroFusion/");
                Console.WriteLine("Go to PuroFusion");

                //Check we don't have other windows open already
                Assert.AreEqual(driver.WindowHandles.Count, 1);

                var q = driver.FindElement(By.TagName("input"));
                var inputUserName = driver.FindElement(By.Id("ctl00_MainContentLogin_txtUser"));
                var UserName = inputUserName.GetAttribute("value");
                //Console.WriteLine("txtUser: " + UserName.ToString());

                driver.FindElement(By.Id("ctl00_MainContentLogin_txtPasswrd")).SendKeys("your value");
                driver.FindElement(By.Id("ctl00_MainContentLogin_btnSubmit_input")).Click();
                //Console.WriteLine("Login press");

                string strLogInType = driver.FindElement(By.Id("LoginStatus1_lblRole")).Text;
                //Console.WriteLine("Login Account Type: " + strLogInType);
                driver.FindElement(By.Id("ctl00_MainContent_btnNewRequest_input")).Click();

                // Check tab strip for the tabs that are available
                string strRadTabID = "ctl00_MainContent_RadTabStrip1";
                IList<Tabs> tab2 = new List<Tabs>() {
                    new Tabs() { Name = "Customer Info", Enabled = true, Selected = true },
                    new Tabs() { Name = "Contact Info" },
                    new Tabs() { Name = "Current Solution" },
                    new Tabs() { Name = "Shipping Services" }
                };
                if (GetRadTabStrip(strRadTabID, tab2))
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }
                SelectDropdown("ctl00_MainContent_rddlDistrict");
                Thread.Sleep(5000);
                SelectDropdown("ctl00_MainContent_rddlBranch");
                Thread.Sleep(4000);
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                SelectDropdown("ctl00_MainContent_rddlRequestType");
                Thread.Sleep(4000);

                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerName")).SendKeys(insert.CustomerName);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerAddress")).SendKeys(insert.Address1);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerZip")).SendKeys(insert.Zip);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerCity")).SendKeys(insert.City);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerState")).SendKeys(insert.State);
                driver.FindElement(By.Id("ctl00_MainContent_txtRevenue")).SendKeys(insert.Revenue.ToString());
                driver.FindElement(By.Id("ctl00_MainContent_txtCommodity")).SendKeys("Shoes");

                // Click the Next Button Step 1.1
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab1")).Click();

                IList<Tabs> tab = new List<Tabs>() { 
                    new Tabs() { Name = "Customer Info", Enabled = true }, 
                    new Tabs() { Name = "Contact Info" , Enabled = true, Selected = true},
                    new Tabs() { Name = "Current Solution" },
                    new Tabs() { Name = "Shipping Services" } 
                };
                if( GetRadTabStrip(strRadTabID,tab) )
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                    bRetVal = true;
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }
                driver.FindElement(By.Id("ctl00_MainContent_contactGrid_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();
                SelectDropdown("ctl00_MainContent_contactGrid_ctl00_ctl02_ctl03_radListContactType");
                Thread.Sleep(5000);

                driver.FindElement(By.Id("ctl00_MainContent_contactGrid_ctl00_ctl02_ctl03_txtBxContactName2")).SendKeys("Contact Test Name");
                driver.FindElement(By.Id("ctl00_MainContent_contactGrid_ctl00_ctl02_ctl03_txtBxContactTitle2")).SendKeys("Test Title");
                driver.FindElement(By.Id("ctl00_MainContent_contactGrid_ctl00_ctl02_ctl03_txtBxContactEmail2")).SendKeys("test.person@test.com");
                driver.FindElement(By.Id("ctl00_MainContent_contactGrid_ctl00_ctl02_ctl03_txtBxContactPhone2")).SendKeys("516 725-8956");

                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                Thread.Sleep(5000);
                driver.FindElement(By.Id("ctl00_MainContent_contactGrid_ctl00_ctl02_ctl03_btnUpdate_input")).Click();
                Thread.Sleep(5000);

                //Step 1.2
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                if (driver.FindElement(By.Id("ctl00_MainContent_btnNextTab2")).Displayed)
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                    bRetVal = true;
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab2")).Click();
                Thread.Sleep(5000);

                // Step 1.3
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                IList<Tabs> tab3 = new List<Tabs>() {
                    new Tabs() { Name = "Customer Info", Enabled = true },
                    new Tabs() { Name = "Contact Info" , Enabled = true},
                    new Tabs() { Name = "Current Solution", Enabled = true, Selected = true },
                    new Tabs() { Name = "Shipping Services" }
                };
                if (GetRadTabStrip(strRadTabID, tab3))
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                    bRetVal = true;
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }
                driver.FindElement(By.Id("MainContent_txtareaCurrentSolution")).SendKeys("This is a test message for the Current Soltion.");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab3")).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                IList<Tabs> tab4 = new List<Tabs>() {
                    new Tabs() { Name = "Customer Info", Enabled = true },
                    new Tabs() { Name = "Contact Info" , Enabled = true},
                    new Tabs() { Name = "Current Solution", Enabled = true},
                    new Tabs() { Name = "Shipping Services",Enabled = true, Selected = true }
                };
                // Step 1.4
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                if (GetRadTabStrip(strRadTabID, tab4))
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                    bRetVal = true;
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }
                SelectDropdown("ctl00_MainContent_rddlService");
                Thread.Sleep(5000);
                driver.FindElement(By.Id("ctl00_MainContent_txtVolume")).SendKeys("2");
                Thread.Sleep(5000);
                driver.FindElement(By.Id("ctl00_MainContent_btnAddSvc_input")).Click();
                Thread.Sleep(5000);
                SelectDropdown("ctl00_MainContent_rddlCustomsList");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                SelectDropdown("ctl00_MainContent_rddlCustomsBroker");
                Thread.Sleep(5000);
                driver.FindElement(By.Id("ctl00_MainContent_btnSubmit_input")).Click();

                Thread.Sleep(5000);
                // Step 1.5
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                if (driver.FindElement(By.ClassName("rwPopupButton")).Displayed)
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                    bRetVal = true;
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }
                driver.FindElement(By.ClassName("rwPopupButton")).Click();
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return bRetVal;
        }

        private static bool GetRadTabStrip(string strRadTabID, IList<Tabs> tab)
        {
            bool bRetVal = false;
            var ParentElement = driver.FindElement(By.Id(strRadTabID));
            IReadOnlyCollection<IWebElement> AllTabs = ParentElement.FindElements(By.ClassName("rtsLink"));
            var qAllTabs = AllTabs.Where(f => f.TagName == "span").Select(f => f.Text).ToList();
            IReadOnlyCollection<IWebElement> SelectedTabs = ParentElement.FindElements(By.ClassName("rtsSelected"));
            var qSelectedTabs = SelectedTabs.Where(f => f.TagName == "li").Select(f => f.Text).ToList();
            IReadOnlyCollection<IWebElement> DisabledTabs = ParentElement.FindElements(By.ClassName("rtsDisabled"));
            var qDisabledTabs = DisabledTabs.Where(f => f.TagName == "li").Select(f => f.Text).ToList();

            var qTabs = tab.Select(f => f.Name).ToList();
            if(qAllTabs.Count == tab.Count)
            {
                bool isEqual = Enumerable.SequenceEqual(qAllTabs, qTabs);
                if (isEqual)
                {
                    //Console.WriteLine("Totally tabs correct");
                    var qTabsDisabled = tab.Where(f => f.Enabled == false).Select(f => f.Name).ToList();
                    isEqual = Enumerable.SequenceEqual(qDisabledTabs, qTabsDisabled);
                    if (isEqual)
                    {
                        //Console.WriteLine("Totally disabled tabs correct");
                        var qTabsSelected = tab.Where(f => f.Selected == true).Select(f => f.Name).ToList();
                        isEqual = Enumerable.SequenceEqual(qSelectedTabs, qTabsSelected);
                        if (isEqual)
                        {
                            //Console.WriteLine("Selected tab correct");
                            bRetVal = true;
                        }
                    }
                }
            }
            return bRetVal;
        }

        private static void SelectDropdown(string ID)
        {
            var ParentRequestType = driver.FindElement(By.Id(ID));
            IWebElement ReqTypeItem = ParentRequestType.FindElement(By.ClassName("rddlInner"));
            IReadOnlyCollection<IWebElement> AllRequestTypes = ParentRequestType.FindElements(By.ClassName("rddlItem"));
            ReqTypeItem.Click();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(2000);
            AllRequestTypes.ElementAt(1).Click();
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
        static string GetStringToInsertIntoDb2(DiscoveryReqUpdates insert)
        {
            string sql = @"INSERT[dbo].[tblDiscoveryRequest]([isNewRequest],[SalesRepName],[SalesRepEmail],[idOnboardingPhase],[District],[CustomerName],[Address],[City],[State],[Zipcode],[Country],[Commodity],[ProjectedRevenue],[CurrentSolution],[ProposedCustoms],[CallDate1],[CallDate2],[CallDate3],[UpdatedBy],[UpdatedOn],[CreatedBy],[CreatedOn],[ActiveFlag],[SalesComments],[idITBA],[idShippingChannel],[TargetGoLive],[ActualGoLive],[SolutionSummary],[CustomerWebsite],[Branch],[idVendor],[worldpakFlag],[thirdpartyFlag],[customFlag],[InvoiceType],[BilltoAccount],[FTPUsername],[FTPPassword],[CustomsSupportedFlag],[ElinkFlag],[PARS],[PASS],[CustomsBroker],[SupportUser],[SupportGroup],[Office],[Group],[MigrationDate],[PreMigrationSolution],[PostMigrationSolution],[ControlBranch],[ContractNumber],[ContractStartDate],[ContractEndDate],[ContractCurrency],[PaymentTerms],[CloseReason],[CRR],[BrokerNumber],[DataScrubFlag],[EDICustomizedFlag],[StrategicFlag],[ReturnsAcctNbr],[ReturnsAddress],[ReturnsCity],[ReturnsState],[ReturnsZip],[ReturnsCountry],[ReturnsDestroyFlag],[ReturnsCreateLabelFlag],[WPKSandboxUsername],[WPKSandboxPwd],[WPKProdUsername],[WPKProdPwd],[WPKCustomExportFlag],[WPKGhostScanFlag],[WPKEastWestSplitFlag],[WPKAddressUploadFlag],[WPKProductUploadFlag],[WPKDataEntryMethod],[WPKEquipmentFlag],[EWSelectBy],[EWSortCodeFlag],[EWEastSortCode],[EWWestSortCode],[EWSepCloseoutFlag],[EWSepPUFlag],[EWSortDetails],[EWMissortDetails],[CurrentGoLive],[PhaseChangeDate],[idRequestType],[CurrentlyShippingFlag],[idShippingVendor],[OtherVendorName],[idBroker],[OtherBrokerName],[idVendorType],[Route],[idSolutionType],[FreightAuditor],[EDIDetails],[idEDISpecialist],[idBillingSpecialist],[idCollectionSpecialist],[AuditorPortal],[AuditorURL],[AuditorUserName],[AuditorPassword],[EDITargetGoLive],[EDICurrentGoLive],[EDIActualGoLive],[idEDIOnboardingPhase])" +
                " VALUES(1," +
                " N'" + insert.GetUserFirstLastSpace() + "', N'" + insert.GetUserFirstLastPeriod() + "@purolator.com'," +
                " 5, N'EASTERN', N'" +
                insert.CustomerName + "', N'"+
                insert.Address1 +
                "', N'BAY SHORE', N'NY', N'11706', N'US', N'Cheese', 1929.2900, N'A', N'TBD', null, null, null, N'Scott.Cardinale'," +
                insert.GetDate1() +
                ", N'" + insert.GetUserFirstLastPeriod() + "'," +
                insert.GetDate1() + "," +
                " 1, N'', 7, 5, null, null, N'Customer is shipping courier out of florida.', N'www.cheese.com', N'EWR', null, 0, 0, 0, N'', N'', N'', N'', 1, 0, N' ', N'  ', N' ', N'', N'', N'', N'', null, N'', N'', N'', N'', null, null, N'', N'', N'null', N'', N'', 0, 0, 0, N'', N'', N'', N'', N'', N'', 0, 0, N'', N'', N'', N'', 0, 0, 0, 0, 0, N'', 0, N'', 0, N'', N'', 0, 0, N'', N'', CAST(N'2021-04-15T00:00:00.000' AS DateTime), CAST(N'2021-03-29T15:11:42.843' AS DateTime)," +
                insert.idRequestType.ToString() +
                ", 1, null, N'', null, N'', 3, N'Via EWR',"+
                insert.idSolutionType.ToString() +
                ", 1, N'Just anoth', 1, 2, 2, 1, N'url 1', N'user name 1', N'Password 1', CAST(N'2021-03-01T00:00:00.000' AS DateTime), CAST(N'2021-03-26T00:00:00.000' AS DateTime), CAST(N'2021-03-25T00:00:00.000' AS DateTime), 1)";

            return sql;
        }
    }
    public static class Extensions
    {
        public static T Next<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

            T[] Arr = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf<T>(Arr, src) + 1;
            return (Arr.Length == j) ? Arr[0] : Arr[j];
        }
    }

    public class DiscoveryReqUpdates
    {
        private string format1 = "yyyy-MM-ddTHH:mm:ss.fff";
        public int idSolutionType { get; set; }
        public int idRequestType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CustomerName { get; set; }
        public string Address1 { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public double Revenue { get; set; }
        public DateTime dt1 { get; set; }

        public string GetUserFirstLastPeriod()
        {
            return FirstName + "." + LastName;
        }
        public string GetUserFirstLastSpace()
        {
            return FirstName + " " + LastName;
        }
        public string GetDate1()
        {
            return "CAST(N'" + dt1.ToString(format1) + "' AS DateTime)";
        }
    }
    public class Tabs
    {
        public string Name { get; set; }
        public bool Selected { get; set; }
        public bool Enabled { get; set; }
        public Tabs()
        {
            Selected = false;
            Enabled = false;
        }
    }
    public class WhatToTest
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public double Step { get; set; }
    }
}
