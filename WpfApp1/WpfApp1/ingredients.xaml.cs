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
    public partial class Ingredients : Page
    {
        public Ingredients()
        {
            InitializeComponent();
        }

        private void ingredientslistBox_SelectionChanged(object sender, EventArgs e)
        {
            if (ingredientsBox.SelectedIndex >= 0)
            {
                addButton.IsEnabled = true;

                if(ingredientsBox.SelectedItem == label5)
                {
                    altButton.IsEnabled = true;
                }
                else
                {
                    altButton.IsEnabled = false;
                }
            }
            else
            {
                addButton.IsEnabled = false;
            }
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("./Recipe.xaml", UriKind.Relative));
        }

        
        private void ingredientsCanvas_MouseEnter(object sender, EventArgs e)
        {
            ingredientslistBox_SelectionChanged(sender, e);
        }

        private void ingredientsCanvas_MouseLeave(object sender, MouseEventArgs e)
        {
          //  ingredientsBox.SelectedIndex = -1;    
            addButton.IsEnabled = false;
            altButton.IsEnabled = false;
        }
        
    }
}
