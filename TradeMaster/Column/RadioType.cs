using System;
using System.Windows;
using System.Windows.Controls;

namespace TradeMaster.Column {

    public class RadioType {
        public Border Border { get; private set; }
        public string ColumnName { get; set; }
        public string First { get; set; }
        public string Second { get; set; }

        public RadioType(string colName, string first, string second) {
            ColumnName = colName;
            First = first;
            Second = second;

            SetBorder();
            Border.DataContext = this;
        }

        private void SetBorder() {
            try {
                Border = App.Current.FindResource("RadioType") as Border;
                RadioButton rb1 = (Border.Child as StackPanel).Children[1] as RadioButton;
                rb1.IsChecked = true;
            } catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        public RadioButton GetCheckedRadioButton() {
            RadioButton rb1 = (Border.Child as StackPanel).Children[1] as RadioButton;
            RadioButton rb2 = (Border.Child as StackPanel).Children[2] as RadioButton;

            if (rb1.IsChecked == true)
                return rb1;
            else return rb2;        
        }
    }
}
