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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SearchResults : Page
    {
        public SearchResults()
        {
            InitializeComponent();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("./SearchResults.xaml", UriKind.Relative));
        }

        private void recipe1_click(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("./Ingredients.xaml", UriKind.Relative));
        }
    }
}
