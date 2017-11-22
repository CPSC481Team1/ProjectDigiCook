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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class NoResultsIntermediate : Page
    {
        public NoResultsIntermediate()
        {
            InitializeComponent();
        }


        private void View_Checklist_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("./Checklist.xaml", UriKind.Relative));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            searchBar.setText();
        }

        private void ravioli_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("./Spaghetti.xaml", UriKind.Relative));
        }

      

        private void ravioli_MouseEnter(object sender, MouseEventArgs e)
        {
            ravioli.Width = 215;
            ravioli.Height = 215;
        }

        private void ravioli_MouseLeave(object sender, MouseEventArgs e)
        {
            ravioli.Width = 200;
            ravioli.Height = 200;
        }

        private void dessert_MouseEnter(object sender, MouseEventArgs e)
        {
            dessert.Width = 215;
            dessert.Height = 215;
        }

        private void dessert_MouseLeave(object sender, MouseEventArgs e)
        {
            dessert.Width = 200;
            dessert.Height = 200;
        }

        private void breakfast_MouseEnter(object sender, MouseEventArgs e)
        {
            breakfast.Width = 215;
            breakfast.Height = 215;
        }

        private void breakfast_MouseLeave(object sender, MouseEventArgs e)
        {
            breakfast.Width = 200;
            breakfast.Height = 200;
        }
    }
}
