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
            //PuroTouchServiceClass o = new PuroTouchServiceClass(PuroTouchServiceClass.ConnString.PatientLocal);
            //o.GetDiscoveryDiff1("tblDiscoveryRequest_", "tblDiscoveryRequest");

            //string strConn = GetdbLocation(comboBoxMainDB);
            //PuroReportingServiceClass o2 = new PuroReportingServiceClass(PuroReportingServiceClass.ConnString.FullPatientLocal);
            //o2.TestConn();
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
                        IList<dtoTableCompare> qTableCompare = o.GetDiscoveryDiff1("tblDiscoveryRequest","tblDiscoveryRequest_");
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
                        IList<dtotblDiscoveryRequest> qDiscoveryRequest = o.GettblDiscoveryRequestDesc();
                        ObservableCollection<dtotblDiscoveryRequest> ocWmsGroup = new ObservableCollection<dtotblDiscoveryRequest>();
                        grid.ItemsSource = ocWmsGroup.Concat<dtotblDiscoveryRequest>(qDiscoveryRequest);
                        lbl.Content = strReportItem + " count: " + qDiscoveryRequest.Count();

                        mainGridData.SolutionType = CollectionViewSource.GetDefaultView(o.GetSolutionTypes());
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
                    comboBoxTestingSolutionType.SelectedIndex = rec.idSolutionType.Value-1;
                    txtBxTestingCustomerName.Text = rec.CustomerName;
                    txtBxTestingAddress1.Text = rec.Address;
                    numTextingRevenue.Text = rec.ProjectedRevenue.Value.ToString("c4");
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
                    rec.Address = txtBxTestingAddress1.Text;
                    rec.idSolutionType = SolutionType.idSolutionType;
                    rec.ProjectedRevenue = System.Convert.ToDecimal(numTextingRevenue.Value);
                    rec.idRequest = 0;
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
    }

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

