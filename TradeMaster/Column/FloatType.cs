using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace TradeMaster.Column
{
    class FloatType : IDataErrorInfo {
        public Border Border { get; private set; }
        public string ColumnName { get; set; }
        public string Tag { get; set; }
        private string _ColumnValue;
        public string ColumnValue {
            get => _ColumnValue;
            set {
                if (value.Contains("-") || value.Contains(" ") || (value.IndexOf('.') != value.LastIndexOf('.'))) return;
                if (value.StartsWith("0") && value.Length > 1) _ColumnValue = value.Substring(1);
                else _ColumnValue = value;
            }
        }
        
        public FloatType(string colName, string tag) {
            this.ColumnName = colName;
            this.Tag = tag;

            SetBorder();
            Border.DataContext = this;
        }

        public string Error => null;

        public string this[string PropertyName] {
            get {
                string msg = string.Empty;
                switch (PropertyName) {
                    case "ColumnValue":
                        if (ColumnValue.Equals(""))
                            msg = "Empty TextField.";
                        else {
                            try {
                                Convert.ToSingle(ColumnValue);
                            }
                            catch (FormatException) { msg = "Enter integer only."; }
                            catch (OverflowException) { msg = "Value out of range."; }
                        }
                        break;
                }
                return msg;
            }
        }

        private void SetBorder() {
            try {
                Border = App.Current.FindResource("FloatType") as Border;
            } catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        
    }
}
