using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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

        static void Main(string[] args)
        {
            IList<TestParams> ToTest = new List<TestParams>() {
                new TestParams( AllTest.SalesShippingTest1) { Enabled = false,  Step = 1.0},
                new TestParams( AllTest.SalesShippingTest2) { Enabled = false,  Step = 2.0},
                new TestParams( AllTest.SalesShippingTest3) { Enabled = false,  Step = 3.0},
                new TestParams( AllTest.SalesShippingTest4) { Enabled = false,  Step = 4.0},
                new TestParams( AllTest.SalesShippingTest5) { Enabled = false,  Step = 5.0},
                new TestParams( AllTest.SalesShippingTest7) { Enabled = false,  Step = 7.0},
                new TestParams( AllTest.SalesEDITest1)      { Enabled = false,  Step = 1.0},
                new TestParams( AllTest.SalesEDITest2)      { Enabled = false,  Step = 2.0},
                new TestParams( AllTest.SalesEDITest3)      { Enabled = false,  Step = 3.0},
                new TestParams( AllTest.SalesEDITest4)      { Enabled = false,  Step = 4.0},
                new TestParams( AllTest.SalesEDITest5)      { Enabled = false,  Step = 5.0},
                new TestParams( AllTest.SalesEDITest6)      { Enabled = false,  Step = 6.0},
                new TestParams( AllTest.SalesEDITest7)      { Enabled = false,  Step = 7.0},
                new TestParams( AllTest.SalesBothTest1)     { Enabled = false,  Step = 1.0},
                new TestParams( AllTest.SalesBothTest2)     { Enabled = false,  Step = 2.0},
                new TestParams( AllTest.SalesBothTest3)     { Enabled = false,  Step = 3.0},
                new TestParams( AllTest.SalesBothTest4)     { Enabled = false,  Step = 4.0},
                new TestParams( AllTest.SalesBothTest5)     { Enabled = false,  Step = 5.0},
                new TestParams( AllTest.SalesBothTest6)     { Enabled = false,  Step = 6.0},
                new TestParams( AllTest.SalesBothTest7)     { Enabled = true,  Step = 7.0}
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
            bool bTesting = false;
            //AllTest CurrentTest = AllTest.SalesShippingTest1;
            foreach (TestParams t in ToTest)
            {
                if(t.Enabled)
                {
                    bool bPass = false;
                    switch(t.Tests)
                    {
                        case AllTest.SalesShippingTest1:
                            if (!bTesting)
                                bPass = SalesShippingTest1(insert, t.Step);
                            else
                                bPass = true;
                            break;
                        case AllTest.SalesShippingTest2:
                            if (!bTesting)
                                bPass = SalesShippingTest2(insert, bLoggedIn, t.Step);
                            else
                                bPass = true;
                            break;
                        case AllTest.SalesShippingTest3:
                            if (!bTesting)
                                bPass = SalesShippingTest3(insert, bLoggedIn, t.Step);
                            else
                                bPass = true;
                            break;
                        case AllTest.SalesShippingTest4:
                            if (!bTesting)
                                bPass = SalesShippingTest4(insert, bLoggedIn, t.Step);
                            else
                                bPass = true;
                            break;
                        case AllTest.SalesShippingTest5:
                            if (!bTesting)
                                bPass = SalesShippingTest5(insert, bLoggedIn, t.Step);
                            else
                                bPass = true;
                            break;
                        case AllTest.SalesShippingTest7:
                            if (!bTesting)
                                bPass = SalesShippingTest7(insert, bLoggedIn, t.Step);
                            else
                                bPass = true;
                            break;
                        case AllTest.SalesEDITest1:
                            if (!bTesting)
                                bPass = SalesEDITest1(insert, bLoggedIn, t.Step);
                            else
                                bPass = true;
                            break;
                        case AllTest.SalesEDITest2:
                            if (!bTesting)
                                bPass = SalesEDITest2(insert, bLoggedIn, t.Step);
                            else
                                bPass = true;
                            break;
                        case AllTest.SalesEDITest3:
                            if (!bTesting)
                                bPass = SalesEDITest3(insert, bLoggedIn, t.Step);
                            else
                                bPass = true;
                            break;
                        case AllTest.SalesEDITest4:
                            if (!bTesting)
                                bPass = SalesEDITest4(insert, bLoggedIn, t.Step);
                            else
                                bPass = true;
                            break;
                        case AllTest.SalesEDITest5:
                            if (!bTesting)
                                bPass = SalesEDITest5(insert, bLoggedIn, t.Step);
                            else
                                bPass = true;
                            break;
                        case AllTest.SalesEDITest6:
                            if (!bTesting)
                                bPass = SalesEDITest6(insert, bLoggedIn, t.Step);
                            else
                                bPass = true;
                            break;
                        case AllTest.SalesEDITest7:
                            if (!bTesting)
                                bPass = SalesEDITest7(insert, bLoggedIn, t.Step);
                            else
                                bPass = true;
                            break;
                        case AllTest.SalesBothTest1:
                            if (!bTesting) bPass = SalesBothTest1(insert, bLoggedIn, t.Step);
                            else bPass = true;
                            break;
                        case AllTest.SalesBothTest2:
                            if (!bTesting) bPass = SalesBothTest2(insert, bLoggedIn, t.Step);
                            else bPass = true;
                            break;
                        case AllTest.SalesBothTest3:
                            if (!bTesting) bPass = SalesBothTest3(insert, bLoggedIn, t.Step);
                            else bPass = true;
                            break;
                        case AllTest.SalesBothTest4:
                            if (!bTesting) bPass = SalesBothTest4(insert, bLoggedIn, t.Step);
                            else bPass = true;
                            break;
                        case AllTest.SalesBothTest5:
                            if (!bTesting) bPass = SalesBothTest5(insert, bLoggedIn, t.Step);
                            else bPass = true;
                            break;
                        case AllTest.SalesBothTest6:
                            if (!bTesting) bPass = SalesBothTest6(insert, bLoggedIn, t.Step);
                            else bPass = true;
                            break;
                        case AllTest.SalesBothTest7:
                            if (!bTesting) bPass = SalesBothTest7(insert, bLoggedIn, t.Step);
                            else bPass = true;
                            break;
                        default:
                            break;
                    }
                    //Console.WriteLine("Press Space Bar to start " + ToTest[(int)CurrentTest].Name);
                    //Console.ReadKey();
                    if (bPass)
                    {
                        Console.WriteLine(t.Name + " Passedl!");
                        bLoggedIn = true;
                    }
                    else
                    {
                        Console.WriteLine(t.Name + " Failed!");
                    }
                    //Console.WriteLine(ToTest[(int)CurrentTest].Name + " finished press Space Bar to continue.");
                    //Console.ReadKey();
                }
                //CurrentTest = CurrentTest.Next();
            }
  

            driver.Quit();
            Environment.Exit(0);
            return;
        }
        #region Sales Shipping Tests
        static bool SalesShippingTest7(DiscoveryReqUpdates insert, bool bLoggedIn, double Step)
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)       , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)       },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)   },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices)  }
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

                // Click the Next Button Step 7.1
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab1")).Click();

                IList<Tabs> tab = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true, Selected = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices) }
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

                //Step 7.2
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

                // Step 7.3
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                IList<Tabs> tab3 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices) }
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)    , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)     , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution) , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices),Enabled = true, Selected = true }
                };
                // Step 7.4
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

                // Step 7.5
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                Console.WriteLine(strCurrentStep + " Passed");

                // Step 7.6
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                int iOrd = 0;
                IList<Tabs> tab5 = new List<Tabs>() {
                        new Tabs(AllTabs.CustomerInfo,iOrd++    )     { Enabled = true },
                        new Tabs(AllTabs.ContactInfo,iOrd++     )      { Enabled = true },
                        new Tabs(AllTabs.CurrentSolution,iOrd++ )  { Enabled = true, Selected = true},
                        new Tabs(AllTabs.ShippingServices,iOrd++) { Enabled = true }
                    };
                Tabs CurrentSolutionTab = tab5.Where(f => f.Selected == true).FirstOrDefault();
                SelectTabFromStrip(strRadTabID, CurrentSolutionTab.iOrdinalValue); 

                if (GetRadTabStrip(strRadTabID, tab5))
                {
                    driver.FindElement(By.Id("MainContent_txtareaCurrentSolution")).Clear();
                    Console.WriteLine(strCurrentStep + " Passed");
                    bRetVal = true;
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }

                // Step 7.7
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                iOrd = 0;
                IList<Tabs> tab6 = new List<Tabs>() {
                        new Tabs(AllTabs.CustomerInfo,iOrd++)     { Enabled = true },
                        new Tabs(AllTabs.ContactInfo,iOrd++)      { Enabled = true },
                        new Tabs(AllTabs.CurrentSolution,iOrd++)  { Enabled = true },
                        new Tabs(AllTabs.ShippingServices,iOrd++) { Enabled = true, Selected = true }
                    };
                Tabs ShippingServicesTab = tab6.Where(f => f.Selected == true).FirstOrDefault();
                SelectTabFromStrip(strRadTabID, ShippingServicesTab.iOrdinalValue);

                if (GetRadTabStrip(strRadTabID, tab6))
                {
                    driver.FindElement(By.Id("ctl00_MainContent_btnSubmit_input")).Click();
                    Thread.Sleep(2000);

                    if (driver.FindElement(By.Id("MainContent_CustomValidatorNew")).Displayed)
                    {
                        Console.WriteLine(strCurrentStep + " Passed");
                        bRetVal = true;
                        driver.FindElement(By.Id("ctl00_MainContent_btnExit1_input")).Click();
                    }
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)       , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)       },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)   },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices)  }
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true, Selected = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices) }
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices) }
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)    , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)     , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution) , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices),Enabled = true, Selected = true }
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)       , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)       },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)   },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices)  }
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true, Selected = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices) }
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices) }
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)       , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)       },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)   },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices)  }
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true, Selected = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices) }
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
                Thread.Sleep(2000);

                SelectDropdown("ctl00_MainContent_rddlSolutionType", SOLUTION_TYPE_SHIPPING - 1);
                Thread.Sleep(4000);

                // Check tab strip for the tabs that are available
                string strRadTabID = "ctl00_MainContent_RadTabStrip1";
                IList<Tabs> tab2 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)       , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)       },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)   },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices)  }
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
                    Thread.Sleep(1000);
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)       , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)       },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)   },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices)  }
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true }, 
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true, Selected = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices) } 
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices) }
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)    , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)     , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution) , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices),Enabled = true, Selected = true }
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
        #endregion
        #region Sales Both Tests
        static bool SalesBothTest1(DiscoveryReqUpdates insert, bool bLoggedIn, double Step)
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

                SelectDropdown("ctl00_MainContent_rddlDistrict");
                Thread.Sleep(5000);
                SelectDropdown("ctl00_MainContent_rddlBranch");
                Thread.Sleep(4000);
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                SelectDropdown("ctl00_MainContent_rddlSolutionType", SOLUTION_TYPE_BOTH - 1);
                Thread.Sleep(4000);

                // Check tab strip for the tabs that are available
                string strRadTabID = "ctl00_MainContent_RadTabStrip1";
                IList<Tabs> tab2 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)         ,Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)          },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)      },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)          },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices)     }
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true, Selected = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)      },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices) }
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)       },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices)  }
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)    , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)     , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution) , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)      ,Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices)    }
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

                driver.FindElement(By.Id("ctl00_MainContent_gridShipmentMethods_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();
                Thread.Sleep(3000);
                SelectDropdown("ctl00_MainContent_gridShipmentMethods_ctl00_ctl02_ctl03_radListEDIShipMethod");
                Thread.Sleep(3000);
                driver.FindElement(By.Id("ctl00_MainContent_gridShipmentMethods_ctl00_ctl02_ctl03_btnUpdate_input")).Click();
                Thread.Sleep(3000);

                driver.FindElement(By.Id("ctl00_MainContent_gridEDITransactions_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();
                Thread.Sleep(3000);
                SelectDropdown("ctl00_MainContent_gridEDITransactions_ctl00_ctl02_ctl03_radListEDITransList");
                Thread.Sleep(3000);
                driver.FindElement(By.Id("ctl00_MainContent_gridEDITransactions_ctl00_ctl02_ctl03_btnUpdate_input")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.Id("ctl00_MainContent_btnEDIServicesNext")).Click();
                Thread.Sleep(3000);
                
                // Step 1.5
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                IList<Tabs> tab5 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)    , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)     , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution) , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)      ,Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices), Enabled = true, Selected = true }
                };
                if (GetRadTabStrip(strRadTabID, tab5))
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

                // Step 1.6
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
        static bool SalesBothTest2(DiscoveryReqUpdates insert, bool bLoggedIn, double Step)
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
                Thread.Sleep(2000);

                SelectDropdown("ctl00_MainContent_rddlSolutionType", SOLUTION_TYPE_BOTH - 1);
                Thread.Sleep(4000);

                // Check tab strip for the tabs that are available
                string strRadTabID = "ctl00_MainContent_RadTabStrip1";
                IList<Tabs> tab2 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)         ,Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)          },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)      },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)          },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices)     }
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
                    Thread.Sleep(1000);
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
        static bool SalesBothTest3(DiscoveryReqUpdates insert, bool bLoggedIn, double Step)
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

                SelectDropdown("ctl00_MainContent_rddlDistrict");
                Thread.Sleep(5000);
                SelectDropdown("ctl00_MainContent_rddlBranch");
                Thread.Sleep(4000);
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                SelectDropdown("ctl00_MainContent_rddlSolutionType", SOLUTION_TYPE_BOTH - 1);
                Thread.Sleep(4000);

                // Check tab strip for the tabs that are available
                string strRadTabID = "ctl00_MainContent_RadTabStrip1";
                IList<Tabs> tab2 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)         ,Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)          },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)      },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)          },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices)     }
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true, Selected = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)      },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices) }
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

                //Step 3.2
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
                    //driver.FindElement(By.Id("ctl00_MainContent_btnExit1_input")).Click();
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

                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab2")).Click();
                Thread.Sleep(3000);

                // Step 3.4
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                IList<Tabs> tab3 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)       },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices)  }
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

                driver.FindElement(By.Id("ctl00_MainContent_btnExit1_input")).Click();
                Thread.Sleep(2000);
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return bRetVal;
        }
        static bool SalesBothTest4(DiscoveryReqUpdates insert, bool bLoggedIn, double Step)
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

                SelectDropdown("ctl00_MainContent_rddlDistrict");
                Thread.Sleep(5000);
                SelectDropdown("ctl00_MainContent_rddlBranch");
                Thread.Sleep(4000);
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                SelectDropdown("ctl00_MainContent_rddlSolutionType", SOLUTION_TYPE_BOTH - 1);
                Thread.Sleep(4000);

                // Check tab strip for the tabs that are available
                string strRadTabID = "ctl00_MainContent_RadTabStrip1";
                IList<Tabs> tab2 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)         ,Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)          },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)      },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)          },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices)     }
                };
                // Step 4.0
                if (GetRadTabStrip(strRadTabID, tab2))
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }

                SelectDropdown("ctl00_MainContent_rddlRequestType");
                Thread.Sleep(4000);

                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerName")).SendKeys(insert.CustomerName);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerAddress")).SendKeys(insert.Address1);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerZip")).SendKeys(insert.Zip);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerCity")).SendKeys(insert.City);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerState")).SendKeys(insert.State);
                driver.FindElement(By.Id("ctl00_MainContent_txtRevenue")).SendKeys(insert.Revenue.ToString());
                driver.FindElement(By.Id("ctl00_MainContent_txtCommodity")).SendKeys("Shoes");

                // Click the Next Button Step 4.1
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab1")).Click();

                IList<Tabs> tab = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true, Selected = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)      },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices) }
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

                // Step 4.3
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab2")).Click();
                Thread.Sleep(3000);
                IList<Tabs> tab3 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)       },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices)  }
                };
                if (GetRadTabStrip(strRadTabID, tab3))
                {
                    //Console.WriteLine(strCurrentStep + " Passed");
                    if (driver.FindElement(By.Id("ctl00_MainContent_btnNextTab3")).Displayed)
                    {
                        Console.WriteLine(strCurrentStep + " Passed");
                        bRetVal = true;
                    }
                    else
                    {
                        Console.WriteLine(strCurrentStep + " Failed");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }

                // Step 4.4
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                Thread.Sleep(2000);
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab3")).Click();
                Thread.Sleep(2000);
                if (driver.FindElement(By.Id("MainContent_ctl05")).Displayed)
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                    bRetVal = true;
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }
                
                driver.FindElement(By.Id("ctl00_MainContent_btnExit1_input")).Click();
                Thread.Sleep(2000);
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return bRetVal;
        }
        static bool SalesBothTest5(DiscoveryReqUpdates insert, bool bLoggedIn, double Step)
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

                SelectDropdown("ctl00_MainContent_rddlDistrict");
                Thread.Sleep(5000);
                SelectDropdown("ctl00_MainContent_rddlBranch");
                Thread.Sleep(4000);
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                SelectDropdown("ctl00_MainContent_rddlSolutionType", SOLUTION_TYPE_BOTH - 1);
                Thread.Sleep(4000);

                // Check tab strip for the tabs that are available
                string strRadTabID = "ctl00_MainContent_RadTabStrip1";
                IList<Tabs> tab2 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)         ,Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)          },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)      },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)          },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices)     }
                };
                // Step 5.0
                if (GetRadTabStrip(strRadTabID, tab2))
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }

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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true, Selected = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)      },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices) }
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

                // Step 5.3
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab2")).Click();
                Thread.Sleep(3000);
                IList<Tabs> tab3 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)       },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices)  }
                };
                if (GetRadTabStrip(strRadTabID, tab3))
                {
                    //Console.WriteLine(strCurrentStep + " Passed");
                    if (driver.FindElement(By.Id("ctl00_MainContent_btnNextTab3")).Displayed)
                    {
                        Console.WriteLine(strCurrentStep + " Passed");
                        bRetVal = true;
                    }
                    else
                    {
                        Console.WriteLine(strCurrentStep + " Failed");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }

                // Step 5.4
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                Thread.Sleep(2000);
                driver.FindElement(By.Id("MainContent_txtareaCurrentSolution")).SendKeys("This is a test message for the Current Soltion.");
                Thread.Sleep(1000);
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab3")).Click();
                Thread.Sleep(2000);

                IList<Tabs> tab4 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)    , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)     , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution) , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)      ,Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices)    }
                };

                if (GetRadTabStrip(strRadTabID, tab4))
                {
                    if (driver.FindElement(By.Id("ctl00_MainContent_btnEDIServicesNext")).Displayed)
                    {
                        Console.WriteLine(strCurrentStep + " Passed");
                        bRetVal = true;
                    }
                    else
                    {
                        Console.WriteLine(strCurrentStep + " Failed");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }

                // Step 5.5
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                driver.FindElement(By.Id("ctl00_MainContent_btnEDIServicesNext")).Click();
                Thread.Sleep(3000);
                if (driver.FindElement(By.Id("MainContent_CustomValidator")).Displayed)
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                    bRetVal = true;
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }

                driver.FindElement(By.Id("ctl00_MainContent_btnExit1_input")).Click();
                Thread.Sleep(2000);
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return bRetVal;
        }
        static bool SalesBothTest6(DiscoveryReqUpdates insert, bool bLoggedIn, double Step)
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

                SelectDropdown("ctl00_MainContent_rddlDistrict");
                Thread.Sleep(5000);
                SelectDropdown("ctl00_MainContent_rddlBranch");
                Thread.Sleep(4000);
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                SelectDropdown("ctl00_MainContent_rddlSolutionType", SOLUTION_TYPE_BOTH - 1);
                Thread.Sleep(4000);

                // Check tab strip for the tabs that are available
                string strRadTabID = "ctl00_MainContent_RadTabStrip1";
                IList<Tabs> tab2 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)         ,Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)          },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)      },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)          },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices)     }
                };
                // Step 6.0
                if (GetRadTabStrip(strRadTabID, tab2))
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }

                SelectDropdown("ctl00_MainContent_rddlRequestType");
                Thread.Sleep(4000);

                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerName")).SendKeys(insert.CustomerName);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerAddress")).SendKeys(insert.Address1);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerZip")).SendKeys(insert.Zip);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerCity")).SendKeys(insert.City);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerState")).SendKeys(insert.State);
                driver.FindElement(By.Id("ctl00_MainContent_txtRevenue")).SendKeys(insert.Revenue.ToString());
                driver.FindElement(By.Id("ctl00_MainContent_txtCommodity")).SendKeys("Shoes");

                // Click the Next Button Step 6.1
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab1")).Click();

                IList<Tabs> tab = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true, Selected = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)      },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices) }
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

                //Step 6.2
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

                // Step 6.3
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab2")).Click();
                Thread.Sleep(3000);
                IList<Tabs> tab3 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)       },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices)  }
                };
                if (GetRadTabStrip(strRadTabID, tab3))
                {
                    //Console.WriteLine(strCurrentStep + " Passed");
                    if (driver.FindElement(By.Id("ctl00_MainContent_btnNextTab3")).Displayed)
                    {
                        Console.WriteLine(strCurrentStep + " Passed");
                        bRetVal = true;
                    }
                    else
                    {
                        Console.WriteLine(strCurrentStep + " Failed");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }

                // Step 6.4
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                Thread.Sleep(2000);
                driver.FindElement(By.Id("MainContent_txtareaCurrentSolution")).SendKeys("This is a test message for the Current Soltion.");
                Thread.Sleep(1000);
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab3")).Click();
                Thread.Sleep(2000);

                IList<Tabs> tab4 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)    , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)     , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution) , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)      ,Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices)    }
                };

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

                // Step 6.5
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                driver.FindElement(By.Id("ctl00_MainContent_gridShipmentMethods_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();
                Thread.Sleep(3000);
                SelectDropdown("ctl00_MainContent_gridShipmentMethods_ctl00_ctl02_ctl03_radListEDIShipMethod");
                Thread.Sleep(3000);
                driver.FindElement(By.Id("ctl00_MainContent_gridShipmentMethods_ctl00_ctl02_ctl03_btnUpdate_input")).Click();
                Thread.Sleep(3000);

                driver.FindElement(By.Id("ctl00_MainContent_gridEDITransactions_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();
                Thread.Sleep(3000);
                SelectDropdown("ctl00_MainContent_gridEDITransactions_ctl00_ctl02_ctl03_radListEDITransList");
                Thread.Sleep(3000);
                driver.FindElement(By.Id("ctl00_MainContent_gridEDITransactions_ctl00_ctl02_ctl03_btnUpdate_input")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.Id("ctl00_MainContent_btnEDIServicesNext")).Click();
                Thread.Sleep(3000);


                IList<Tabs> tab5 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)    , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)     , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution) , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)      ,Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices), Enabled = true, Selected = true }
                };
                if (GetRadTabStrip(strRadTabID, tab5))
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                    bRetVal = true;
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }

                // Step 6.6
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                driver.FindElement(By.Id("ctl00_MainContent_btnSubmit_input")).Click();
                Thread.Sleep(5000);
                if (driver.FindElement(By.Id("MainContent_CustomValidatorNew")).Displayed)
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                    bRetVal = true;
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }

                driver.FindElement(By.Id("ctl00_MainContent_btnExit1_input")).Click();
                Thread.Sleep(2000);
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return bRetVal;
        }
        static bool SalesBothTest7(DiscoveryReqUpdates insert, bool bLoggedIn, double Step)
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

                SelectDropdown("ctl00_MainContent_rddlDistrict");
                Thread.Sleep(5000);
                SelectDropdown("ctl00_MainContent_rddlBranch");
                Thread.Sleep(4000);
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                SelectDropdown("ctl00_MainContent_rddlSolutionType", SOLUTION_TYPE_BOTH - 1);
                Thread.Sleep(4000);

                // Check tab strip for the tabs that are available
                string strRadTabID = "ctl00_MainContent_RadTabStrip1";
                IList<Tabs> tab2 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)         ,Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)          },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)      },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)          },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices)     }
                };
                // Step 7.0
                if (GetRadTabStrip(strRadTabID, tab2))
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }

                SelectDropdown("ctl00_MainContent_rddlRequestType");
                Thread.Sleep(4000);

                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerName")).SendKeys(insert.CustomerName);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerAddress")).SendKeys(insert.Address1);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerZip")).SendKeys(insert.Zip);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerCity")).SendKeys(insert.City);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerState")).SendKeys(insert.State);
                driver.FindElement(By.Id("ctl00_MainContent_txtRevenue")).SendKeys(insert.Revenue.ToString());
                driver.FindElement(By.Id("ctl00_MainContent_txtCommodity")).SendKeys("Shoes");

                // Click the Next Button Step 7.1
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab1")).Click();

                IList<Tabs> tab = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true, Selected = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)      },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices) }
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

                //Step 7.2
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

                // Step 7.3
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab2")).Click();
                Thread.Sleep(3000);
                IList<Tabs> tab3 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)       },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices)  }
                };
                if (GetRadTabStrip(strRadTabID, tab3))
                {
                    //Console.WriteLine(strCurrentStep + " Passed");
                    if (driver.FindElement(By.Id("ctl00_MainContent_btnNextTab3")).Displayed)
                    {
                        Console.WriteLine(strCurrentStep + " Passed");
                        bRetVal = true;
                    }
                    else
                    {
                        Console.WriteLine(strCurrentStep + " Failed");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }

                // Step 7.4
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                Thread.Sleep(2000);
                driver.FindElement(By.Id("MainContent_txtareaCurrentSolution")).SendKeys("This is a test message for the Current Soltion.");
                Thread.Sleep(1000);
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab3")).Click();
                Thread.Sleep(2000);

                int iOrd = 0;
                IList<Tabs> tab4 = new List<Tabs>() {
                    new Tabs(AllTabs.CustomerInfo,iOrd++    ) { Enabled = true },
                    new Tabs(AllTabs.ContactInfo,iOrd++     ) { Enabled = true},
                    new Tabs(AllTabs.CurrentSolution,iOrd++ ) { Enabled = true},
                    new Tabs(AllTabs.EDIServices,iOrd++     ) { Enabled = true, Selected = true },
                    new Tabs(AllTabs.ShippingServices,iOrd++) {   }
                };

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

                // Step 7.5
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                SelectTabFromStrip(strRadTabID, (int)AllTabs.CurrentSolution);

                IList<Tabs> tab5 = new List<Tabs>() {
                    new Tabs(AllTabs.CustomerInfo,iOrd++    ) { Enabled = true },
                    new Tabs(AllTabs.ContactInfo,iOrd++     ) { Enabled = true},
                    new Tabs(AllTabs.CurrentSolution,iOrd++ ) { Enabled = true, Selected = true },
                    new Tabs(AllTabs.EDIServices,iOrd++     ) { Enabled = true},
                    new Tabs(AllTabs.ShippingServices,iOrd++) {   }
                };
                if (GetRadTabStrip(strRadTabID, tab5))
                {
                    SelectTabFromStrip(strRadTabID, (int)AllTabs.CurrentSolution);
                    Thread.Sleep(2000);
                    driver.FindElement(By.Id("MainContent_txtareaCurrentSolution")).Clear();
                    Thread.Sleep(2000);
                    bool bctl05 = driver.FindElement(By.Id("MainContent_ctl05")).Displayed;
                    if (bctl05)
                    {
                        Console.WriteLine(strCurrentStep + " Passed");
                        bRetVal = true;
                    }
                    else
                    {
                        Console.WriteLine(strCurrentStep + " Failed");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }

                // Step 7.6
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                driver.FindElement(By.Id("MainContent_txtareaCurrentSolution")).SendKeys("This is a test message for the Current Soltion.");
                Thread.Sleep(1000);
                SelectTabFromStrip(strRadTabID, (int)AllTabs.EDIServices);
                Thread.Sleep(2000);
                
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

                driver.FindElement(By.Id("ctl00_MainContent_btnExit1_input")).Click();
                Thread.Sleep(2000);
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return bRetVal;
        }

        #endregion
        #region Sales EDI Tests
        static bool SalesEDITest1(DiscoveryReqUpdates insert, bool bLoggedIn, double Step)
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
                
                SelectDropdown("ctl00_MainContent_rddlDistrict");
                Thread.Sleep(5000);
                SelectDropdown("ctl00_MainContent_rddlBranch");
                Thread.Sleep(4000);
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                SelectDropdown("ctl00_MainContent_rddlSolutionType", SOLUTION_TYPE_EDI-1);
                Thread.Sleep(4000);

                // Check tab strip for the tabs that are available
                string strRadTabID = "ctl00_MainContent_RadTabStrip1";
                IList<Tabs> tab2 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)       , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)       },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)   },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)  }
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true, Selected = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices) }
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices) }
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)    , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)     , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution) , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices),Enabled = true, Selected = true }
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

                driver.FindElement(By.Id("ctl00_MainContent_gridShipmentMethods_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();
                Thread.Sleep(3000);   
                SelectDropdown("ctl00_MainContent_gridShipmentMethods_ctl00_ctl02_ctl03_radListEDIShipMethod");
                Thread.Sleep(3000);
                driver.FindElement(By.Id("ctl00_MainContent_gridShipmentMethods_ctl00_ctl02_ctl03_btnUpdate_input")).Click();
                Thread.Sleep(3000);

                driver.FindElement(By.Id("ctl00_MainContent_gridEDITransactions_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();
                Thread.Sleep(3000);
                SelectDropdown("ctl00_MainContent_gridEDITransactions_ctl00_ctl02_ctl03_radListEDITransList");
                Thread.Sleep(3000);
                driver.FindElement(By.Id("ctl00_MainContent_gridEDITransactions_ctl00_ctl02_ctl03_btnUpdate_input")).Click();
                Thread.Sleep(3000);

                driver.FindElement(By.Id("ctl00_MainContent_btnSubmitEDIServices_input")).Click();
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
        static bool SalesEDITest2(DiscoveryReqUpdates insert, bool bLoggedIn, double Step)
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

                SelectDropdown("ctl00_MainContent_rddlDistrict");
                Thread.Sleep(5000);
                SelectDropdown("ctl00_MainContent_rddlBranch");
                Thread.Sleep(4000);
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                SelectDropdown("ctl00_MainContent_rddlSolutionType", SOLUTION_TYPE_EDI - 1);
                Thread.Sleep(4000);

                // Check tab strip for the tabs that are available
                string strRadTabID = "ctl00_MainContent_RadTabStrip1";
                IList<Tabs> tab2 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)       , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)       },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)   },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)  }
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

                int iOrd = 0;
                IList<Tabs> tab = new List<Tabs>() {
                    new Tabs(AllTabs.CustomerInfo,iOrd++   )  { Enabled = true },
                    new Tabs(AllTabs.ContactInfo,iOrd++    )  { Enabled = true, Selected = true},
                    new Tabs(AllTabs.CurrentSolution,iOrd++)  { },
                    new Tabs(AllTabs.EDIServices,iOrd++    )  { }
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

                // Press the previous Tab
                Tabs CurrentSolutionTab = tab.Where(f => f.Enabled == true).FirstOrDefault();
                SelectTabFromStrip(strRadTabID, CurrentSolutionTab.iOrdinalValue);

                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerName")).Clear();
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerAddress")).Clear();
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerZip")).Clear();
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerCity")).Clear();
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerState")).Clear();
                driver.FindElement(By.Id("ctl00_MainContent_txtRevenue")).Clear();
                driver.FindElement(By.Id("ctl00_MainContent_txtCommodity")).Clear();

                //IList<Tabs> tab3 = new List<Tabs>() {
                //    new Tabs(AllTabs.CustomerInfo,iOrd++   ) {  Enabled = true, Selected = true },
                //    new Tabs(AllTabs.ContactInfo,iOrd++    ) {  Enabled = false},
                //    new Tabs(AllTabs.CurrentSolution,iOrd++) {  },
                //    new Tabs(AllTabs.EDIServices,iOrd++    ) {  }
                //};
                //Step 2.2
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                bool bctl02 = driver.FindElement(By.Id("MainContent_ctl02")).Displayed;
                if (bctl02)
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                    bRetVal = true;
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }
                driver.FindElement(By.Id("ctl00_MainContent_btnExit1_input")).Click();
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return bRetVal;
        }
        static bool SalesEDITest3(DiscoveryReqUpdates insert, bool bLoggedIn, double Step)
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

                SelectDropdown("ctl00_MainContent_rddlDistrict");
                Thread.Sleep(5000);
                SelectDropdown("ctl00_MainContent_rddlBranch");
                Thread.Sleep(4000);
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                SelectDropdown("ctl00_MainContent_rddlSolutionType", SOLUTION_TYPE_EDI - 1);
                Thread.Sleep(4000);

                // Check tab strip for the tabs that are available
                string strRadTabID = "ctl00_MainContent_RadTabStrip1";
                IList<Tabs> tab2 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)       , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)       },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)   },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)  }
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true, Selected = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices) }
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

                //Step 3.2
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
        static bool SalesEDITest4(DiscoveryReqUpdates insert, bool bLoggedIn, double Step)
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

                SelectDropdown("ctl00_MainContent_rddlDistrict");
                Thread.Sleep(5000);
                SelectDropdown("ctl00_MainContent_rddlBranch");
                Thread.Sleep(4000);
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                SelectDropdown("ctl00_MainContent_rddlSolutionType", SOLUTION_TYPE_EDI - 1);
                Thread.Sleep(4000);

                // Check tab strip for the tabs that are available
                string strRadTabID = "ctl00_MainContent_RadTabStrip1";
                IList<Tabs> tab2 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)       , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)       },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)   },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)  }
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

                SelectDropdown("ctl00_MainContent_rddlRequestType");
                Thread.Sleep(4000);

                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerName")).SendKeys(insert.CustomerName);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerAddress")).SendKeys(insert.Address1);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerZip")).SendKeys(insert.Zip);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerCity")).SendKeys(insert.City);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerState")).SendKeys(insert.State);
                driver.FindElement(By.Id("ctl00_MainContent_txtRevenue")).SendKeys(insert.Revenue.ToString());
                driver.FindElement(By.Id("ctl00_MainContent_txtCommodity")).SendKeys("Shoes");

                // Click the Next Button Step 4.1
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab1")).Click();

                IList<Tabs> tab = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true, Selected = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices) }
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices) }
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)    , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)     , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution) , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices),Enabled = true, Selected = true }
                };
                // Step 4.4
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

                //driver.FindElement(By.Id("ctl00_MainContent_gridShipmentMethods_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();
                //Thread.Sleep(3000);
                //SelectDropdown("ctl00_MainContent_gridShipmentMethods_ctl00_ctl02_ctl03_radListEDIShipMethod");
                //Thread.Sleep(3000);
                //driver.FindElement(By.Id("ctl00_MainContent_gridShipmentMethods_ctl00_ctl02_ctl03_btnUpdate_input")).Click();
                //Thread.Sleep(3000);

                //driver.FindElement(By.Id("ctl00_MainContent_gridEDITransactions_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();
                //Thread.Sleep(3000);
                //SelectDropdown("ctl00_MainContent_gridEDITransactions_ctl00_ctl02_ctl03_radListEDITransList");
                //Thread.Sleep(3000);
                //driver.FindElement(By.Id("ctl00_MainContent_gridEDITransactions_ctl00_ctl02_ctl03_btnUpdate_input")).Click();
                //Thread.Sleep(3000);

                driver.FindElement(By.Id("ctl00_MainContent_btnSubmitEDIServices_input")).Click();
                Thread.Sleep(5000);

                // Step 4.5
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                if (driver.FindElement(By.Id("MainContent_CustomValidator")).Displayed)
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
        static bool SalesEDITest5(DiscoveryReqUpdates insert, bool bLoggedIn, double Step)
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

                SelectDropdown("ctl00_MainContent_rddlDistrict");
                Thread.Sleep(5000);
                SelectDropdown("ctl00_MainContent_rddlBranch");
                Thread.Sleep(4000);
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                SelectDropdown("ctl00_MainContent_rddlSolutionType", SOLUTION_TYPE_EDI - 1);
                Thread.Sleep(4000);

                // Check tab strip for the tabs that are available
                string strRadTabID = "ctl00_MainContent_RadTabStrip1";
                IList<Tabs> tab2 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)       , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)       },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)   },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)  }
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true, Selected = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices) }
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices) }
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)    , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)     , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution) , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices),Enabled = true, Selected = true }
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
                int iOrd = 0; 
                IList<Tabs> tab5 = new List<Tabs>() {
                        new Tabs(AllTabs.CustomerInfo,iOrd++)     { Enabled = true },
                        new Tabs(AllTabs.ContactInfo,iOrd++)      { Enabled = true },
                        new Tabs(AllTabs.CurrentSolution,iOrd++)  { Enabled = true, Selected = true},
                        new Tabs(AllTabs.EDIServices,iOrd++)      { Enabled = true }
                    };

                Tabs CurrentSolutionTab = tab5.Where(f => f.Selected == true).FirstOrDefault();
                SelectTabFromStrip(strRadTabID, CurrentSolutionTab.iOrdinalValue);

                driver.FindElement(By.Id("MainContent_txtareaCurrentSolution")).Clear();

                // Step 5.5
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                if (driver.FindElement(By.Id("MainContent_ctl05")).Displayed)
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
        static bool SalesEDITest6(DiscoveryReqUpdates insert, bool bLoggedIn, double Step)
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

                SelectDropdown("ctl00_MainContent_rddlDistrict");
                Thread.Sleep(5000);
                SelectDropdown("ctl00_MainContent_rddlBranch");
                Thread.Sleep(4000);
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                SelectDropdown("ctl00_MainContent_rddlSolutionType", SOLUTION_TYPE_EDI - 1);
                Thread.Sleep(4000);

                // Check tab strip for the tabs that are available
                string strRadTabID = "ctl00_MainContent_RadTabStrip1";
                IList<Tabs> tab2 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)       , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)       },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)   },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)  }
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

                SelectDropdown("ctl00_MainContent_rddlRequestType");
                Thread.Sleep(4000);

                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerName")).SendKeys(insert.CustomerName);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerAddress")).SendKeys(insert.Address1);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerZip")).SendKeys(insert.Zip);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerCity")).SendKeys(insert.City);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerState")).SendKeys(insert.State);
                driver.FindElement(By.Id("ctl00_MainContent_txtRevenue")).SendKeys(insert.Revenue.ToString());
                driver.FindElement(By.Id("ctl00_MainContent_txtCommodity")).SendKeys("Shoes");

                // Click the Next Button Step 6.1
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab1")).Click();

                IList<Tabs> tab = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true, Selected = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices) }
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

                //Step 6.2
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

                // Step 6.3
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                IList<Tabs> tab3 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices) }
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)    , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)     , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution) , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices),Enabled = true, Selected = true }
                };
                // Step 6.4
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
                int iOrd = 0;
                IList<Tabs> tab5 = new List<Tabs>() {
                        new Tabs(AllTabs.CustomerInfo,iOrd++)     { Enabled = true },
                        new Tabs(AllTabs.ContactInfo,iOrd++)      { Enabled = true },
                        new Tabs(AllTabs.CurrentSolution,iOrd++)  { Enabled = true, Selected = true},
                        new Tabs(AllTabs.EDIServices,iOrd++)      { Enabled = true }
                    };

                Tabs CurrentSolutionTab = tab5.Where(f => f.Selected == true).FirstOrDefault();
                SelectTabFromStrip(strRadTabID, CurrentSolutionTab.iOrdinalValue);

                driver.FindElement(By.Id("MainContent_txtareaCurrentSolution")).Clear();

                // Step 6.5
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                if (driver.FindElement(By.Id("MainContent_ctl05")).Displayed)
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                    bRetVal = true;
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }

                // Step 6.6
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                driver.FindElement(By.Id("MainContent_txtareaCurrentSolution")).SendKeys("This is a test message for the Current Soltion.");
                Thread.Sleep(2000); 
                if (!driver.FindElement(By.Id("MainContent_ctl05")).Displayed)
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
        static bool SalesEDITest7(DiscoveryReqUpdates insert, bool bLoggedIn, double Step)
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

                SelectDropdown("ctl00_MainContent_rddlDistrict");
                Thread.Sleep(5000);
                SelectDropdown("ctl00_MainContent_rddlBranch");
                Thread.Sleep(4000);
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                SelectDropdown("ctl00_MainContent_rddlSolutionType", SOLUTION_TYPE_EDI - 1);
                Thread.Sleep(4000);

                // Check tab strip for the tabs that are available
                string strRadTabID = "ctl00_MainContent_RadTabStrip1";
                IList<Tabs> tab2 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)       , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)       },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)   },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices)  }
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

                SelectDropdown("ctl00_MainContent_rddlRequestType");
                Thread.Sleep(4000);

                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerName")).SendKeys(insert.CustomerName);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerAddress")).SendKeys(insert.Address1);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerZip")).SendKeys(insert.Zip);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerCity")).SendKeys(insert.City);
                driver.FindElement(By.Id("ctl00_MainContent_txtCustomerState")).SendKeys(insert.State);
                driver.FindElement(By.Id("ctl00_MainContent_txtRevenue")).SendKeys(insert.Revenue.ToString());
                driver.FindElement(By.Id("ctl00_MainContent_txtCommodity")).SendKeys("Shoes");

                // Click the Next Button Step 7.1
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab1")).Click();

                IList<Tabs> tab = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true, Selected = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices) }
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

                //Step 7.2
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

                // Step 7.3
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                IList<Tabs> tab3 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices) }
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
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)    , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)     , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution) , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.EDIServices),Enabled = true, Selected = true }
                };
                // Step 7.4
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

                driver.FindElement(By.Id("ctl00_MainContent_btnSubmitEDIServices_input")).Click();
                Thread.Sleep(5000);
                // Step 7.5
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                if (driver.FindElement(By.Id("MainContent_CustomValidator")).Displayed)
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                    bRetVal = true;
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }
                driver.FindElement(By.Id("ctl00_MainContent_gridShipmentMethods_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();
                Thread.Sleep(3000);
                SelectDropdown("ctl00_MainContent_gridShipmentMethods_ctl00_ctl02_ctl03_radListEDIShipMethod");
                Thread.Sleep(3000);
                driver.FindElement(By.Id("ctl00_MainContent_gridShipmentMethods_ctl00_ctl02_ctl03_btnUpdate_input")).Click();
                Thread.Sleep(3000);

                driver.FindElement(By.Id("ctl00_MainContent_gridEDITransactions_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();
                Thread.Sleep(3000);
                SelectDropdown("ctl00_MainContent_gridEDITransactions_ctl00_ctl02_ctl03_radListEDITransList");
                Thread.Sleep(3000);
                driver.FindElement(By.Id("ctl00_MainContent_gridEDITransactions_ctl00_ctl02_ctl03_btnUpdate_input")).Click();
                Thread.Sleep(3000);

                // Step 7.6
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                if (!driver.FindElement(By.Id("MainContent_CustomValidator")).Displayed)
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                    bRetVal = true;
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    return false;
                }

                driver.FindElement(By.Id("ctl00_MainContent_btnSubmitEDIServices_input")).Click();
                Thread.Sleep(5000);

                // Step 7.7
                Step += 0.1;
                strCurrentStep = String.Format("Step {0:0.0#}", Step);
                if (driver.FindElement(By.ClassName("rwPopupButton")).Enabled)
                {
                    driver.FindElement(By.ClassName("rwPopupButton")).Click();
                    Console.WriteLine(strCurrentStep + " Passed");
                    bRetVal = true;
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

        #endregion
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
        private static bool SelectTabFromStrip(string strRadTabID, AllTabs tab)
        {
            bool bRetVal = false;
            var ParentElement = driver.FindElement(By.Id(strRadTabID));
            IReadOnlyCollection<IWebElement> children = ParentElement.FindElements(By.XPath(".//*"));
            IReadOnlyCollection<IWebElement> AllTheTabs = children.Where(f => f.TagName == "li").ToList();
            AllTheTabs.ElementAt((int)tab).Click();
            return bRetVal;
        }
        private static bool SelectTabFromStrip(string strRadTabID, int tab)
        {
            bool bRetVal = false;
            var ParentElement = driver.FindElement(By.Id(strRadTabID));
            IReadOnlyCollection<IWebElement> children = ParentElement.FindElements(By.XPath(".//*"));
            IReadOnlyCollection<IWebElement> AllTheTabs = children.Where(f => f.TagName == "li").ToList();
            AllTheTabs.ElementAt(tab).Click();
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
        private static void SelectDropdown(string ID, int iMenuItem)
        {
            var ParentRequestType = driver.FindElement(By.Id(ID));
            IWebElement ReqTypeItem = ParentRequestType.FindElement(By.ClassName("rddlInner"));
            IReadOnlyCollection<IWebElement> AllRequestTypes = ParentRequestType.FindElements(By.ClassName("rddlItem"));
            ReqTypeItem.Click();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(2000);
            AllRequestTypes.ElementAt(iMenuItem).Click();
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
        static int GetOrdValueFromTabs(IList<Tabs> tabList)
        {
            int iRetVal = 0;
            //IList<bool>
            foreach(Tabs t in tabList)
            {

            }
            return iRetVal;
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
        public static int iCount { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }
        public bool Enabled { get; set; }
        public  int iOrdinalValue { get; set; }
        public AllTabs localTab { get; set; }
        public Tabs()
        {
            Selected = false;
            Enabled = false;
            iOrdinalValue = iCount;
            iCount++;
        }
        public Tabs(AllTabs val)
        {
            localTab = val;
            Name = StringEnum.GetStringValue(val);
            Selected = false;
            Enabled = false;
            iOrdinalValue = iCount;
            iCount++;
        }
        public Tabs(AllTabs val, int iOrd)
        {
            localTab = val;
            Name = StringEnum.GetStringValue(val);
            Selected = false;
            Enabled = false;
            iOrdinalValue = iOrd;
            //iCount++;
        }
    }
    
    public class TestParams
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public double Step { get; set; }
        public AllTest Tests { get; set; }
        public TestParams( AllTest test)
        {
            Tests = test;
            Name = StringEnum.GetStringValue(test);
        }
    }
    #region Enumerations
    public class StringValue : System.Attribute
    {
        private string _value;
        public StringValue(string value)
        {
            _value = value;
        }
        public string Value
        {
            get { return _value; }
        }
    }
    public enum AllTabs
    {
        [StringValue("Customer Info")]
        CustomerInfo = 0,
        [StringValue("Contact Info")]
        ContactInfo = 1,
        [StringValue("Current Solution")]
        CurrentSolution = 2,
        [StringValue("EDI Services")]
        EDIServices = 3,
        [StringValue("Shipping Services")]
        ShippingServices = 4,
        [StringValue("Profile")]
        Profile = 5,
        [StringValue("Courier EDI")]
        CourierEDI = 6,
        [StringValue("Non-Courier EDI")]
        NonCourierEDI = 7,
        [StringValue("Add'l Notes")]
        AddlNotes = 8,
        [StringValue("File Uploads")]
        FileUploads = 9
    }
    public static class GetTheTab
    {
        public static AllTabs Get(string strTab)
        {
            AllTabs retTab = AllTabs.CustomerInfo;

            if (strTab == StringEnum.GetStringValue(AllTabs.CustomerInfo))
                retTab = AllTabs.CustomerInfo;
            else if (strTab == StringEnum.GetStringValue(AllTabs.ContactInfo))
                retTab = AllTabs.ContactInfo;
            else if (strTab == StringEnum.GetStringValue(AllTabs.CurrentSolution))
                retTab = AllTabs.CurrentSolution;
            else if (strTab == StringEnum.GetStringValue(AllTabs.EDIServices))
                retTab = AllTabs.EDIServices;
            else if (strTab == StringEnum.GetStringValue(AllTabs.ShippingServices))
                retTab = AllTabs.ShippingServices;
            else if (strTab == StringEnum.GetStringValue(AllTabs.Profile))
                retTab = AllTabs.Profile;
            else if (strTab == StringEnum.GetStringValue(AllTabs.CourierEDI))
                retTab = AllTabs.CourierEDI;
            else if (strTab == StringEnum.GetStringValue(AllTabs.NonCourierEDI))
                retTab = AllTabs.NonCourierEDI;
            else if (strTab == StringEnum.GetStringValue(AllTabs.AddlNotes))
                retTab = AllTabs.AddlNotes;
            else if (strTab == StringEnum.GetStringValue(AllTabs.FileUploads))
                retTab = AllTabs.FileUploads;
            return retTab;
        }
    }
    public enum AllTest
    {
        [StringValue("Sales Shipping Test 1")]
        SalesShippingTest1 = 0,
        [StringValue("Sales Shipping Test 2")]
        SalesShippingTest2 = 1,
        [StringValue("Sales Shipping Test 3")]
        SalesShippingTest3 = 2,
        [StringValue("Sales Shipping Test 4")]
        SalesShippingTest4 = 3,
        [StringValue("Sales Shipping Test 5")]
        SalesShippingTest5 = 4,
        [StringValue("Sales Shipping Test 7")]
        SalesShippingTest7 = 5,
        [StringValue("Sales EDI Test 1")]
        SalesEDITest1 = 6,
        [StringValue("Sales EDI Test 2")]
        SalesEDITest2 = 7,
        [StringValue("Sales EDI Test 3")]
        SalesEDITest3 = 8,
        [StringValue("Sales EDI Test 4")]
        SalesEDITest4 = 9,
        [StringValue("Sales EDI Test 5")]
        SalesEDITest5 = 10,
        [StringValue("Sales EDI Test 6")]
        SalesEDITest6 = 11,
        [StringValue("Sales EDI Test 7")]
        SalesEDITest7 = 12,
        [StringValue("Sales Both Test 1")]
        SalesBothTest1 = 13,
        [StringValue("Sales Both Test 2")]
        SalesBothTest2 = 14,
        [StringValue("Sales Both Test 3")]
        SalesBothTest3 = 15,
        [StringValue("Sales Both Test 4")]
        SalesBothTest4 = 16,
        [StringValue("Sales Both Test 5")]
        SalesBothTest5 = 17,
        [StringValue("Sales Both Test 6")]
        SalesBothTest6 = 18,
        [StringValue("Sales Both Test 7")]
        SalesBothTest7 = 19
    }
    public static class GetTheTest
    {
        public static AllTest Get(string strTab)
        {
            AllTest retTab = AllTest.SalesShippingTest1;

            if (strTab == StringEnum.GetStringValue(AllTest.SalesShippingTest1))
                retTab = AllTest.SalesShippingTest1;
            else if (strTab == StringEnum.GetStringValue(AllTest.SalesShippingTest2))
                retTab = AllTest.SalesShippingTest2;
            else if (strTab == StringEnum.GetStringValue(AllTest.SalesShippingTest3))
                retTab = AllTest.SalesShippingTest3;
            else if (strTab == StringEnum.GetStringValue(AllTest.SalesShippingTest4))
                retTab = AllTest.SalesShippingTest4;
            else if (strTab == StringEnum.GetStringValue(AllTest.SalesShippingTest5))
                retTab = AllTest.SalesShippingTest5;
            else if (strTab == StringEnum.GetStringValue(AllTest.SalesShippingTest7))
                retTab = AllTest.SalesShippingTest7;
            else if (strTab == StringEnum.GetStringValue(AllTest.SalesEDITest1))
                retTab = AllTest.SalesEDITest1;
            else if (strTab == StringEnum.GetStringValue(AllTest.SalesEDITest2))
                retTab = AllTest.SalesEDITest2;
            else if (strTab == StringEnum.GetStringValue(AllTest.SalesEDITest3))
                retTab = AllTest.SalesEDITest3;
            //else if (strTab == StringEnum.GetStringValue(AllTest.FileUploads))
            //    retTab = AllTest.FileUploads;
            return retTab;
        }
    }
    public static class StringEnum
    {
        public static string GetStringValue(Enum value)
        {
            string output = null;
            Type type = value.GetType();

            FieldInfo fi = type.GetField(value.ToString());
            StringValue[] attrs = fi.GetCustomAttributes(typeof(StringValue), false) as StringValue[];
            if (attrs.Length > 0)
            {
                output = attrs[0].Value;
            }
            return output;
        }
    }
    #endregion
}
//#region Sales Shipping Test 1
//if (ToTest[(int)CurrentTest].Enabled)
//{
//    //Console.WriteLine("Press Space Bar to start " + ToTest[(int)CurrentTest].Name);
//    //Console.ReadKey();
//    if (SalesShippingTest1(insert, ToTest[(int)CurrentTest].Step))
//    {
//        Console.WriteLine(ToTest[(int)CurrentTest].Name + " Passedl!");
//        bLoggedIn = true;
//    }
//    else
//    {
//        Console.WriteLine(ToTest[(int)CurrentTest].Name + " Failed!");
//    }
//    //Console.WriteLine(ToTest[(int)CurrentTest].Name + " finished press Space Bar to continue.");
//    //Console.ReadKey();
//}
//#endregion

//CurrentTest = CurrentTest.Next();

//#region Sales Shipping Test 2
//if (ToTest[(int)CurrentTest].Enabled)
//{
//    //Console.WriteLine("Press Space Bar to start " + ToTest[(int)CurrentTest].Name);
//    //Console.ReadKey();
//    if ( SalesShippingTest2(insert, bLoggedIn, ToTest[(int)CurrentTest].Step) )
//    {
//        Console.WriteLine(ToTest[(int)CurrentTest].Name + " Passed!");
//    }
//    else
//    {
//        Console.WriteLine(ToTest[(int)CurrentTest].Name + " failed!");
//    }
//    bLoggedIn = true;
//    //Console.WriteLine(ToTest[(int)CurrentTest].Name + " finished press Space Bar to continue.");
//    //Console.ReadKey();
//}
//#endregion

//CurrentTest = CurrentTest.Next();

//#region Sales Shipping Test 3
//if (ToTest[(int)CurrentTest].Enabled)
//{
//    //Console.WriteLine("Press Space Bar to start " + ToTest[(int)CurrentTest].Name);
//    //Console.ReadKey();
//    if (SalesShippingTest3(insert, bLoggedIn, ToTest[(int)CurrentTest].Step))
//    {
//        Console.WriteLine(ToTest[(int)CurrentTest].Name + " Passed!");
//    }
//    else
//    {
//        Console.WriteLine(ToTest[(int)CurrentTest].Name + " failed!");
//    }
//    bLoggedIn = true;
//    //Console.WriteLine(ToTest[(int)CurrentTest].Name + " finished press Space Bar to continue.");
//    //Console.ReadKey();
//}
//#endregion

//CurrentTest = CurrentTest.Next();

//#region Sales Shipping Test 4
//if (ToTest[(int)CurrentTest].Enabled)
//{
//    //Console.WriteLine("Press Space Bar to start " + ToTest[(int)CurrentTest].Name);
//    //Console.ReadKey();
//    if (SalesShippingTest4(insert, bLoggedIn, ToTest[(int)CurrentTest].Step))
//    {
//        Console.WriteLine(ToTest[(int)CurrentTest].Name + " Passed!");
//    }
//    else
//    {
//        Console.WriteLine(ToTest[(int)CurrentTest].Name + " failed!");
//    }
//    bLoggedIn = true;
//    //Console.WriteLine(ToTest[(int)CurrentTest].Name + " finished press Space Bar to continue.");
//    //Console.ReadKey();
//}
//#endregion

//CurrentTest = CurrentTest.Next();

//#region Sales Shipping Test 5
//if (ToTest[(int)CurrentTest].Enabled)
//{
//    //Console.WriteLine("Press Space Bar to start " + ToTest[(int)CurrentTest].Name);
//    //Console.ReadKey();
//    if (SalesShippingTest5(insert, bLoggedIn, ToTest[(int)CurrentTest].Step))
//    {
//        Console.WriteLine(ToTest[(int)CurrentTest].Name + " Passed!");
//    }
//    else
//    {
//        Console.WriteLine(ToTest[(int)CurrentTest].Name + " failed!");
//    }
//    bLoggedIn = true;
//    //Console.WriteLine(ToTest[(int)CurrentTest].Name + " finished press Space Bar to continue.");
//    //Console.ReadKey();
//}
//#endregion

//CurrentTest = CurrentTest.Next();

//#region Sales Shipping Test 7
//if (ToTest[(int)CurrentTest].Enabled)
//{
//    //Console.WriteLine("Press Space Bar to start " + ToTest[(int)CurrentTest].Name);
//    //Console.ReadKey();
//    if (SalesShippingTest7(insert, bLoggedIn, ToTest[(int)CurrentTest].Step))
//    {
//        Console.WriteLine(ToTest[(int)CurrentTest].Name + " Passed!");
//    }
//    else
//    {
//        Console.WriteLine(ToTest[(int)CurrentTest].Name + " failed!");
//    }
//    bLoggedIn = true;
//    //Console.WriteLine(ToTest[(int)CurrentTest].Name + " finished press Space Bar to continue.");
//    //Console.ReadKey();
//}
//#endregion