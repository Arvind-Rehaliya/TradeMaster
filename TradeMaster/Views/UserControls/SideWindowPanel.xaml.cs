using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TradeMaster.Views.UserControls {
    public partial class SideWindowPanel : UserControl {
        private ObservableCollection<string> listItems = null;
        private ListBox list;
        private ListBoxItem SelectedItem;
        private DockPanel ColumnNamePanel;

        public SideWindowPanel() {
            InitializeComponent();

            list = FindName("ColumnNameListView") as ListBox;
            ColumnNamePanel = FindName("dock_SideWindow_Up_Right") as DockPanel;
            SetEventsOfListView();

        }

        private void SetEventsOfListView() {
            list.SelectionChanged += OnColumnName_SelectionChanged;
            list.LostFocus += OnColumnName_LostFocus;
            list.KeyUp += List_KeyUp;

            tb_ColumnName.KeyUp += ColumnNameTextBox_KeyUp;
        }

        private void List_KeyUp(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter)
                tb_ColumnName.Focus();
            tb_ColumnName.SelectAll();
        }

        private void OnColumnName_LostFocus(object sender, RoutedEventArgs e) {
            if (tb_ColumnName.IsKeyboardFocused) return;

            SetColumnNamePanel(false, "");
        }

        private void ColumnNameTextBox_KeyUp(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {
                SelectedItem.Content = tb_ColumnName.Text;
                SelectedItem.Focus();
            }
        }

        private void OnColumnName_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (list.SelectedIndex == -1) return;
            SelectedItem = GetSelectedListBoxItem();
            SetColumnNamePanel(true, SelectedItem.Content.ToString());
        }

        private ListBoxItem GetSelectedListBoxItem() {
            return list.ItemContainerGenerator.ContainerFromItem(list.SelectedItem) as ListBoxItem;
        }

        private void SetColumnNamePanel(bool visibility, string text) {
            tb_ColumnName.Text = text;
            if (visibility)
                ColumnNamePanel.Visibility = Visibility.Visible;
            else ColumnNamePanel.Visibility = Visibility.Collapsed;
        }

        private void AddColumn_Clicked(object sender, RoutedEventArgs args) {
            listItems = new ObservableCollection<string> {
                "ListBoxItem1",
                "ListBoxItem2",
                "ListBoxItem3",
                "ListBoxItem4",
                "ListBoxItem5",
                "ListBoxItem6"
            };
            list.ItemsSource = listItems;
        }

        private void RemoveColumn_Clicked(object sender, RoutedEventArgs args) {
            listItems.Remove(SelectedItem.Content.ToString());
        }

    }
}
