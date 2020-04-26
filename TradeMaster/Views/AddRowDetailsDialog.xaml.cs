using System.Windows;
using System.Windows.Controls;
using TradeMaster.Column;

namespace TradeMaster.Views {

    public partial class AddRowDetailsDialog : Window {
        public AddRowDetailsDialog() {
            InitializeComponent();
            Populate();
        }

        private void Populate() {
            IntegerType c1 = new IntegerType("id", "id");
            Border b1 = c1.Border;
            stackPanel.Children.Add(b1);

            StringType c2 = new StringType("First Name", "First Name");
            Border b2 = c2.Border;
            stackPanel.Children.Add(b2);

            StringType c3 = new StringType("Last Name", "Last Name");
            Border b3 = c3.Border;
            stackPanel.Children.Add(b3);

            RadioType c4 = new RadioType("Gender", "Male", "Female");
            Border b4 = c4.Border;
            stackPanel.Children.Add(b4);

            LongType c5 = new LongType("Phone No.", "Phone No");
            Border b5 = c5.Border;
            stackPanel.Children.Add(b5);

            DateType c9 = new DateType("Date", System.DateTime.Now);
            Border b9 = c9.Border;
            stackPanel.Children.Add(b9);

            FloatType c6 = new FloatType("Salary", "Salary");
            Border b6 = c6.Border;
            stackPanel.Children.Add(b6);

            IntegerType c7 = new IntegerType("Roll no", "Roll No");
            Border b7 = c7.Border;
            stackPanel.Children.Add(b7);

            StringType c8 = new StringType("Address", "Address");
            Border b8 = c8.Border;
            stackPanel.Children.Add(b8);
            
        }

        private void Close_Clicked(object sender, RoutedEventArgs e) {
            this.Visibility = Visibility.Collapsed;
            this.Close();
        }

        private void Submit_Clicked(object sender, RoutedEventArgs e) {
            MessageBox.Show("Submit Clicked");

        }

    }
}
