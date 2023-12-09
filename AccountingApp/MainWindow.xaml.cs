using AccountingApp.Models;
using AccountingApp.Services;
using AccountingApp.Views;
using System.Linq;
using System.Windows;
using System.Windows.Navigation;

namespace AccountingApp
{
    public partial class MainWindow : Window
    {
        private readonly AppNavigationService _navigation;

        public MainWindow(AppNavigationService navigationService)
        {
            _navigation = navigationService;

            InitializeComponent();
        }

        private void catCostMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = _navigation.GetPage<CostCathegoryPage>();
        }

        private void costMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = _navigation.GetPage<CostsPage>();
        }

        private void statMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = _navigation.GetPage<StatisticsPage>();
        }
    }
}
