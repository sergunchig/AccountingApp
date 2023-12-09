using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AccountingApp.Services
{
    public class AppNavigationService
    {
        private readonly IServiceProvider _serviceProvider;
        public AppNavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public T GetPage<T>() where T : Page
        {
            var page = _serviceProvider!.GetService(typeof(T));
            return (T)page!;
        }
        public T GetDialog<T>() where T : Window
        {
            var window = _serviceProvider!.GetService(typeof(T));
            return (T)window!;
        } 
    }
}
