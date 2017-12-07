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
    /// Interaction logic for HelperPage2.xaml
    /// </summary>
    public partial class HelperPage2 : Page
    {
        public HelperPage2()
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

        private void navigate_sea(object sender, RoutedEventArgs e)
        {

        }

        private void navigate_skill(object sender, RoutedEventArgs e)
        {
            Page destination = GetDependencyObjectFromVisualTree(this, typeof(Page)) as Page;

            destination.NavigationService.Navigate(new Uri("./HelperPage.xaml", UriKind.Relative));
        }
        private void navigate_search(object sender, RoutedEventArgs e)
        {
            Page destination = GetDependencyObjectFromVisualTree(this, typeof(Page)) as Page;

            destination.NavigationService.Navigate(new Uri("./HelperPage3.xaml", UriKind.Relative));
        }
    }
}
