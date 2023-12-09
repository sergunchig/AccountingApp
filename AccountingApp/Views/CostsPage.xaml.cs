using AccountingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccountingApp.Views
{
    /// <summary>
    /// Interaction logic for CostsPage.xaml
    /// </summary>
    public partial class CostsPage : Page
    {
        private readonly AppDbContext _db;
        private List<Cost> _costs;
        public CostsPage(AppDbContext context)
        {
            _db = context;
            InitializeComponent();
        }

        private void addCatMn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditCatMn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DelCatMn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RefreshCatMn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
