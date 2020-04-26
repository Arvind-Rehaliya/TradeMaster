using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace TradeMaster.Views.TabPanels.TablePanel {
    public partial class TableRow : UserControl {
        public TextBox TableButton { get; private set; }
        public TextBox DatabaseTableName { get; private set; }
        private Action<RoutedEventArgs> OrderClicked;
        private string prevText;

        public TableRow(string tableButtonName, string databaseTableName, Action<RoutedEventArgs> orderClicked) {
            InitializeComponent();

            Init();
            prevText = TableButton.Text = tableButtonName;
            DatabaseTableName.Text = databaseTableName;
            OrderClicked = orderClicked;
        }

        private void Init() {
            TableButton = GdTableButtonRow.Children[1] as TextBox;
            DatabaseTableName = GdTableButtonRow.Children[3] as TextBox;
        }

        private void Edit_MouseUp(object sender, MouseEventArgs e) {
            TableButton.Focus();
            TableButton.SelectAll();
            TableButton.IsReadOnly = false;
        }

        private void TbTableButton_KeyUp(object sender, KeyEventArgs e) {
            TextBox tb = e.Source as TextBox;
            if (!tb.IsReadOnly) {
                if (e.Key == Key.Enter) {
                    if (string.IsNullOrEmpty(tb.Text))
                        tb.Text = TableButton.Text;
                    else prevText = TableButton.Text = tb.Text;

                    tb.MoveFocus(new TraversalRequest(FocusNavigationDirection.Left));
                    tb.IsReadOnly = true;
                }
            }
        }

        private void TbTableButton_FocusLost(object sender, RoutedEventArgs e) {
            TextBox tb = e.Source as TextBox;
                tb.Text = prevText;
            tb.IsReadOnly = true;
        }
        
        public Grid GetGrid() {
            RemoveLogicalChild(GdTableButtonRow);
            RemoveVisualChild(GdTableButtonRow);
            return GdTableButtonRow;
        }

        private void Order_Clicked(object sender, RoutedEventArgs e) {
            OrderClicked.Invoke(e);
        }
        
    }
}
