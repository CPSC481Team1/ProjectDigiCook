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
using System.IO;
using System.Web;
using System.Reflection;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for SearchBar.xaml
    /// </summary>
    public partial class SearchBar : UserControl
    {

        private string initialSeatchString;
        public SearchBar()
        {
            InitializeComponent();

            // Set the default text to the globalVar
            SearchBox.Text = GlobalVars.searchText;
            if (SearchBox.Text == GlobalVars.defaultSearchText)
                SearchBox.FontStyle = FontStyles.Italic;

            initialSeatchString = SearchBox.Text;
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

        // TO-DO If can't find the url, navigate to 404 page
        private void navigateToSearchResult()
        {

            // Set serachBox Test
            GlobalVars.searchText = SearchBox.Text;

            Page pg = GetDependencyObjectFromVisualTree(this, typeof(Page)) as Page;
            string navPage = "./" + SearchBox.Text + GlobalVars.skillLevel.ToString() + ".xaml";


            string fileDir = System.IO.Path.GetFullPath(@"..\..\");

             if (File.Exists(fileDir + navPage))
            {
                pg.NavigationService.Navigate(new Uri(navPage , UriKind.Relative));
            }
            else //Navigate to 404 page
            {
                if (GlobalVars.skillLevel == 1)
                {
                    pg.NavigationService.Navigate(new Uri("./NoResults.xaml", UriKind.Relative));
                }
                else if (GlobalVars.skillLevel == 2)
                {
                    pg.NavigationService.Navigate(new Uri("./NoResultsIntermediate.xaml", UriKind.Relative));
                }
                else
                {
                    pg.NavigationService.Navigate(new Uri("./NoResultsExpert.xaml", UriKind.Relative));
                }
                
            }
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(SearchBox.Text) && SearchBox.Text != GlobalVars.defaultSearchText) // Only search if text
                navigateToSearchResult();
        }

        // Blue highlight on hover
        private void SearchBox_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SearchBox.BorderBrush = System.Windows.Media.Brushes.LightBlue;
        }

        // Handle mouse click events
        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {

            if (SearchBox.Text == GlobalVars.defaultSearchText)
            {
                SearchBox.Text = "";
                SearchBox.FontStyle = FontStyles.Italic;
            }

            SearchBox.FontStyle = FontStyles.Normal;
            SearchBox.Foreground = System.Windows.Media.Brushes.Black;

            SearchBox.BorderBrush = System.Windows.Media.Brushes.LightBlue;
            
        }

        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text == "")
            {
                SearchBox.Text = GlobalVars.defaultSearchText;
                SearchBox.FontStyle = FontStyles.Italic;
            }

            SearchBox.FontStyle = FontStyles.Normal;
            SearchBox.BorderBrush = System.Windows.Media.Brushes.Black;

            SearchBox.Foreground = System.Windows.Media.Brushes.Gray;
        }

        // Search if user presses enter
        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            //GlobalVars.searchText = SearchBox.Text;

            
            if (e.Key == Key.Enter && !String.IsNullOrWhiteSpace(SearchBox.Text) && SearchBox.Text != GlobalVars.defaultSearchText) // enter pressed and text not empty or all spaces
            {
                navigateToSearchResult();
            }
        }

        public void setText()
        {
            //SearchBox.Text = GlobalVars.searchText;
        }

        public string getText()
        {
            return initialSeatchString;
        }
    }
}
