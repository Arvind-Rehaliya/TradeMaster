using System.Windows;
using System.Windows.Controls;
using TradeMaster.Views.TabPanels.HomePanel;
using TradeMaster.Views.TabPanels.AnalyticsPanel;
using TradeMaster.Views.TabPanels.PerformancePanel;
using TradeMaster.Views.TabPanels.DownloadsPanel;
using TradeMaster.Views.TabPanels.TablePanel;
using System.Collections.ObjectModel;

namespace TradeMaster.Views.UserControls {
    public partial class SettingsPanel : UserControl {
        public SettingsPanel() {
            InitializeComponent();
            DPTabPanel.Children.Add(new HomePanel());
        }

        private void TabButton_Clicked(object sender, RoutedEventArgs e) {
            int index = int.Parse((e.Source as Button).Uid);
            Grid grid = FindName("GridCursor") as Grid;

            switch (index) {
                case 0:
                    grid.Margin = new Thickness((110 * index) + 16, 0, 0, 0);
                    DPTabPanel.Children.Clear();
                    DPTabPanel.Children.Add(new HomePanel());
                    break;
                case 1:
                    grid.Margin = new Thickness((110 * index) + 16, 0, 0, 0);
                    DPTabPanel.Children.Clear();
                    DPTabPanel.Children.Add(new PerformancePanel());
                    break;
                case 2:
                    grid.Margin = new Thickness((110 * index) + 16, 0, 0, 0);
                    DPTabPanel.Children.Clear();
                    DPTabPanel.Children.Add(new AnalyticsPanel());
                    break;
                case 3:
                    grid.Margin = new Thickness((110 * index) + 16, 0, 0, 0);
                    DPTabPanel.Children.Clear();
                    DPTabPanel.Children.Add(new DownloadsPanel());
                    break;
                case 4:
                    grid.Margin = new Thickness((110 * index) + 16, 0, 0, 0);
                    DPTabPanel.Children.Clear();
                    DPTabPanel.Children.Add(new TablePanel());
                    break;
            }
        }
    }
}
