using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TradeMaster.IO.Tables;
using TradeMaster.Models;

namespace TradeMaster.Views.TabPanels.TablePanel {
    public partial class TablePanel : UserControl {
        private Grid SelectedGrid;
        private TextBlock TablesCount;
        private List<TableDetails> ActualTableDetails, ModifiedTableDetails = null;
        private bool IsSaveClicked = false;

        public TablePanel() {
            InitializeComponent();

            Init();
            PopulateTableRows();
        }

        private void PopulateTableRows() {
            try {
                ActualTableDetails = XmlTablesNameList.Read();
                TablesCount.Text = ActualTableDetails.Count.ToString();

                for (int i = 0; i < ActualTableDetails.Count; i++) {
                    SPTableRows.Children.Add(new TableRow(ActualTableDetails[i].TableButtonName, ActualTableDetails[i].TableName, Order_Clicked).GetGrid());
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Init() {
            TablesCount = FindName("TBTablesCount") as TextBlock;
            ActualTableDetails = new List<TableDetails>();
            ModifiedTableDetails = new List<TableDetails>();
        }

        private void Order_Clicked(RoutedEventArgs e) {
            if (SelectedGrid != null)
                SelectedGrid.Background = new BrushConverter().ConvertFromString("Transparent") as SolidColorBrush;

            SelectedGrid = GetSelectedTableRow(e);
            SelectedGrid.Background = new BrushConverter().ConvertFromString("BlueViolet") as SolidColorBrush;
            Enable();
            int index = SPTableRows.Children.IndexOf(SelectedGrid);
            if (index == 0) BtUp.IsEnabled = false;
            else if (index == (SPTableRows.Children.Count - 1)) BtDown.IsEnabled = false;

        }

        private void Disable() {
            BtUp.IsEnabled = false;
            BtDown.IsEnabled = false;
            SelectedGrid.Background = new BrushConverter().ConvertFromString("Transparent") as SolidColorBrush;

        }

        private void Enable() {
            BtUp.IsEnabled = true;
            BtDown.IsEnabled = true;
        }

        private Grid GetSelectedTableRow(RoutedEventArgs e) {
            Grid gd = (e.Source as Button).Parent as Grid;
            for (int i = 0; i < SPTableRows.Children.Count; i++) {
                if (SPTableRows.Children[i] == gd)
                    return gd;
            }
            return null;
        }

        private void BtSave_Clicked(object sender, RoutedEventArgs e) {
            try {
                IsSaveClicked = true;
                ModifiedTableDetails.Clear();
                for (int i = 0; i < SPTableRows.Children.Count; i++) {
                    Grid gd = GetGridAt(i);
                    ModifiedTableDetails.Add(new TableDetails() {
                        TableButtonName = (gd.Children[1] as TextBox).Text,
                        TableName = (gd.Children[3] as TextBox).Text,
                    });
                }
                XmlTablesNameList.Write(ModifiedTableDetails);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            Disable();
        }

        private void BtRevert_Clicked(object sender, RoutedEventArgs e) {
            try {
                SPTableRows.Children.Clear();
                for (int i = 0; i < ActualTableDetails.Count; i++) {
                    SPTableRows.Children.Add(new TableRow(ActualTableDetails[i].TableButtonName, ActualTableDetails[i].TableName, Order_Clicked).GetGrid());
                }
                if (IsSaveClicked) {
                    XmlTablesNameList.Write(ActualTableDetails);
                    IsSaveClicked = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            Disable();
        }

        private Grid GetGridAt(int index) {
            return SPTableRows.Children[index] as Grid;
        }

        private void BtUp_Clicked(object sender, RoutedEventArgs e) {
            if (SelectedGrid == null) return;
            int index = SPTableRows.Children.IndexOf(SelectedGrid);

            if (index > 0) {
                Grid prevGrid = SPTableRows.Children[index - 1] as Grid;
                SPTableRows.Children.Remove(SelectedGrid);
                SPTableRows.Children.Insert(index - 1, SelectedGrid);
                SPTableRows.Children.Remove(prevGrid);
                SPTableRows.Children.Insert(index, prevGrid);

                BtDown.IsEnabled = true;
                if ((index - 1) == 0)
                    BtUp.IsEnabled = false;
                (SPTableRows.Children[index - 1] as Grid).Background = new BrushConverter().ConvertFromString("BlueViolet") as SolidColorBrush;
            } else if (index == 0) {
                (SPTableRows.Children[0] as Grid).Background = new BrushConverter().ConvertFromString("BlueViolet") as SolidColorBrush;
                BtUp.IsEnabled = false;
            }

        }

        private void BtDown_Clicked(object sender, RoutedEventArgs e) {
            if (SelectedGrid == null) return;
            int index = SPTableRows.Children.IndexOf(SelectedGrid);
            int totalRows = SPTableRows.Children.Count - 1;

            if (index < totalRows) {
                Grid nextGrid = SPTableRows.Children[index + 1] as Grid;
                SPTableRows.Children.Remove(SelectedGrid);
                SPTableRows.Children.Insert(index + 1, SelectedGrid);
                SPTableRows.Children.Remove(nextGrid);
                SPTableRows.Children.Insert(index, nextGrid);

                BtUp.IsEnabled = true;
                if ((index + 1) == totalRows)
                    BtDown.IsEnabled = false;
                (SPTableRows.Children[index + 1] as Grid).Background = new BrushConverter().ConvertFromString("BlueViolet") as SolidColorBrush;
            } else if (index == totalRows) {
                (SPTableRows.Children[totalRows] as Grid).Background = new BrushConverter().ConvertFromString("BlueViolet") as SolidColorBrush;
                BtDown.IsEnabled = false;
            }
        }

    }
}
