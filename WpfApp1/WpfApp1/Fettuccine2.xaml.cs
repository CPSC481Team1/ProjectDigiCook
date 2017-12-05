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
    public partial class Fettuccine2 : Page
    {
        public Fettuccine2()
        {
            InitializeComponent();
   
        }

        private void recipe1_click(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("./Ingredients.xaml", UriKind.Relative));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            searchBar.setText();
        }

        //set text
        private void textBlock_Loaded(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "Results for spaghetti...";
        }

        private void ItemHighlight(object sender, MouseEventArgs e)
        {
            Recipe1.Background = Brushes.BlanchedAlmond;
        }

        private void ItemUnhighlight(object sender, MouseEventArgs e)
        {
            Recipe1.Background = Brushes.AliceBlue;
        }

        private void ItemHighlight2(object sender, MouseEventArgs e)
        {
            Recipe2.Background = Brushes.BlanchedAlmond;
        }

        private void ItemUnhighlight2(object sender, MouseEventArgs e)
        {
            Recipe2.Background = Brushes.AliceBlue;
        }

        private void ItemHighlight3(object sender, MouseEventArgs e)
        {
            Recipe3.Background = Brushes.BlanchedAlmond;
        }

        private void ItemUnhighlight3(object sender, MouseEventArgs e)
        {
            Recipe3.Background = Brushes.AliceBlue;
        }
    }
}
