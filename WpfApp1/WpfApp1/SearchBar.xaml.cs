﻿using System;
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
    /// Interaction logic for SearchBar.xaml
    /// </summary>
    public partial class SearchBar : UserControl
    {
        public SearchBar()
        {
            InitializeComponent();

            // Set the default text to the globalVar
            SearchBox.Text = GlobalVars.searchText;
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

            string navPage = "./" + SearchBox.Text + ".xaml";


            pg.NavigationService.Navigate(new Uri("./SearchResults.xaml", UriKind.Relative));


        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            navigateToSearchResult();
        }

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
            }

            SearchBox.Foreground = System.Windows.Media.Brushes.Black;

            SearchBox.BorderBrush = System.Windows.Media.Brushes.LightBlue;
            
        }

        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text == "")
            {
                SearchBox.Text = GlobalVars.defaultSearchText;
            }

            SearchBox.BorderBrush = System.Windows.Media.Brushes.Black;

            SearchBox.Foreground = System.Windows.Media.Brushes.Gray;
        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                navigateToSearchResult();
            }
}
    }
}
