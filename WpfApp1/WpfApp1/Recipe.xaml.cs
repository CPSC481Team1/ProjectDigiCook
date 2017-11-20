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
    public partial class Recipe : Page
    {
        public Recipe()
        {
            InitializeComponent();
            expander1.Expanded += new RoutedEventHandler(expander_MouseLeftButtonUp);
            expander2.Expanded += new RoutedEventHandler(expander_MouseLeftButtonUp);
            expander3.Expanded += new RoutedEventHandler(expander_MouseLeftButtonUp);
            expander4.Expanded += new RoutedEventHandler(expander_MouseLeftButtonUp);
            expander5.Expanded += new RoutedEventHandler(expander_MouseLeftButtonUp);
            expander6.Expanded += new RoutedEventHandler(expander_MouseLeftButtonUp);
        }

        private void expander_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            Expander caller = sender as Expander;
            foreach (UIElement element in expanderContainer.Children)
            {
                Expander expander = element as Expander;
                if (expander != null && expander != caller)
                {
                    expander.IsExpanded = false;
                }
            }
        }

        private void listBox_SelectionChanged(object sender, EventArgs e)
        {
            Label[] ingredientWithAlts = new Label[] { label4, label6, label8 };

            addButton.IsEnabled = true;

            if (ingredientWithAlts.Contains(Ingredients_Box.SelectedItem))   //instead of label6, we can make it select from a list (of labels?)
            {
                altButton.IsEnabled = true;
            }
            else
            {
                altButton.IsEnabled = false;
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Label selection = (Label)Ingredients_Box.SelectedItem;
            string selectionStr = selection.Content.ToString();
            GlobalVars.checklist.Add(selectionStr);

            MessageBox.Show("Added item to checklist");
        }

        private void altButton_Click(object sender, RoutedEventArgs e)
        {
            List<Label> ingredientWithAlts = new List<Label> { label4, label6, label8 };
            string[] alts = new string[] { "2 Small Banana Pepper", "1 Bottle Ketchup", "1 Teaspoons Oregano" };

            int idx = ingredientWithAlts.IndexOf((Label)Ingredients_Box.SelectedItem);
            MessageBox.Show(alts[idx], "Alternative Ingredient:");
        }

        private void Grid_MouseDown(object sender, EventArgs e)
        {
            if (Ingredients_Box.IsMouseOver)
            {
                listBox_SelectionChanged(sender, e);
            }
            else
            {
                Ingredients_Box.SelectedIndex = -1;
                addButton.IsEnabled = false;
                altButton.IsEnabled = false;
            }
        }
    }
}
