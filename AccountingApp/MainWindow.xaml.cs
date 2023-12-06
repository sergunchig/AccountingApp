using AccountingApp.Models;
using System.Linq;
using System.Windows;

namespace AccountingApp
{
    public partial class MainWindow : Window
    {
        private readonly AppDbContext _db;
        public MainWindow(AppDbContext context)
        {
            _db = context;
            InitializeComponent();
        }
    }
}
