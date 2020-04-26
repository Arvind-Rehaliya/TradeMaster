using System;
using System.Windows;
using System.Windows.Controls;

namespace TradeMaster.Column
{
    class DateType {
        public Border Border { get; private set; }
        public string ColumnName { get; set; }
        public DateTime ColumnValue { get; set; }

        public DateType(string colName, DateTime colValue) {
            this.ColumnName = colName;
            this.ColumnValue = colValue;

            SetBorder();
            Border.DataContext = this;
        }

        private void SetBorder() {
            try {
                Border = App.Current.FindResource("DateType") as Border;
            } catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
    }
}
