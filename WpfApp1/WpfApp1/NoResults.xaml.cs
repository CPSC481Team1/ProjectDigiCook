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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    /// 

    public partial class NoResults : Page
    {

        public NoResults()
        {
            InitializeComponent();

            //this.Title = "DigiCook";

            //// Set window to center of the computer screen at startup
            //this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            //// Turn off resizing
            //this.ResizeMode = ResizeMode.NoResize;
        }

     

        private void View_Checklist_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("./Checklist.xaml", UriKind.Relative));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            searchBar.setText();
        }

       

        private void spaghetti_MouseEnter(object sender, MouseEventArgs e)
        {
            spaghetti.Width = 215;
            spaghetti.Height = 215;
        }

       

        private void spaghetti_MouseLeave(object sender, MouseEventArgs e)
        {
            spaghetti.Width = 200;
            spaghetti.Height = 200;
        }

        private void lunch_MouseEnter(object sender, MouseEventArgs e)
        {
            lunch.Height = 215;
            lunch.Width = 215;
        }

        private void lunch_MouseLeave(object sender, MouseEventArgs e)
        {
            lunch.Height = 200;
            lunch.Width = 200;
        }

        private void dinner_MouseEnter(object sender, MouseEventArgs e)
        {
            dinner.Height = 215;
            dinner.Width = 215;
        }

        private void dinner_MouseLeave(object sender, MouseEventArgs e)
        {
            dinner.Height = 200;
            dinner.Width = 200;
        }

        private void spaghetti_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("./Spaghetti.xaml", UriKind.Relative));
        }
    }
}
