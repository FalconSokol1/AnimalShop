using PracticeShop.View;
using PracticeShop.ViewModel;
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

namespace PracticeShop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowVM();
            
        }


        private void btnNewTrip(object sender, RoutedEventArgs e)
        {
            var newTrip = new NewTrade(null);

            newTrip.Show();
        }

        private void btnDeleteTrip(object sender, RoutedEventArgs e)
        {
            (DataContext as MainWindowVM).DeleteSelectItem();
        }

        private void btnUpdateGrid(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            (DataContext as MainWindowVM).LoadData();
        }

        private void btnUpdateTrip(object sender, RoutedEventArgs e)
        {
            var newTrip = new NewTrade((DataContext as MainWindowVM).SelectedGoods);

            newTrip.Show();
        }


        private void btnExit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnVievTable(object sender, RoutedEventArgs e)
        {

        }
    }
}
