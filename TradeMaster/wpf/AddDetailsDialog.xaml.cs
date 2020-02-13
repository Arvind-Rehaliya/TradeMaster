using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace TradeMaster.wpf
{
    /// <summary>
    /// Interaction logic for AddDetailsDialog.xaml
    /// </summary>
    public partial class AddDetailsDialog : Window
    {
        public AddDetailsDialog()
        {
            InitializeComponent();

            
        }

        private void Close_Clicked(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            this.Close();
        }

        private void Submit_Clicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Submit Clicked");

        }

    }
}
