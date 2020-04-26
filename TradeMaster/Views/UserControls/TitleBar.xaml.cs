using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TradeMaster.Views.UserControls {
    public partial class TitleBar : UserControl {
        public TitleBar() {
            InitializeComponent();

            TbSearch.LostKeyboardFocus += (object sender, KeyboardFocusChangedEventArgs e) => {
                if (TbSearch.Text.Length == 0) TbSearch.Text = "Search";
            };

            TbSearch.GotFocus += (object sender, RoutedEventArgs e) => {
                if (TbSearch.Text.Equals("Search")) TbSearch.Text = "";
            };
        }

        private void abc(object sender, RoutedEventArgs e) {
            MessageBox.Show("Search");
        }
    }
}
