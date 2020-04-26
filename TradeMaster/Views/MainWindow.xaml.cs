using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TradeMaster.IO.Tables;
using TradeMaster.Views.UserControls;
using TradeMaster.Models;
using TradeMaster.Models.Interfaces;
using TradeMaster.ViewModels;

namespace TradeMaster.Views {

    public partial class MainWindow : Window, IMainWindow {
        private List<TableDetails> TableButtons = null;
        private UIElement ActivePanel;
        private DataGridTable DataGridTablePanel;
        private SettingsPanel SettingsPanel;

        public MainWindow() {
            InitializeComponent();
            //          PopulateData();
            Init();
            AddTableButtons();
        }

        private void Init() {
            (DataContext as MainWindowViewModel).View = this;
            TableButtons = new List<TableDetails>();

            DataGridTablePanel = new DataGridTable();
            SettingsPanel = new SettingsPanel() { Visibility = Visibility.Collapsed };
            ActivePanel = DataGridTablePanel;
            DPBasePanel.Children.Add(DataGridTablePanel);
        }

        public DataGrid GetTable() {
            return DataGridTablePanel.FindName("Table") as DataGrid;
        }

        public string GetSearchText() {
            return ((((FindName("UCTitleBar") as UserControl).Content as StackPanel).Children[0] as StackPanel).Children[0] as TextBox).Text;
        }

        public Grid GetSideWindowPanel() {
            return (FindName("UCSideWindowPanel") as UserControl).Content as Grid;
        }

        private void PopulateData() {
            /*        DataGridTextColumn Id = new DataGridTextColumn();
                    DataGridTextColumn Name = new DataGridTextColumn();
                    DataGridTextColumn Phone = new DataGridTextColumn();
                    DataGridTextColumn Address = new DataGridTextColumn();


                    Id.Header = "Id";
                    Id.Binding = new Binding("Id");
                    Name.Header = "Name";
                    Name.Binding = new Binding("Name");
                    Phone.Header = "Phone";
                    Phone.Binding = new Binding("Phone");
                    Address.Header = "Address";
                    Address.Binding = new Binding("Address");

                    table.Columns.Add(Id);
                    table.Columns.Add(Name);
                    table.Columns.Add(Phone);
                    table.Columns.Add(Address);

                    table.Items.Add(new Student(1001, "sdffas adfsf", "8787798", "8dfsf87fsf 5454"));
                    table.Items.Add(new Student(1002, "erdffas adert", "324134", "345 dfdsf fdsfa"));
                    table.Items.Add(new Student(1003, "cvx vxcv", "676765", "78 gdfgrt tretw"));
                    table.Items.Add(new Student(1004, "hghh hf", "90908987", "324 dfsdf dffa"));
                    table.Items.Add(new Student(1005, "ytrytb yrty", "65756767", "76 dfsdf fdsf"));
                    table.Items.Add(new Student(1006, "nbmnbm bmb", "14234434", "134 fdfss sffs"));
                    */

            /*
                                 ObservableCollection<Student> items = new ObservableCollection<Student>() {
                        new Student("1", "sdf dfds", "3454423353", "sdf dfsda adfsd dfdsfss"),
                        new Student("6", "ghfd wsdfsd", "3454423353", "sdf dfsda adfsd dfdsfss"),
                        new Student("7", "xcvxcv esdfd", "4423454357", "sdfsd dfsdfssdfda erwadfsd"),
                        new Student("8", "cxvzx resadf", "4323414346", "erwerq ghd rtew ssda adfsd"),
                         new Student("6", "ghfd wsdfsd", "3454423353", "sdf dfsda adfsd dfdsfss"),
                        new Student("7", "xcvxcv esdfd", "4423454357", "sdfsd dfsdfssdfda erwadfsd"),
                        new Student("8", "cxvzx resadf", "4323414346", "erwerq ghd rtew ssda adfsd"),
                        new Student("6", "ghfd wsdfsd", "3454423353", "sdf dfsda adfsd dfdsfss"),
                        new Student("7", "xcvxcv esdfd", "4423454357", "sdfsd dfsdfssdfda erwadfsd"),
                        new Student("8", "cxvzx resadf", "4323414346", "erwerq ghd rtew ssda adfsd"),
                        new Student("2", "dsfd ads", "4423454357", "sdfsd dfsdfssdfda erwadfsd"),
                        new Student("3", "sdf fsas", "4323414346", "erwerq ghd rtew ssda adfsd"),
                        new Student("4", "sdf gsddf", "3234254334", "vzxvxcvb gsdfds da adfsd"),
                        new Student("5", "sdf qsdfds", "2343454323", "hjjhgj dffsafaa adfsd"),
                        new Student("6", "ghfd wsdfsd", "3454423353", "sdf dfsda adfsd dfdsfss"),
                        new Student("7", "xcvxcv esdfd", "4423454357", "sdfsd dfsdfssdfda erwadfsd"),
                        new Student("8", "cxvzx resadf", "4323414346", "erwerq ghd rtew ssda adfsd"),
                        new Student("9", "afds tsdfs", "3234254334", "vzxvxcvb gsdfds da adfsd"),
                        };
            
            table.ItemsSource = items;
            
             */
            /*

           DataTable dt = new DataTable();
           DataColumn id = new DataColumn("Id", typeof(int));
           DataColumn name = new DataColumn("Name", typeof(string));
           DataColumn pno = new DataColumn("Pno", typeof(string));
           DataColumn address = new DataColumn("Address", typeof(string));

           dt.Columns.Add(id);
           dt.Columns.Add(name);
           dt.Columns.Add(pno);
           dt.Columns.Add(address);

           table.ItemsSource = dt.DefaultView;

           DataRow row = dt.NewRow();
           row[0] = 1001;
           row[1] = "asdfdf";
           row[2] = "9879879879";
           row[3] = "54 sdfd dfsd sdfsafda";

           dt.Rows.Add(row);
           table.ItemsSource = dt.DefaultView;
           */


            //      table.ItemsSource = dt.DefaultView;
        }

        private void SideWindowVisibility(object sender, RoutedEventArgs e) {
            string content = (e.Source as Button).Content as string;

            switch (content) {
                case "Visible":
                    GetSideWindowPanel().Visibility = Visibility.Visible;
                    BtSideWindowCollapsed.Visibility = Visibility.Visible;
                    BtSideWindowVisible.Visibility = Visibility.Collapsed;
                    break;

                case "Collapse":
                    BtSideWindowCollapsed.Visibility = Visibility.Collapsed;
                    BtSideWindowVisible.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void AddTableButtons() {
            try {
                SPTableButtons.Children.Clear();
                TableButtons = XmlTablesNameList.Read();
                for (int i = 0; i < TableButtons.Count; i++) {
                    Button bt = new Button();
                    bt.Content = TableButtons[i].TableButtonName;
                    bt.Click += (object obj, RoutedEventArgs e) => EnableTable();
                    SPTableButtons.Children.Add(bt);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void NavPanelVisibility(object sender, RoutedEventArgs e) {
            string tag = (e.Source as Button).Tag as string;

            switch (tag) {
                case "Show":
                    BtNavPanelCollapse.Visibility = Visibility.Visible;
                    BtNavPanelShow.Visibility = Visibility.Collapsed;

                    DPTablesLabel.Visibility = Visibility.Visible;
                    SVTableButtons.Visibility = Visibility.Visible;
                    break;

                case "Collapse":
                    BtNavPanelCollapse.Visibility = Visibility.Collapsed;
                    BtNavPanelShow.Visibility = Visibility.Visible;


                    DPTablesLabel.Visibility = Visibility.Collapsed;
                    SVTableButtons.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void TableButtonsVisibility(object sender, RoutedEventArgs e) {
            string tag = (e.Source as Button).Tag as string;

            switch (tag) {
                case "Expand":
                    BtExpand.Visibility = Visibility.Collapsed;
                    BtCollapse.Visibility = Visibility.Visible;
                    break;

                case "Collapse":
                    BtExpand.Visibility = Visibility.Visible;
                    BtCollapse.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void BtDashboard_Clicked(object sender, RoutedEventArgs e) {

        }

        private void BtSettings_Clicked(object sender, RoutedEventArgs e) {
            if (ActivePanel == SettingsPanel) return;
            ActivePanel.Visibility = Visibility.Collapsed;
            ActivePanel = SettingsPanel;
            SettingsPanel.Visibility = Visibility.Visible;
            DPBasePanel.Children.Clear();
            DPBasePanel.Children.Add(SettingsPanel);
        }

        private void EnableTable() {
            if (ActivePanel == DataGridTablePanel) return;
            ActivePanel.Visibility = Visibility.Collapsed;
            ActivePanel = DataGridTablePanel;
            DataGridTablePanel.Visibility = Visibility.Visible;
            DPBasePanel.Children.Clear();
            DPBasePanel.Children.Add(DataGridTablePanel);
        }



    }

    public class Student {
        #region Properties
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        #endregion

        public Student(string id, string name, string phone, string address) {
            Id = id;
            Name = name;
            Phone = phone;
            Address = address;
        }
    }

}
