using AccountingApp.Models;
using AccountingApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for StatisticsPage.xaml
    /// </summary>
    public partial class StatisticsPage : Page
    {
        private readonly AppDbContext _db;
        private List<Cost> _costs;
        private string[] monthes = {"Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август",
                "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"};
        public StatisticsPage(AppDbContext context)
        {
            _db = context;
            InitializeComponent();

            _costs = _db.Costs.Include(x=> x.Cathegory).ToList();
            var years = _costs.Select(x => x.Date.Year).ToHashSet();

            yearsCBx.ItemsSource = years;
        }

        private void yearsCBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var si = (int)yearsCBx.SelectedItem;

            var filteredCosts = _costs.Where(x => x.Date.Year == si);
            var groupedCosts = filteredCosts
                .Select(x => new StatisticDisplay()
                {
                    Cathegory = x.Cathegory.Title,
                    Month = monthes[x.Date.Month - 1],
                    Total = x.Cathegory.Costs.Where(y => y.Date.Month == x.Date.Month).Sum(y => y.Price)
                }).Distinct(new StatisticComparer()).ToList();

            var lcv = CollectionViewSource.GetDefaultView(groupedCosts);
            lcv.GroupDescriptions.Add(new PropertyGroupDescription("Month"));

            StatDg.ItemsSource = lcv;
            StatDg.Visibility = Visibility.Visible;

            for(int i = 0; i < StatisticDisplay.fields.Count(); i++)
            {
                if (StatisticDisplay.fields[i] != null)
                {
                    StatDg.Columns[i].Header = StatisticDisplay.fields[i];
                }
                else
                {
                    StatDg.Columns[i].Visibility = Visibility.Hidden;
                }
            }
        }
    }
}
