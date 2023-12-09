using AccountingApp.Models;
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
    /// Interaction logic for CostCathegoryPage.xaml
    /// </summary>
    public partial class CostCathegoryPage : Page
    {
        private readonly AppDbContext _db;
        private List<Cathegory> _cathegories;
        public CostCathegoryPage(AppDbContext context)
        {
            _db = context;
            _cathegories = _db.Cathegories.ToList();
            InitializeComponent();
        }
    }
}
