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
using System.Windows.Media.Effects;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for NavigationBar.xaml
    /// </summary>
    public partial class NavigationBar : UserControl
    {
        public NavigationBar()
        {
            InitializeComponent();
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

        private void Title_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Page destination = GetDependencyObjectFromVisualTree(this, typeof(Page)) as Page;

            destination.NavigationService.Navigate(new Uri("./FrontPage.xaml", UriKind.Relative));

        }

        private void Title_MouseEnter(object sender, MouseEventArgs e)
        {
            UIElement uie = new UIElement();
            uie.Effect =
                new DropShadowEffect
                {              
                    Color = new Color { A = 255, R = 0, G = 90, B = 255 },
                    Direction = 240,
                    ShadowDepth = 3,
                    Opacity = 0.20,
                    BlurRadius = 0.0

                };

            TitleText.Effect = uie.Effect;
        }

        private void Title_MouseLeave(object sender, MouseEventArgs e)
        {
            UIElement uie = new UIElement();


            TitleText.Effect = uie.Effect;

        }
    }
}
