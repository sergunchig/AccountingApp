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
using System.Windows.Shapes;

namespace AccountingApp.Windows
{
    /// <summary>
    /// Interaction logic for AddCatheforyWndw.xaml
    /// </summary>
    public partial class AddEditCathegoryWndw : Window
    {
        public Cathegory Cathegory { get; set; }
        public AddEditCathegoryWndw(Cathegory cathegory = null!)
        {
            InitializeComponent();
            if(cathegory != null)
            {
                this.Cathegory = cathegory;
            }
            else
            {
                this.Cathegory = new Cathegory();
            }
            titleTextBx.DataContext = Cathegory;
        }

        private void okBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true; this.Close();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
