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
using System.Windows.Threading;

namespace PuroFusionTestGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GridData1 mainGridData;
        public class GridData1 : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            public ICollectionView _AppRules;
            public ICollectionView _AppUserRules;
            public ICollectionView _SolutionType;
            public string _selectedItem;
            public ICollectionView _Employee;
            public ICollectionView _Applications;
            public ICollectionView _Users;
            public ICollectionView AppRules
            {
                get { return _AppRules; }
                set
                {
                    _AppRules = value;
                    OnPropertyChanged("AppRules");
                }
            }
            public ICollectionView AppUserRules
            {
                get { return _AppUserRules; }
                set
                {
                    _AppUserRules = value;
                    OnPropertyChanged("AppUserRules");
                }
            }
            public ICollectionView SolutionType
            {
                get { return _SolutionType; }
                set
                {
                    _SolutionType = value;
                    OnPropertyChanged("SolutionType");
                }
            }
            public string SelectedItem
            {
                get { return _selectedItem; }
                set
                {
                    _selectedItem = value;
                    OnPropertyChanged("SelectedItem");
                }
            }
            public ICollectionView Employee
            {
                get { return _Employee; }
                set
                {
                    _Employee = value;
                    OnPropertyChanged("Employee");
                }
            }
            public ICollectionView Applications
            {
                get { return _Applications; }
                set
                {
                    _Applications = value;
                    OnPropertyChanged("Applications");
                }
            }
            public ICollectionView Users
            {
                get { return _Users; }
                set
                {
                    _Users = value;
                    OnPropertyChanged("Users");
                }
            }
            public GridData1() { }
            // Create the OnPropertyChanged method to raise the event
            protected void OnPropertyChanged(string name)
            {
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
        }
        IList<Tabs> tabShippingTest1 = new List<Tabs>() {
            new Tabs(AllTabs.CustomerInfo    ) { Enabled = true, Selected = true },
            new Tabs(AllTabs.ContactInfo     ) { },
            new Tabs(AllTabs.CurrentSolution ) { },
            new Tabs(AllTabs.ShippingServices) { },
            new Tabs(AllTabs.EDIServices)      { Visible = false },
            new Tabs(AllTabs.Profile)          { Visible = false },
            new Tabs(AllTabs.CourierEDI)       { Visible = false },
            new Tabs(AllTabs.NonCourierEDI)    { Visible = false },
            new Tabs(AllTabs.AddlNotes)        { Visible = false },
            new Tabs(AllTabs.FileUploads)      { Visible = false }
        };
        IList<TestParams> ToTest2 = new List<TestParams>() {
            new TestParams( AllTest.SalesShippingTest1,5) { Enabled = false,  Step = 1.0},
            new TestParams( AllTest.SalesShippingTest2,5) { Enabled = false,  Step = 2.0},
            new TestParams( AllTest.SalesShippingTest3,5) { Enabled = false,  Step = 3.0},
            new TestParams( AllTest.SalesShippingTest4,5) { Enabled = false,  Step = 4.0},
            new TestParams( AllTest.SalesShippingTest5,5) { Enabled = false,  Step = 5.0},
            new TestParams( AllTest.SalesShippingTest7,5) { Enabled = false,  Step = 7.0},
            new TestParams( AllTest.SalesEDITest1,5)      { Enabled = false,  Step = 1.0},
            new TestParams( AllTest.SalesEDITest2,5)      { Enabled = false,  Step = 2.0},
            new TestParams( AllTest.SalesEDITest3,5)      { Enabled = false,  Step = 3.0},
            new TestParams( AllTest.SalesEDITest4,5)      { Enabled = false,  Step = 4.0},
            new TestParams( AllTest.SalesEDITest5,5)      { Enabled = false,  Step = 5.0},
            new TestParams( AllTest.SalesEDITest6,5)      { Enabled = false,  Step = 6.0},
            new TestParams( AllTest.SalesEDITest7,5)      { Enabled = false,  Step = 7.0},
            new TestParams( AllTest.SalesBothTest1,5)     { Enabled = false,  Step = 1.0},
            new TestParams( AllTest.SalesBothTest2,5)     { Enabled = false,  Step = 2.0},
            new TestParams( AllTest.SalesBothTest3,5)     { Enabled = false,  Step = 3.0},
            new TestParams( AllTest.SalesBothTest4,5)     { Enabled = false,  Step = 4.0},
            new TestParams( AllTest.SalesBothTest5,5)     { Enabled = false,  Step = 5.0},
            new TestParams( AllTest.SalesBothTest6,5)     { Enabled = false,  Step = 6.0},
            new TestParams( AllTest.SalesBothTest7,5)     { Enabled = true,  Step = 7.0}
        };
        Step curStep;
        static bool bTimeTimer;
        public delegate void ShowMessageDelegate(int iFunct, string strIn);

        const string OK_ICON = @"F:\src\Customer\Purolator\PuroFusion\PuroFusionTestHarness\PuroFusionTestGui\OK.ico";
        const string CODEBREAK_ICON = @"F:\src\Customer\Purolator\PuroFusion\PuroFusionTestHarness\PuroFusionTestGui\CodeBreakpoint.ico";
        const string DELETE_ICON = @"F:\src\Customer\Purolator\PuroFusion\PuroFusionTestHarness\PuroFusionTestGui\Delete.ico";
        public MainWindow()
        {
            InitializeComponent();
            mainGridData = new GridData1();
           

            Assembly myAssembly = Assembly.GetExecutingAssembly();
            AssemblyName myAssemblyName = myAssembly.GetName();
            this.Title = "PuroFusion Test Gui Ver " + myAssemblyName.Version.ToString();

            comboBoxMainDB.Items.Add(PuroReportingServiceClass.ConnString.PatientLocal);
            comboBoxMainDB.Items.Add(PuroReportingServiceClass.ConnString.PatientLocal2);
            comboBoxMainDB.Items.Add(PuroReportingServiceClass.ConnString.PatientLocal3);
            comboBoxTouchDB.Items.Add(PuroTouchServiceClass.ConnString.PatientLocal);
            comboBoxTouchDB.Items.Add(PuroTouchServiceClass.ConnString.PatientLocal2);
            comboBoxTouchDB.Items.Add(PuroTouchServiceClass.ConnString.PatientLocal3);
            comboBoxTestingTouchDB.Items.Add(PuroTouchServiceClass.ConnString.PatientLocal);
            comboBoxTestingTouchDB.Items.Add(PuroTouchServiceClass.ConnString.PatientLocal2);
            comboBoxTestingTouchDB.Items.Add(PuroTouchServiceClass.ConnString.PatientLocal3);

            foreach (AllTabs i in Enum.GetValues(typeof(AllTabs)))
            {
                cmbBoxWebTesterSelectedTab.Items.Add(StringEnum.GetStringValue(i));
            }
            cmbBoxWebTesterSelectedTab.SelectedIndex = 0;
            lblWebTesterWarningMsg.Visibility = Visibility.Hidden;

            AddTreeViewItems5(ToTest2);
            curStep = new Step(ToTest2[0], 1);
            bTimeTimer = true;
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(timerForTime_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            //dispatcherTimer.Start();

            int er = 0;
            er++;
       }
        public class DiscoveryReqUpdates
        {
            private string format1 = "yyyy-MM-ddTHH:mm:ss.fff";
            public int idRequestType { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime dt1 { get; set; }

            //public string Value { get; set; }
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
        public class Props
        {
            public string Name { get; set; }
            public string Value { get; set; }
            public bool Show { get; set; }
            public bool IsNull { get; set; }
            public string PropName1 { get; set; }
            public string PropName2 { get; set; }
            public string PropName3 { get; set; }
            public Props()
            {
                Show = true;
            }

        }
        private string GetdbLocation(ComboBox cmb)
        {
            string curItem = ((string)cmb.SelectedItem);
            if (curItem == null)
            {
                lbldbConnErrorMsg.Visibility = System.Windows.Visibility.Visible;
                return "na";
            }
            else
                lbldbConnErrorMsg.Visibility = System.Windows.Visibility.Collapsed;

            String strDbVal = curItem;
            string connection = "";
            if (strDbVal == PuroReportingServiceClass.ConnString.PatientLocal)
                connection = PuroReportingServiceClass.ConnString.FullPatientLocal;
            else if (strDbVal == PuroReportingServiceClass.ConnString.PatientLocal2)
                connection = PuroReportingServiceClass.ConnString.FullPatientLocal2;
            else if (strDbVal == PuroReportingServiceClass.ConnString.PatientLocal3)
                connection = PuroReportingServiceClass.ConnString.FullPatientLocal3;
            else if (strDbVal == PuroTouchServiceClass.ConnString.PatientLocal)
                connection = PuroTouchServiceClass.ConnString.FullPatientLocal;
            else if (strDbVal == PuroTouchServiceClass.ConnString.PatientLocal2)
                connection = PuroTouchServiceClass.ConnString.FullPatientLocal2;
            else if (strDbVal == PuroTouchServiceClass.ConnString.PatientLocal3)
                connection = PuroTouchServiceClass.ConnString.FullPatientLocal3;
            return connection;
        }
        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            string extension = "xls";
            Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog()
            {
                DefaultExt = extension,
                Filter = String.Format("{1} files (*.{0})|*.{0}|All files (*.*)|*.*", extension, "Excel"),
                FilterIndex = 1
            };
            if (dialog.ShowDialog() == true)
            {
                using (Stream stream = dialog.OpenFile())
                {
                    if (((Button)sender).Name == "TouchDBExportTopLeft")
                        this.radGridTouchDBTopLeft.Export(stream, new GridViewExportOptions() { Format = ExportFormat.Text, ShowColumnHeaders = true, ShowColumnFooters = false, ShowGroupFooters = false, });
                    //else if (((Button)sender).Name == "MainradGridTopRight")
                    //    this.MainradGridTopRight.Export(stream, new GridViewExportOptions() { Format = ExportFormat.Text, ShowColumnHeaders = true, ShowColumnFooters = false, ShowGroupFooters = false, });
                }
            }
        }
        private void btnMainLoadGridTopLeft_Click(object sender, RoutedEventArgs e)
        {
            string strConn = GetdbLocation(comboBoxMainDB);
            if (strConn != "na")
            {
                ComboBoxItem ReportItem = ((ComboBoxItem)comboBoxMainReportNames.SelectedItem);
                if (ReportItem == null)
                {
                    lbldbConnErrorMsg.Visibility = System.Windows.Visibility.Visible;
                    lbldbConnErrorMsg.Content = "Must select a report type";
                }
                else
                {
                    lbldbConnErrorMsg.Visibility = System.Windows.Visibility.Collapsed;

                    System.Windows.Controls.Label lbl = lblMainTopLeftCount;
                    RadGridView grid = this.radGridMainTopLeft;

                    #region Test which button pressed
                    if (((Button)sender).Name == "btnMainLoadGridTopLeft")
                    {
                        grid = this.radGridMainTopLeft;
                        lbl = lblMainTopLeftCount;
                    }
                    else if (((Button)sender).Name == "btnMainTopRightLoadGrid")
                    {
                        grid = this.radGridMainTopRight;
                        lbl = lblMainTopRightCount;
                    }
                    else if (((Button)sender).Name == "btnMainLoadGridBottomLeft")
                    {
                        grid = this.radGridMainLowerLeft;
                        lbl = lblMainLowerLeftCount;
                    }
                    #endregion
                    PuroReportingServiceClass o = new PuroReportingServiceClass(strConn);
                    String strReportItem = ReportItem.Content.ToString();
                    if ("tblPI_Applications" == strReportItem)
                    {
                        IList<dtotblPI_Applications> qtblPI_Applications = o.GetPI_Applications();
                        ObservableCollection<dtotblPI_Applications> ocWmsGroup = new ObservableCollection<dtotblPI_Applications>();
                        grid.ItemsSource = ocWmsGroup.Concat<dtotblPI_Applications>(qtblPI_Applications);
                        lbl.Content = strReportItem + " count: " + qtblPI_Applications.Count();
                    }
                    else if ("PuroFusion Users" == strReportItem)
                    {
                        IList<dtoPuroTouchUsers> qPI_ApplicationUser = o.GetPuroTouchUsers();
                        ObservableCollection<dtoPuroTouchUsers> ocWmsGroup = new ObservableCollection<dtoPuroTouchUsers>();
                        grid.ItemsSource = ocWmsGroup.Concat<dtoPuroTouchUsers>(qPI_ApplicationUser);
                        lbl.Content = strReportItem + " count: " + qPI_ApplicationUser.Count();
                    }
                    else if ("tblPI_ApplicationsGroup" == strReportItem)
                    {
                        IList<dtotblPI_Applications> qtblPI_Applications = o.GetPI_ApplicationsGroupByName();
                        ObservableCollection<dtotblPI_Applications> ocWmsGroup = new ObservableCollection<dtotblPI_Applications>();
                        grid.ItemsSource = ocWmsGroup.Concat<dtotblPI_Applications>(qtblPI_Applications);
                        lbl.Content = strReportItem + " count: " + qtblPI_Applications.Count();
                        mainGridData.Applications = CollectionViewSource.GetDefaultView(qtblPI_Applications);
                        DataContext = mainGridData;
                        comboBoxApplications.SelectedIndex = 15;
                    }
                    else if ("tblEmployee" == strReportItem)
                    {
                        IList<dtotblEmployee> qtblEmployee = o.GettblEmployee();
                        ObservableCollection<dtotblEmployee> ocWmsGroup = new ObservableCollection<dtotblEmployee>();
                        grid.ItemsSource = ocWmsGroup.Concat<dtotblEmployee>(qtblEmployee);
                        lbl.Content = strReportItem + " count: " + qtblEmployee.Count();
                        mainGridData.Employee = CollectionViewSource.GetDefaultView(qtblEmployee);
                        DataContext = mainGridData;

                        //comboBoxEmployee.SelectedIndex = 333;
                    }
                    else if ("tblPI_ApplicationUser" == strReportItem)
                    {
                        IList<tblPI_ApplicationUser> qApplicationUser = o.GetPI_ApplicationUser();
                        ObservableCollection<tblPI_ApplicationUser> ocWmsGroup = new ObservableCollection<tblPI_ApplicationUser>();
                        grid.ItemsSource = ocWmsGroup.Concat<tblPI_ApplicationUser>(qApplicationUser);
                        lbl.Content = strReportItem + " count: " + qApplicationUser.Count();
                    }
                    else if ("tblPI_ApplicationUserRole" == strReportItem)
                    {
                        IList<dtotblPI_ApplicationUserRole> qtblPI_ApplicationUserRole = o.GettblPI_ApplicationUserRole();
                        ObservableCollection<dtotblPI_ApplicationUserRole> ocWmsGroup = new ObservableCollection<dtotblPI_ApplicationUserRole>();
                        grid.ItemsSource = ocWmsGroup.Concat<dtotblPI_ApplicationUserRole>(qtblPI_ApplicationUserRole);
                        lbl.Content = strReportItem + " count: " + qtblPI_ApplicationUserRole.Count();
                    }
                    else if ("tblPI_ApplicationRoles" == strReportItem)
                    {
                        IList<dtotblPI_ApplicationRoles> qtblPI_ApplicationRoles = o.GettblPI_ApplicationRoles();
                        ObservableCollection<dtotblPI_ApplicationRoles> ocWmsGroup = new ObservableCollection<dtotblPI_ApplicationRoles>();
                        grid.ItemsSource = ocWmsGroup.Concat<dtotblPI_ApplicationRoles>(qtblPI_ApplicationRoles);
                        lbl.Content = strReportItem + " count: " + qtblPI_ApplicationRoles.Count();
                    }
                }
            }
        }
        private void btnTouchDBLoadGrid_Click(object sender, RoutedEventArgs e)
        {
            string strConn = GetdbLocation(comboBoxTouchDB);
            if (strConn != "na")
            {
                ComboBoxItem ReportItem = ((ComboBoxItem)comboBoxTouchDBMainReportNames.SelectedItem);
                if (ReportItem == null)
                {
                    lblTouchDBConnErrorMsg.Visibility = System.Windows.Visibility.Visible;
                    lblTouchDBConnErrorMsg.Content = "Must select a report type";
                }
                else
                {
                    lblTouchDBConnErrorMsg.Visibility = System.Windows.Visibility.Collapsed;

                    System.Windows.Controls.Label lbl = lblTouchDBTopLeftCount;
                    RadGridView grid = this.radGridTouchDBTopLeft;
                    #region Test which button pressed
                    if (((Button)sender).Name == "btnTouchDBLoadGridTopLeft")
                    {
                        grid = this.radGridTouchDBTopLeft;
                        lbl = lblTouchDBTopLeftCount;
                    }
                    else if (((Button)sender).Name == "btnTouchDBTopRightLoadGrid")
                    {
                        grid = this.radGridTouchDBTopRight;
                        lbl = lblTouchDBTopRightCount;
                    }
                    else if (((Button)sender).Name == "btnTouchDBLoadGridBottomLeft")
                    {
                        grid = this.radGridTouchDBLowerLeft;
                        lbl = lblTouchDBLowerLeftCount;
                    }
                    #endregion
                    PuroTouchServiceClass o = new PuroTouchServiceClass(strConn);
                    String strReportItem = ReportItem.Content.ToString();
                    if ("tblDiscoveryRequest" == strReportItem)
                    {
                        IList<dtotblDiscoveryRequest> qDiscoveryRequest = o.GettblDiscoveryRequestDesc();
                        ObservableCollection<dtotblDiscoveryRequest> ocWmsGroup = new ObservableCollection<dtotblDiscoveryRequest>();
                        grid.ItemsSource = ocWmsGroup.Concat<dtotblDiscoveryRequest>(qDiscoveryRequest);
                        lbl.Content = strReportItem + " count: " + qDiscoveryRequest.Count();
                    }
                    else if ("Error Logs" == strReportItem)
                    {
                        List<clsExceptionLogging> qErrors = o.GetExceptionLogging();
                        ObservableCollection<clsExceptionLogging> ocWmsGroup = new ObservableCollection<clsExceptionLogging>();
                        grid.ItemsSource = ocWmsGroup.Concat<clsExceptionLogging>(qErrors);
                        lbl.Content = strReportItem + " count: " + qErrors.Count();
                    }
                    else if ("blContactType" == strReportItem)
                    {
                        IList<dtotblContactType> qtblContactType = o.GettblContactType();
                        ObservableCollection<dtotblContactType> ocWmsGroup = new ObservableCollection<dtotblContactType>();
                        grid.ItemsSource = ocWmsGroup.Concat<dtotblContactType>(qtblContactType);
                        lbl.Content = strReportItem + " count: " + qtblContactType.Count();
                    }
                    else if ("tblContact" == strReportItem)
                    {
                        IList<dtotblContact> qtblContact = o.GettblContact();
                        ObservableCollection<dtotblContact> ocWmsGroup = new ObservableCollection<dtotblContact>();
                        grid.ItemsSource = ocWmsGroup.Concat<dtotblContact>(qtblContact);
                        lbl.Content = strReportItem + " count: " + qtblContact.Count();
                    }
                    else if ("tblEDIRecipReq" == strReportItem)
                    {
                        List<dtotblEDIRecipReqs> qEDIRecipReq = o.GetEDIRecipReqs();
                        ObservableCollection<dtotblEDIRecipReqs> ocWmsGroup = new ObservableCollection<dtotblEDIRecipReqs>();
                        grid.ItemsSource = ocWmsGroup.Concat<dtotblEDIRecipReqs>(qEDIRecipReq);
                        lbl.Content = strReportItem + " count: " + qEDIRecipReq.Count();
                    }
                    else if ("tblEDIAccounts" == strReportItem)
                    {
                        List<clsEDIAccount> qEDIAccounts = o.GetEDIAccounts();
                        ObservableCollection<clsEDIAccount> ocWmsGroup = new ObservableCollection<clsEDIAccount>();
                        grid.ItemsSource = ocWmsGroup.Concat<clsEDIAccount>(qEDIAccounts);
                        lbl.Content = strReportItem + " count: " + qEDIAccounts.Count();
                    }
                    else if ("tblEDITranscations" == strReportItem)
                    {
                        IList<dtotblEDITranscations> qTransType = o.GetEDITransactions();
                        ObservableCollection<dtotblEDITranscations> ocWmsGroup = new ObservableCollection<dtotblEDITranscations>();
                        grid.ItemsSource = ocWmsGroup.Concat<dtotblEDITranscations>(qTransType);
                        lbl.Content = strReportItem + " count: " + qTransType.Count();
                    }
                    else if ("tblEDITranscationType" == strReportItem)
                    {
                        IList<clsEDITransactionType> qTransType = o.GetEDITransactionTypes();
                        ObservableCollection<clsEDITransactionType> ocWmsGroup = new ObservableCollection<clsEDITransactionType>();
                        grid.ItemsSource = ocWmsGroup.Concat<clsEDITransactionType>(qTransType);
                        lbl.Content = strReportItem + " count: " + qTransType.Count();
                    }
                    else if ("tblFileType" == strReportItem)
                    {
                        List<ClsFileType> qFileTypes = o.GetFileTypes();
                        ObservableCollection<ClsFileType> ocWmsGroup = new ObservableCollection<ClsFileType>();
                        grid.ItemsSource = ocWmsGroup.Concat<ClsFileType>(qFileTypes);
                        lbl.Content = strReportItem + " count: " + qFileTypes.Count();
                    }
                    else if ("tblCommunicationMethod" == strReportItem)
                    {
                        IList<ClsCommunicationMethod> qCommMeth = o.GetCommunicationMethods();
                        ObservableCollection<ClsCommunicationMethod> ocWmsGroup = new ObservableCollection<ClsCommunicationMethod>();
                        grid.ItemsSource = ocWmsGroup.Concat<ClsCommunicationMethod>(qCommMeth);
                        lbl.Content = strReportItem + " count: " + qCommMeth.Count();
                    }
                    else if ("tblTriggerMechanism" == strReportItem)
                    {
                        List<clsTriggerMechanism> qTrigMeth = o.GetTriggerMechanisms();
                        ObservableCollection<clsTriggerMechanism> ocWmsGroup = new ObservableCollection<clsTriggerMechanism>();
                        grid.ItemsSource = ocWmsGroup.Concat<clsTriggerMechanism>(qTrigMeth);
                        lbl.Content = strReportItem + " count: " + qTrigMeth.Count();
                    }
                    else if ("tblContactGroup" == strReportItem)
                    {
                        IList<Counters> qtheCount = o.GettblContactGroupBy();
                        ObservableCollection<Counters> ocWmsGroup = new ObservableCollection<Counters>();
                        grid.ItemsSource = ocWmsGroup.Concat<Counters>(qtheCount);
                        lbl.Content = strReportItem + " count: " + qtheCount.Count();
                    }
                    else if ("vw_ITBA" == strReportItem)
                    {
                        List<dtotblITBA> qITBAs = o.GetITBAs();
                        ObservableCollection<dtotblITBA> ocWmsGroup = new ObservableCollection<dtotblITBA>();
                        grid.ItemsSource = ocWmsGroup.Concat<dtotblITBA>(qITBAs);
                        lbl.Content = strReportItem + " count: " + qITBAs.Count();
                    }
                    else if ("PartialDiscoveryRequest" == strReportItem)
                    {
                        IList<dtoPartialDiscoveryRequest> qDiscoveryRequest = o.GetPartialDiscoveryRequest();
                        ObservableCollection<dtoPartialDiscoveryRequest> ocWmsGroup = new ObservableCollection<dtoPartialDiscoveryRequest>();
                        grid.ItemsSource = ocWmsGroup.Concat<dtoPartialDiscoveryRequest>(qDiscoveryRequest);
                        lbl.Content = strReportItem + " count: " + qDiscoveryRequest.Count();
                    }
                    else if ("DiscoveryRequestBusContacts" == strReportItem)
                    {
                        IList<dtoPartialDiscoveryRequest> qDiscoveryRequest = o.GetDiscoveryRequestBusContacts();
                        ObservableCollection<dtoPartialDiscoveryRequest> ocWmsGroup = new ObservableCollection<dtoPartialDiscoveryRequest>();
                        grid.ItemsSource = ocWmsGroup.Concat<dtoPartialDiscoveryRequest>(qDiscoveryRequest);
                        lbl.Content = strReportItem + " count: " + qDiscoveryRequest.Count();
                    }
                    else if ("DiscoveryRequestITContacts" == strReportItem)
                    {
                        IList<dtoPartialDiscoveryRequest> qDiscoveryRequest = o.GetDiscoveryRequestITContacts();
                        ObservableCollection<dtoPartialDiscoveryRequest> ocWmsGroup = new ObservableCollection<dtoPartialDiscoveryRequest>();
                        grid.ItemsSource = ocWmsGroup.Concat<dtoPartialDiscoveryRequest>(qDiscoveryRequest);
                        lbl.Content = strReportItem + " count: " + qDiscoveryRequest.Count();
                    }
                    else if ("CompareDiscReq-ToReq" == strReportItem)
                    {
                        o.strConn = comboBoxTouchDB.SelectedItem.ToString();
                        IList<dtoTableCompare> qTableCompare = o.GetDiscoveryDiff1("tblDiscoveryRequest_", "tblDiscoveryRequest");
                        ObservableCollection<dtoTableCompare> ocWmsGroup = new ObservableCollection<dtoTableCompare>();
                        grid.ItemsSource = ocWmsGroup.Concat<dtoTableCompare>(qTableCompare);
                        lbl.Content = strReportItem + " count: " + qTableCompare.Count();
                    }
                    else if ("CompareDiscReqToReq-" == strReportItem)
                    {
                        o.strConn = comboBoxTouchDB.SelectedItem.ToString();
                        IList<dtoTableCompare> qTableCompare = o.GetDiscoveryDiff1("tblDiscoveryRequest", "tblDiscoveryRequest_");
                        ObservableCollection<dtoTableCompare> ocWmsGroup = new ObservableCollection<dtoTableCompare>();
                        grid.ItemsSource = ocWmsGroup.Concat<dtoTableCompare>(qTableCompare);
                        lbl.Content = strReportItem + " count: " + qTableCompare.Count();
                    }
                }
            }
        }
        private void radGridTouchDBTopLeft_Filtered(object sender, Telerik.Windows.Controls.GridView.GridViewFilteredEventArgs e)
        {
            lblTouchDBTopLeftCountFiltered.Content = "Filtered recs: " + radGridTouchDBTopLeft.Items.Count.ToString();
        }
        private void radGridTouchDBTopLeft_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            if (((RadGridView)sender).SelectedItem is dtotblDiscoveryRequest)
            {
                string strConn = GetdbLocation(comboBoxTouchDB);
                PuroTouchServiceClass o = new PuroTouchServiceClass(strConn);
                dtotblDiscoveryRequest rec = ((dtotblDiscoveryRequest)(((RadGridView)sender).SelectedItem));
                IList<dtotblContact> qtblContact = o.GetContactsByRequestID(rec.idRequest);
                ObservableCollection<dtotblContact> ocWmsGroup = new ObservableCollection<dtotblContact>();
                radGridTouchDBLowRight1.ItemsSource = ocWmsGroup.Concat<dtotblContact>(qtblContact);
                lblTouchDBLowRight1.Content = "Contact count: " + qtblContact.Count();

                List<dtotblEDITranscations> qEDITrans = o.GetEDITransactionsByidRequestW_OCategory(rec.idRequest);
                ObservableCollection<dtotblEDITranscations> ocWmsGroup2 = new ObservableCollection<dtotblEDITranscations>();
                radGridTouchDBLowRight2.ItemsSource = ocWmsGroup2.Concat<dtotblEDITranscations>(qEDITrans);
                lblTouchDBLowRight2.Content = "EDITranscations count: " + qEDITrans.Count();

                List<dtotblEDIShipMethods> qShipMeth = o.GetEDIShipMethodTypesByidRequest(rec.idRequest);
                ObservableCollection<dtotblEDIShipMethods> ocWmsGroup3 = new ObservableCollection<dtotblEDIShipMethods>();
                radGridTouchDBLowRight3.ItemsSource = ocWmsGroup3.Concat<dtotblEDIShipMethods>(qShipMeth);
                lblTouchDBLowRight3.Content = "EDIShipMethod count: " + qShipMeth.Count();

                List<dtotblEDIRecipReqs> qEDIRecipReqs = o.GetEDIRecipReqsByRequesID(rec.idRequest);
                ObservableCollection<dtotblEDIRecipReqs> ocWmsGroup4 = new ObservableCollection<dtotblEDIRecipReqs>();
                radGridTouchDBLowRight4.ItemsSource = ocWmsGroup4.Concat<dtotblEDIRecipReqs>(qEDIRecipReqs);
                lblTouchDBLowRight4.Content = "tblEDIRecipReqs count: " + qEDIRecipReqs.Count();

                List<clsEDIAccount> qEDIAccounts = o.GetEDIAccountByidRequest(rec.idRequest);
                ObservableCollection<clsEDIAccount> ocWmsGroup5 = new ObservableCollection<clsEDIAccount>();
                radGridTouchDBLowRight5.ItemsSource = ocWmsGroup5.Concat<clsEDIAccount>(qEDIAccounts);
                lblTouchDBLowRight5.Content = "tblEDIAccounts count: " + qEDIAccounts.Count();
                int er = 0;
                er++;
            }
        }
        private void radGridMainTopLeft_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            if (((RadGridView)sender).SelectedItem is dtoPuroTouchUsers)
            {
                dtoPuroTouchUsers rec = ((dtoPuroTouchUsers)(((RadGridView)sender).SelectedItem));
                txtBxFirst.Text = rec.FirstName;
                txtBxMainLast.Text = rec.LastName;
                txtBxMainCurrentRole.Text = rec.RoleName;
                txtBxMainEmployeeID.Text = rec.idEmployee.ToString();
                txtBxMainApplicationUserRole.Text = rec.idPI_ApplicationUserRole.ToString();
                txtBxMainApplicationRole.Text = rec.idPI_ApplicationRole.ToString() + "-" + rec.RoleName;
            }
        }
        private void btnMainLoadPuroRoles_Click(object sender, RoutedEventArgs e)
        {
            string strConn = GetdbLocation(comboBoxMainDB);
            if (strConn != "na")
            {
                PuroReportingServiceClass o = new PuroReportingServiceClass(strConn);
                IList<dtotblPI_ApplicationRoles> qtblPI_Applications = o.GetPuroFusionApplicationRoles();
                mainGridData.AppUserRules = CollectionViewSource.GetDefaultView(qtblPI_Applications);
                DataContext = mainGridData;
                comboBoxMainPuroRoles.SelectedIndex = 0;
            }
        }
        private void btnMainChangePuroRoles_Click(object sender, RoutedEventArgs e)
        {
            dtotblPI_ApplicationRoles appRole = (dtotblPI_ApplicationRoles)comboBoxMainPuroRoles.SelectedItem;
            dtoPuroTouchUsers PuroTouchUser = ((dtoPuroTouchUsers)((radGridMainTopLeft).SelectedItem));
            string strConn = GetdbLocation(comboBoxMainDB);
            if (strConn != "na")
            {
                PuroReportingServiceClass o = new PuroReportingServiceClass(strConn);
                o.UpdateApplicationUserRole(PuroTouchUser, appRole);
            }

        }

        private void radGridTouchDBLowRight2_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            if (((RadGridView)sender).SelectedItem is dtotblEDITranscations)
            {
                dtotblEDITranscations rec = ((dtotblEDITranscations)(((RadGridView)sender).SelectedItem));
                string strConn = GetdbLocation(comboBoxTouchDB);
                if (strConn != "na")
                {
                    PuroTouchServiceClass o = new PuroTouchServiceClass(strConn);
                    List<dtotblEDIRecipReqs> qEDIRecipReqs = o.GetEDIRecipReqsByID(rec.idEDITranscation);
                    ObservableCollection<dtotblEDIRecipReqs> ocWmsGroup4 = new ObservableCollection<dtotblEDIRecipReqs>();
                    radGridTouchDBLowRight4.ItemsSource = ocWmsGroup4.Concat<dtotblEDIRecipReqs>(qEDIRecipReqs);
                    lblTouchDBLowRight4.Content = "tblEDIRecipReqs count: " + qEDIRecipReqs.Count();

                    List<clsEDIAccount> qEDIAccounts = o.GetEDIAccountByidEDITranscation(rec.idEDITranscation);
                    ObservableCollection<clsEDIAccount> ocWmsGroup5 = new ObservableCollection<clsEDIAccount>();
                    radGridTouchDBLowRight5.ItemsSource = ocWmsGroup5.Concat<clsEDIAccount>(qEDIAccounts);
                    lblTouchDBLowRight5.Content = "tblEDIAccounts count: " + qEDIAccounts.Count();
                }
            }
        }

        private void btnTestingLoad_Click(object sender, RoutedEventArgs e)
        {
            string strConn = GetdbLocation(comboBoxTestingTouchDB);
            if (strConn != "na")
            {
                ComboBoxItem ReportItem = ((ComboBoxItem)comboBoxTestingReportNames.SelectedItem);
                if (ReportItem == null)
                {
                    lblTouchDBConnErrorMsg.Visibility = System.Windows.Visibility.Visible;
                    lblTouchDBConnErrorMsg.Content = "Must select a report type";
                }
                else
                {
                    lblTouchDBConnErrorMsg.Visibility = System.Windows.Visibility.Collapsed;

                    System.Windows.Controls.Label lbl = lblTestingTopLeftRecCount;
                    RadGridView grid = this.radGridTestingLeftTop;
                    #region Test which button pressed
                    if (((Button)sender).Name == "btnTestingLoad")
                    {
                        grid = this.radGridTestingLeftTop;
                        lbl = lblTestingTopLeftRecCount;
                    }
                    //else if (((Button)sender).Name == "btnTouchDBTopRightLoadGrid")
                    //{
                    //    grid = this.radGridTouchDBTopRight;
                    //    lbl = lblTouchDBTopRightCount;
                    //}
                    #endregion
                    PuroTouchServiceClass o = new PuroTouchServiceClass(strConn);
                    String strReportItem = ReportItem.Content.ToString();
                    if ("tblDiscoveryRequest" == strReportItem)
                    {
                        IList<dtotblDiscoveryRequest> qDiscoveryRequest = o.GettblDiscoveryRequestDesc2();
                        ObservableCollection<dtotblDiscoveryRequest> ocWmsGroup = new ObservableCollection<dtotblDiscoveryRequest>();
                        grid.ItemsSource = ocWmsGroup.Concat<dtotblDiscoveryRequest>(qDiscoveryRequest);
                        lbl.Content = strReportItem + " count: " + qDiscoveryRequest.Count();

                        mainGridData.SolutionType = CollectionViewSource.GetDefaultView(o.GetSolutionTypes());
                        mainGridData.SelectedItem = "Both Ship Sys & EDI";
                        DataContext = mainGridData;
                    }
                    else if ("Error Logs" == strReportItem)
                    {
                        List<clsExceptionLogging> qErrors = o.GetExceptionLogging();
                        ObservableCollection<clsExceptionLogging> ocWmsGroup = new ObservableCollection<clsExceptionLogging>();
                        grid.ItemsSource = ocWmsGroup.Concat<clsExceptionLogging>(qErrors);
                        lbl.Content = strReportItem + " count: " + qErrors.Count();
                    }
                }
            }
        }

        private void radGridTestingLeftTop_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            if (((RadGridView)sender).SelectedItem is dtotblDiscoveryRequest)
            {
                dtotblDiscoveryRequest rec = ((dtotblDiscoveryRequest)(((RadGridView)sender).SelectedItem));
                string strConn = GetdbLocation(comboBoxTestingTouchDB);
                if (strConn != "na")
                {
                    //PuroTouchServiceClass o = new PuroTouchServiceClass(strConn);
                    //dtotblSolutionType sol = o.GetSolutionType(rec.idSolutionType.Value);
                    comboBoxTestingSolutionType.SelectedIndex = rec.idSolutionType.Value - 1;
                    txtBxTestingCustomerName.Text = rec.CustomerName;
                    txtBxTestingAddress2.Text = rec.Address;
                    numTextingRevenue.Value = rec.ProjectedRevenue.Value;
                    radDateTimeTestingCreated.DateTimeText = rec.CreatedOn.ToString();
                    radDateTimeTestingUpdated.DateTimeText = rec.UpdatedOn.ToString();
                }
            }
        }

        private void btnTestingInsert_Click(object sender, RoutedEventArgs e)
        {
            if (radGridTestingLeftTop.SelectedItem is dtotblDiscoveryRequest)
            {
                dtotblDiscoveryRequest rec = (dtotblDiscoveryRequest)radGridTestingLeftTop.SelectedItem;
                string strConn = GetdbLocation(comboBoxTestingTouchDB);
                if (strConn != "na")
                {
                    dtotblSolutionType SolutionType = (dtotblSolutionType)comboBoxTestingSolutionType.SelectedItem;
                    rec.CustomerName = txtBxTestingCustomerName.Text;
                    rec.Address = txtBxTestingAddress2.Text;
                    rec.idSolutionType = SolutionType.idSolutionType;
                    rec.ProjectedRevenue = System.Convert.ToDecimal(numTextingRevenue.Value);
                    rec.idRequest = 0;
                    rec.CreatedOn = radDateTimeTestingCreated.SelectedValue;
                    PuroTouchServiceClass o = new PuroTouchServiceClass(strConn);
                    o.InsertDiscoveryRequest(rec);
                }
                int er = 0;
                er++;
            }
        }

        private void comboBoxTestingSolutionType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dtotblSolutionType Solution = (dtotblSolutionType)((ComboBox)sender).SelectedItem;
            int er = 0;
            er++;
        }

        private void btnTestingCreateInsert_Click(object sender, RoutedEventArgs e)
        {
            if (radGridTestingLeftTop.SelectedItem is dtotblDiscoveryRequest)
            {
                dtotblDiscoveryRequest rec = (dtotblDiscoveryRequest)radGridTestingLeftTop.SelectedItem;
                string strConn = ((string)comboBoxTestingTouchDB.SelectedItem);
                //string strConn = GetdbLocation(comboBoxTestingTouchDB);
                dtotblSolutionType SolutionType = (dtotblSolutionType)comboBoxTestingSolutionType.SelectedItem;
                rec.CustomerName = txtBxTestingCustomerName.Text;
                rec.Address = txtBxTestingAddress2.Text;
                rec.idSolutionType = SolutionType.idSolutionType;
                rec.ProjectedRevenue = System.Convert.ToDecimal(numTextingRevenue.Value);
                rec.idRequest = 0;
                if (chBxTestingNow.IsChecked.Value)
                {
                    rec.CreatedOn = DateTime.Now;
                    rec.UpdatedOn = DateTime.Now;
                }
                else
                {
                    rec.CreatedOn = radDateTimeTestingCreated.SelectedValue;
                    rec.UpdatedOn = radDateTimeTestingUpdated.SelectedValue;
                }
                string strFullSql = GetStringToInsertIntoDb(rec);
                txtBoxTestingValue2.Text = strFullSql;
                txtBxTestingInsertSql.Text = strFullSql;
                //PuroTouchServiceClass o = new PuroTouchServiceClass(strConn);
                //o.InsertTestDiscoveryRequestRecord(strFullSql);
                int er = 0;
                er++;
            }
        }
        private string GetStringToInsertIntoDb(dtotblDiscoveryRequest rec)
        {
            IList<Props> pList = new List<Props>();
            bool bFirstField = true;
            foreach (PropertyInfo prop in rec.GetType().GetProperties())
            {
                string strValue = prop.GetValue(rec, null) != null ? prop.GetValue(rec, null).ToString() : "null";
                string s = prop.Name;
                string strPropType = prop.PropertyType.FullName;
                Props pp = new Props() { Name = prop.Name, PropName1 = prop.PropertyType.Name, Value = strValue };
                if (bFirstField)
                {
                    bFirstField = false;
                    pp.Show = false;
                }
                else if (strPropType.Contains("Nullable`1"))
                {
                    pp.IsNull = true;
                    pp.PropName1 = "Nullable";
                    if (strPropType.Contains("Boolean"))
                        pp.PropName2 = "Boolean";
                    else if (strPropType.Contains("Int32"))
                        pp.PropName2 = "Int32";
                    else if (strPropType.Contains("Decimal"))
                        pp.PropName2 = "Decimal";
                    else if (strPropType.Contains("DateTime"))
                    {
                        if (!strValue.Contains("null"))
                        {
                            DateTime tm = (DateTime)prop.GetValue(rec, null);
                            string format = "yyyy-MM-ddTHH:mm:ss.fff";
                            pp.Value = tm.ToString(format);
                            int er1 = 0;
                            er1++;
                            //pp.Value = prop.GetValue(rec, null).ToString("yyyy-MM-dd HH:mm:ss");
                        }
                        pp.PropName2 = "DateTime";
                    }
                    else
                    {
                        pp.PropName2 = strPropType;
                    }
                }
                else if (strPropType.Contains("Boolean"))
                    pp.PropName1 = "Boolean";
                else if (strPropType.Contains("String"))
                    pp.PropName1 = "String";
                else if (strPropType.Contains("Int32"))
                    pp.PropName1 = "Int32";
                else if (strPropType.Contains("Decimal"))
                    pp.PropName1 = "Decimal";
                else if (strPropType.Contains("DateTime"))
                    pp.PropName1 = "DateTime";
                else
                {
                    pp.PropName1 = strPropType;
                }

                pList.Add(pp);
            }
            StringBuilder sbFields = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            int iCount = 1;
            foreach (Props p in pList)
            {
                if (p.Show && iCount < pList.Count)
                    sbFields.Append("[" + p.Name + "],");
                else if (p.Show)
                    sbFields.Append("[" + p.Name + "]");

                if (p.Show)
                {
                    if (p.PropName1.Contains("Nullable"))
                    {
                        if (p.PropName2.Contains("Boolean"))
                        {
                            if (!p.Value.Contains("null"))
                            {
                                bool bVal = false;
                                Boolean.TryParse(p.Value, out bVal);
                                sbValue.Append(Convert.ToInt32(bVal).ToString() + ",");
                            }
                            else
                                sbValue.Append(p.Value + ",");
                        }
                        else if (p.PropName2.Contains("Int32"))
                            sbValue.Append(p.Value + ",");
                        else if (p.PropName2.Contains("Decimal"))
                            sbValue.Append(p.Value + ",");
                        else if (p.PropName2.Contains("String"))
                            sbValue.Append("N'" + p.Value + "',");
                        else if (p.PropName2.Contains("DateTime"))
                        {
                            if (!p.Value.Contains("null"))
                                sbValue.Append("CAST(N'" + p.Value + "' AS DateTime),");
                            else
                                sbValue.Append(p.Value + ",");
                        }
                        else
                            sbValue.Append(p.Value + ",");
                    }
                    else
                    {
                        if (p.PropName1.Contains("Boolean"))
                        {
                            bool bVal = false;
                            Boolean.TryParse(p.Value, out bVal);
                            sbValue.Append(Convert.ToInt32(bVal).ToString() + ",");
                        }
                        else if (p.PropName1.Contains("DateTime"))
                            sbValue.Append("CAST(N'" + p.Value + "' AS DateTime),");
                        else if (p.PropName1.Contains("String"))
                            sbValue.Append("N'" + p.Value + "',");
                        else
                            sbValue.Append(p.Value + ",");
                    }
                }
                iCount++;
            }
            string newValues = sbValue.ToString().Remove(sbValue.Length - 1, 1);
            string strFullSql = @"INSERT [dbo].[tblDiscoveryRequest] (" + sbFields.ToString() + ") VALUES (" + newValues + ")";
            return strFullSql;
        }
        private string GetStringToInsertIntoDb2(DiscoveryReqUpdates insert)
        {
            string sql = @"INSERT[dbo].[tblDiscoveryRequest]([isNewRequest],[SalesRepName],[SalesRepEmail],[idOnboardingPhase],[District],[CustomerName],[Address],[City],[State],[Zipcode],[Country],[Commodity],[ProjectedRevenue],[CurrentSolution],[ProposedCustoms],[CallDate1],[CallDate2],[CallDate3],[UpdatedBy],[UpdatedOn],[CreatedBy],[CreatedOn],[ActiveFlag],[SalesComments],[idITBA],[idShippingChannel],[TargetGoLive],[ActualGoLive],[SolutionSummary],[CustomerWebsite],[Branch],[idVendor],[worldpakFlag],[thirdpartyFlag],[customFlag],[InvoiceType],[BilltoAccount],[FTPUsername],[FTPPassword],[CustomsSupportedFlag],[ElinkFlag],[PARS],[PASS],[CustomsBroker],[SupportUser],[SupportGroup],[Office],[Group],[MigrationDate],[PreMigrationSolution],[PostMigrationSolution],[ControlBranch],[ContractNumber],[ContractStartDate],[ContractEndDate],[ContractCurrency],[PaymentTerms],[CloseReason],[CRR],[BrokerNumber],[DataScrubFlag],[EDICustomizedFlag],[StrategicFlag],[ReturnsAcctNbr],[ReturnsAddress],[ReturnsCity],[ReturnsState],[ReturnsZip],[ReturnsCountry],[ReturnsDestroyFlag],[ReturnsCreateLabelFlag],[WPKSandboxUsername],[WPKSandboxPwd],[WPKProdUsername],[WPKProdPwd],[WPKCustomExportFlag],[WPKGhostScanFlag],[WPKEastWestSplitFlag],[WPKAddressUploadFlag],[WPKProductUploadFlag],[WPKDataEntryMethod],[WPKEquipmentFlag],[EWSelectBy],[EWSortCodeFlag],[EWEastSortCode],[EWWestSortCode],[EWSepCloseoutFlag],[EWSepPUFlag],[EWSortDetails],[EWMissortDetails],[CurrentGoLive],[PhaseChangeDate],[idRequestType],[CurrentlyShippingFlag],[idShippingVendor],[OtherVendorName],[idBroker],[OtherBrokerName],[idVendorType],[Route],[idSolutionType],[FreightAuditor],[EDIDetails],[idEDISpecialist],[idBillingSpecialist],[idCollectionSpecialist],[AuditorPortal],[AuditorURL],[AuditorUserName],[AuditorPassword],[EDITargetGoLive],[EDICurrentGoLive],[EDIActualGoLive],[idEDIOnboardingPhase])" +
                " VALUES(1," +
                " N'" + insert.GetUserFirstLastSpace() + "', N'" + insert.GetUserFirstLastPeriod() + "@purolator.com'," +
                " 5, N'EASTERN', N'Both Test 5', N'Address Both Test 5', N'BAY SHORE', N'NY', N'11706', N'US', N'Cheese', 1929.2900, N'A', N'TBD', null, null, null, N'Scott.Cardinale'," +
                insert.GetDate1() +
                ", N'" + insert.GetUserFirstLastPeriod() + "'," +
                insert.GetDate1() + "," +
                " 1, N'', 7, 5, null, null, N'Customer is shipping courier out of florida.', N'www.cheese.com', N'EWR', null, 0, 0, 0, N'', N'', N'', N'', 1, 0, N' ', N'  ', N' ', N'', N'', N'', N'', null, N'', N'', N'', N'', null, null, N'', N'', N'null', N'', N'', 0, 0, 0, N'', N'', N'', N'', N'', N'', 0, 0, N'', N'', N'', N'', 0, 0, 0, 0, 0, N'', 0, N'', 0, N'', N'', 0, 0, N'', N'', CAST(N'2021-04-15T00:00:00.000' AS DateTime), CAST(N'2021-03-29T15:11:42.843' AS DateTime)," +
                insert.idRequestType.ToString() +
                ", 1, null, N'', null, N'', 3, N'Via EWR', 3, 1, N'Just anoth', 1, 2, 2, 1, N'url 1', N'user name 1', N'Password 1', CAST(N'2021-03-01T00:00:00.000' AS DateTime), CAST(N'2021-03-26T00:00:00.000' AS DateTime), CAST(N'2021-03-25T00:00:00.000' AS DateTime), 1)";

            return sql;
        }

        private void cmbBoxWebTesterSelectedTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tabName = (string)((ComboBox)sender).SelectedItem;
            int indexOfTab = (int)GetTheTab.Get(tabName);
            RadTabItem theTab = new RadTabItem();
            foreach (RadTabItem t in radTabPuroFusion.Items)
            {
                string s = t.Header.ToString();
                if (tabName.Contains(t.Header.ToString()))
                {
                    theTab = t;
                    break;
                }
            }
            ComboBoxItem TabState = (ComboBoxItem)cmbBoxWebTesterState.SelectedItem;
            switch (TabState.Content.ToString())
            {
                case "Select":
                    radTabPuroFusion.SelectedIndex = indexOfTab;
                    break;
                case "Enable":
                    theTab.IsEnabled = true;
                    break;
                case "Disable":
                    theTab.IsEnabled = false;
                    break;
                case "Hidden":
                    theTab.Visibility = Visibility.Hidden;
                    break;
                case "Visible":
                    theTab.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void cmbBoxWebTesterCustomerInfoSolutionType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem tabName = (ComboBoxItem)((ComboBox)sender).SelectedItem;
            string strtabName = tabName.Content.ToString();
            ComboBoxItem UserType = (ComboBoxItem)cmbddBoxWebTesterUser.SelectedItem;
            if (strtabName.Contains("Shipping"))
                SetTabsForShippingTest1();
            else if (strtabName.Contains("EDI"))
                SetTabsForEDITest1();

            foreach (Tabs t in tabShippingTest1)
            {
                RadTabItem theTab = new RadTabItem();
                foreach (RadTabItem r in radTabPuroFusion.Items)
                {
                    string s = r.Header.ToString();
                    if (t.Name == r.Header.ToString())
                    {
                        theTab = r;
                        int indexOfTab = (int)GetTheTab.Get(t.Name);
                        if (t.Selected)
                        {
                            radTabPuroFusion.SelectedIndex = indexOfTab;
                            theTab.Visibility = Visibility.Visible;
                        }
                        else if (!t.Visible)
                        {
                            theTab.Visibility = Visibility.Hidden;
                        }
                        else if (t.Enabled)
                        {
                            theTab.IsEnabled = true;
                            theTab.Visibility = Visibility.Visible;
                        }
                        else if (!t.Enabled)
                        {
                            if (t.Visible)
                                theTab.Visibility = Visibility.Visible;
                            theTab.IsEnabled = false;
                        }
                        break;
                    }
                }
                int er2 = 0;
                er2++;
            }
            IList<string> q = tabShippingTest1.Select(f => f.Name).ToList();
        }

        private void txtBxWebTesterCustomerInfo1_KeyUp(object sender, KeyEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBxWebTesterCustomerInfo1.Text))
            {
                lblWebTesterWarningMsg.Visibility = Visibility.Hidden;
            }
            else
            {
                lblWebTesterWarningMsg.Visibility = Visibility.Visible;
            }
        }
        // Add a new contact from Contact Info Tab
        private void txtBxWebTesterContactInfo1_KeyUp(object sender, KeyEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBxWebTesterContactInfo1.Text))
            {
                // contactGrid_ItemCommand
                btnNextTab2.Visibility = Visibility.Visible;
                btnNextTab2.IsEnabled = true;
            }
            else
            {
                //  contactGrid_DeleteCommand
                btnNextTab2.Visibility = Visibility.Visible;
                btnNextTab2.IsEnabled = false;
            }
        }
        private void txtBxWebTesterCurrentSolution1_KeyUp(object sender, KeyEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtareaCurrentSolution.Text))
            {
                lblWebTesterWarningMsg.Visibility = Visibility.Hidden;
            }
            else
            {
                lblWebTesterWarningMsg.Visibility = Visibility.Visible;
            }
        }
        private void btnNextTab1_Click(object sender, RoutedEventArgs e)
        {
            ContactInfo.IsEnabled = true;
            ContactInfo.IsSelected = true;
            ContactInfo.Visibility = Visibility.Visible;
            btnNextTab1.Visibility = Visibility.Hidden;

            if (String.IsNullOrEmpty(txtBxWebTesterContactInfo1.Text))
                btnNextTab2.Visibility = Visibility.Hidden;
        }

        private void btnNextTab2_Click(object sender, RoutedEventArgs e)
        {
            //ComboBoxItem SolutionTypeItem = (ComboBoxItem)rddlSolutionType.SelectedItem;
            //string strSolutionTypeItem = SolutionTypeItem.Content.ToString();
            if (String.IsNullOrEmpty(txtareaCurrentSolution.Text))
            {
                CurrentSolution.IsEnabled = true;
                CurrentSolution.IsSelected = true;
                CurrentSolution.Visibility = Visibility.Visible;
                btnNextTab2.Visibility = Visibility.Hidden;
            }
            else if (rddlSolutionType.SelectedIndex == 1)
            {

            }
            else if (rddlSolutionType.SelectedIndex == 0)
            {
                ShippingServices.IsEnabled = true;
                ShippingServices.IsSelected = true;
                ShippingServices.Visibility = Visibility.Visible;
            }

        }
        private void btnNextTab3_Click(object sender, RoutedEventArgs e)
        {
            if (rddlSolutionType.SelectedIndex == 1)
            {
                EDIServices.IsEnabled = true;
                EDIServices.IsSelected = true;
                EDIServices.Visibility = Visibility.Visible;
                btnSubmit.Visibility = Visibility.Visible;
                btnNextTab3.Visibility = Visibility.Hidden;
            }
            else if (rddlSolutionType.SelectedIndex == 0)
            {
                ShippingServices.IsEnabled = true;
                ShippingServices.IsSelected = true;
                ShippingServices.Visibility = Visibility.Visible;
                btnSubmit.Visibility = Visibility.Visible;
            }
        }
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtBxWebTesterShippingServices.Text) ||
                String.IsNullOrEmpty(txtareaCurrentSolution.Text) ||
                String.IsNullOrEmpty(txtBxWebTesterContactInfo1.Text) ||
                String.IsNullOrEmpty(txtBxWebTesterCustomerInfo1.Text))
            {
                StringBuilder sb = new StringBuilder();

                if (String.IsNullOrEmpty(txtBxWebTesterCustomerInfo1.Text))
                    sb.Append("Customer Info missing, ");
                if (String.IsNullOrEmpty(txtBxWebTesterContactInfo1.Text))
                    sb.Append("Contact Info missing, ");
                if (String.IsNullOrEmpty(txtareaCurrentSolution.Text))
                    sb.Append("Current Solution missing, ");
                if (String.IsNullOrEmpty(txtBxWebTesterShippingServices.Text))
                    sb.Append("Shipping Services missing, ");

                lblWebTesterWarningMsg.Content = sb.ToString();
                lblWebTesterWarningMsg.Visibility = Visibility.Visible;
            }
            else
            {
                lblWebTesterWarningMsg.Visibility = Visibility.Hidden;
                if (MessageBox.Show("Successful", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    // Close the window  
                    int er = 0;
                    er++;
                }
                else
                {
                    // Do not close the window  
                    int er = 0;
                    er++;
                }
            }
        }
        private void btnWebTesterResetTest_Click(object sender, RoutedEventArgs e)
        {
            ReSetTabs();
            foreach (Tabs t in tabShippingTest1)
            {
                RadTabItem theTab = new RadTabItem();
                foreach (RadTabItem r in radTabPuroFusion.Items)
                {
                    string s = r.Header.ToString();
                    if (t.Name == r.Header.ToString())
                    {
                        theTab = r;
                        int indexOfTab = (int)GetTheTab.Get(t.Name);
                        if (t.Selected)
                        {
                            radTabPuroFusion.SelectedIndex = indexOfTab;
                            theTab.Visibility = Visibility.Visible;
                        }
                        else if (!t.Visible)
                        {
                            theTab.Visibility = Visibility.Hidden;
                        }
                        else if (t.Enabled)
                        {
                            theTab.IsEnabled = true;
                            theTab.Visibility = Visibility.Visible;
                        }
                        else if (!t.Enabled)
                        {
                            if (t.Visible)
                                theTab.Visibility = Visibility.Visible;
                            theTab.IsEnabled = false;
                        }
                        break;
                    }
                }
            }
            btnNextTab1.IsEnabled = true;
            btnNextTab1.Visibility = Visibility.Visible;
            txtBxWebTesterCustomerInfo1.Text = "";
            txtBxWebTesterContactInfo1.Text = "";
            txtareaCurrentSolution.Text = "";
            txtBxWebTesterShippingServices.Text = "";
        }
        public void ReSetTabs()
        {
            Tabs qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.CustomerInfo).FirstOrDefault();
            qtab.Visible = true;
            qtab.Enabled = true;
            qtab.Selected = true;
            qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.ContactInfo).FirstOrDefault();
            qtab.Visible = true;
            qtab.Enabled = true;
            qtab.Selected = false;
            qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.CurrentSolution).FirstOrDefault();
            qtab.Visible = true;
            qtab.Enabled = true;
            qtab.Selected = false;
            qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.ShippingServices).FirstOrDefault();
            qtab.Visible = true;
            qtab.Enabled = true;
            qtab.Selected = false;
            qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.EDIServices).FirstOrDefault();
            qtab.Visible = true;
            qtab.Enabled = true;
            qtab.Selected = false;
            qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.Profile).FirstOrDefault();
            qtab.Visible = true;
            qtab.Enabled = true;
            qtab.Selected = false;
            qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.CourierEDI).FirstOrDefault();
            qtab.Visible = true;
            qtab.Enabled = true;
            qtab.Selected = false;
            qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.NonCourierEDI).FirstOrDefault();
            qtab.Visible = true;
            qtab.Enabled = true;
            qtab.Selected = false;
            qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.AddlNotes).FirstOrDefault();
            qtab.Visible = true;
            qtab.Enabled = true;
            qtab.Selected = false;
            qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.FileUploads).FirstOrDefault();
            qtab.Visible = true;
            qtab.Enabled = true;
            qtab.Selected = false;
        }

        public void SetTabsForShippingTest1()
        {
            Tabs qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.CustomerInfo).FirstOrDefault();
            qtab.Visible = true;
            qtab.Enabled = true;
            qtab.Selected = true;
            qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.ContactInfo).FirstOrDefault();
            qtab.Visible = true;
            qtab.Enabled = false;
            qtab.Selected = false;
            qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.CurrentSolution).FirstOrDefault();
            qtab.Visible = true;
            qtab.Enabled = false;
            qtab.Selected = false;
            qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.ShippingServices).FirstOrDefault();
            qtab.Visible = true;
            qtab.Enabled = false;
            qtab.Selected = false;
            qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.EDIServices).FirstOrDefault();
            qtab.Visible = false;
            qtab.Enabled = false;
            qtab.Selected = false;
            qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.Profile).FirstOrDefault();
            qtab.Visible = false;
            qtab.Enabled = false;
            qtab.Selected = false;
            qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.CourierEDI).FirstOrDefault();
            qtab.Visible = false;
            qtab.Enabled = false;
            qtab.Selected = false;
            qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.NonCourierEDI).FirstOrDefault();
            qtab.Visible = false;
            qtab.Enabled = false;
            qtab.Selected = false;
            qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.AddlNotes).FirstOrDefault();
            qtab.Visible = false;
            qtab.Enabled = false;
            qtab.Selected = false;
            qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.FileUploads).FirstOrDefault();
            qtab.Visible = false;
            qtab.Enabled = false;
            qtab.Selected = false;
        }
        public void SetTabsForEDITest1()
        {
            Tabs qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.CustomerInfo).FirstOrDefault();
            qtab.Visible = true;
            qtab.Enabled = true;
            qtab.Selected = true;
            qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.ContactInfo).FirstOrDefault();
            qtab.Visible = true;
            qtab.Enabled = false;
            qtab.Selected = false;
            qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.CurrentSolution).FirstOrDefault();
            qtab.Visible = true;
            qtab.Enabled = false;
            qtab.Selected = false;
            qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.ShippingServices).FirstOrDefault();
            qtab.Visible = false;
            qtab.Enabled = false;
            qtab.Selected = false;
            qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.EDIServices).FirstOrDefault();
            qtab.Visible = true;
            qtab.Enabled = false;
            qtab.Selected = false;
            qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.Profile).FirstOrDefault();
            qtab.Visible = false;
            qtab.Enabled = false;
            qtab.Selected = false;
            qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.CourierEDI).FirstOrDefault();
            qtab.Visible = false;
            qtab.Enabled = false;
            qtab.Selected = false;
            qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.NonCourierEDI).FirstOrDefault();
            qtab.Visible = false;
            qtab.Enabled = false;
            qtab.Selected = false;
            qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.AddlNotes).FirstOrDefault();
            qtab.Visible = false;
            qtab.Enabled = false;
            qtab.Selected = false;
            qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.FileUploads).FirstOrDefault();
            qtab.Visible = false;
            qtab.Enabled = false;
            qtab.Selected = false;
        }
        //private void AddTreeViewItems()
        //{
        //    RadTreeViewItem TestCategory = new RadTreeViewItem();
        //    TestCategory.Header = "Sales Shipping Tests";
        //    TestCategory.IsExpanded = true;
        //    TestCategory.Foreground = new SolidColorBrush(Colors.Green);
        //    TestCategory.CheckState = System.Windows.Automation.ToggleState.On;
        //    radTreeView.Items.Add(TestCategory);

        //    // Adding child items 
        //    RadTreeViewItem product = new RadTreeViewItem();
        //    product.Header = "Test 1";
        //    TestCategory.Items.Add(product);
        //    // Added
        //    RadTreeViewItem product111 = new RadTreeViewItem();
        //    product111.Header = "Step 1.0";
        //    product.Items.Add(product111);
        //    product111 = new RadTreeViewItem();
        //    product111.Header = "Step 1.1";
        //    product.Items.Add(product111);
        //    // from web page
        //    product = new RadTreeViewItem();
        //    product.Header = "Test 2";
        //    TestCategory.Items.Add(product);
        //    // Added
        //    product111 = new RadTreeViewItem();
        //    product111.Header = "Step 2.0";
        //    product.Items.Add(product111);
        //    product111 = new RadTreeViewItem();
        //    product111.Header = "Step 2.1";
        //    product.Items.Add(product111);

        //    TestCategory = new RadTreeViewItem();
        //    TestCategory.Header = "Sales EDI Tests";
        //    TestCategory.IsExpanded = true;
        //    TestCategory.Foreground = new SolidColorBrush(Colors.Purple);
        //    radTreeView.Items.Add(TestCategory);

        //    // Adding child items 
        //    product = new RadTreeViewItem();
        //    product.Header = "Test 1";
        //    TestCategory.Items.Add(product);
        //    product111 = new RadTreeViewItem();
        //    product111.Header = "Step 1.0";
        //    product.Items.Add(product111);
        //    product = new RadTreeViewItem();
        //    product.Header = "Test 2";
        //    TestCategory.Items.Add(product);
        //    product111 = new RadTreeViewItem();
        //    product111.Header = "Step 2.0";
        //    product.Items.Add(product111);
        //    product111 = new RadTreeViewItem();
        //    product111.Header = "Step 2.1";
        //    product.Items.Add(product111);
        //    product111 = new RadTreeViewItem();
        //    product111.Header = "Step 2.2";
        //    product.Items.Add(product111);
        //}
        //private void AddTreeViewItems2(IList<TestParams> ToTest)
        //{
        //    RadTreeViewItem TestCategory = new RadTreeViewItem();
        //    TestCategory.Header = ToTest[0].strCategoryName;
        //    TestCategory.IsExpanded = true;
        //    TestCategory.Foreground = new SolidColorBrush(Colors.Green);
        //    TestCategory.CheckState = System.Windows.Automation.ToggleState.On;
        //    radTreeView2.Items.Add(TestCategory);

        //    // Adding child items 
        //    RadTreeViewItem product = new RadTreeViewItem();
        //    product.Header = ToTest[0].Name;
        //    TestCategory.Items.Add(product);
        //    // Added
        //    int iIndex = 0;
        //    double dStep = ToTest[iIndex].Step;
        //    for (int i=0;i< ToTest[0].iTotalSteps;i++)
        //    {
        //        RadTreeViewItem StepItem = new RadTreeViewItem();
        //        StepItem.Header = ToTest[iIndex].GetCurrentStep(dStep);
        //        product.Items.Add(StepItem);
        //        dStep += 0.1;
        //    }
        //    iIndex++;
        //    dStep = ToTest[iIndex].Step;
        //    product = new RadTreeViewItem();
        //    product.Header = ToTest[iIndex].Name;
        //    TestCategory.Items.Add(product);
        //    for (int i = 0; i < ToTest[iIndex].iTotalSteps; i++)
        //    {
        //        RadTreeViewItem StepItem = new RadTreeViewItem();
        //        StepItem.Header = ToTest[iIndex].GetCurrentStep(dStep);
        //        product.Items.Add(StepItem);
        //        dStep += 0.1;
        //    }

        //    iIndex++;
        //    dStep = ToTest[iIndex].Step;
        //    product = new RadTreeViewItem();
        //    product.Header = ToTest[iIndex].Name;
        //    TestCategory.Items.Add(product);
        //    for (int i = 0; i < ToTest[iIndex].iTotalSteps; i++)
        //    {
        //        RadTreeViewItem StepItem = new RadTreeViewItem();
        //        StepItem.Header = ToTest[iIndex].GetCurrentStep(dStep);
        //        product.Items.Add(StepItem);
        //        dStep += 0.1;
        //    }
        //    iIndex++;
        //    dStep = ToTest[iIndex].Step;
        //    product = new RadTreeViewItem();
        //    product.Header = ToTest[iIndex].Name;
        //    TestCategory.Items.Add(product);
        //    for (int i = 0; i < ToTest[iIndex].iTotalSteps; i++)
        //    {
        //        RadTreeViewItem StepItem = new RadTreeViewItem();
        //        StepItem.Header = ToTest[iIndex].GetCurrentStep(dStep);
        //        product.Items.Add(StepItem);
        //        dStep += 0.1;
        //    }
        //    iIndex++;
        //    dStep = ToTest[iIndex].Step;
        //    product = new RadTreeViewItem();
        //    product.Header = ToTest[iIndex].Name;
        //    TestCategory.Items.Add(product);
        //    for (int i = 0; i < ToTest[iIndex].iTotalSteps; i++)
        //    {
        //        RadTreeViewItem StepItem = new RadTreeViewItem();
        //        StepItem.Header = ToTest[iIndex].GetCurrentStep(dStep);
        //        product.Items.Add(StepItem);
        //        dStep += 0.1;
        //    }
        //    iIndex++;
        //    dStep = ToTest[iIndex].Step;
        //    product = new RadTreeViewItem();
        //    product.Header = ToTest[iIndex].Name;
        //    TestCategory.Items.Add(product);
        //    for (int i = 0; i < ToTest[iIndex].iTotalSteps; i++)
        //    {
        //        RadTreeViewItem StepItem = new RadTreeViewItem();
        //        StepItem.Header = ToTest[iIndex].GetCurrentStep(dStep);
        //        product.Items.Add(StepItem);
        //        dStep += 0.1;
        //    }

        //    iIndex++; 
        //    TestCategory = new RadTreeViewItem();
        //    TestCategory.Header = ToTest[iIndex].strCategoryName;
        //    TestCategory.IsExpanded = true;
        //    TestCategory.Foreground = new SolidColorBrush(Colors.Blue);
        //    TestCategory.CheckState = System.Windows.Automation.ToggleState.On;
        //    radTreeView2.Items.Add(TestCategory);
        //    dStep = ToTest[iIndex].Step;
        //    product = new RadTreeViewItem();
        //    product.Header = ToTest[iIndex].Name;
        //    TestCategory.Items.Add(product);
        //    for (int i = 0; i < ToTest[iIndex].iTotalSteps; i++)
        //    {
        //        RadTreeViewItem StepItem = new RadTreeViewItem();
        //        StepItem.Header = ToTest[iIndex].GetCurrentStep(dStep);
        //        product.Items.Add(StepItem);
        //        dStep += 0.1;
        //    }
        //    iIndex++;
        //    dStep = ToTest[iIndex].Step;
        //    product = new RadTreeViewItem();
        //    product.Header = ToTest[iIndex].Name;
        //    TestCategory.Items.Add(product);
        //    for (int i = 0; i < ToTest[iIndex].iTotalSteps; i++)
        //    {
        //        RadTreeViewItem StepItem = new RadTreeViewItem();
        //        StepItem.Header = ToTest[iIndex].GetCurrentStep(dStep);
        //        product.Items.Add(StepItem);
        //        dStep += 0.1;
        //    }
        //    iIndex++;
        //    dStep = ToTest[iIndex].Step;
        //    product = new RadTreeViewItem();
        //    product.Header = ToTest[iIndex].Name;
        //    TestCategory.Items.Add(product);
        //    for (int i = 0; i < ToTest[iIndex].iTotalSteps; i++)
        //    {
        //        RadTreeViewItem StepItem = new RadTreeViewItem();
        //        StepItem.Header = ToTest[iIndex].GetCurrentStep(dStep);
        //        product.Items.Add(StepItem);
        //        dStep += 0.1;
        //    }
        //    iIndex++;
        //    dStep = ToTest[iIndex].Step;
        //    product = new RadTreeViewItem();
        //    product.Header = ToTest[iIndex].Name;
        //    TestCategory.Items.Add(product);
        //    for (int i = 0; i < ToTest[iIndex].iTotalSteps; i++)
        //    {
        //        RadTreeViewItem StepItem = new RadTreeViewItem();
        //        StepItem.Header = ToTest[iIndex].GetCurrentStep(dStep);
        //        product.Items.Add(StepItem);
        //        dStep += 0.1;
        //    }
        //    iIndex++;
        //    dStep = ToTest[iIndex].Step;
        //    product = new RadTreeViewItem();
        //    product.Header = ToTest[iIndex].Name;
        //    TestCategory.Items.Add(product);
        //    for (int i = 0; i < ToTest[iIndex].iTotalSteps; i++)
        //    {
        //        RadTreeViewItem StepItem = new RadTreeViewItem();
        //        StepItem.Header = ToTest[iIndex].GetCurrentStep(dStep);
        //        product.Items.Add(StepItem);
        //        dStep += 0.1;
        //    }
        //    iIndex++;
        //    dStep = ToTest[iIndex].Step;
        //    product = new RadTreeViewItem();
        //    product.Header = ToTest[iIndex].Name;
        //    TestCategory.Items.Add(product);
        //    for (int i = 0; i < ToTest[iIndex].iTotalSteps; i++)
        //    {
        //        RadTreeViewItem StepItem = new RadTreeViewItem();
        //        StepItem.Header = ToTest[iIndex].GetCurrentStep(dStep);
        //        product.Items.Add(StepItem);
        //        dStep += 0.1;
        //    }
        //    iIndex++;
        //    dStep = ToTest[iIndex].Step;
        //    product = new RadTreeViewItem();
        //    product.Header = ToTest[iIndex].Name;
        //    TestCategory.Items.Add(product);
        //    for (int i = 0; i < ToTest[iIndex].iTotalSteps; i++)
        //    {
        //        RadTreeViewItem StepItem = new RadTreeViewItem();
        //        StepItem.Header = ToTest[iIndex].GetCurrentStep(dStep);
        //        product.Items.Add(StepItem);
        //        dStep += 0.1;
        //    }
        //    iIndex++;
        //    TestCategory = new RadTreeViewItem();
        //    TestCategory.Header = ToTest[iIndex].strCategoryName;
        //    TestCategory.IsExpanded = true;
        //    TestCategory.Foreground = new SolidColorBrush(Colors.Red);
        //    TestCategory.CheckState = System.Windows.Automation.ToggleState.On;
        //    radTreeView2.Items.Add(TestCategory);
        //    dStep = ToTest[iIndex].Step;
        //    product = new RadTreeViewItem();
        //    product.Header = ToTest[iIndex].Name;
        //    TestCategory.Items.Add(product);
        //    for (int i = 0; i < ToTest[iIndex].iTotalSteps; i++)
        //    {
        //        RadTreeViewItem StepItem = new RadTreeViewItem();
        //        StepItem.Header = ToTest[iIndex].GetCurrentStep(dStep);
        //        product.Items.Add(StepItem);
        //        dStep += 0.1;
        //    }
        //    iIndex++;
        //    dStep = ToTest[iIndex].Step;
        //    product = new RadTreeViewItem();
        //    product.Header = ToTest[iIndex].Name;
        //    TestCategory.Items.Add(product);
        //    for (int i = 0; i < ToTest[iIndex].iTotalSteps; i++)
        //    {
        //        RadTreeViewItem StepItem = new RadTreeViewItem();
        //        StepItem.Header = ToTest[iIndex].GetCurrentStep(dStep);
        //        product.Items.Add(StepItem);
        //        dStep += 0.1;
        //    }
        //    iIndex++;
        //    dStep = ToTest[iIndex].Step;
        //    product = new RadTreeViewItem();
        //    product.Header = ToTest[iIndex].Name;
        //    TestCategory.Items.Add(product);
        //    for (int i = 0; i < ToTest[iIndex].iTotalSteps; i++)
        //    {
        //        RadTreeViewItem StepItem = new RadTreeViewItem();
        //        StepItem.Header = ToTest[iIndex].GetCurrentStep(dStep);
        //        product.Items.Add(StepItem);
        //        dStep += 0.1;
        //    }
        //    iIndex++;
        //    dStep = ToTest[iIndex].Step;
        //    product = new RadTreeViewItem();
        //    product.Header = ToTest[iIndex].Name;
        //    TestCategory.Items.Add(product);
        //    for (int i = 0; i < ToTest[iIndex].iTotalSteps; i++)
        //    {
        //        RadTreeViewItem StepItem = new RadTreeViewItem();
        //        StepItem.Header = ToTest[iIndex].GetCurrentStep(dStep);
        //        product.Items.Add(StepItem);
        //        dStep += 0.1;
        //    }
        //    iIndex++;
        //    dStep = ToTest[iIndex].Step;
        //    product = new RadTreeViewItem();
        //    product.Header = ToTest[iIndex].Name;
        //    TestCategory.Items.Add(product);
        //    for (int i = 0; i < ToTest[iIndex].iTotalSteps; i++)
        //    {
        //        RadTreeViewItem StepItem = new RadTreeViewItem();
        //        StepItem.Header = ToTest[iIndex].GetCurrentStep(dStep);
        //        product.Items.Add(StepItem);
        //        dStep += 0.1;
        //    }
        //    iIndex++;
        //    dStep = ToTest[iIndex].Step;
        //    product = new RadTreeViewItem();
        //    product.Header = ToTest[iIndex].Name;
        //    TestCategory.Items.Add(product);
        //    for (int i = 0; i < ToTest[iIndex].iTotalSteps; i++)
        //    {
        //        RadTreeViewItem StepItem = new RadTreeViewItem();
        //        StepItem.Header = ToTest[iIndex].GetCurrentStep(dStep);
        //        product.Items.Add(StepItem);
        //        dStep += 0.1;
        //    }
        //    iIndex++;
        //    dStep = ToTest[iIndex].Step;
        //    product = new RadTreeViewItem();
        //    product.Header = ToTest[iIndex].Name;
        //    TestCategory.Items.Add(product);
        //    for (int i = 0; i < ToTest[iIndex].iTotalSteps; i++)
        //    {
        //        RadTreeViewItem StepItem = new RadTreeViewItem();
        //        StepItem.Header = ToTest[iIndex].GetCurrentStep(dStep);
        //        product.Items.Add(StepItem);
        //        dStep += 0.1;
        //    }
        //}
        //private void AddTreeViewItems3(IList<TestParams> ToTest)
        //{
        //    RadTreeView radTreeView = radTreeView3;
        //    RadTreeViewItem TestCategory;
        //    int iIndex = 0;
        //    double dStep = 0;

        //    TestCategory = new RadTreeViewItem();
        //    TestCategory.Header = ToTest[0].strCategoryName;
        //    TestCategory.IsExpanded = true;
        //    TestCategory.Foreground = new SolidColorBrush(Colors.Green);
        //    TestCategory.CheckState = System.Windows.Automation.ToggleState.On;
        //    radTreeView.Items.Add(TestCategory);

        //    RadTreeViewItem product = new RadTreeViewItem();
        //    product.Header = ToTest[0].Name;
        //    TestCategory.Items.Add(product);
        //    dStep = ToTest[iIndex].Step;
        //    for (int i = 0; i < ToTest[0].iTotalSteps; i++)
        //    {
        //        RadTreeViewItem StepItem = new RadTreeViewItem();
        //        StepItem.Header = ToTest[iIndex].GetCurrentStep(dStep);
        //        product.Items.Add(StepItem);
        //        dStep += 0.1;
        //    }
        //    for (int j = 0; j < 5; j++)
        //    {
        //        iIndex = CreateIndivTests(ToTest, TestCategory, iIndex, out dStep, out product);
        //    }

        //    iIndex++;
        //    TestCategory = new RadTreeViewItem();
        //    TestCategory.Header = ToTest[iIndex].strCategoryName;
        //    TestCategory.IsExpanded = true;
        //    TestCategory.Foreground = new SolidColorBrush(Colors.Blue);
        //    TestCategory.CheckState = System.Windows.Automation.ToggleState.On;
        //    radTreeView.Items.Add(TestCategory);
        //    dStep = ToTest[iIndex].Step;
        //    product = new RadTreeViewItem();
        //    product.Header = ToTest[iIndex].Name;
        //    TestCategory.Items.Add(product);
        //    for (int i = 0; i < ToTest[iIndex].iTotalSteps; i++)
        //    {
        //        RadTreeViewItem StepItem = new RadTreeViewItem();
        //        StepItem.Header = ToTest[iIndex].GetCurrentStep(dStep);
        //        product.Items.Add(StepItem);
        //        dStep += 0.1;
        //    }
        //    for (int j = 0; j < 6; j++)
        //    {
        //        iIndex = CreateIndivTests(ToTest, TestCategory, iIndex, out dStep, out product);
        //    }
            
        //    iIndex++;
        //    TestCategory = new RadTreeViewItem();
        //    TestCategory.Header = ToTest[iIndex].strCategoryName;
        //    TestCategory.IsExpanded = true;
        //    TestCategory.Foreground = new SolidColorBrush(Colors.Red);
        //    TestCategory.CheckState = System.Windows.Automation.ToggleState.On;
        //    radTreeView.Items.Add(TestCategory);
        //    dStep = ToTest[iIndex].Step;
        //    product = new RadTreeViewItem();
        //    product.Header = ToTest[iIndex].Name;
        //    TestCategory.Items.Add(product);
        //    for (int i = 0; i < ToTest[iIndex].iTotalSteps; i++)
        //    {
        //        RadTreeViewItem StepItem = new RadTreeViewItem();
        //        StepItem.Header = ToTest[iIndex].GetCurrentStep(dStep);
        //        product.Items.Add(StepItem);
        //        dStep += 0.1;
        //    }
        //    for (int j = 0; j < 6; j++)
        //    {
        //        iIndex = CreateIndivTests(ToTest, TestCategory, iIndex, out dStep, out product);
        //    }
        //}
        //private void AddTreeViewItems4(IList<TestParams> ToTest)
        //{
        //    RadTreeView radTreeView = radTreeView3;
        //    RadTreeViewItem TestCategory;
        //    RadTreeViewItem SpecificTest;
        //    int iIndex = -1;
        //    double dStep = 0;

        //    iIndex++; 
        //    TestCategory = new RadTreeViewItem();
        //    TestCategory.Header = ToTest[iIndex].strCategoryName;
        //    TestCategory.IsExpanded = true;
        //    TestCategory.Foreground = new SolidColorBrush(Colors.Green);
        //    TestCategory.CheckState = System.Windows.Automation.ToggleState.On;
        //    radTreeView.Items.Add(TestCategory);

        //    dStep = ToTest[iIndex].Step;
        //    SpecificTest = new RadTreeViewItem();
        //    SpecificTest.Header = ToTest[0].Name;
        //    TestCategory.Items.Add(SpecificTest);
        //    for (int i = 0; i < ToTest[0].iTotalSteps; i++)
        //    {
        //        RadTreeViewItem StepItem = new RadTreeViewItem();
        //        StepItem.Header = ToTest[iIndex].GetCurrentStep(dStep);
        //        SpecificTest.Items.Add(StepItem);
        //        dStep += 0.1;
        //    }
        //    var qCatSteps = ToTest.Where(f => f.strCategoryName == StringEnum.GetStringValue(AllTestCategory.SalesShippingTests)).ToList();
        //    int iCatSteps = qCatSteps.Count-1;
        //    for (int j = 0; j < iCatSteps; j++)
        //    {
        //        iIndex = CreateIndivTests(ToTest, TestCategory, iIndex, out dStep, out SpecificTest);
        //    }

        //    iIndex++;
        //    TestCategory = new RadTreeViewItem();
        //    TestCategory.Header = ToTest[iIndex].strCategoryName;
        //    TestCategory.IsExpanded = true;
        //    TestCategory.Foreground = new SolidColorBrush(Colors.Blue);
        //    TestCategory.CheckState = System.Windows.Automation.ToggleState.On;
        //    radTreeView.Items.Add(TestCategory);

        //    dStep = ToTest[iIndex].Step;
        //    SpecificTest = new RadTreeViewItem();
        //    SpecificTest.Header = ToTest[iIndex].Name;
        //    TestCategory.Items.Add(SpecificTest);
        //    for (int i = 0; i < ToTest[iIndex].iTotalSteps; i++)
        //    {
        //        RadTreeViewItem StepItem = new RadTreeViewItem();
        //        StepItem.Header = ToTest[iIndex].GetCurrentStep(dStep);
        //        SpecificTest.Items.Add(StepItem);
        //        dStep += 0.1;
        //    }
        //    qCatSteps = ToTest.Where(f => f.strCategoryName == StringEnum.GetStringValue(AllTestCategory.SalesEDITests)).ToList();
        //    iCatSteps = qCatSteps.Count - 1;
        //    for (int j = 0; j < iCatSteps; j++)
        //    {
        //        iIndex = CreateIndivTests(ToTest, TestCategory, iIndex, out dStep, out SpecificTest);
        //    }

        //    iIndex++;
        //    TestCategory = new RadTreeViewItem();
        //    TestCategory.Header = ToTest[iIndex].strCategoryName;
        //    TestCategory.IsExpanded = true;
        //    TestCategory.Foreground = new SolidColorBrush(Colors.Red);
        //    TestCategory.CheckState = System.Windows.Automation.ToggleState.On;
        //    radTreeView.Items.Add(TestCategory);
        //    dStep = ToTest[iIndex].Step;
        //    SpecificTest = new RadTreeViewItem();
        //    SpecificTest.Header = ToTest[iIndex].Name;
        //    TestCategory.Items.Add(SpecificTest);
        //    for (int i = 0; i < ToTest[iIndex].iTotalSteps; i++)
        //    {
        //        RadTreeViewItem StepItem = new RadTreeViewItem();
        //        StepItem.Header = ToTest[iIndex].GetCurrentStep(dStep);
        //        SpecificTest.Items.Add(StepItem);
        //        dStep += 0.1;
        //    }
        //    qCatSteps = ToTest.Where(f => f.strCategoryName == StringEnum.GetStringValue(AllTestCategory.SalesBothTests)).ToList();
        //    iCatSteps = qCatSteps.Count - 1;
        //    for (int j = 0; j < iCatSteps; j++)
        //    {
        //        iIndex = CreateIndivTests(ToTest, TestCategory, iIndex, out dStep, out SpecificTest);
        //    }
        //}
        private void AddTreeViewItems5(IList<TestParams> ToTest)
        {
            RadTreeView radTreeView = radTreeView3;
            int iIndex = -1;

            iIndex = CreateEntireCategory2(ToTest, radTreeView, iIndex, AllTestCategory.SalesShippingTests, Colors.Green);
            iIndex = CreateEntireCategory2(ToTest, radTreeView, iIndex, AllTestCategory.SalesEDITests, Colors.Blue);
            iIndex = CreateEntireCategory2(ToTest, radTreeView, iIndex, AllTestCategory.SalesBothTests, Colors.Red);
        }

        //private static int CreateEntireCategory(IList<TestParams> ToTest, RadTreeView radTreeView, out RadTreeViewItem TestCategory, out RadTreeViewItem SpecificTest, int iIndex, out double dStep, out List<TestParams> qCatSteps, AllTestCategory TestCat)
        //{
        //    iIndex++;
        //    TestCategory = new RadTreeViewItem();
        //    TestCategory.Header = ToTest[iIndex].strCategoryName;
        //    TestCategory.IsExpanded = true;
        //    TestCategory.Foreground = new SolidColorBrush(Colors.Green);
        //    TestCategory.CheckState = System.Windows.Automation.ToggleState.On;
        //    radTreeView.Items.Add(TestCategory);

        //    dStep = ToTest[iIndex].Step;
        //    SpecificTest = new RadTreeViewItem();
        //    SpecificTest.Header = ToTest[iIndex].Name;
        //    TestCategory.Items.Add(SpecificTest);
        //    for (int i = 0; i < ToTest[iIndex].iTotalSteps; i++)
        //    {
        //        RadTreeViewItem StepItem = new RadTreeViewItem();
        //        StepItem.Header = ToTest[iIndex].GetCurrentStep(dStep);
        //        SpecificTest.Items.Add(StepItem);
        //        dStep += 0.1;
        //    }
        //    qCatSteps = ToTest.Where(f => f.strCategoryName == StringEnum.GetStringValue(TestCat)).ToList();
        //    int iCatSteps = qCatSteps.Count - 1;
        //    for (int j = 0; j < iCatSteps; j++)
        //    {
        //        iIndex = CreateIndivTests(ToTest, TestCategory, iIndex, out dStep, out SpecificTest);
        //    }

        //    return iIndex;
        //}
        private static int CreateEntireCategory2(IList<TestParams> ToTest, RadTreeView radTreeView, int iIndex, AllTestCategory TestCat, Color c)
        {
            iIndex++;
            RadTreeViewItem TestCategory = new RadTreeViewItem();
            TestCategory.Header = ToTest[iIndex].strCategoryName;
            //TestCategory.IsExpanded = true;
            TestCategory.Foreground = new SolidColorBrush(c);
            //TestCategory.CheckState = System.Windows.Automation.ToggleState.Off;
            radTreeView.Items.Add(TestCategory);

            double dStep = ToTest[iIndex].Step;
            RadTreeViewItem SpecificTest = new RadTreeViewItem();
            SpecificTest.Header = ToTest[iIndex].Name;
            TestCategory.Items.Add(SpecificTest);
            for (int i = 0; i < ToTest[iIndex].iTotalSteps; i++)
            {
                RadTreeViewItem StepItem = new RadTreeViewItem();
                StepItem.Header = ToTest[iIndex].GetCurrentStep(dStep);
                StepItem.DefaultImageSrc = CODEBREAK_ICON;
                SpecificTest.Items.Add(StepItem);
                dStep += 0.1;
            }
            List<TestParams> qCatSteps = ToTest.Where(f => f.strCategoryName == StringEnum.GetStringValue(TestCat)).ToList();
            int iCatSteps = qCatSteps.Count - 1;
            for (int j = 0; j < iCatSteps; j++)
            {
                iIndex = CreateIndivTests(ToTest, TestCategory, iIndex, out dStep, out SpecificTest);
            }

            return iIndex;
        }
        private static int CreateIndivTests(IList<TestParams> ToTest, RadTreeViewItem TestCategory, int iIndex, out double dStep, out RadTreeViewItem SpecificTest)
        {
            iIndex++;
            dStep = ToTest[iIndex].Step;
            SpecificTest = new RadTreeViewItem();
            SpecificTest.Header = ToTest[iIndex].Name;
            TestCategory.Items.Add(SpecificTest);
            for (int i = 0; i < ToTest[iIndex].iTotalSteps; i++)
            {
                RadTreeViewItem StepItem = new RadTreeViewItem();
                StepItem.Header = ToTest[iIndex].GetCurrentStep(dStep);
                StepItem.DefaultImageSrc = CODEBREAK_ICON;
                SpecificTest.Items.Add(StepItem);
                dStep += 0.1;
            }

            return iIndex;
        }

        private void radTreeView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get a reference to the treeview 
            RadTreeView treeView = sender as RadTreeView;
            // Get the currently selected items 
            ObservableCollection<Object> selectedItems = treeView.SelectedItems;
            RadTreeViewItem item = selectedItems[0] as RadTreeViewItem;
            // Get the previous item and the previous sibling item 
            RadTreeViewItem previousItem = item.PreviousItem;
            RadTreeViewItem previousSiblingItem = item.PreviousSiblingItem;

            // Get the next item and the next sibling item 
            RadTreeViewItem nextItem = item.NextItem;
            RadTreeViewItem nextSiblingItem = item.NextSiblingItem;

            // Get the parent item and the root item 
            RadTreeViewItem parentItem = item.ParentItem;
            RadTreeViewItem rootItem = item.RootItem;
            int er = 0;
            er++;
        }

        private void radTreeView_Checked(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            RadTreeViewItem item = e.Source as RadTreeViewItem;
            if ( item.Header.ToString() == StringEnum.GetStringValue(AllTestCategory.SalesShippingTests))
            {
                var allTreeContainers = GetAllItemContainers(radTreeView3).Where(f => f.Header.ToString().Contains(StringEnum.GetStringValue(AllTestCategory.SalesShippingTests))).ToList();
                foreach (RadTreeViewItem i in allTreeContainers[0].Items)
                {
                    //string str = i.Header.ToString();
                    i.CheckState = System.Windows.Automation.ToggleState.On;
                    i.DefaultImageSrc = CODEBREAK_ICON;
                }
            }
            else if(item.Header.ToString() == StringEnum.GetStringValue(AllTestCategory.SalesEDITests))
            {
                var allTreeContainers = GetAllItemContainers(radTreeView3).Where(f => f.Header.ToString().Contains(StringEnum.GetStringValue(AllTestCategory.SalesEDITests))).ToList();
                foreach (RadTreeViewItem i in allTreeContainers[0].Items)
                {
                    i.CheckState = System.Windows.Automation.ToggleState.On;
                    i.DefaultImageSrc = OK_ICON;
                }
            }
            else if (item.Header.ToString() == StringEnum.GetStringValue(AllTestCategory.SalesBothTests))
            {
                var allTreeContainers = GetAllItemContainers(radTreeView3).Where(f => f.Header.ToString().Contains(StringEnum.GetStringValue(AllTestCategory.SalesBothTests))).ToList();
                foreach (RadTreeViewItem i in allTreeContainers[0].Items)
                {
                    i.CheckState = System.Windows.Automation.ToggleState.On;
                    i.DefaultImageSrc = DELETE_ICON;
                }
            }
        }
        private Collection<RadTreeViewItem> GetAllItemContainers(System.Windows.Controls.ItemsControl itemsControl)
        {
            Collection<RadTreeViewItem> allItems = new Collection<RadTreeViewItem>();
            for (int i = 0; i < itemsControl.Items.Count; i++)
            {
                // try to get the item Container   
                RadTreeViewItem childItemContainer = itemsControl.ItemContainerGenerator.ContainerFromIndex(i) as RadTreeViewItem;
                // the item container maybe null if it is still not generated from the runtime   
                if (childItemContainer != null)
                {
                    allItems.Add(childItemContainer);
                    Collection<RadTreeViewItem> childItems = GetAllItemContainers(childItemContainer);
                    foreach (RadTreeViewItem childItem in childItems)
                    {
                        allItems.Add(childItem);
                    }
                }
            }
            return allItems;
        }
        private void radTreeView_Unchecked(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            RadTreeViewItem item = e.Source as RadTreeViewItem;
            if (item.Header.ToString() == StringEnum.GetStringValue(AllTestCategory.SalesShippingTests))
            {
                var allTreeContainers = GetAllItemContainers(radTreeView3).Where(f => f.Header.ToString().Contains(StringEnum.GetStringValue(AllTestCategory.SalesShippingTests))).ToList();
                foreach (RadTreeViewItem i in allTreeContainers[0].Items)
                {
                    //string str = i.Header.ToString();
                    i.CheckState = System.Windows.Automation.ToggleState.Off;
                }
            }
            else if (item.Header.ToString() == StringEnum.GetStringValue(AllTestCategory.SalesEDITests))
            {
                var allTreeContainers = GetAllItemContainers(radTreeView3).Where(f => f.Header.ToString().Contains(StringEnum.GetStringValue(AllTestCategory.SalesEDITests))).ToList();
                foreach (RadTreeViewItem i in allTreeContainers[0].Items)
                {
                    i.CheckState = System.Windows.Automation.ToggleState.Off;
                }
            }
            else if (item.Header.ToString() == StringEnum.GetStringValue(AllTestCategory.SalesBothTests))
            {
                var allTreeContainers = GetAllItemContainers(radTreeView3).Where(f => f.Header.ToString().Contains(StringEnum.GetStringValue(AllTestCategory.SalesBothTests))).ToList();
                foreach (RadTreeViewItem i in allTreeContainers[0].Items)
                {
                    i.CheckState = System.Windows.Automation.ToggleState.Off;
                }
            }
        }

        private void btnWebTesterRunTreeSim_Click(object sender, RoutedEventArgs e)
        {
            var allTreeContainers = GetAllItemContainers(radTreeView3);
            //int er = 0;
            foreach(TestParams t in ToTest2)
            {
                //var q;
                switch (t.Category)
                {
                    case AllTestCategory.SalesShippingTests:
                        var q = allTreeContainers.Where(f => f.Header.ToString().Contains(StringEnum.GetStringValue(AllTestCategory.SalesShippingTests))).ToList();
                        foreach (RadTreeViewItem node in q[0].Items)
                        {
                            //string str = node.Header.ToString();
                            foreach (RadTreeViewItem step in node.Items)
                            {
                                step.DefaultImageSrc = OK_ICON;
                            }
                            //node.DefaultImageSrc = OK_ICON;
                        }
                        break;
                    case AllTestCategory.SalesEDITests:
                        var q2 = allTreeContainers.Where(f => f.Header.ToString().Contains(StringEnum.GetStringValue(AllTestCategory.SalesEDITests))).ToList();
                        foreach (RadTreeViewItem node in q2[0].Items)
                        {
                            //string str = node.Header.ToString();
                            foreach (RadTreeViewItem step in node.Items)
                            {
                                step.DefaultImageSrc = OK_ICON;
                            }
                            //node.DefaultImageSrc = OK_ICON;
                        }
                        break;
                    case AllTestCategory.SalesBothTests:
                        var q3 = allTreeContainers.Where(f => f.Header.ToString().Contains(StringEnum.GetStringValue(AllTestCategory.SalesBothTests))).ToList();
                        foreach (RadTreeViewItem node in q3[0].Items)
                        {
                            //string str = node.Header.ToString();
                            foreach (RadTreeViewItem step in node.Items)
                            {
                                step.DefaultImageSrc = OK_ICON;
                            }
                            //node.DefaultImageSrc = OK_ICON;
                        }
                        break;
                }
            }
        }
        public void SetSteps(string strIconLocation)
        {
            bool bNextTest = false;
            var allTreeContainers = GetAllItemContainers(radTreeView3);
            var q = allTreeContainers.Where(f => f.Header.ToString().Contains(StringEnum.GetStringValue(curStep.Category))).ToList();

            foreach (RadTreeViewItem node in q[0].Items)
            {
                if (node.Header.ToString().Contains(StringEnum.GetStringValue(curStep.Test)))
                {
                    foreach (RadTreeViewItem step in node.Items)
                    {
                        if (curStep.strCurStep.Contains(step.Header.ToString()))
                        {
                            step.DefaultImageSrc = strIconLocation;
                            curStep.dCurStep += 0.1;
                            curStep.strCurStep = String.Format("Step {0:0.0#}", curStep.dCurStep);
                            curStep.iCurStep++;
                            if (curStep.iCurStep >= curStep.iTotalSteps)
                            {
                                AllTest NextTest = curStep.Test.Next();
                                curStep = new Step(ToTest2[(int)NextTest], ToTest2[(int)NextTest].Step);
                                bNextTest = true;
                            }
                            break;
                        }

                    }
                }
                if (bNextTest)
                    break;
            }
            return;
        }
        private void btnWebTesterTreeNext_Click(object sender, RoutedEventArgs e)
        {
            SetSteps(OK_ICON);
        }
        private void timerForTime_Tick(object sender, EventArgs e)
        {
            if (bTimeTimer == true)
            {
                ShowMessageDelegate del = new ShowMessageDelegate(ShowMessage);
                this.radTreeView3.Dispatcher.BeginInvoke(DispatcherPriority.Normal, del, 0, "test");
                Step curStep2 = curStep;
                int er = 0;
                er++;
            }
        }

        private void btnWebTesterTreeClear_Click(object sender, RoutedEventArgs e)
        {
            curStep = new Step(ToTest2[0], 1);
            string strIcon = OK_ICON;
            ComboBoxItem comboBoxItem = (ComboBoxItem)cmbBoxWebTesterIcon.SelectedItem;
            switch(comboBoxItem.Content.ToString() )
            {
                case "OK":
                    strIcon = OK_ICON;
                    break;
                case "Stop":
                    strIcon = CODEBREAK_ICON;
                    break;
                case "Delete":
                    strIcon = DELETE_ICON;
                    break;
            }
            foreach (TestParams t in ToTest2)
            {
                for (int i = 0; i < t.iTotalSteps; i++)
                {
                    SetSteps(strIcon);
                }
            }
        }
        public void ShowMessage(int iFunct, string strIn)
        {
            if (0 == iFunct)
                SetSteps(OK_ICON); 
            //if (strIn.Contains("xx001"))
            //    strIn = strIn.Substring(5, strIn.Length - 5);
        }

        private void btnWebTesterTreeTimer_Click(object sender, RoutedEventArgs e)
        {
            bTimeTimer = true;
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(timerForTime_Tick);
            TimeSpan.FromMilliseconds(250);
            //dispatcherTimer.Interval = new TimeSpan(0, 0, 0,250);
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(100); 
            dispatcherTimer.Start();
        }
    }
    public class Tabs
    {
        public static int iCount { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }
        public bool Enabled { get; set; }
        public bool Visible { get; set; }
        public int iOrdinalValue { get; set; }
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
            Visible = true;
            iOrdinalValue = (int)val;
        }
        public Tabs(AllTabs val, int iOrd)
        {
            localTab = val;
            Name = StringEnum.GetStringValue(val);
            Selected = false;
            Enabled = false;
            iOrdinalValue = iOrd;
        }
    }
    public class TestParams
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public double Step { get; set; }
        public int iTotalSteps { get; set; }
        public AllTest Tests { get; set; }
        public AllTestCategory Category { get; set; }
        public string strCategoryName { get; set; }
        public TestParams(AllTest test, int itotalsteps)
        {
            Tests = test;
            Name = StringEnum.GetStringValue(test);
            iTotalSteps = itotalsteps;
            //GetCategoryFromTest get = new GetCategoryFromTest(test);
            //strCategoryName = get.ToString();
            switch (test)
            {
                case AllTest.SalesShippingTest1:
                case AllTest.SalesShippingTest2:
                case AllTest.SalesShippingTest3:
                case AllTest.SalesShippingTest4:
                case AllTest.SalesShippingTest5:
                case AllTest.SalesShippingTest7:
                    Category = AllTestCategory.SalesShippingTests;
                    strCategoryName = StringEnum.GetStringValue(Category);
                    break;
                case AllTest.SalesEDITest1:
                case AllTest.SalesEDITest2:
                case AllTest.SalesEDITest3:
                case AllTest.SalesEDITest4:
                case AllTest.SalesEDITest5:
                case AllTest.SalesEDITest6:
                case AllTest.SalesEDITest7:
                    Category = AllTestCategory.SalesEDITests;
                    strCategoryName = StringEnum.GetStringValue(Category);
                    break;
                case AllTest.SalesBothTest1:
                case AllTest.SalesBothTest2:
                case AllTest.SalesBothTest3:
                case AllTest.SalesBothTest4:
                case AllTest.SalesBothTest5:
                case AllTest.SalesBothTest6:
                case AllTest.SalesBothTest7:
                    Category = AllTestCategory.SalesBothTests;
                    strCategoryName = StringEnum.GetStringValue(Category);
                    break;
            }
        }
        public string GetCurrentStep()
        {
            return String.Format("Step {0:0.0#}", Step);
        }
        public string GetCurrentStep(double step)
        {
            return String.Format("Step {0:0.0#}", step);
        }
    }
    //public class GetCategoryFromTest
    //{
    //    public AllTest Tests { get; set; }
    //    public AllTestCategory Category { get; set; }
    //    public string strCategoryName { get; set; }
    //    public GetCategoryFromTest(AllTest test)
    //    {
    //        this.Tests = test;
    //    }
    //    public override string ToString()
    //    {
    //        switch (Tests)
    //        {
    //            case AllTest.SalesShippingTest1:
    //            case AllTest.SalesShippingTest2:
    //            case AllTest.SalesShippingTest3:
    //            case AllTest.SalesShippingTest4:
    //            case AllTest.SalesShippingTest5:
    //            case AllTest.SalesShippingTest7:
    //                Category = AllTestCategory.SalesShippingTests;
    //                strCategoryName = StringEnum.GetStringValue(Category);
    //                break;
    //            case AllTest.SalesEDITest1:
    //            case AllTest.SalesEDITest2:
    //            case AllTest.SalesEDITest3:
    //            case AllTest.SalesEDITest4:
    //            case AllTest.SalesEDITest5:
    //            case AllTest.SalesEDITest6:
    //            case AllTest.SalesEDITest7:
    //                Category = AllTestCategory.SalesEDITests;
    //                strCategoryName = StringEnum.GetStringValue(Category);
    //                break;
    //            case AllTest.SalesBothTest1:
    //            case AllTest.SalesBothTest2:
    //            case AllTest.SalesBothTest3:
    //            case AllTest.SalesBothTest4:
    //            case AllTest.SalesBothTest5:
    //            case AllTest.SalesBothTest6:
    //            case AllTest.SalesBothTest7:
    //                Category = AllTestCategory.SalesBothTests;
    //                strCategoryName = StringEnum.GetStringValue(Category);
    //                break;
    //        }
    //        return strCategoryName;
    //    }
    //}
    public class Step
    {
        public double dCurStep { get; set; }
        public double iCurStep { get; set; }
        public string strCurStep { get; set; }
        public int iTotalSteps { get; set; }
        public bool Enabled { get; set; }
        public string Name { get; set; }
        public AllTest Test { get; set; }
        public AllTestCategory Category { get; set; }

        public Step(TestParams param, double dStep)
        {
            this.Test = param.Tests;
            this.Name = param.Name;
            this.Category = param.Category;
            this.iTotalSteps = param.iTotalSteps;
            this.Enabled = param.Enabled;
            this.dCurStep = dStep;
            this.strCurStep = String.Format("Step {0:0.0#}", dStep);
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
    #region Enumerations
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
    public enum AllTestCategory
    {
        [StringValue("Sales Shipping")]
        SalesShippingTests = 0,
        
        [StringValue("Sales EDI")]
        SalesEDITests = 1,
       
        [StringValue("Sales Both")]
        SalesBothTests = 2
    }
    public static class GetTheCategory
    {
        public static AllTestCategory Get(string strTab)
        {
            AllTestCategory retCategory = AllTestCategory.SalesShippingTests;

            if (strTab == StringEnum.GetStringValue(AllTestCategory.SalesShippingTests))
                retCategory = AllTestCategory.SalesShippingTests;
            else if (strTab == StringEnum.GetStringValue(AllTestCategory.SalesEDITests))
                retCategory = AllTestCategory.SalesEDITests;
            else if (strTab == StringEnum.GetStringValue(AllTestCategory.SalesBothTests))
                retCategory = AllTestCategory.SalesBothTests;
            return retCategory;
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
    // https://stackoverflow.com/questions/5175629/how-to-style-grid-columndefinitions-in-wpf
    public class GridHelpers
    {
        #region RowCount Property

        /// <summary>
        /// Adds the specified number of Rows to RowDefinitions. 
        /// Default Height is Auto
        /// </summary>
        public static readonly DependencyProperty RowCountProperty =
            DependencyProperty.RegisterAttached("RowCount", typeof(int), typeof(GridHelpers), new PropertyMetadata(-1, RowCountChanged));

        // Get
        public static int GetRowCount(DependencyObject obj)
        {
            return (int)obj.GetValue(RowCountProperty);
        }

        // Set
        public static void SetRowCount(DependencyObject obj, int value)
        {
            obj.SetValue(RowCountProperty, value);
        }

        // Change Event - Adds the Rows
        public static void RowCountChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (!(obj is Grid) || (int)e.NewValue < 0)
                return;

            Grid grid = (Grid)obj;
            grid.RowDefinitions.Clear();

            for (int i = 0; i < (int)e.NewValue; i++)
                grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

            SetStarRows(grid);
        }

        #endregion

        #region ColumnCount Property

        /// <summary>
        /// Adds the specified number of Columns to ColumnDefinitions. 
        /// Default Width is Auto
        /// </summary>
        public static readonly DependencyProperty ColumnCountProperty =
            DependencyProperty.RegisterAttached("ColumnCount", typeof(int), typeof(GridHelpers), new PropertyMetadata(-1, ColumnCountChanged));

        // Get
        public static int GetColumnCount(DependencyObject obj)
        {
            return (int)obj.GetValue(ColumnCountProperty);
        }

        // Set
        public static void SetColumnCount(DependencyObject obj, int value)
        {
            obj.SetValue(ColumnCountProperty, value);
        }

        // Change Event - Add the Columns
        public static void ColumnCountChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (!(obj is Grid) || (int)e.NewValue < 0)
                return;

            Grid grid = (Grid)obj;
            grid.ColumnDefinitions.Clear();

            for (int i = 0; i < (int)e.NewValue; i++)
                //grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100) });
            SetStarColumns(grid);
        }

        #endregion

        #region StarRows Property

        /// <summary>
        /// Makes the specified Row's Height equal to Star. 
        /// Can set on multiple Rows
        /// </summary>
        public static readonly DependencyProperty StarRowsProperty =
            DependencyProperty.RegisterAttached(
                "StarRows", typeof(string), typeof(GridHelpers),
                new PropertyMetadata(string.Empty, StarRowsChanged));

        // Get
        public static string GetStarRows(DependencyObject obj)
        {
            return (string)obj.GetValue(StarRowsProperty);
        }

        // Set
        public static void SetStarRows(DependencyObject obj, string value)
        {
            obj.SetValue(StarRowsProperty, value);
        }

        // Change Event - Makes specified Row's Height equal to Star
        public static void StarRowsChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (!(obj is Grid) || string.IsNullOrEmpty(e.NewValue.ToString()))
                return;

            SetStarRows((Grid)obj);
        }

        #endregion

        #region StarColumns Property

        /// <summary>
        /// Makes the specified Column's Width equal to Star. 
        /// Can set on multiple Columns
        /// </summary>
        public static readonly DependencyProperty StarColumnsProperty =
            DependencyProperty.RegisterAttached("StarColumns", typeof(string), typeof(GridHelpers), new PropertyMetadata(string.Empty, StarColumnsChanged));

        // Get
        public static string GetStarColumns(DependencyObject obj)
        {
            return (string)obj.GetValue(StarColumnsProperty);
        }

        // Set
        public static void SetStarColumns(DependencyObject obj, string value)
        {
            obj.SetValue(StarColumnsProperty, value);
        }

        // Change Event - Makes specified Column's Width equal to Star
        public static void StarColumnsChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (!(obj is Grid) || string.IsNullOrEmpty(e.NewValue.ToString()))
                return;

            SetStarColumns((Grid)obj);
        }

        #endregion

        private static void SetStarColumnsN(Grid grid)
        {
            string[] starColumns = GetStarColumns(grid).Split(',');

            for (int i = 0; i < grid.ColumnDefinitions.Count; i++)
            {
                grid.ColumnDefinitions[i].Width = new GridLength(double.Parse(starColumns[i]));
            }
        }
        private static void SetStarColumns(Grid grid)
        {
            string[] starColumns = GetStarColumns(grid).Split(',');

            for (int i = 0; i < grid.ColumnDefinitions.Count; i++)
            {
                if (starColumns.Contains(i.ToString()))
                {
                    grid.ColumnDefinitions[i].Width = new GridLength(double.Parse(starColumns[i * 2 + 1]));
                }
                //grid.ColumnDefinitions[i].Width = new GridLength(1, GridUnitType.Star);
            }
        }
        private static void SetStarRows(Grid grid)
        {
            string[] starRows = GetStarRows(grid).Split(',');

            for (int i = 0; i < grid.RowDefinitions.Count; i++)
            {
                if (starRows.Contains(i.ToString()))
                    grid.RowDefinitions[i].Height = new GridLength(1, GridUnitType.Star);
            }
        }
    }
    public class WaitCursor : IDisposable
    {
        private Cursor _previousCursor;

        public WaitCursor()
        {
            _previousCursor = Mouse.OverrideCursor;

            Mouse.OverrideCursor = Cursors.Wait;
        }

        public void Dispose()
        {
            Mouse.OverrideCursor = _previousCursor;
        }
    }

}

