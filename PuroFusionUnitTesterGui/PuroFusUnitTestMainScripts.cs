using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Telerik.Windows.Controls;
using System.Reflection;
using System.ComponentModel;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.IO;
using PuroFusionLib;
using System.Windows.Input;
using System.Windows.Media;
using System.Threading;
using System.Runtime.Remoting.Messaging;

using System.Windows.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using NUnit.Framework;
using System.Windows.Automation;

namespace PuroFusionTestGui
{
    public partial class MainWindow : Window
    {
        IList<TestParams> ToTest2 = new List<TestParams>() {
            new TestParams( AllTest.SalesShippingTest1,5, 1.0) { Enabled = true},
            new TestParams( AllTest.SalesShippingTest2,5, 2.0) { Enabled = true},
            new TestParams( AllTest.SalesShippingTest3,5, 3.0) { Enabled = true},
            new TestParams( AllTest.SalesShippingTest4,5, 4.0) { Enabled = true},
            new TestParams( AllTest.SalesShippingTest5,5, 5.0) { Enabled = true},
            new TestParams( AllTest.SalesShippingTest7,5, 7.0) { Enabled = true},
            new TestParams( AllTest.SalesEDITest1,5, 1.0)      { Enabled = true},
            new TestParams( AllTest.SalesEDITest2,5, 2.0)      { Enabled = true},
            new TestParams( AllTest.SalesEDITest3,5, 3.0)      { Enabled = true},
            new TestParams( AllTest.SalesEDITest4,5, 4.0)      { Enabled = true},
            new TestParams( AllTest.SalesEDITest5,5, 5.0)      { Enabled = true},
            new TestParams( AllTest.SalesEDITest6,5, 6.0)      { Enabled = true},
            new TestParams( AllTest.SalesEDITest7,5, 7.0)      { Enabled = true},
            new TestParams( AllTest.SalesBothTest1,5, 1.0)     { Enabled = true},
            new TestParams( AllTest.SalesBothTest2,5, 2.0)     { Enabled = true},
            new TestParams( AllTest.SalesBothTest3,5, 3.0)     { Enabled = true},
            new TestParams( AllTest.SalesBothTest4,5, 4.0)     { Enabled = true},
            new TestParams( AllTest.SalesBothTest5,5, 5.0)     { Enabled = true},
            new TestParams( AllTest.SalesBothTest6,5, 6.0)     { Enabled = true},
            new TestParams( AllTest.SalesBothTest7,5, 7.0)     { Enabled = true}
        };
        #region Async / Threading
        public delegate void TransferDel(bool bTesting, string strIn);
        private void StartAsyncFileTrans(bool bTesting, string strIn)
        {
            TransferDel del = new TransferDel(TransferFile);
            TestParams tp = new TestParams(AllTest.SalesShippingTest1, 5);
            IAsyncResult iar = del.BeginInvoke(bTesting, strIn, new AsyncCallback(FileTransDone), tp);
        }
        void FileTransDone(IAsyncResult iar)
        {
            AsyncResult ar = (AsyncResult)iar;
            TransferDel del = (TransferDel)ar.AsyncDelegate;
            //    bool result = del.EndInvoke(iar);
            //    if (result)
            //    {
            //        GateDataPull gatePull = (GateDataPull)iar.AsyncState;
            //        updateGUI("File Transfer Done From: " + gatePull.transObj.strFrom + " To: " + gatePull.transObj.strTo);
            //        StartAsyncLoadTable(gatePull);
            //    }
        }
        public void TransferFile(bool bTesting, string strIn)
        {
            RunTestScript(bTesting);
            return;
        }
        #endregion
        public void RunTestScript(bool bTesting)
        {
            ShowMessageDelegate2 del = new ShowMessageDelegate2(ShowMessage);
            bool bLoggedIn = false;
            //bool bTesting = false;
            if (!bTesting)
                driver = new ChromeDriver(@"C:\Software\Selenium");

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

            foreach (TestParams t in ToTest2)
            {
                if (t.Enabled)
                {
                    bool bPass = false;
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, StringEnum.GetStringValue(t.Tests));
                    switch (t.Tests)
                    {
                        case AllTest.SalesShippingTest1:
                            if (!bTesting)
                                bPass = SalesShippingTest1(t,insert);
                            else
                                bPass = true;
                            break;
                        case AllTest.SalesShippingTest2:
                            if (!bTesting)
                                bPass = SalesShippingTest2(t, insert, bLoggedIn);
                            else
                                bPass = true;
                            break;
                        case AllTest.SalesShippingTest3:
                            if (!bTesting)
                                bPass = SalesShippingTest3(t, insert, bLoggedIn);
                            else
                                bPass = true;
                            break;
                        case AllTest.SalesShippingTest4:
                            if (!bTesting)
                                bPass = SalesShippingTest4(t, insert, bLoggedIn);
                            else
                                bPass = true;
                            break;
                        case AllTest.SalesShippingTest5:
                            if (!bTesting)
                                bPass = SalesShippingTest5(t, insert, bLoggedIn);
                            else
                                bPass = true;
                            break;
                        case AllTest.SalesShippingTest7:
                            if (!bTesting)
                                bPass = SalesShippingTest7(t, insert, bLoggedIn);
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
        }
        public void LoadTree()
        {
            foreach (TestParams param in ToTest2)
            {
                if (param.Enabled)
                {
                    //SelectTreeNode(param, READY_ICON, System.Windows.Automation.ToggleState.On);
                    //bool bPass = false;
                    //this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, StringEnum.GetStringValue(t.Tests));
                    //switch (param.Tests)
                    //{
                    //    case AllTest.SalesShippingTest1:
                    //        SelectTreeNode(param, CODEBREAK_ICON);
                    //        break;
                    //    case AllTest.SalesShippingTest2:
                    //        break;
                    //    case AllTest.SalesShippingTest3:
                    //        break;
                    //    case AllTest.SalesShippingTest4:
                    //        break;
                    //    case AllTest.SalesShippingTest5:
                    //        break;
                    //    case AllTest.SalesShippingTest7:
                    //        break;
                    //    case AllTest.SalesEDITest1:
                    //        break;
                    //    case AllTest.SalesEDITest2:
                    //        break;
                    //    case AllTest.SalesEDITest3:
                    //        break;
                    //    case AllTest.SalesEDITest4:
                    //        break;
                    //    case AllTest.SalesEDITest5:
                    //        break;
                    //    case AllTest.SalesEDITest6:
                    //        break;
                    //    case AllTest.SalesEDITest7:
                    //        break;
                    //    case AllTest.SalesBothTest1:
                    //        break;
                    //    case AllTest.SalesBothTest2:
                    //        break;
                    //    case AllTest.SalesBothTest3:
                    //        break;
                    //    case AllTest.SalesBothTest4:
                    //        break;
                    //    case AllTest.SalesBothTest5:
                    //        break;
                    //    case AllTest.SalesBothTest6:
                    //        break;
                    //    case AllTest.SalesBothTest7:
                    //        break;
                    //    default:
                    //        break;
                    //}
                }
            }
            bUseTreeCheck = true;
        }
        #region Sales Shipping Tests
        bool SalesShippingTest7(TestParams t, DiscoveryReqUpdates insert, bool bLoggedIn)
        {
            ShowMessageDelegate2 del = new ShowMessageDelegate2(ShowMessage);
            ShowDelegateUpdateTree del2 = new ShowDelegateUpdateTree(SelectTreeNode);
            bool bRetVal = false;
            int iCurStep = 0;
            string strCurrentStep = t.ListSteps[iCurStep].Name;
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
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
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
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
                    bRetVal = true;
                }
                else
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
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
                iCurStep++;
                strCurrentStep = t.ListSteps[iCurStep].Name;
                if (driver.FindElement(By.Id("ctl00_MainContent_btnNextTab2")).Displayed)
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
                    bRetVal = true;
                }
                else
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    return false;
                }
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab2")).Click();
                Thread.Sleep(5000);

                // Step 7.3
                iCurStep++;
                strCurrentStep = t.ListSteps[iCurStep].Name;
                IList<Tabs> tab3 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices) }
                };
                if (GetRadTabStrip(strRadTabID, tab3))
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
                    bRetVal = true;
                }
                else
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
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
                iCurStep++;
                strCurrentStep = t.ListSteps[iCurStep].Name;
                if (GetRadTabStrip(strRadTabID, tab4))
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
                    bRetVal = true;
                }
                else
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
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
                iCurStep++;
                strCurrentStep = t.ListSteps[iCurStep].Name;
                this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);

                // Step 7.6
                iCurStep++;
                strCurrentStep = t.ListSteps[iCurStep].Name;
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
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
                    bRetVal = true;
                }
                else
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    return false;
                }

                // Step 7.7
                iCurStep++;
                strCurrentStep = t.ListSteps[iCurStep].Name;
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
                        this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                        this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
                        bRetVal = true;
                        driver.FindElement(By.Id("ctl00_MainContent_btnExit1_input")).Click();
                    }
                }
                else
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    return false;
                }
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return bRetVal;
        }
        bool SalesShippingTest5(TestParams t, DiscoveryReqUpdates insert, bool bLoggedIn)
        {
            ShowMessageDelegate2 del = new ShowMessageDelegate2(ShowMessage);
            ShowDelegateUpdateTree del2 = new ShowDelegateUpdateTree(SelectTreeNode);
            bool bRetVal = false;
            int iCurStep = 0;
            string strCurrentStep = t.ListSteps[iCurStep].Name;
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
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
                }
                else
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, DELETE_ICON, ToggleState.On, strCurrentStep, DELETE_ICON);
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
                iCurStep++;
                strCurrentStep = t.ListSteps[iCurStep].Name;
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab1")).Click();

                IList<Tabs> tab = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true, Selected = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices) }
                };
                if (GetRadTabStrip(strRadTabID, tab))
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
                    bRetVal = true;
                }
                else
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, DELETE_ICON, ToggleState.On, strCurrentStep, DELETE_ICON);
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
                iCurStep++;
                strCurrentStep = t.ListSteps[iCurStep].Name;
                if (driver.FindElement(By.Id("ctl00_MainContent_btnNextTab2")).Displayed)
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
                    bRetVal = true;
                }
                else
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, DELETE_ICON, ToggleState.On, strCurrentStep, DELETE_ICON);
                    return false;
                }
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab2")).Click();
                Thread.Sleep(5000);

                // Step 5.3
                iCurStep++;
                strCurrentStep = t.ListSteps[iCurStep].Name;
                IList<Tabs> tab3 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices) }
                };
                if (GetRadTabStrip(strRadTabID, tab3))
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
                    bRetVal = true;
                }
                else
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, DELETE_ICON, ToggleState.On, strCurrentStep, DELETE_ICON);
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
                iCurStep++;
                strCurrentStep = t.ListSteps[iCurStep].Name;
                if (GetRadTabStrip(strRadTabID, tab4))
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
                    bRetVal = true;
                }
                else
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, DELETE_ICON, ToggleState.On, strCurrentStep, DELETE_ICON);
                    return false;
                }

                driver.FindElement(By.Id("ctl00_MainContent_btnSubmit_input")).Click();
                Thread.Sleep(2000);

                // Step 1.5
                iCurStep++;
                strCurrentStep = t.ListSteps[iCurStep].Name;
                if (driver.FindElement(By.Id("MainContent_CustomValidatorNew")).Displayed)
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
                    bRetVal = true;
                    driver.FindElement(By.Id("ctl00_MainContent_btnExit1_input")).Click();
                }
                else
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, DELETE_ICON, ToggleState.On, strCurrentStep, DELETE_ICON);
                    return false;
                }
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return bRetVal;
        }
        bool SalesShippingTest4(TestParams t, DiscoveryReqUpdates insert, bool bLoggedIn)
        {
            ShowMessageDelegate2 del = new ShowMessageDelegate2(ShowMessage);
            ShowDelegateUpdateTree del2 = new ShowDelegateUpdateTree(SelectTreeNode);
            bool bRetVal = false;
            int iCurStep = 0;
            string strCurrentStep = t.ListSteps[iCurStep].Name;
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
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
                }
                else
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, DELETE_ICON, ToggleState.On, strCurrentStep, DELETE_ICON);
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
                iCurStep++;
                strCurrentStep = t.ListSteps[iCurStep].Name;
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab1")).Click();

                IList<Tabs> tab = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true, Selected = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices) }
                };
                if (GetRadTabStrip(strRadTabID, tab))
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
                    bRetVal = true;
                }
                else
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, DELETE_ICON, ToggleState.On, strCurrentStep, DELETE_ICON);
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
                iCurStep++;
                strCurrentStep = t.ListSteps[iCurStep].Name;
                if (driver.FindElement(By.Id("ctl00_MainContent_btnNextTab2")).Displayed)
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
                    bRetVal = true;
                }
                else
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, DELETE_ICON, ToggleState.On, strCurrentStep, DELETE_ICON);
                    return false;
                }
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab2")).Click();
                Thread.Sleep(5000);

                // Step 4.3
                iCurStep++;
                strCurrentStep = t.ListSteps[iCurStep].Name;
                IList<Tabs> tab3 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices) }
                };
                if (GetRadTabStrip(strRadTabID, tab3))
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
                    bRetVal = true;
                }
                else
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, DELETE_ICON, ToggleState.On, strCurrentStep, DELETE_ICON);
                    return false;
                }

                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab3")).Click();
                // Step 4.4
                iCurStep++;
                strCurrentStep = t.ListSteps[iCurStep].Name;
                this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);

                Thread.Sleep(2000);
                bool bctl05 = driver.FindElement(By.Id("MainContent_ctl05")).Displayed;
                // Step 4.5
                iCurStep++;
                strCurrentStep = t.ListSteps[iCurStep].Name;
                if (bctl05)
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
                    bRetVal = true;
                    driver.FindElement(By.Id("ctl00_MainContent_btnExit1_input")).Click();
                }
                else
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, DELETE_ICON, ToggleState.On, strCurrentStep, DELETE_ICON);
                    return false;
                }
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return bRetVal;
        }
        bool SalesShippingTest3(TestParams t, DiscoveryReqUpdates insert, bool bLoggedIn)
        {
            ShowMessageDelegate2 del = new ShowMessageDelegate2(ShowMessage);
            ShowDelegateUpdateTree del2 = new ShowDelegateUpdateTree(SelectTreeNode);
            bool bRetVal = false;
            //string strCurrentStep = String.Format("Step {0:0.0#}", t.Step);
            int iCurStep = 0;
            string strCurrentStep = t.ListSteps[iCurStep].Name;
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
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
                }
                else
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, DELETE_ICON, ToggleState.On, strCurrentStep, DELETE_ICON);
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
                iCurStep++;
                strCurrentStep = t.ListSteps[iCurStep].Name;
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab1")).Click();
                IList<Tabs> tab = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true, Selected = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices) }
                };
                if (GetRadTabStrip(strRadTabID, tab))
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
                    bRetVal = true;
                }
                else
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, DELETE_ICON, ToggleState.On, strCurrentStep, DELETE_ICON);
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
                iCurStep++;
                strCurrentStep = t.ListSteps[iCurStep].Name;
                if (driver.FindElement(By.Id("ctl00_MainContent_btnNextTab2")).Displayed)
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
                    bRetVal = true;
                }
                else
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, DELETE_ICON, ToggleState.On, strCurrentStep, DELETE_ICON);
                    return false;
                }

                // Step 3.3
                iCurStep++;
                strCurrentStep = t.ListSteps[iCurStep].Name;
                // deleted the contact
                driver.FindElement(By.Id("ctl00_MainContent_contactGrid_ctl00_ctl04_gbcDeleteLink")).Click();
                Thread.Sleep(2000);
                if (!driver.FindElement(By.Id("ctl00_MainContent_btnNextTab2")).Enabled)
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
                    bRetVal = true;
                    driver.FindElement(By.Id("ctl00_MainContent_btnExit1_input")).Click();
                }
                else
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, DELETE_ICON, ToggleState.On, strCurrentStep, DELETE_ICON);
                    return false;
                }
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return bRetVal;
        }
        bool SalesShippingTest2(TestParams t, DiscoveryReqUpdates insert, bool bLoggedIn)
        {
            ShowMessageDelegate2 del = new ShowMessageDelegate2(ShowMessage);
            ShowDelegateUpdateTree del2 = new ShowDelegateUpdateTree(SelectTreeNode);
            bool bRetVal = false;
            int iCurStep = 0;
            string strCurrentStep = t.ListSteps[iCurStep].Name;
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
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
                }
                else
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    return false;
                }

                // Click the Next Button Step 2.1
                iCurStep++;
                strCurrentStep = t.ListSteps[iCurStep].Name;
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
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
                    driver.FindElement(By.Id("ctl00_MainContent_btnExit1_input")).Click();
                    Thread.Sleep(1000);
                }
                else
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, DELETE_ICON, ToggleState.On, strCurrentStep, DELETE_ICON);
                    return false;
                }
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return bRetVal;
        }
        bool SalesShippingTest1(TestParams t,DiscoveryReqUpdates insert)
        {
            ShowMessageDelegate2 del = new ShowMessageDelegate2(ShowMessage);
            ShowDelegateUpdateTree del2 = new ShowDelegateUpdateTree(SelectTreeNode);
            bool bRetVal = false;
            //string strCurrentStep = String.Format("Step {0:0.0#}", t.Step);
            int iCurStep = 0;
            string strCurrentStep =  t.ListSteps[iCurStep].Name;
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
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2,t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
                }
                else
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, DELETE_ICON, ToggleState.On, strCurrentStep, DELETE_ICON);
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
                iCurStep++;
                strCurrentStep = t.ListSteps[iCurStep].Name;
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab1")).Click();

                IList<Tabs> tab = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true, Selected = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices) }
                };
                if (GetRadTabStrip(strRadTabID, tab))
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
                    bRetVal = true;
                }
                else
                {
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, DELETE_ICON, ToggleState.On, strCurrentStep, DELETE_ICON);
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
                iCurStep++;
                strCurrentStep = t.ListSteps[iCurStep].Name;
                if (driver.FindElement(By.Id("ctl00_MainContent_btnNextTab2")).Displayed)
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
                    bRetVal = true;
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, DELETE_ICON, ToggleState.On, strCurrentStep, DELETE_ICON);
                    return false;
                }
                driver.FindElement(By.Id("ctl00_MainContent_btnNextTab2")).Click();
                Thread.Sleep(5000);

                // Step 1.3
                iCurStep++;
                strCurrentStep = t.ListSteps[iCurStep].Name;
                IList<Tabs> tab3 = new List<Tabs>() {
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CustomerInfo)     , Enabled = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ContactInfo)      , Enabled = true},
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.CurrentSolution)  , Enabled = true, Selected = true },
                    new Tabs() { Name = StringEnum.GetStringValue(AllTabs.ShippingServices) }
                };
                if (GetRadTabStrip(strRadTabID, tab3))
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
                    bRetVal = true;
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, DELETE_ICON, ToggleState.On, strCurrentStep, DELETE_ICON);
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
                iCurStep++;
                strCurrentStep = t.ListSteps[iCurStep].Name;
                if (GetRadTabStrip(strRadTabID, tab4))
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
                    bRetVal = true;
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, DELETE_ICON, ToggleState.On, strCurrentStep, DELETE_ICON);
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
                iCurStep++;
                strCurrentStep = t.ListSteps[iCurStep].Name;
                if (driver.FindElement(By.ClassName("rwPopupButton")).Displayed)
                {
                    Console.WriteLine(strCurrentStep + " Passed");
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Passed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, OK_ICON, ToggleState.On, strCurrentStep, OK_ICON);
                    bRetVal = true;
                }
                else
                {
                    Console.WriteLine(strCurrentStep + " Failed");
                    this.listBox1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, strCurrentStep + " Failed");
                    this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del2, t, DELETE_ICON, ToggleState.On, strCurrentStep, DELETE_ICON);
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
        #region Script Support Functions
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
            if (qAllTabs.Count == tab.Count)
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
        #endregion
    }
}
