using System.Windows.Controls;

namespace TradeMaster.Models.Interfaces {

    interface IMainWindow {
        DataGrid GetTable();
        string GetSearchText();
    }
}
