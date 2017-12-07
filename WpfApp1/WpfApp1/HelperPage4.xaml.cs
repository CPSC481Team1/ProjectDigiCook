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
    /// Interaction logic for HelperPage4.xaml
    /// </summary>
    public partial class HelperPage4 : Page
    {
        public HelperPage4()
        {
            InitializeComponent();
        }

        private DependencyObject GetDependencyObjectFromVisualTree(DependencyObject startObject, Type type)
        {
            DependencyObject parent = startObject;
            while (parent != null)
            {
                if (type.IsInstanceOfType(parent))
                    break;
                else
                    parent = VisualTreeHelper.GetParent(parent);
            }
            return parent;
        }

        private void Page_Initial(object sender, EventArgs e)
        {

        }

        private void back_search_Click(object sender, RoutedEventArgs e)
        {
            Page destination = GetDependencyObjectFromVisualTree(this, typeof(Page)) as Page;

            destination.NavigationService.Navigate(new Uri("./HelperPage3.xaml", UriKind.Relative));

        }

        private void to_recipe_page(object sender, RoutedEventArgs e)
        {

            Page destination = GetDependencyObjectFromVisualTree(this, typeof(Page)) as Page;

            destination.NavigationService.Navigate(new Uri("./HelperPage6.xaml", UriKind.Relative));
        }
    }
}
