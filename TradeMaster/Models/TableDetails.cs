namespace TradeMaster.Models {
    public class TableDetails {
        private string _tableButtonName;
        public string TableButtonName {
            get => _tableButtonName;
            set {
                if (!(string.IsNullOrEmpty(value.ToString()) || string.IsNullOrWhiteSpace(value.ToString())))
                    _tableButtonName = value;
            }
        }

        private string _tableName;
        public string TableName {
            get => _tableName;
            set {
                if (!(string.IsNullOrEmpty(value.ToString()) || string.IsNullOrWhiteSpace(value.ToString())))
                    _tableName = value;
            }
        }


        public TableDetails() { }



    }
}
