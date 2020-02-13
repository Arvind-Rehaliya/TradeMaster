using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TradeMaster
{
    public partial class MainWindow : Window
    {
        private bool SearchbarFocused = false;

        public MainWindow()
        {
            InitializeComponent();
            PopulateData();
            SetTableProperties();
            
        }

        private void PopulateData()
        {
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
            ObservableCollection<Student> items = new ObservableCollection<Student>() {
                        new Student("1", "sdf dfds", "3454423353", "sdf dfsda adfsd dfdsfss"),
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

        }

        private void SetTableProperties()
        {
            table.PreparingCellForEdit += (value, e) =>
            {
                MessageBox.Show("PreparingCellForEdit");
            };

            table.CellEditEnding += (value, e) =>
            {
                MessageBox.Show("CellEditEnding");
            };

            table.RowHeaderWidth = 25;
        }

        private void Add_Clicked(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Clicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Delete_Clicked");
        }

        private void Refresh_Clicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Refresh_Clicked");

        }

        private void Minimized_Clicked(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Maximized_Clicked(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void Close_Clicked(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void MenuOpen_Clicked(object sender, RoutedEventArgs e)
        {
            bt_collapse.Visibility = Visibility.Visible;
            bt_open.Visibility = Visibility.Collapsed;
        }

        private void MenuCollapse_Clicked(object sender, RoutedEventArgs e)
        {
            bt_collapse.Visibility = Visibility.Collapsed;
            bt_open.Visibility = Visibility.Visible;
        }

        private void TableButton_Clicked(object sender, RoutedEventArgs e)
        { //new System.Windows.Controls.TextBox().
            Button bt = (Button)sender;
            int uid = int.Parse(bt.Uid);
            gridcursor.Margin = new Thickness(0, 40 * uid, 0, 0);
        }

        private void Tb_Search_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_Search.Text.Equals("Search"))
                Tb_Search.Text = "";
            stack_searchbar.Background = new SolidColorBrush(Colors.BlueViolet);
            SearchbarFocused = true;
        }

        private void Tb_Search_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_Search.Text.Length == 0)
                Tb_Search.Text = "Search";
            stack_searchbar.Background = new SolidColorBrush(Colors.Black);
            SearchbarFocused = false;
        }

        private void Bt_Search_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchbarFocused) return;
            stack_searchbar.Background = new SolidColorBrush(Colors.BlueViolet);
        }

        private void Bt_Search_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SearchbarFocused) return;
            stack_searchbar.Background = new SolidColorBrush(Colors.Black);
        }

        private void Tb_Search_MouseEnter(object sender, RoutedEventArgs e)
        {
            if (SearchbarFocused) return;
            Tb_Search.Foreground = new SolidColorBrush(Colors.White);
            stack_searchbar.Background = new SolidColorBrush(Colors.BlueViolet);
        }

        private void Tb_Search_MouseLeave(object sender, RoutedEventArgs e)
        {
            if (SearchbarFocused) return;
            Tb_Search.Foreground = new SolidColorBrush(Colors.LightGray);
            stack_searchbar.Background = new SolidColorBrush(Colors.Black);
        }

        private void Bt_Search_MouseEnter(object sender, RoutedEventArgs e)
        {
            if (SearchbarFocused) return;
            stack_searchbar.Background = new SolidColorBrush(Colors.BlueViolet);
        }

        private void Bt_Search_MouseLeave(object sender, RoutedEventArgs e)
        {
            if (SearchbarFocused) return;
            stack_searchbar.Background = new SolidColorBrush(Colors.Black);
        }

        private void Table_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show("Row Selected.");
        }

        private void Table_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            
        }

        private void Table_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {

        }

        private void Table_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        private void Table_CurrentCellChanged(object sender, System.EventArgs e)
        {

        }
        

    }

    public class Color1
    {
        public string Background { get { return "Red"; } }

    }
 
    public class Student
    {
        #region Properties
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        #endregion

        public Student() { }
        public Student(string id, string name, string phone, string address)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Address = address;
        }
    }

}
