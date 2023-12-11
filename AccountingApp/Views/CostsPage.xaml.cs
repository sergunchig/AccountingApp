using AccountingApp.Models;
using AccountingApp.ViewModels;
using AccountingApp.Windows;
using Microsoft.EntityFrameworkCore;
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
        private List<CostDisplay> Costs { get; set; }
        public CostsPage(AppDbContext context)
        {
            _db = context;
            InitializeComponent();

            Costs = _db.Costs.Include(x=> x.Cathegory).Select(x=> new CostDisplay(x))
                .AsNoTracking().ToList();

            CostDg.ItemsSource = Costs;
        }

        private void addCostMn_Click(object sender, RoutedEventArgs e)
        {
            var catList = _db.Cathegories.AsNoTracking().ToList();
            AddEditCostWndw wndw = new AddEditCostWndw(catList);
            if (wndw.ShowDialog() == true)
            {
                try
                {
                    var newCost = wndw.CurrCost;
                    var nc = new Cost()
                    {
                        CathegoryId = catList.FirstOrDefault(x => x.Title.Equals(newCost.Cathegory))!.Id,
                        Date = newCost.Date.ToUniversalTime(),
                        Price = newCost.Price,
                        Description = newCost.Description
                    };
                    _db.Costs.Add(nc);
                    _db.SaveChanges();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void EditCostMn_Click(object sender, RoutedEventArgs e)
        {
            var costDisplay = CostDg.SelectedItem as CostDisplay;
            var catList = _db.Cathegories.AsNoTracking().ToList();
            AddEditCostWndw wndw = new AddEditCostWndw(catList, costDisplay!);
            if (wndw.ShowDialog() == true)
            {
                var updtCost = wndw.CurrCost;
                try
                {
                    var cost = _db.Costs.FirstOrDefault(x => x.Id == updtCost.Id);

                    cost.Date = updtCost.Date;
                    cost.Price = updtCost.Price;
                    cost.Description = updtCost.Description;
                    cost.CathegoryId = updtCost.CathegoryId;

                    _db.Costs.Update(cost);
                    _db.SaveChanges();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DelCostMn_Click(object sender, RoutedEventArgs e)
        {
            var costDisplay = CostDg.SelectedItem as CostDisplay;

            try
            {
                var cost = _db.Costs.First(x => x.Id == costDisplay.Id);
                _db.Costs.Remove(cost);
                _db.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshCostMn_Click(object sender, RoutedEventArgs e)
        {
            Costs = _db.Costs.Include(x => x.Cathegory).Select(x => new CostDisplay(x))
                .AsNoTracking().ToList();
            CostDg.ItemsSource = Costs;
        }
    }
}
