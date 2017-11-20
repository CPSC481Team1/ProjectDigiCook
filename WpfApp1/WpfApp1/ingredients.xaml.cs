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
            addButton.IsEnabled = true;
            skillsBox.SelectedIndex = -1;

            if (ingredientsBox.SelectedItem == label5)   //instead of label5, we can make it select from a list (of labels?)
            {
                altButton.IsEnabled = true;
            }
            else
            {
                altButton.IsEnabled = false;
            }
        }
  
        private void skillsBox_SelectionChanged(object sender, EventArgs e)
        {
            ingredientsBox.SelectedIndex = -1;
            addButton.IsEnabled = false;
            altButton.IsEnabled = false;
        }
        
        private void start_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("./Recipe.xaml", UriKind.Relative));
        }

        private void Grid_MouseDown(object sender, EventArgs e)
        {
            if (ingredientsBox.IsMouseOver)
            {
                ingredientslistBox_SelectionChanged(sender, e);
            }
            else if (skillsBox.IsMouseOver)
            {
                skillsBox_SelectionChanged(sender, e);
            }
            else
            {
                skillsBox.SelectedIndex = -1;
                ingredientsBox.SelectedIndex = -1;
                addButton.IsEnabled = false;
                altButton.IsEnabled = false;
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Label selection = (Label) ingredientsBox.SelectedItem;
            string selectionStr = selection.Content.ToString();


            GlobalVars.checklist.Add(selectionStr);

        }
    }
}
