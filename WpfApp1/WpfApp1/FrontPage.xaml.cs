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

    public partial class FrontPage : Page
    {

        public FrontPage()
        {
            InitializeComponent();

            
            //this.Title = "DigiCook";

            //// Set window to center of the computer screen at startup
            //this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            //// Turn off resizing
            //this.ResizeMode = ResizeMode.NoResize;

        }


        private DependencyObject GetDependencyObjectFromVisualTree(DependencyObject startObject, Type type)
        {
            //Walk the visual tree to get the parent(ItemsControl)
            //of this control

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

        private void CategoryResult()
        {

            Page destination = GetDependencyObjectFromVisualTree(this, typeof(Page)) as Page;

            if (GlobalVars.skillLevel == 1)
            {
                destination.NavigationService.Navigate(new Uri("./NoResults.xaml", UriKind.Relative));
            }
            else if (GlobalVars.skillLevel == 2)
            {
                destination.NavigationService.Navigate(new Uri("./NoResultsIntermediate.xaml", UriKind.Relative));
            }
            else
            {
                destination.NavigationService.Navigate(new Uri("./NoResultsExpert.xaml", UriKind.Relative));
            }
        }

        private void View_Checklist_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("./Checklist.xaml", UriKind.Relative));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            searchBar.setText();
        }



        private void button_Click(object sender, RoutedEventArgs e)
        {
            CategoryResult();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            CategoryResult();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            CategoryResult();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            CategoryResult();
        }

        private void button_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }

        private void button_MouseLeave(object sender, MouseEventArgs e)
        {
           
        }

        private void button2_MouseEnter(object sender, MouseEventArgs e)
        {
          
        }

        private void button2_MouseLeave(object sender, MouseEventArgs e)
        {
            
        }

        private void button3_MouseEnter(object sender, MouseEventArgs e)
        {
           
        }

        private void button3_MouseLeave(object sender, MouseEventArgs e)
        {
            
        }

        private void button4_MouseEnter(object sender, MouseEventArgs e)
        {
           
        }

        private void button4_MouseLeave(object sender, MouseEventArgs e)
        {
          
        }

        private void button5_MouseEnter(object sender, MouseEventArgs e)
        {
           
        }

        private void button5_MouseLeave(object sender, MouseEventArgs e)
        {
            
           
        }

        private void button6_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }

        private void button6_MouseLeave(object sender, MouseEventArgs e)
        {
           
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("./Lunch" + GlobalVars.skillLevel.ToString() + ".xaml", UriKind.Relative));
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("./Dinner" + GlobalVars.skillLevel.ToString() + ".xaml", UriKind.Relative));
        }
    }
}
