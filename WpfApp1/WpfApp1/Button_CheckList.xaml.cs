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
using System.ComponentModel;
using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class Button_CheckList : UserControl
    {

        public Button_CheckList()
        {
            InitializeComponent();
            //updateNumber(GlobalVars.checklist.Count.ToString());
        }

        /// <summary>

        /// Walk visual tree to find the first DependencyObject  of the specific type.

        /// </summary>

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

        private void View_Checklist_Click(object sender, RoutedEventArgs e)
        {
            Page pg = GetDependencyObjectFromVisualTree(this, typeof(Page)) as Page;

            pg.NavigationService.Navigate(new Uri("./Checklist.xaml", UriKind.Relative));

        }

        private void ChecklistNum_Initialized(object sender, EventArgs e)
        {
            updateNumber(GlobalVars.checklist.Count.ToString());
        }

        public void updateNumber(string number)
        {
            ChecklistNum.Content = number;
            if (GlobalVars.checklist.Count > 0)
            {
                ChecklistNum.Foreground = Brushes.OrangeRed;
            }
            else
            {
                ChecklistNum.Foreground = Brushes.Black;
            }

            if (GlobalVars.checklist.Count > 9)
            {
                plus.Visibility = Visibility.Visible;
                ChecklistNum.Content = "9";
            }
            else
            {
                plus.Visibility = Visibility.Hidden;
            }

            this.Refresh();
        }
 

    }

    public static class ExtensionMethods
    {
        private static Action EmptyDelegate = delegate () { };

        public static void Refresh(this UIElement uiElement)
        {
            uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }

}
