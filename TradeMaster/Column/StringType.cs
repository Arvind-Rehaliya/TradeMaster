using System;
using System.Windows;
using System.Windows.Controls;

namespace TradeMaster.Column
{
    class StringType {
        public Border Border { get; private set; }
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }
        public string Tag { get; set; }

        public StringType(string colName, string tag) {
            this.ColumnName = colName;
            this.Tag = tag;

            SetBorder();
            Border.DataContext = this;
        }

        private void SetBorder() {
            try {
                Border = App.Current.FindResource("StringType") as Border;
            } catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
    }
}
