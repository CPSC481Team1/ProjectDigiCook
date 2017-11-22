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
    public partial class NoResultsExpert : Page
    {
        public NoResultsExpert()
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

        private void fettuccine_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("./Spaghetti.xaml", UriKind.Relative));
        }



        private void fettuccine_MouseEnter(object sender, MouseEventArgs e)
        {
            fettuccine.Width = 215;
            fettuccine.Height = 215;
        }

        private void fettuccine_MouseLeave(object sender, MouseEventArgs e)
        {
            fettuccine.Width = 200;
            fettuccine.Height = 200;
        }

        private void vegan_MouseEnter(object sender, MouseEventArgs e)
        {
            vegan.Width = 215;
            vegan.Height = 215;
        }

        private void vegan_MouseLeave(object sender, MouseEventArgs e)
        {
            vegan.Width = 200;
            vegan.Height = 200;
        }

        private void vegetarian_MouseEnter(object sender, MouseEventArgs e)
        {
            vegetarian.Width = 215;
            vegetarian.Height = 215;
        }

        private void vegetarian_MouseLeave(object sender, MouseEventArgs e)
        {
            vegetarian.Width = 200;
            vegetarian.Height = 200;
        }
    }
}
