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
        public MainWindow()
        {
            InitializeComponent();
            mainGridData = new GridData1();

            Tabs qtab = tabShippingTest1.Where(f => f.iOrdinalValue == (int)AllTabs.EDIServices).FirstOrDefault();
            qtab.Visible = true;

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
            //int j= radTabPuroFusion.Items.Count;
            //var q = radTabPuroFusion.Items;
            //CustomerInfo.IsEnabled = true;
            //IList<string> q2 = tabShippingTest1.Select(f => f.Name).ToList();
            int er = 0;
            er++;
            //DiscoveryReqUpdates insert = new DiscoveryReqUpdates(){ FirstName = "Pinky", LastName = "Jones", idRequestType = 2, dt1 = DateTime.Now };
            //string sql = GetStringToInsertIntoDb2(insert);
            //int er = 0;
            //er++;
            //string sql = @"INSERT[dbo].[tblDiscoveryRequest]( [isNewRequest], [SalesRepName], [SalesRepEmail], [idOnboardingPhase], [District], [CustomerName], [Address], [City], [State], [Zipcode], [Country], [Commodity], [ProjectedRevenue], [CurrentSolution], [ProposedCustoms], [CallDate1], [CallDate2], [CallDate3], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag], [SalesComments], [idITBA], [idShippingChannel], [TargetGoLive], [ActualGoLive], [SolutionSummary], [CustomerWebsite], [Branch], [idVendor], [worldpakFlag], [thirdpartyFlag], [customFlag], [InvoiceType], [BilltoAccount], [FTPUsername], [FTPPassword], [CustomsSupportedFlag], [ElinkFlag], [PARS], [PASS], [CustomsBroker], [SupportUser], [SupportGroup], [Office], [Group], [MigrationDate], [PreMigrationSolution], [PostMigrationSolution], [ControlBranch], [ContractNumber], [ContractStartDate], [ContractEndDate], [ContractCurrency], [PaymentTerms], [CloseReason], [CRR], [BrokerNumber], [DataScrubFlag], [EDICustomizedFlag], [StrategicFlag], [ReturnsAcctNbr], [ReturnsAddress], [ReturnsCity], [ReturnsState], [ReturnsZip], [ReturnsCountry], [ReturnsDestroyFlag], [ReturnsCreateLabelFlag], [WPKSandboxUsername], [WPKSandboxPwd], [WPKProdUsername], [WPKProdPwd], [WPKCustomExportFlag], [WPKGhostScanFlag], [WPKEastWestSplitFlag], [WPKAddressUploadFlag], [WPKProductUploadFlag], [WPKDataEntryMethod], [WPKEquipmentFlag], [EWSelectBy], [EWSortCodeFlag], [EWEastSortCode], [EWWestSortCode], [EWSepCloseoutFlag], [EWSepPUFlag], [EWSortDetails], [EWMissortDetails], [CurrentGoLive], [PhaseChangeDate], [idRequestType], [CurrentlyShippingFlag], [idShippingVendor], [OtherVendorName], [idBroker], [OtherBrokerName], [idVendorType], [Route], [idSolutionType], [FreightAuditor], [EDIDetails], [idEDISpecialist], [idBillingSpecialist], [idCollectionSpecialist], [AuditorPortal], [AuditorURL], [AuditorUserName], [AuditorPassword], [EDITargetGoLive], [EDICurrentGoLive], [EDIActualGoLive], [idEDIOnboardingPhase]) " +
            //                "VALUES(1, N'Joe Murphy', N'Joe.Murphy@purolator.com', 8, N'EASTERN', N'Both Test 2', N'Both Address 2', N'BAY SHORE', N'NY', N'12 street', N'United States', N'Cheese', 9999.2200, N'sadgfagv', N'PARS & PASS', NULL, NULL, NULL, N'scott.cardinale', CAST(N'2021-06-04T15:15:28.137' AS DateTime), N'scott.cardinale', CAST(N'2021-06-04T15:15:28.137' AS DateTime), 1, N'aswdefw', NULL, NULL, NULL, NULL, N'', N'', N'BUF', NULL, 0, 0, 0, N'', N'', N'', N'', 1, 0, N'                         ', N'                         ', N'                                                                                                                                                                                                                                                               ', N'', N'', N'', N'', NULL, N'', N'', N'', N'', NULL, NULL, N'', N'', NULL, N'', N'', 0, 0, 1, N'', N'', N'', N'', N'', N'', 0, 0, N'', N'', N'', N'', 0, 0, 0, 0, 0, N'', 0, N'', 0, N'', N'', 0, 0, N'', N'', NULL, CAST(N'2021-04-23T15:04:57.723' AS DateTime), 3, 1, NULL, N'', 4, N'', NULL, N'', 3, 1, N'', NULL, NULL, NULL, 0, N'', N'', N'', NULL, NULL, NULL, 0)";

            //o.strConn = PuroTouchServiceClass.ConnString.PatientLocal;
            //PuroTouchServiceClass o = new PuroTouchServiceClass(PuroTouchServiceClass.ConnString.PatientLocal);
            //o.InsertTestDiscoveryRequestRecord(strFullSql);

            //string strConn = GetdbLocation(comboBoxMainDB);
            //PuroReportingServiceClass o2 = new PuroReportingServiceClass(PuroReportingServiceClass.ConnString.FullPatientLocal);
            //o2.TestConn();
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

