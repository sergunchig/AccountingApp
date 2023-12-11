using AccountingApp.Models;
using AccountingApp.ViewModels;
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
using System.Windows.Shapes;

namespace AccountingApp.Windows
{
    /// <summary>
    /// Interaction logic for AddEditCostWndw.xaml
    /// </summary>
    public partial class AddEditCostWndw : Window
    {
        public CostDisplay CurrCost {  get; set; }
        public AddEditCostWndw(List<Cathegory> catList, CostDisplay cost = null)
        {
            if(cost != null)
            {
                CurrCost = cost;
            }
            else
            {
                CurrCost = new CostDisplay() { Date = DateTime.Now };
            }

            InitializeComponent();
            DataContext = CurrCost;
            costsLstBx.ItemsSource = catList.Select(x=> x.Title);
        }

        private void okBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
