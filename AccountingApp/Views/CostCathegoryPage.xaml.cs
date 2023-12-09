using AccountingApp.Models;
using AccountingApp.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
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
    /// Interaction logic for CostCathegoryPage.xaml
    /// </summary>
    public partial class CostCathegoryPage : Page
    {
        private readonly AppDbContext _db;
        private List<Cathegory> Cathegories { get; set; }
        public CostCathegoryPage(AppDbContext context)
        {
            _db = context;
            InitializeComponent();
            Cathegories = _db.Cathegories.ToList();
            CatCostDg.ItemsSource = Cathegories;
        }
        private void addCatMn_Click(object sender, RoutedEventArgs e)
        {
            AddEditCathegoryWndw wndw = new AddEditCathegoryWndw();
            if(wndw.ShowDialog() == true)
            {
                try
                {
                    _db.Cathegories.Add(wndw.Cathegory);
                    _db.SaveChanges();
                    Cathegories.Add(wndw.Cathegory);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void EditCatMn_Click(object sender, RoutedEventArgs e)
        {
            var selItem = CatCostDg.SelectedItem as Cathegory;
            if (selItem != null)
            {
                AddEditCathegoryWndw wndw = new AddEditCathegoryWndw(selItem);
                if(wndw.ShowDialog()==true)
                {
                    try
                    {
                        _db.Cathegories.Update(wndw.Cathegory);
                        _db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void DelCatMn_Click(object sender, RoutedEventArgs e)
        {
            var selItem = CatCostDg.SelectedItem as Cathegory;
            if (selItem != null)
            {
                if (MessageBox.Show("Вы Действительно хотите удалить запись?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        _db.Cathegories.Remove(selItem);
                        _db.SaveChanges();
                        Cathegories.Remove(selItem);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }
        private void RefreshCatMn_Click(object sender, RoutedEventArgs e)
        {
            CatCostDg.ItemsSource = _db.Cathegories;
        }
    }
}
