using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace TradeMaster.Column {
    public class LongType : IDataErrorInfo {
        public Border Border { get; private set; }
        public string ColumnName { get; set; }
        public string Tag { get; set; }
        private string _ColumnValue;
        public string ColumnValue {
            get => _ColumnValue;
            set {
                if (value.Contains(".") || value.Contains(" ") || value.LastIndexOf("+") != value.IndexOf("+")) return;
                if (value.StartsWith("00") && value.Length > 1) _ColumnValue = value.Substring(1);
                else _ColumnValue = value;
            }
        }
        public LongType(string colName, string tag) {
            this.ColumnName = colName;
            this.Tag = tag;

            SetBorder();
            Border.DataContext = this;
        }


        public string this[string PropertyName] {
            get {
                string msg = string.Empty;
                switch (PropertyName) {
                    case "ColumnValue":
                        if (ColumnValue.Equals(""))
                            msg = "Empty TextField.";
                        else {
                            try {
                                if (Convert.ToUInt64(RemoveCharacter(ColumnValue)).ToString().Length < 8) msg = "Phone no must be greater than 8-digits";
                            }
                            catch (FormatException) { msg = "Enter valid Phone no"; }
                            catch (OverflowException) { msg = "Value out of range."; }
                        }
                        break;
                }
                return msg;
            }
        }

        private string RemoveCharacter(string value) {
            int index = 0, counter = 0;
            while (index != -1) {
                index = value.IndexOf('-');
                if (index > -1) {
                    if (counter == index) return value;
                    else value = value.Remove(index, 1);
                    counter = index;
                }
            }
            return value;
        }

        public string Error => null;

        private void SetBorder() {
            try {
                Border = App.Current.FindResource("LongType") as Border;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
    }
}
